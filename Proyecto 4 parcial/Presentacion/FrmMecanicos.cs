using Proyecto_4_parcial.Datos;
using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmMecanicos : Form
    {
        private TallerServicio negocio;
        private IRepositorio<Mecanico> datos;
        private Func<Mecanico> crear;
        private Dictionary<string, Control> controles = new Dictionary<string, Control>();
        private int idSeleccionado;
        public FrmMecanicos() : this(new TallerServicio()) { }
        public FrmMecanicos(TallerServicio servicio)
        {
            InitializeComponent();
            negocio = servicio;
            datos = servicio.Datos.Mecanicos;
            crear = () => new Mecanico();
            controles.Add("Nombre", txtNombre);
            campos.Add("Nombre", txtNombre);
            controles.Add("Especialidad", txtEspecialidad);
            campos.Add("Especialidad", txtEspecialidad);
            controles.Add("Disponible", chkDisponible);
            campos.Add("Disponible", chkDisponible);
            txtBuscar.TextChanged += (_, _) => Buscar();
            btnNuevo.Click += (_, _) => Seguro(Limpiar);
            btnGuardar.Click += (_, _) => Seguro(Guardar);
            btnBaja.Click += (_, _) => Seguro(Eliminar);
            btnCerrar.Click += (_, _) => Close();
            dgvDatos.CellClick += (_, e) => Seguro(() => { if (e.RowIndex >= 0 && dgvDatos.Rows[e.RowIndex].DataBoundItem is Mecanico entidad) Cargar(entidad); });
            Limpiar();
            Mostrar();
        }

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
        private void Guardar()
        {
            Mecanico entidad = crear();
            entidad.Id = idSeleccionado;
            foreach (var campo in controles)
            {
                var propiedad = entidad.GetType().GetProperty(campo.Key)!;
                Control control = campo.Value;
                object? valor = null;
                if (control is TextBox texto) valor = texto.Text.Trim();
                if (control is CheckBox opcion) valor = opcion.Checked;
                if (control is ComboBox combo) valor = (combo.SelectedItem as Entidad)?.Id ?? 0;
                if (control is NumericUpDown numero)
                {
                    if (propiedad.PropertyType == typeof(int)) valor = (int)numero.Value;
                    else valor = numero.Value;
                }
                propiedad.SetValue(entidad, valor);
            }
            negocio.Guardar(entidad, datos);
            Limpiar();
            Mostrar();
        }

        private void Cargar(Mecanico entidad)
        {
            idSeleccionado = entidad.Id;
            foreach (var campo in controles)
            {
                object? valor = entidad.GetType().GetProperty(campo.Key)!.GetValue(entidad);
                if (campo.Value is TextBox texto) texto.Text = valor?.ToString();
                if (campo.Value is CheckBox opcion) opcion.Checked = (bool)valor!;
                if (campo.Value is NumericUpDown numero) numero.Value = Convert.ToDecimal(valor);
                if (campo.Value is ComboBox combo)
                    combo.SelectedItem = combo.Items.Cast<Entidad>().FirstOrDefault(e => e.Id == Convert.ToInt32(valor));
            }
            if (controles.TryGetValue("Stock", out Control? stock)) stock.Enabled = false;
        }

        private void Eliminar()
        {
            Mecanico entidad = datos.Todos().FirstOrDefault(e => e.Id == idSeleccionado)
                ?? throw new InvalidOperationException("Selecciona un registro en la tabla.");
            if (MessageBox.Show(this, "¿Dar de baja el registro seleccionado?", Text, MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            negocio.Eliminar(entidad, datos);
            Limpiar();
            Mostrar();
        }

        private void Limpiar()
        {
            Cargar(crear());
            idSeleccionado = 0;
            if (controles.TryGetValue("Stock", out Control? stock)) stock.Enabled = true;
        }

        private void Mostrar()
        {
            // El selector de vehículos abre un catálogo para cada clase derivada.
            dgvDatos.DataSource = datos.Todos()

                .Where(e => e.GetType().GetProperties().Any(p =>
                    (p.GetValue(e)?.ToString() ?? "").Contains(txtBuscar.Text, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            if (dgvDatos.Columns.Contains("Activo")) dgvDatos.Columns["Activo"]!.Visible = false;
        }

        private void Buscar()
        {
            Mostrar();
        }
    }
}
