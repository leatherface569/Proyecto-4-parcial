using Proyecto_4_parcial.Modelos;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmVehiculos : Form
    {
        private TallerServicio negocio;
        public FrmVehiculos() : this(new TallerServicio()) { }
        public FrmVehiculos(TallerServicio servicio)
        {
            InitializeComponent();
            negocio = servicio;
            btnAutomovil.Click += (_, _) => Abrir("Automóvil", () => new Automovil());
            btnMotocicleta.Click += (_, _) => Abrir("Motocicleta", () => new Motocicleta());
            btnCamioneta.Click += (_, _) => Abrir("Camioneta", () => new Camioneta());
        }
        private void Abrir(string titulo, Func<Vehiculo> crear)
        {
            try
            {
                using var formulario = new FrmDetalleVehiculo(negocio, crear());
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo abrir el catálogo. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
