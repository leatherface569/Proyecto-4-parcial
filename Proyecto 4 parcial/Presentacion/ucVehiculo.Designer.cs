using System.Drawing;
using System.Windows.Forms;
namespace Proyecto_4_parcial.Presentacion
{
    partial class ucVehiculo
    {
        private System.ComponentModel.IContainer components = null;
        private ErrorProvider errorProvider1;
        private ComboBox cmbCliente;
        private Label lblcmbCliente;
        private ComboBox cmbTipo;
        private Label lblcmbTipo;
        private TextBox txtSerie;
        private Label lbltxtSerie;
        private TextBox txtPlaca;
        private Label lbltxtPlaca;
        private TextBox txtMarca;
        private Label lbltxtMarca;
        private TextBox txtModelo;
        private Label lbltxtModelo;
        private TextBox txtAnio;
        private Label lbltxtAnio;
        private TextBox txtKilometraje;
        private Label lbltxtKilometraje;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            cmbCliente = new ComboBox();
            lblcmbCliente = new Label();
            cmbTipo = new ComboBox();
            lblcmbTipo = new Label();
            txtSerie = new TextBox();
            lbltxtSerie = new Label();
            txtPlaca = new TextBox();
            lbltxtPlaca = new Label();
            txtMarca = new TextBox();
            lbltxtMarca = new Label();
            txtModelo = new TextBox();
            lbltxtModelo = new Label();
            txtAnio = new TextBox();
            lbltxtAnio = new Label();
            txtKilometraje = new TextBox();
            lbltxtKilometraje = new Label();
            SuspendLayout();
            errorProvider1.ContainerControl = this;
            lblcmbCliente.AutoSize = true;
            lblcmbCliente.Location = new Point(20, 15);
            lblcmbCliente.Text = "Propietario";
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Location = new Point(20, 40);
            cmbCliente.Size = new Size(225, 27);
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(lblcmbCliente);
            Controls.Add(cmbCliente);
            lblcmbTipo.AutoSize = true;
            lblcmbTipo.Location = new Point(270, 15);
            lblcmbTipo.Text = "Tipo de vehículo";
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Location = new Point(270, 40);
            cmbTipo.Size = new Size(225, 27);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(lblcmbTipo);
            Controls.Add(cmbTipo);
            lbltxtSerie.AutoSize = true;
            lbltxtSerie.Location = new Point(520, 15);
            lbltxtSerie.Text = "Número de serie";
            txtSerie.Name = "txtSerie";
            txtSerie.Location = new Point(520, 40);
            txtSerie.Size = new Size(225, 27);
            Controls.Add(lbltxtSerie);
            Controls.Add(txtSerie);
            lbltxtPlaca.AutoSize = true;
            lbltxtPlaca.Location = new Point(770, 15);
            lbltxtPlaca.Text = "Placa";
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Location = new Point(770, 40);
            txtPlaca.Size = new Size(225, 27);
            Controls.Add(lbltxtPlaca);
            Controls.Add(txtPlaca);
            lbltxtMarca.AutoSize = true;
            lbltxtMarca.Location = new Point(20, 90);
            lbltxtMarca.Text = "Marca";
            txtMarca.Name = "txtMarca";
            txtMarca.Location = new Point(20, 115);
            txtMarca.Size = new Size(225, 27);
            Controls.Add(lbltxtMarca);
            Controls.Add(txtMarca);
            lbltxtModelo.AutoSize = true;
            lbltxtModelo.Location = new Point(270, 90);
            lbltxtModelo.Text = "Modelo";
            txtModelo.Name = "txtModelo";
            txtModelo.Location = new Point(270, 115);
            txtModelo.Size = new Size(225, 27);
            Controls.Add(lbltxtModelo);
            Controls.Add(txtModelo);
            lbltxtAnio.AutoSize = true;
            lbltxtAnio.Location = new Point(520, 90);
            lbltxtAnio.Text = "Año";
            txtAnio.Name = "txtAnio";
            txtAnio.Location = new Point(520, 115);
            txtAnio.Size = new Size(225, 27);
            Controls.Add(lbltxtAnio);
            Controls.Add(txtAnio);
            lbltxtKilometraje.AutoSize = true;
            lbltxtKilometraje.Location = new Point(770, 90);
            lbltxtKilometraje.Text = "Kilometraje";
            txtKilometraje.Name = "txtKilometraje";
            txtKilometraje.Location = new Point(770, 115);
            txtKilometraje.Size = new Size(225, 27);
            Controls.Add(lbltxtKilometraje);
            Controls.Add(txtKilometraje);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            Name = "ucVehiculo";
            Size = new Size(1020, 170);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
