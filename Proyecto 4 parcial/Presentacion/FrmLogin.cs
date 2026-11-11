using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion
{
    public partial class FrmLogin : Form
    {
        private SesionNegocio sesion = new SesionNegocio();
        public string Perfil { get { return sesion.Perfil; } }
        public FrmLogin()
        {
            InitializeComponent();
            btnIngresar.Click += btnIngresar_Click;
        }
        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            if (sesion.Iniciar(txtUsuario.Text.Trim(), txtClave.Text)) DialogResult = DialogResult.OK;
            else MessageBox.Show(this, "Usuario o contraseña incorrectos.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
