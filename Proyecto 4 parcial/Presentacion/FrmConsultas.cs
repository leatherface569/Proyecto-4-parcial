using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmConsultas : Form
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

        public FrmConsultas() : this(new TallerServicio()) { }

        public FrmConsultas(TallerServicio servicio)
        {
            InitializeComponent();
            negocio = servicio;

            foreach (Vehiculo v in negocio.Datos.Vehiculos.Todos()) cmbVehiculo.Items.Add(v);
            foreach (Cliente c in negocio.Datos.Clientes.Todos()) cmbCliente.Items.Add(c);
            campos.Add("Vehiculo", cmbVehiculo);
            btnAccion1.Click += (_, _) => Seguro(() =>
            {
                if (cmbVehiculo.SelectedItem is not Vehiculo v) throw new InvalidOperationException("Selecciona un vehículo.");
                MostrarOrdenes(negocio.Datos.Ordenes.Todos().Where(o => o.VehiculoId == v.Id));
                MessageBox.Show(this, v.Describir(), "Recomendación de mantenimiento");
            });
            campos.Add("Cliente", cmbCliente);
            btnAccion2.Click += (_, _) => Seguro(() =>
            {
                if (cmbCliente.SelectedItem is not Cliente c) throw new InvalidOperationException("Selecciona un cliente.");
                MostrarOrdenes(negocio.Datos.Ordenes.Todos().Where(o => o.ClienteId == c.Id));
            });
            btnAccion3.Click += (_, _) => Seguro(() =>
            {
                if (cmbCliente.SelectedItem is not Cliente c) throw new InvalidOperationException("Selecciona un cliente.");
                dgvDatos.DataSource = negocio.Datos.Vehiculos.Todos().Where(v => v.ClienteId == c.Id).Select(v => new { v.Id, v.Placa, v.NumeroSerie, v.Marca, v.Modelo, v.Tipo, v.Kilometraje, Recomendacion = v.Describir() }).ToList();
            });
            btnAccion4.Click += (_, _) => Seguro(() => MostrarOrdenes(negocio.Datos.Ordenes.Todos().Where(o => o.Estado != EstadoOrden.Cancelada && o.Estado != EstadoOrden.Entregada)));
            btnAccion5.Click += (_, _) => Seguro(() => MostrarOrdenes(negocio.Datos.Ordenes.Todos().Where(o => o.Estado != EstadoOrden.Cancelada && o.Saldo > 0)));
            btnAccion6.Click += (_, _) => Seguro(() => dgvDatos.DataSource = negocio.Datos.Refacciones.Todos().Where(r => r.Stock <= r.StockMinimo).Select(r => new { r.Nombre, r.Stock, r.StockMinimo, r.ValorInventario }).ToList());
            btnAccion7.Click += (_, _) => Seguro(() => dgvDatos.DataSource = negocio.Datos.Servicios.Todos().Select(s => new { s.Nombre, Veces = negocio.Datos.Ordenes.Todos().Where(o => o.Estado != EstadoOrden.Cancelada).Sum(o => o.Servicios.Count(d => d.ServicioId == s.Id)) }).OrderByDescending(s => s.Veces).ToList());
            btnAccion8.Click += (_, _) => Seguro(() => dgvDatos.DataSource = negocio.Datos.Mecanicos.Todos().Select(m => new { m.Nombre, m.Especialidad, m.Disponible, Activas = negocio.Datos.Ordenes.Todos().Count(o => o.MecanicoId == m.Id && o.Estado != EstadoOrden.Cancelada && o.Estado != EstadoOrden.Entregada), Terminadas = negocio.Datos.Ordenes.Todos().Count(o => o.MecanicoId == m.Id && (o.Estado == EstadoOrden.Terminada || o.Estado == EstadoOrden.Entregada)) }).ToList());
            btnAccion9.Click += (_, _) => Seguro(() => dgvDatos.DataSource = negocio.Datos.Clientes.Todos().Select(c => new { c.Nombre, Facturacion = negocio.Datos.Ordenes.Todos().Where(o => o.ClienteId == c.Id && o.Estado != EstadoOrden.Cancelada).Sum(o => o.Total), Pagado = negocio.Datos.Ordenes.Todos().Where(o => o.ClienteId == c.Id).Sum(o => o.Pagado) }).OrderByDescending(c => c.Facturacion).ToList());
            btnAccion10.Click += (_, _) => Seguro(Close);
        }
        private void MostrarOrdenes(IEnumerable<OrdenServicio> ordenes)
        {
            // El detalle completo se consulta en Órdenes mediante su número.
            dgvDatos.DataSource = ordenes.Select(o => new { o.Id, o.Fecha, o.VehiculoId, o.MecanicoId, o.Diagnostico, o.Estado, Servicios = string.Join(", ", o.Servicios.Select(d => negocio.Datos.Servicios.Todos().First(s => s.Id == d.ServicioId).Nombre)), Refacciones = string.Join(", ", o.Refacciones.Select(d => negocio.Datos.Refacciones.Todos().First(r => r.Id == d.RefaccionId).Nombre + " x" + d.Cantidad)), o.Total, o.Pagado, o.Saldo }).ToList();
        }
    }
}
