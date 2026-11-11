#nullable enable
namespace Proyecto_4_parcial.Presentacion
{
    partial class FrmLogin
    {
        private TextBox txtUsuario = null!;
        private TextBox txtClave = null!;
        private Button btnIngresar = null!;
        private Label lblUsuario = null!;
        private Label lblClave = null!;
        private Label lblDemo = null!;
        private void InitializeComponent()
        {
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnIngresar = new Button();
            lblUsuario = new Label();
            lblClave = new Label();
            lblDemo = new Label();
            SuspendLayout();
            lblUsuario.Text = "Usuario";
            lblUsuario.Location = new Point(25, 25);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Location = new Point(145, 25);
            txtUsuario.Size = new Size(240, 28);
            lblClave.Text = "Contraseña";
            lblClave.Location = new Point(25, 75);
            txtClave.Name = "txtClave";
            txtClave.UseSystemPasswordChar = true;
            txtClave.Location = new Point(145, 75);
            txtClave.Size = new Size(240, 28);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Text = "Ingresar";
            btnIngresar.Location = new Point(145, 125);
            btnIngresar.Size = new Size(115, 35);
            lblDemo.Text = "Prueba: admin / demo123\nSolo consultas: consulta / demo123\nLos datos se pierden al cerrar el programa.";
            lblDemo.Location = new Point(25, 180);
            lblDemo.AutoSize = true;
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(420, 280);
            Name = "FrmLogin";
            Text = "Inicio de sesión - Taller mecánico";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            AcceptButton = btnIngresar;
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblClave);
            Controls.Add(txtClave);
            Controls.Add(btnIngresar);
            Controls.Add(lblDemo);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
