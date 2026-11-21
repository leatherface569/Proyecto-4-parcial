using System;
using System.Windows.Forms;
using Proyecto_4_parcial.Modelos;
using Proyecto_4_parcial.Negocio;

namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmClientes : Form
    {
        private TallerServicio negocio = new TallerServicio();
        private int idSeleccionado = 0;

        public FrmClientes()
        {
            InitializeComponent();
            dgvDatos.Columns.Add("Id", "Id");
            dgvDatos.Columns.Add("Nombre", "Nombre");
            dgvDatos.Columns.Add("Telefono", "Teléfono");
            dgvDatos.Columns.Add("Correo", "Correo");
        }
        public FrmClientes(TallerServicio servicio) : this()
        {
            negocio = servicio;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ucCliente1.ValidarCampos()) return;
            try
            {
                Cliente cliente = new Cliente(idSeleccionado, ucCliente1.Nombre.Trim(),
                    ucCliente1.Telefono.Trim(), ucCliente1.Correo.Trim());
                negocio.GuardarCliente(cliente);
                MessageBox.Show("Cliente guardado correctamente.");
                idSeleccionado = 0;
                ucCliente1.Limpiar();
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
            foreach (Cliente cliente in negocio.ObtenerClientes())
            {
                dgvDatos.Rows.Add(cliente.Id, cliente.Nombre, cliente.Telefono, cliente.Correo);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
            try
            {
                int id = Convert.ToInt32(txtBuscar.Text);
                Cliente cliente = negocio.ObtenerCliente(id);
                dgvDatos.Rows.Add(cliente.Id, cliente.Nombre, cliente.Telefono, cliente.Correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                idSeleccionado = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells[0].Value);
                Cliente cliente = negocio.ObtenerCliente(idSeleccionado);
                ucCliente1.Nombre = cliente.Nombre;
                ucCliente1.Telefono = cliente.Telefono;
                ucCliente1.Correo = cliente.Correo;
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
                negocio.ObtenerCliente(idSeleccionado);
                DialogResult respuesta = MessageBox.Show("¿Dar de baja el cliente?", "Confirmar", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.EliminarCliente(idSeleccionado);
                    idSeleccionado = 0;
                    ucCliente1.Limpiar();
                    dgvDatos.Rows.Clear();
                    MessageBox.Show("Cliente dado de baja correctamente.");
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
            ucCliente1.Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
