using System.Drawing;
using System.Windows.Forms;
namespace Proyecto_4_parcial.Presentacion
{
    partial class ucCliente
    {
        private System.ComponentModel.IContainer components = null;
        private ErrorProvider errorProvider1;
        private TextBox txtNombre;
        private Label lbltxtNombre;
        private TextBox txtTelefono;
        private Label lbltxtTelefono;
        private TextBox txtCorreo;
        private Label lbltxtCorreo;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            txtNombre = new TextBox();
            lbltxtNombre = new Label();
            txtTelefono = new TextBox();
            lbltxtTelefono = new Label();
            txtCorreo = new TextBox();
            lbltxtCorreo = new Label();
            SuspendLayout();
            errorProvider1.ContainerControl = this;
            lbltxtNombre.AutoSize = true;
            lbltxtNombre.Location = new Point(20, 15);
            lbltxtNombre.Text = "Nombre";
            txtNombre.Name = "txtNombre";
            txtNombre.Location = new Point(20, 40);
            txtNombre.Size = new Size(225, 27);
            Controls.Add(lbltxtNombre);
            Controls.Add(txtNombre);
            lbltxtTelefono.AutoSize = true;
            lbltxtTelefono.Location = new Point(270, 15);
            lbltxtTelefono.Text = "Teléfono (10)";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.MaxLength = 10;
            txtTelefono.Location = new Point(270, 40);
            txtTelefono.Size = new Size(225, 27);
            Controls.Add(lbltxtTelefono);
            Controls.Add(txtTelefono);
            lbltxtCorreo.AutoSize = true;
            lbltxtCorreo.Location = new Point(520, 15);
            lbltxtCorreo.Text = "Correo";
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Location = new Point(520, 40);
            txtCorreo.Size = new Size(225, 27);
            Controls.Add(lbltxtCorreo);
            Controls.Add(txtCorreo);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            Name = "ucCliente";
            Size = new Size(1020, 95);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
