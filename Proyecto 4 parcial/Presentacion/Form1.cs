using Proyecto_4_parcial.Negocio;
using Proyecto_4_parcial.Presentacion;

namespace Proyecto_4_parcial
{
    public partial class Form1 : Form
    {
        private TallerServicio negocio = new TallerServicio();

        public Form1() { InitializeComponent(); }

        private void clientesMenu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form abierto in MdiChildren)
                {
                    if (abierto is FrmClientes) { abierto.Activate(); return; }
                    abierto.Close();
                }
                FrmClientes formulario = new FrmClientes(negocio);
                formulario.MdiParent = this;
                formulario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void vehiculosMenu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form abierto in MdiChildren)
                {
                    if (abierto is FrmVehiculos) { abierto.Activate(); return; }
                    abierto.Close();
                }
                FrmVehiculos formulario = new FrmVehiculos(negocio);
                formulario.MdiParent = this;
                formulario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
