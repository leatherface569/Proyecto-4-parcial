using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmInventario : Form
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

        public FrmInventario() : this(new TallerServicio()) { }

        public FrmInventario(TallerServicio servicio)
        {
            InitializeComponent();
            negocio = servicio;

            foreach (Refaccion r in negocio.Datos.Refacciones.Todos()) cmbRefaccion.Items.Add(r);
            campos.Add("Refaccion", cmbRefaccion);
            campos.Add("Cantidad", nudCantidad);
            campos.Add("Motivo", txtMotivo);
            btnAccion1.Click += (_, _) => Seguro(() => Mover(1));
            btnAccion2.Click += (_, _) => Seguro(() => Mover(-1));
            btnAccion3.Click += (_, _) => Seguro(() => dgvDatos.DataSource = negocio.Datos.Movimientos.Todos().Select(m => new { m.Id, m.Fecha, Refaccion = negocio.Datos.Refacciones.Todos().First(r => r.Id == m.RefaccionId).Nombre, m.Cantidad, m.Motivo }).ToList());
            btnAccion4.Click += (_, _) => Seguro(Actualizar);
            btnAccion5.Click += (_, _) => Seguro(Close);
            Actualizar();
        }
        private void Mover(int signo)
        {
            if (cmbRefaccion.SelectedItem is not Refaccion r) throw new InvalidOperationException("Selecciona una refacción.");
            negocio.MoverInventario(r.Id, signo * (int)nudCantidad.Value, txtMotivo.Text);
            Actualizar();
        }
        private void Actualizar()
        {
            dgvDatos.DataSource = negocio.Datos.Refacciones.Todos().Select(r => new { r.Id, r.Nombre, r.Precio, r.Stock, r.StockMinimo, r.ValorInventario, r.EstadoInventario }).ToList();
        }
    }
}
