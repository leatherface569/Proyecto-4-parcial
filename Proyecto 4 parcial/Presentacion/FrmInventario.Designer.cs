#nullable enable
namespace Proyecto_4_parcial.Presentacion
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer? components = null;
        private FlowLayoutPanel panel = null!;
        private DataGridView dgvDatos = null!;
        private ErrorProvider errores = null!;
        private ComboBox cmbRefaccion = null!;
        private FlowLayoutPanel grupocmbRefaccion = null!;
        private Label etiquetacmbRefaccion = null!;
        private NumericUpDown nudCantidad = null!;
        private FlowLayoutPanel gruponudCantidad = null!;
        private Label etiquetanudCantidad = null!;
        private TextBox txtMotivo = null!;
        private FlowLayoutPanel grupotxtMotivo = null!;
        private Label etiquetatxtMotivo = null!;
        private Button btnAccion1 = null!;
        private Button btnAccion2 = null!;
        private Button btnAccion3 = null!;
        private Button btnAccion4 = null!;
        private Button btnAccion5 = null!;
        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel = new FlowLayoutPanel();
            grupocmbRefaccion = new FlowLayoutPanel();
            etiquetacmbRefaccion = new Label();
            cmbRefaccion = new ComboBox();
            gruponudCantidad = new FlowLayoutPanel();
            etiquetanudCantidad = new Label();
            nudCantidad = new NumericUpDown();
            grupotxtMotivo = new FlowLayoutPanel();
            etiquetatxtMotivo = new Label();
            txtMotivo = new TextBox();
            btnAccion1 = new Button();
            btnAccion2 = new Button();
            btnAccion3 = new Button();
            btnAccion4 = new Button();
            btnAccion5 = new Button();
            dgvDatos = new DataGridView();
            errores = new ErrorProvider(components);
            panel.SuspendLayout();
            grupocmbRefaccion.SuspendLayout();
            gruponudCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            grupotxtMotivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errores).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(grupocmbRefaccion);
            panel.Controls.Add(gruponudCantidad);
            panel.Controls.Add(grupotxtMotivo);
            panel.Controls.Add(btnAccion1);
            panel.Controls.Add(btnAccion2);
            panel.Controls.Add(btnAccion3);
            panel.Controls.Add(btnAccion4);
            panel.Controls.Add(btnAccion5);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Padding = new Padding(12);
            panel.Size = new Size(1100, 190);
            panel.TabIndex = 1;
            // 
            // grupocmbRefaccion
            // 
            grupocmbRefaccion.Controls.Add(etiquetacmbRefaccion);
            grupocmbRefaccion.Controls.Add(cmbRefaccion);
            grupocmbRefaccion.FlowDirection = FlowDirection.TopDown;
            grupocmbRefaccion.Location = new Point(15, 15);
            grupocmbRefaccion.Name = "grupocmbRefaccion";
            grupocmbRefaccion.Size = new Size(230, 70);
            grupocmbRefaccion.TabIndex = 0;
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
            gruponudCantidad.Location = new Point(251, 15);
            gruponudCantidad.Name = "gruponudCantidad";
            gruponudCantidad.Size = new Size(230, 70);
            gruponudCantidad.TabIndex = 1;
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
            // grupotxtMotivo
            // 
            grupotxtMotivo.Controls.Add(etiquetatxtMotivo);
            grupotxtMotivo.Controls.Add(txtMotivo);
            grupotxtMotivo.FlowDirection = FlowDirection.TopDown;
            grupotxtMotivo.Location = new Point(487, 15);
            grupotxtMotivo.Name = "grupotxtMotivo";
            grupotxtMotivo.Size = new Size(230, 70);
            grupotxtMotivo.TabIndex = 2;
            grupotxtMotivo.WrapContents = false;
            // 
            // etiquetatxtMotivo
            // 
            etiquetatxtMotivo.AutoSize = true;
            etiquetatxtMotivo.Location = new Point(3, 0);
            etiquetatxtMotivo.Name = "etiquetatxtMotivo";
            etiquetatxtMotivo.Size = new Size(187, 23);
            etiquetatxtMotivo.TabIndex = 0;
            etiquetatxtMotivo.Text = "Motivo del movimiento";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(3, 26);
            txtMotivo.MaxLength = 250;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(210, 30);
            txtMotivo.TabIndex = 1;
            // 
            // btnAccion1
            // 
            btnAccion1.AutoSize = true;
            btnAccion1.Location = new Point(728, 38);
            btnAccion1.Margin = new Padding(8, 26, 8, 0);
            btnAccion1.Name = "btnAccion1";
            btnAccion1.Size = new Size(79, 35);
            btnAccion1.TabIndex = 3;
            btnAccion1.Text = "Entrada";
            // 
            // btnAccion2
            // 
            btnAccion2.AutoSize = true;
            btnAccion2.Location = new Point(823, 38);
            btnAccion2.Margin = new Padding(8, 26, 8, 0);
            btnAccion2.Name = "btnAccion2";
            btnAccion2.Size = new Size(75, 35);
            btnAccion2.TabIndex = 4;
            btnAccion2.Text = "Salida";
            // 
            // btnAccion3
            // 
            btnAccion3.AutoSize = true;
            btnAccion3.Location = new Point(914, 38);
            btnAccion3.Margin = new Padding(8, 26, 8, 0);
            btnAccion3.Name = "btnAccion3";
            btnAccion3.Size = new Size(148, 35);
            btnAccion3.TabIndex = 5;
            btnAccion3.Text = "Ver movimientos";
            // 
            // btnAccion4
            // 
            btnAccion4.AutoSize = true;
            btnAccion4.Location = new Point(20, 114);
            btnAccion4.Margin = new Padding(8, 26, 8, 0);
            btnAccion4.Name = "btnAccion4";
            btnAccion4.Size = new Size(126, 35);
            btnAccion4.TabIndex = 6;
            btnAccion4.Text = "Ver inventario";
            // 
            // btnAccion5
            // 
            btnAccion5.AutoSize = true;
            btnAccion5.Location = new Point(162, 114);
            btnAccion5.Margin = new Padding(8, 26, 8, 0);
            btnAccion5.Name = "btnAccion5";
            btnAccion5.Size = new Size(75, 35);
            btnAccion5.TabIndex = 7;
            btnAccion5.Text = "Cerrar";
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDatos.ColumnHeadersHeight = 29;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 190);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(1100, 510);
            dgvDatos.TabIndex = 0;
            // 
            // errores
            // 
            errores.ContainerControl = this;
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(dgvDatos);
            Controls.Add(panel);
            Font = new Font("Segoe UI", 10F);
            Name = "FrmInventario";
            Text = "Inventario";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            grupocmbRefaccion.ResumeLayout(false);
            grupocmbRefaccion.PerformLayout();
            gruponudCantidad.ResumeLayout(false);
            gruponudCantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            grupotxtMotivo.ResumeLayout(false);
            grupotxtMotivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errores).EndInit();
            ResumeLayout(false);
        }
    }
}
