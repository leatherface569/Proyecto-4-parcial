using Proyecto_4_parcial.Modelos;
using Proyecto_4_parcial.Negocio;

namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmDetalleVehiculo : Form
    {
        private TallerServicio negocio;
        private Vehiculo tipo;
        private int idSeleccionado;

        public FrmDetalleVehiculo() : this(new TallerServicio(), new Automovil()) { }

        public FrmDetalleVehiculo(TallerServicio servicio, Vehiculo tipoVehiculo)
        {
            InitializeComponent();
            negocio = servicio;
            tipo = tipoVehiculo;
            Text = "Vehículos - " + tipo.Tipo;
            foreach (Cliente cliente in negocio.Datos.Clientes.Todos()) cmbCliente.Items.Add(cliente);
            lblCaracteristica.Text = tipo is Automovil ? "Puertas" : tipo is Motocicleta ? "Cilindrada (cc)" : "Capacidad de carga (kg)";
            btnNuevo.Click += (_, _) => Seguro(Limpiar);
            btnGuardar.Click += (_, _) => Seguro(Guardar);
            btnBaja.Click += (_, _) => Seguro(DarDeBaja);
            btnCerrar.Click += (_, _) => Close();
            txtBuscar.TextChanged += (_, _) => Mostrar();
            dgvDatos.CellClick += (_, e) => Seguro(() =>
            {
                if (e.RowIndex >= 0 && dgvDatos.Rows[e.RowIndex].DataBoundItem is Vehiculo vehiculo) Cargar(vehiculo);
            });
            Limpiar();
            Mostrar();
        }

        private Vehiculo Crear()
        {
            if (tipo is Automovil) return new Automovil { Puertas = (int)nudCaracteristica.Value };
            if (tipo is Motocicleta) return new Motocicleta { Cilindrada = (int)nudCaracteristica.Value };
            return new Camioneta { CapacidadCarga = nudCaracteristica.Value };
        }

        private void Guardar()
        {
            Vehiculo vehiculo = Crear();
            vehiculo.Id = idSeleccionado;
            vehiculo.ClienteId = (cmbCliente.SelectedItem as Cliente)?.Id ?? 0;
            vehiculo.NumeroSerie = txtSerie.Text.Trim().ToUpperInvariant();
            vehiculo.Placa = txtPlaca.Text.Trim().ToUpperInvariant();
            vehiculo.Marca = txtMarca.Text.Trim();
            vehiculo.Modelo = txtModelo.Text.Trim();
            vehiculo.Anio = (int)nudAnio.Value;
            vehiculo.Kilometraje = (int)nudKilometraje.Value;
            negocio.Guardar<Vehiculo>(vehiculo, negocio.Datos.Vehiculos);
            Limpiar();
            Mostrar();
        }

        private void Cargar(Vehiculo vehiculo)
        {
            idSeleccionado = vehiculo.Id;
            cmbCliente.SelectedItem = cmbCliente.Items.Cast<Cliente>().FirstOrDefault(c => c.Id == vehiculo.ClienteId);
            txtSerie.Text = vehiculo.NumeroSerie;
            txtPlaca.Text = vehiculo.Placa;
            txtMarca.Text = vehiculo.Marca;
            txtModelo.Text = vehiculo.Modelo;
            nudAnio.Value = vehiculo.Anio;
            nudKilometraje.Value = vehiculo.Kilometraje;
            nudCaracteristica.Value = vehiculo is Automovil auto ? auto.Puertas : vehiculo is Motocicleta moto ? moto.Cilindrada : ((Camioneta)vehiculo).CapacidadCarga;
            lblRecomendacion.Text = vehiculo.Describir();
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            errores.Clear();
            cmbCliente.SelectedIndex = -1;
            txtSerie.Clear(); txtPlaca.Clear(); txtMarca.Clear(); txtModelo.Clear();
            nudAnio.Value = DateTime.Today.Year;
            nudKilometraje.Value = 0;
            nudCaracteristica.Value = tipo is Automovil ? 4 : tipo is Motocicleta ? 150 : 750;
            lblRecomendacion.Text = "";
        }

        private void Mostrar()
        {
            dgvDatos.DataSource = negocio.Datos.Vehiculos.Todos()
                .Where(v => v.GetType() == tipo.GetType())
                .Where(v => (v.Placa + " " + v.Marca + " " + v.Modelo + " " + v.NumeroSerie).Contains(txtBuscar.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            if (dgvDatos.Columns.Contains("Activo")) dgvDatos.Columns["Activo"]!.Visible = false;
        }

        private void DarDeBaja()
        {
            Vehiculo vehiculo = negocio.Datos.Vehiculos.Todos().FirstOrDefault(v => v.Id == idSeleccionado)
                ?? throw new InvalidOperationException("Selecciona un vehículo en la tabla.");
            if (MessageBox.Show(this, "¿Dar de baja el vehículo?", Text, MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            negocio.Eliminar<Vehiculo>(vehiculo, negocio.Datos.Vehiculos);
            Limpiar();
            Mostrar();
        }

        private void Seguro(Action accion)
        {
            errores.Clear();
            try { accion(); }
            catch (ValidacionException ex)
            {
                Control control = ex.Campo switch
                {
                    "ClienteId" => cmbCliente, "NumeroSerie" => txtSerie, "Placa" => txtPlaca,
                    "Marca" => txtMarca, "Modelo" => txtModelo, "Anio" => nudAnio,
                    "Kilometraje" => nudKilometraje, _ => nudCaracteristica
                };
                errores.SetError(control, ex.Message);
                control.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Operación no realizada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
