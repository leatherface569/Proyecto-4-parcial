using Proyecto_4_parcial.Modelos;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmOrdenes : Form
    {

        private Dictionary<string, Control> campos = new Dictionary<string, Control>();
        private void Seguro(Action accion)
        {
            errores.Clear();
            try { accion(); }
            catch (ValidacionException ex)
            {
                if (campos.TryGetValue(ex.Campo, out Control? control))
                {
                    errores.SetError(control, ex.Message);
                    control.Focus();
                }
                MessageBox.Show(this, ex.Message, "Revisa la información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Operación no realizada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private TallerServicio negocio;

        private OrdenServicio? seleccionada;

        public FrmOrdenes() : this(new TallerServicio()) { }

        public FrmOrdenes(TallerServicio servicio)
        {
            InitializeComponent();
            negocio = servicio;

            nudCantidad.Value = 1;
            foreach (Vehiculo vehiculo in negocio.Datos.Vehiculos.Todos()) cmbVehiculo.Items.Add(vehiculo);
            foreach (Mecanico mecanico in negocio.Datos.Mecanicos.Todos()) cmbMecanico.Items.Add(mecanico);
            foreach (Servicio s in negocio.Datos.Servicios.Todos()) cmbServicio.Items.Add(s);
            foreach (Refaccion r in negocio.Datos.Refacciones.Todos()) cmbRefaccion.Items.Add(r);
            cmbEstado.DataSource = Enum.GetValues<EstadoOrden>();
            cmbVehiculo.SelectedIndexChanged += (_, _) =>
            {
                if (cmbVehiculo.SelectedItem is Vehiculo v) nudKilometraje.Value = v.Kilometraje;
            };
            campos.Add("VehiculoId", cmbVehiculo);
            campos.Add("MecanicoId", cmbMecanico);
            campos.Add("Kilometraje", nudKilometraje);
            campos.Add("Observaciones", txtFalla);
            btnAccion1.Click += (_, _) => Seguro(AbrirOrden);
            campos.Add("Diagnostico", txtDiagnostico);
            campos.Add("Estado", cmbEstado);
            btnAccion2.Click += (_, _) => Seguro(() => { negocio.CambiarEstado(Orden(), (EstadoOrden)cmbEstado.SelectedItem!, txtDiagnostico.Text); Actualizar(); });
            campos.Add("Servicio", cmbServicio);
            btnAccion3.Click += (_, _) => Seguro(() =>
            {
                if (cmbServicio.SelectedItem is not Servicio s) throw new InvalidOperationException("Selecciona un servicio.");
                negocio.AgregarServicio(Orden(), s.Id); Actualizar();
            });
            campos.Add("Refaccion", cmbRefaccion);
            campos.Add("Cantidad", nudCantidad);
            btnAccion4.Click += (_, _) => Seguro(() =>
            {
                if (cmbRefaccion.SelectedItem is not Refaccion r) throw new InvalidOperationException("Selecciona una refacción.");
                negocio.AgregarRefaccion(Orden(), r.Id, (int)nudCantidad.Value); Actualizar();
            });
            campos.Add("Importe", nudPago);
            btnAccion5.Click += (_, _) => Seguro(() => { negocio.RegistrarPago(Orden(), nudPago.Value); Actualizar(); });
            btnAccion6.Click += (_, _) => Seguro(VerDetalle);
            btnAccion7.Click += (_, _) => Seguro(() =>
            {
                OrdenServicio orden = Orden();
                if (MessageBox.Show(this, "¿Cancelar la orden y devolver las refacciones al inventario?", "Cancelar orden", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { negocio.CancelarOrden(orden); Actualizar(); }
            });
            btnAccion8.Click += (_, _) => Seguro(Actualizar);
            btnAccion9.Click += (_, _) => Seguro(Close);

            dgvDatos.CellClick += (_, e) => Seguro(() =>
            {
                if (e.RowIndex < 0) return;
                int id = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["Id"].Value);
                seleccionada = negocio.Datos.Ordenes.Todos().First(o => o.Id == id);
                txtDiagnostico.Text = seleccionada.Diagnostico;
                cmbEstado.SelectedItem = seleccionada.Estado;
                lblOrden.Text = "Orden seleccionada: " + id;
            });
            Actualizar();
        }
        private OrdenServicio Orden()
        {
            return seleccionada ?? throw new InvalidOperationException("Selecciona una orden en la tabla.");
        }
        private void AbrirOrden()
        {
            int vehiculoId = (cmbVehiculo.SelectedItem as Vehiculo)?.Id ?? 0;
            int mecanicoId = (cmbMecanico.SelectedItem as Mecanico)?.Id ?? 0;
            seleccionada = negocio.AbrirOrden(vehiculoId, mecanicoId, (int)nudKilometraje.Value, txtFalla.Text);
            lblOrden.Text = "Orden seleccionada: " + seleccionada.Id;
            txtFalla.Clear(); txtDiagnostico.Clear();
            Actualizar();
        }
        private void Actualizar()
        {
            dgvDatos.DataSource = negocio.Datos.Ordenes.Todos().Select(o => new
            {
                o.Id,
                Cliente = negocio.Datos.Clientes.Todos().First(c => c.Id == o.ClienteId).Nombre,
                Vehiculo = negocio.Datos.Vehiculos.Todos().First(v => v.Id == o.VehiculoId).Placa,
                Mecanico = negocio.Datos.Mecanicos.Todos().First(m => m.Id == o.MecanicoId).Nombre,
                o.Fecha,
                o.Kilometraje,
                o.Observaciones,
                o.Diagnostico,
                o.Estado,
                o.Total,
                o.Pagado,
                o.Saldo
            }).ToList();
        }
        private void VerDetalle()
        {
            OrdenServicio orden = Orden();
            using Form ventana = new Form { Text = "Detalle de orden " + orden.Id, Width = 800, Height = 600, StartPosition = FormStartPosition.CenterParent };
            TextBox texto = new TextBox { Dock = DockStyle.Fill, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Both, Font = new Font("Consolas", 11) };
            List<string> lineas = new List<string> { "ORDEN " + orden.Id, "Falla: " + orden.Observaciones, "Diagnóstico: " + orden.Diagnostico, "", "SERVICIOS" };
            foreach (DetalleServicio detalle in orden.Servicios)
                lineas.Add(negocio.Datos.Servicios.Todos().First(s => s.Id == detalle.ServicioId).Nombre + "  $" + detalle.Precio.ToString("N2"));
            lineas.Add("REFACCIONES");
            foreach (DetalleRefaccion detalle in orden.Refacciones)
                lineas.Add(negocio.Datos.Refacciones.Todos().First(r => r.Id == detalle.RefaccionId).Nombre + " x" + detalle.Cantidad + "  $" + detalle.Subtotal.ToString("N2"));
            lineas.Add("HISTORIAL DE ESTADOS");
            foreach (CambioEstado cambio in orden.Historial) lineas.Add(cambio.Fecha + " - " + cambio.Estado);
            lineas.Add("PAGOS");
            foreach (Pago pago in orden.Pagos) lineas.Add(pago.Fecha + " - $" + pago.Importe.ToString("N2"));
            lineas.Add("Total: $" + orden.Total.ToString("N2") + "  Pagado: $" + orden.Pagado.ToString("N2") + "  Saldo: $" + orden.Saldo.ToString("N2"));
            texto.Lines = lineas.ToArray(); ventana.Controls.Add(texto); ventana.ShowDialog(this);
        }
    }
}
