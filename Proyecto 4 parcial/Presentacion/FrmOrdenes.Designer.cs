#nullable enable
namespace Proyecto_4_parcial.Presentacion
{
    partial class FrmOrdenes
    {
        private System.ComponentModel.IContainer? components = null;
        private FlowLayoutPanel panel = null!;
        private DataGridView dgvDatos = null!;
        private ErrorProvider errores = null!;
        private ComboBox cmbVehiculo = null!;
        private FlowLayoutPanel grupocmbVehiculo = null!;
        private Label etiquetacmbVehiculo = null!;
        private ComboBox cmbMecanico = null!;
        private FlowLayoutPanel grupocmbMecanico = null!;
        private Label etiquetacmbMecanico = null!;
        private NumericUpDown nudKilometraje = null!;
        private FlowLayoutPanel gruponudKilometraje = null!;
        private Label etiquetanudKilometraje = null!;
        private TextBox txtFalla = null!;
        private FlowLayoutPanel grupotxtFalla = null!;
        private Label etiquetatxtFalla = null!;
        private TextBox txtDiagnostico = null!;
        private FlowLayoutPanel grupotxtDiagnostico = null!;
        private Label etiquetatxtDiagnostico = null!;
        private ComboBox cmbEstado = null!;
        private FlowLayoutPanel grupocmbEstado = null!;
        private Label etiquetacmbEstado = null!;
        private ComboBox cmbServicio = null!;
        private FlowLayoutPanel grupocmbServicio = null!;
        private Label etiquetacmbServicio = null!;
        private ComboBox cmbRefaccion = null!;
        private FlowLayoutPanel grupocmbRefaccion = null!;
        private Label etiquetacmbRefaccion = null!;
        private NumericUpDown nudCantidad = null!;
        private FlowLayoutPanel gruponudCantidad = null!;
        private Label etiquetanudCantidad = null!;
        private NumericUpDown nudPago = null!;
        private FlowLayoutPanel gruponudPago = null!;
        private Label etiquetanudPago = null!;
        private Button btnAccion1 = null!;
        private Button btnAccion2 = null!;
        private Button btnAccion3 = null!;
        private Button btnAccion4 = null!;
        private Button btnAccion5 = null!;
        private Button btnAccion6 = null!;
        private Button btnAccion7 = null!;
        private Button btnAccion8 = null!;
        private Button btnAccion9 = null!;
        private Label lblOrden = null!;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel = new FlowLayoutPanel();
            grupocmbVehiculo = new FlowLayoutPanel();
            etiquetacmbVehiculo = new Label();
            cmbVehiculo = new ComboBox();
            grupocmbMecanico = new FlowLayoutPanel();
            etiquetacmbMecanico = new Label();
            cmbMecanico = new ComboBox();
            gruponudKilometraje = new FlowLayoutPanel();
            etiquetanudKilometraje = new Label();
            nudKilometraje = new NumericUpDown();
            grupotxtFalla = new FlowLayoutPanel();
            etiquetatxtFalla = new Label();
            txtFalla = new TextBox();
            grupotxtDiagnostico = new FlowLayoutPanel();
            etiquetatxtDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            grupocmbEstado = new FlowLayoutPanel();
            etiquetacmbEstado = new Label();
            cmbEstado = new ComboBox();
            grupocmbServicio = new FlowLayoutPanel();
            etiquetacmbServicio = new Label();
            cmbServicio = new ComboBox();
            grupocmbRefaccion = new FlowLayoutPanel();
            etiquetacmbRefaccion = new Label();
            cmbRefaccion = new ComboBox();
            gruponudCantidad = new FlowLayoutPanel();
            etiquetanudCantidad = new Label();
            nudCantidad = new NumericUpDown();
            gruponudPago = new FlowLayoutPanel();
            etiquetanudPago = new Label();
            nudPago = new NumericUpDown();
            btnAccion1 = new Button();
            btnAccion2 = new Button();
            btnAccion3 = new Button();
            btnAccion4 = new Button();
            btnAccion5 = new Button();
            btnAccion6 = new Button();
            btnAccion7 = new Button();
            btnAccion8 = new Button();
            btnAccion9 = new Button();
            lblOrden = new Label();
            dgvDatos = new DataGridView();
            errores = new ErrorProvider(components);
            panel.SuspendLayout();
            grupocmbVehiculo.SuspendLayout();
            grupocmbMecanico.SuspendLayout();
            gruponudKilometraje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudKilometraje).BeginInit();
            grupotxtFalla.SuspendLayout();
            grupotxtDiagnostico.SuspendLayout();
            grupocmbEstado.SuspendLayout();
            grupocmbServicio.SuspendLayout();
            grupocmbRefaccion.SuspendLayout();
            gruponudCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            gruponudPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPago).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errores).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(grupocmbVehiculo);
            panel.Controls.Add(grupocmbMecanico);
            panel.Controls.Add(gruponudKilometraje);
            panel.Controls.Add(grupotxtFalla);
            panel.Controls.Add(grupotxtDiagnostico);
            panel.Controls.Add(grupocmbEstado);
            panel.Controls.Add(grupocmbServicio);
            panel.Controls.Add(grupocmbRefaccion);
            panel.Controls.Add(gruponudCantidad);
            panel.Controls.Add(gruponudPago);
            panel.Controls.Add(btnAccion1);
            panel.Controls.Add(btnAccion2);
            panel.Controls.Add(btnAccion3);
            panel.Controls.Add(btnAccion4);
            panel.Controls.Add(btnAccion5);
            panel.Controls.Add(btnAccion6);
            panel.Controls.Add(btnAccion7);
            panel.Controls.Add(btnAccion8);
            panel.Controls.Add(btnAccion9);
            panel.Controls.Add(lblOrden);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Padding = new Padding(12);
            panel.Size = new Size(1100, 430);
            panel.TabIndex = 1;
            // 
            // grupocmbVehiculo
            // 
            grupocmbVehiculo.Controls.Add(etiquetacmbVehiculo);
            grupocmbVehiculo.Controls.Add(cmbVehiculo);
            grupocmbVehiculo.FlowDirection = FlowDirection.TopDown;
            grupocmbVehiculo.Location = new Point(15, 15);
            grupocmbVehiculo.Name = "grupocmbVehiculo";
            grupocmbVehiculo.Size = new Size(230, 70);
            grupocmbVehiculo.TabIndex = 0;
            grupocmbVehiculo.WrapContents = false;
            // 
            // etiquetacmbVehiculo
            // 
            etiquetacmbVehiculo.AutoSize = true;
            etiquetacmbVehiculo.Location = new Point(3, 0);
            etiquetacmbVehiculo.Name = "etiquetacmbVehiculo";
            etiquetacmbVehiculo.Size = new Size(75, 23);
            etiquetacmbVehiculo.TabIndex = 0;
            etiquetacmbVehiculo.Text = "Vehículo";
            // 
            // cmbVehiculo
            // 
            cmbVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehiculo.Location = new Point(3, 26);
            cmbVehiculo.Name = "cmbVehiculo";
            cmbVehiculo.Size = new Size(210, 31);
            cmbVehiculo.TabIndex = 1;
            // 
            // grupocmbMecanico
            // 
            grupocmbMecanico.Controls.Add(etiquetacmbMecanico);
            grupocmbMecanico.Controls.Add(cmbMecanico);
            grupocmbMecanico.FlowDirection = FlowDirection.TopDown;
            grupocmbMecanico.Location = new Point(251, 15);
            grupocmbMecanico.Name = "grupocmbMecanico";
            grupocmbMecanico.Size = new Size(230, 70);
            grupocmbMecanico.TabIndex = 1;
            grupocmbMecanico.WrapContents = false;
            // 
            // etiquetacmbMecanico
            // 
            etiquetacmbMecanico.AutoSize = true;
            etiquetacmbMecanico.Location = new Point(3, 0);
            etiquetacmbMecanico.Name = "etiquetacmbMecanico";
            etiquetacmbMecanico.Size = new Size(179, 23);
            etiquetacmbMecanico.TabIndex = 0;
            etiquetacmbMecanico.Text = "Mecánico responsable";
            // 
            // cmbMecanico
            // 
            cmbMecanico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMecanico.Location = new Point(3, 26);
            cmbMecanico.Name = "cmbMecanico";
            cmbMecanico.Size = new Size(210, 31);
            cmbMecanico.TabIndex = 1;
            // 
            // gruponudKilometraje
            // 
            gruponudKilometraje.Controls.Add(etiquetanudKilometraje);
            gruponudKilometraje.Controls.Add(nudKilometraje);
            gruponudKilometraje.FlowDirection = FlowDirection.TopDown;
            gruponudKilometraje.Location = new Point(487, 15);
            gruponudKilometraje.Name = "gruponudKilometraje";
            gruponudKilometraje.Size = new Size(230, 70);
            gruponudKilometraje.TabIndex = 2;
            gruponudKilometraje.WrapContents = false;
            // 
            // etiquetanudKilometraje
            // 
            etiquetanudKilometraje.AutoSize = true;
            etiquetanudKilometraje.Location = new Point(3, 0);
            etiquetanudKilometraje.Name = "etiquetanudKilometraje";
            etiquetanudKilometraje.Size = new Size(199, 23);
            etiquetanudKilometraje.TabIndex = 0;
            etiquetanudKilometraje.Text = "Kilometraje de recepción";
            // 
            // nudKilometraje
            // 
            nudKilometraje.Location = new Point(3, 26);
            nudKilometraje.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudKilometraje.Name = "nudKilometraje";
            nudKilometraje.Size = new Size(210, 30);
            nudKilometraje.TabIndex = 1;
            // 
            // grupotxtFalla
            // 
            grupotxtFalla.Controls.Add(etiquetatxtFalla);
            grupotxtFalla.Controls.Add(txtFalla);
            grupotxtFalla.FlowDirection = FlowDirection.TopDown;
            grupotxtFalla.Location = new Point(723, 15);
            grupotxtFalla.Name = "grupotxtFalla";
            grupotxtFalla.Size = new Size(230, 70);
            grupotxtFalla.TabIndex = 3;
            grupotxtFalla.WrapContents = false;
            // 
            // etiquetatxtFalla
            // 
            etiquetatxtFalla.AutoSize = true;
            etiquetatxtFalla.Location = new Point(3, 0);
            etiquetatxtFalla.Name = "etiquetatxtFalla";
            etiquetatxtFalla.Size = new Size(123, 23);
            etiquetatxtFalla.TabIndex = 0;
            etiquetatxtFalla.Text = "Falla reportada";
            // 
            // txtFalla
            // 
            txtFalla.Location = new Point(3, 26);
            txtFalla.MaxLength = 250;
            txtFalla.Name = "txtFalla";
            txtFalla.Size = new Size(210, 30);
            txtFalla.TabIndex = 1;
            // 
            // grupotxtDiagnostico
            // 
            grupotxtDiagnostico.Controls.Add(etiquetatxtDiagnostico);
            grupotxtDiagnostico.Controls.Add(txtDiagnostico);
            grupotxtDiagnostico.FlowDirection = FlowDirection.TopDown;
            grupotxtDiagnostico.Location = new Point(15, 91);
            grupotxtDiagnostico.Name = "grupotxtDiagnostico";
            grupotxtDiagnostico.Size = new Size(230, 70);
            grupotxtDiagnostico.TabIndex = 4;
            grupotxtDiagnostico.WrapContents = false;
            // 
            // etiquetatxtDiagnostico
            // 
            etiquetatxtDiagnostico.AutoSize = true;
            etiquetatxtDiagnostico.Location = new Point(3, 0);
            etiquetatxtDiagnostico.Name = "etiquetatxtDiagnostico";
            etiquetatxtDiagnostico.Size = new Size(100, 23);
            etiquetatxtDiagnostico.TabIndex = 0;
            etiquetatxtDiagnostico.Text = "Diagnóstico";
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(3, 26);
            txtDiagnostico.MaxLength = 250;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.Size = new Size(210, 30);
            txtDiagnostico.TabIndex = 1;
            // 
            // grupocmbEstado
            // 
            grupocmbEstado.Controls.Add(etiquetacmbEstado);
            grupocmbEstado.Controls.Add(cmbEstado);
            grupocmbEstado.FlowDirection = FlowDirection.TopDown;
            grupocmbEstado.Location = new Point(251, 91);
            grupocmbEstado.Name = "grupocmbEstado";
            grupocmbEstado.Size = new Size(230, 70);
            grupocmbEstado.TabIndex = 5;
            grupocmbEstado.WrapContents = false;
            // 
            // etiquetacmbEstado
            // 
            etiquetacmbEstado.AutoSize = true;
            etiquetacmbEstado.Location = new Point(3, 0);
            etiquetacmbEstado.Name = "etiquetacmbEstado";
            etiquetacmbEstado.Size = new Size(137, 23);
            etiquetacmbEstado.TabIndex = 0;
            etiquetacmbEstado.Text = "Siguiente estado";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(3, 26);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(210, 31);
            cmbEstado.TabIndex = 1;
            // 
            // grupocmbServicio
            // 
            grupocmbServicio.Controls.Add(etiquetacmbServicio);
            grupocmbServicio.Controls.Add(cmbServicio);
            grupocmbServicio.FlowDirection = FlowDirection.TopDown;
            grupocmbServicio.Location = new Point(487, 91);
            grupocmbServicio.Name = "grupocmbServicio";
            grupocmbServicio.Size = new Size(230, 70);
            grupocmbServicio.TabIndex = 6;
            grupocmbServicio.WrapContents = false;
            // 
            // etiquetacmbServicio
            // 
            etiquetacmbServicio.AutoSize = true;
            etiquetacmbServicio.Location = new Point(3, 0);
            etiquetacmbServicio.Name = "etiquetacmbServicio";
            etiquetacmbServicio.Size = new Size(68, 23);
            etiquetacmbServicio.TabIndex = 0;
            etiquetacmbServicio.Text = "Servicio";
            // 
            // cmbServicio
            // 
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Location = new Point(3, 26);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(210, 31);
            cmbServicio.TabIndex = 1;
            // 
            // grupocmbRefaccion
            // 
            grupocmbRefaccion.Controls.Add(etiquetacmbRefaccion);
            grupocmbRefaccion.Controls.Add(cmbRefaccion);
            grupocmbRefaccion.FlowDirection = FlowDirection.TopDown;
            grupocmbRefaccion.Location = new Point(723, 91);
            grupocmbRefaccion.Name = "grupocmbRefaccion";
            grupocmbRefaccion.Size = new Size(230, 70);
            grupocmbRefaccion.TabIndex = 7;
            grupocmbRefaccion.WrapContents = false;
            // 
            // etiquetacmbRefaccion
            // 
            etiquetacmbRefaccion.AutoSize = true;
            etiquetacmbRefaccion.Location = new Point(3, 0);
            etiquetacmbRefaccion.Name = "etiquetacmbRefaccion";
            etiquetacmbRefaccion.Size = new Size(83, 23);
            etiquetacmbRefaccion.TabIndex = 0;
            etiquetacmbRefaccion.Text = "Refacción";
            // 
            // cmbRefaccion
            // 
            cmbRefaccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRefaccion.Location = new Point(3, 26);
            cmbRefaccion.Name = "cmbRefaccion";
            cmbRefaccion.Size = new Size(210, 31);
            cmbRefaccion.TabIndex = 1;
            // 
            // gruponudCantidad
            // 
            gruponudCantidad.Controls.Add(etiquetanudCantidad);
            gruponudCantidad.Controls.Add(nudCantidad);
            gruponudCantidad.FlowDirection = FlowDirection.TopDown;
            gruponudCantidad.Location = new Point(15, 167);
            gruponudCantidad.Name = "gruponudCantidad";
            gruponudCantidad.Size = new Size(230, 70);
            gruponudCantidad.TabIndex = 8;
            gruponudCantidad.WrapContents = false;
            // 
            // etiquetanudCantidad
            // 
            etiquetanudCantidad.AutoSize = true;
            etiquetanudCantidad.Location = new Point(3, 0);
            etiquetanudCantidad.Name = "etiquetanudCantidad";
            etiquetanudCantidad.Size = new Size(79, 23);
            etiquetanudCantidad.TabIndex = 0;
            etiquetanudCantidad.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(3, 26);
            nudCantidad.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(210, 30);
            nudCantidad.TabIndex = 1;
            // 
            // gruponudPago
            // 
            gruponudPago.Controls.Add(etiquetanudPago);
            gruponudPago.Controls.Add(nudPago);
            gruponudPago.FlowDirection = FlowDirection.TopDown;
            gruponudPago.Location = new Point(251, 167);
            gruponudPago.Name = "gruponudPago";
            gruponudPago.Size = new Size(230, 70);
            gruponudPago.TabIndex = 9;
            gruponudPago.WrapContents = false;
            // 
            // etiquetanudPago
            // 
            etiquetanudPago.AutoSize = true;
            etiquetanudPago.Location = new Point(3, 0);
            etiquetanudPago.Name = "etiquetanudPago";
            etiquetanudPago.Size = new Size(143, 23);
            etiquetanudPago.TabIndex = 0;
            etiquetanudPago.Text = "Importe del pago";
            // 
            // nudPago
            // 
            nudPago.DecimalPlaces = 2;
            nudPago.Location = new Point(3, 26);
            nudPago.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPago.Name = "nudPago";
            nudPago.Size = new Size(210, 30);
            nudPago.TabIndex = 1;
            // 
            // btnAccion1
            // 
            btnAccion1.AutoSize = true;
            btnAccion1.Location = new Point(492, 190);
            btnAccion1.Margin = new Padding(8, 26, 8, 0);
            btnAccion1.Name = "btnAccion1";
            btnAccion1.Size = new Size(107, 35);
            btnAccion1.TabIndex = 10;
            btnAccion1.Text = "Abrir orden";
            // 
            // btnAccion2
            // 
            btnAccion2.AutoSize = true;
            btnAccion2.Location = new Point(615, 190);
            btnAccion2.Margin = new Padding(8, 26, 8, 0);
            btnAccion2.Name = "btnAccion2";
            btnAccion2.Size = new Size(140, 35);
            btnAccion2.TabIndex = 11;
            btnAccion2.Text = "Cambiar estado";
            // 
            // btnAccion3
            // 
            btnAccion3.AutoSize = true;
            btnAccion3.Location = new Point(771, 190);
            btnAccion3.Margin = new Padding(8, 26, 8, 0);
            btnAccion3.Name = "btnAccion3";
            btnAccion3.Size = new Size(142, 35);
            btnAccion3.TabIndex = 12;
            btnAccion3.Text = "Agregar servicio";
            // 
            // btnAccion4
            // 
            btnAccion4.AutoSize = true;
            btnAccion4.Location = new Point(20, 266);
            btnAccion4.Margin = new Padding(8, 26, 8, 0);
            btnAccion4.Name = "btnAccion4";
            btnAccion4.Size = new Size(155, 35);
            btnAccion4.TabIndex = 13;
            btnAccion4.Text = "Agregar refacción";
            // 
            // btnAccion5
            // 
            btnAccion5.AutoSize = true;
            btnAccion5.Location = new Point(191, 266);
            btnAccion5.Margin = new Padding(8, 26, 8, 0);
            btnAccion5.Name = "btnAccion5";
            btnAccion5.Size = new Size(131, 35);
            btnAccion5.TabIndex = 14;
            btnAccion5.Text = "Registrar pago";
            // 
            // btnAccion6
            // 
            btnAccion6.AutoSize = true;
            btnAccion6.Location = new Point(338, 266);
            btnAccion6.Margin = new Padding(8, 26, 8, 0);
            btnAccion6.Name = "btnAccion6";
            btnAccion6.Size = new Size(180, 35);
            btnAccion6.TabIndex = 15;
            btnAccion6.Text = "Ver detalle e historial";
            // 
            // btnAccion7
            // 
            btnAccion7.AutoSize = true;
            btnAccion7.Location = new Point(534, 266);
            btnAccion7.Margin = new Padding(8, 26, 8, 0);
            btnAccion7.Name = "btnAccion7";
            btnAccion7.Size = new Size(136, 35);
            btnAccion7.TabIndex = 16;
            btnAccion7.Text = "Cancelar orden";
            // 
            // btnAccion8
            // 
            btnAccion8.AutoSize = true;
            btnAccion8.Location = new Point(686, 266);
            btnAccion8.Margin = new Padding(8, 26, 8, 0);
            btnAccion8.Name = "btnAccion8";
            btnAccion8.Size = new Size(95, 35);
            btnAccion8.TabIndex = 17;
            btnAccion8.Text = "Actualizar";
            // 
            // btnAccion9
            // 
            btnAccion9.AutoSize = true;
            btnAccion9.Location = new Point(797, 266);
            btnAccion9.Margin = new Padding(8, 26, 8, 0);
            btnAccion9.Name = "btnAccion9";
            btnAccion9.Size = new Size(75, 35);
            btnAccion9.TabIndex = 18;
            btnAccion9.Text = "Cerrar";
            // 
            // lblOrden
            // 
            lblOrden.AutoSize = true;
            lblOrden.Location = new Point(883, 240);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(0, 23);
            lblOrden.TabIndex = 19;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDatos.ColumnHeadersHeight = 29;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 430);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(1100, 270);
            dgvDatos.TabIndex = 0;
            // 
            // errores
            // 
            errores.ContainerControl = this;
            // 
            // FrmOrdenes
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(dgvDatos);
            Controls.Add(panel);
            Font = new Font("Segoe UI", 10F);
            Name = "FrmOrdenes";
            Text = "Órdenes de servicio";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            grupocmbVehiculo.ResumeLayout(false);
            grupocmbVehiculo.PerformLayout();
            grupocmbMecanico.ResumeLayout(false);
            grupocmbMecanico.PerformLayout();
            gruponudKilometraje.ResumeLayout(false);
            gruponudKilometraje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudKilometraje).EndInit();
            grupotxtFalla.ResumeLayout(false);
            grupotxtFalla.PerformLayout();
            grupotxtDiagnostico.ResumeLayout(false);
            grupotxtDiagnostico.PerformLayout();
            grupocmbEstado.ResumeLayout(false);
            grupocmbEstado.PerformLayout();
            grupocmbServicio.ResumeLayout(false);
            grupocmbServicio.PerformLayout();
            grupocmbRefaccion.ResumeLayout(false);
            grupocmbRefaccion.PerformLayout();
            gruponudCantidad.ResumeLayout(false);
            gruponudCantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            gruponudPago.ResumeLayout(false);
            gruponudPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPago).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errores).EndInit();
            ResumeLayout(false);
        }
    }
}
