using System.Drawing;
using System.Windows.Forms;
namespace Proyecto_4_parcial.Presentacion
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;
        private ucCliente ucCliente1;
        private FlowLayoutPanel panelBotones;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private DataGridView dgvDatos;
        private Button btnGuardar;
        private Button btnMostrar;
        private Button btnBuscar;
        private Button btnNuevo;
        private Button btnDarDeBaja;
        private Button btnCerrar;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            ucCliente1 = new ucCliente();
            panelBotones = new FlowLayoutPanel();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            dgvDatos = new DataGridView();
            btnGuardar = new Button();
            btnMostrar = new Button();
            btnBuscar = new Button();
            btnNuevo = new Button();
            btnDarDeBaja = new Button();
            btnCerrar = new Button();
            SuspendLayout();
            panelBotones.SuspendLayout();
            ucCliente1.Name = "ucCliente1";
            ucCliente1.Dock = DockStyle.Top;
            ucCliente1.Height = 95;
            panelBotones.Name = "panelBotones";
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Height = 70;
            panelBotones.Padding = new Padding(15);
            panelBotones.AutoScroll = true;
            lblBuscar.Text = "Buscar:";
            lblBuscar.AutoSize = true;
            lblBuscar.Margin = new Padding(0, 8, 5, 0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Width = 160;
            panelBotones.Controls.Add(lblBuscar);
            panelBotones.Controls.Add(txtBuscar);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.AutoSize = true;
            btnGuardar.Height = 32;
            btnGuardar.Click += btnGuardar_Click;
            panelBotones.Controls.Add(btnGuardar);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Text = "Mostrar";
            btnMostrar.AutoSize = true;
            btnMostrar.Height = 32;
            btnMostrar.Click += btnMostrar_Click;
            panelBotones.Controls.Add(btnMostrar);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Text = "Buscar";
            btnBuscar.AutoSize = true;
            btnBuscar.Height = 32;
            btnBuscar.Click += btnBuscar_Click;
            panelBotones.Controls.Add(btnBuscar);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Text = "Nuevo";
            btnNuevo.AutoSize = true;
            btnNuevo.Height = 32;
            btnNuevo.Click += btnNuevo_Click;
            panelBotones.Controls.Add(btnNuevo);
            btnDarDeBaja.Name = "btnDarDeBaja";
            btnDarDeBaja.Text = "Dar de baja";
            btnDarDeBaja.AutoSize = true;
            btnDarDeBaja.Height = 32;
            btnDarDeBaja.Click += btnDarDeBaja_Click;
            panelBotones.Controls.Add(btnDarDeBaja);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Text = "Cerrar";
            btnCerrar.AutoSize = true;
            btnCerrar.Height = 32;
            btnCerrar.Click += btnCerrar_Click;
            panelBotones.Controls.Add(btnCerrar);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.ReadOnly = true;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.MultiSelect = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.CellClick += dgvDatos_CellClick;
            Controls.Add(dgvDatos);
            Controls.Add(panelBotones);
            Controls.Add(ucCliente1);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1100, 650);
            Name = "FrmClientes";
            Text = "Clientes";
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            ResumeLayout(false);
        }
    }
}
