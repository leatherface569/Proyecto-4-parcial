using System;
using System.Windows.Forms;
using Proyecto_4_parcial.Modelos;
using Proyecto_4_parcial.Negocio;

namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmVehiculos : Form
    {
        private TallerServicio negocio = new TallerServicio();
        private int idSeleccionado = 0;

        public FrmVehiculos()
        {
            InitializeComponent();
            dgvDatos.Columns.Add("Id", "Id");
            dgvDatos.Columns.Add("ClienteId", "Id propietario");
            dgvDatos.Columns.Add("Tipo", "Tipo");
            dgvDatos.Columns.Add("NumeroSerie", "Número de serie");
            dgvDatos.Columns.Add("Placa", "Placa");
            dgvDatos.Columns.Add("Marca", "Marca");
            dgvDatos.Columns.Add("Modelo", "Modelo");
            dgvDatos.Columns.Add("Anio", "Año");
            dgvDatos.Columns.Add("Kilometraje", "Kilometraje");
        }
        public FrmVehiculos(TallerServicio servicio) : this()
        {
            negocio = servicio;
            ucVehiculo1.CargarClientes(negocio.ObtenerClientes());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ucVehiculo1.ValidarCampos()) return;
            try
            {
                Vehiculo vehiculo = new Vehiculo(idSeleccionado, ucVehiculo1.ClienteId,
                    ucVehiculo1.Tipo, ucVehiculo1.NumeroSerie.Trim(), ucVehiculo1.Placa.Trim(),
                    ucVehiculo1.Marca.Trim(), ucVehiculo1.Modelo.Trim(),
                    Convert.ToInt32(ucVehiculo1.Anio), Convert.ToInt32(ucVehiculo1.Kilometraje));
                negocio.GuardarVehiculo(vehiculo);
                MessageBox.Show("Vehículo guardado correctamente.");
                idSeleccionado = 0;
                ucVehiculo1.Limpiar();
                dgvDatos.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
            foreach (Vehiculo vehiculo in negocio.ObtenerVehiculos())
            {
                dgvDatos.Rows.Add(vehiculo.Id, vehiculo.ClienteId, vehiculo.Tipo,
                    vehiculo.NumeroSerie, vehiculo.Placa, vehiculo.Marca,
                    vehiculo.Modelo, vehiculo.Anio, vehiculo.Kilometraje);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
            foreach (Vehiculo vehiculo in negocio.ObtenerVehiculos())
            {
                string texto = vehiculo.Placa + " " + vehiculo.Marca + " " + vehiculo.Modelo
                    + " " + vehiculo.Tipo + " " + vehiculo.NumeroSerie;
                if (texto.ToLower().Contains(txtBuscar.Text.ToLower()))
                {
                    dgvDatos.Rows.Add(vehiculo.Id, vehiculo.ClienteId, vehiculo.Tipo,
                        vehiculo.NumeroSerie, vehiculo.Placa, vehiculo.Marca,
                        vehiculo.Modelo, vehiculo.Anio, vehiculo.Kilometraje);
                }
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                idSeleccionado = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells[0].Value);
                Vehiculo vehiculo = negocio.ObtenerVehiculo(idSeleccionado);
                ucVehiculo1.ClienteId = vehiculo.ClienteId;
                ucVehiculo1.Tipo = vehiculo.Tipo;
                ucVehiculo1.NumeroSerie = vehiculo.NumeroSerie;
                ucVehiculo1.Placa = vehiculo.Placa;
                ucVehiculo1.Marca = vehiculo.Marca;
                ucVehiculo1.Modelo = vehiculo.Modelo;
                ucVehiculo1.Anio = vehiculo.Anio.ToString();
                ucVehiculo1.Kilometraje = vehiculo.Kilometraje.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            try
            {
                negocio.ObtenerVehiculo(idSeleccionado);
                DialogResult respuesta = MessageBox.Show("¿Dar de baja el vehículo?", "Confirmar", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.EliminarVehiculo(idSeleccionado);
                    idSeleccionado = 0;
                    ucVehiculo1.Limpiar();
                    dgvDatos.Rows.Clear();
                    MessageBox.Show("Vehículo dado de baja correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idSeleccionado = 0;
            ucVehiculo1.Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
