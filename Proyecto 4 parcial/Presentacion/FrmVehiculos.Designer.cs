#nullable enable
namespace Proyecto_4_parcial.Presentacion
{
    partial class FrmVehiculos
    {
        private Button btnAutomovil = null!;
        private Button btnMotocicleta = null!;
        private Button btnCamioneta = null!;
        private void InitializeComponent()
        {
            btnAutomovil = new Button();
            btnMotocicleta = new Button();
            btnCamioneta = new Button();
            SuspendLayout();
            btnAutomovil.Name = "btnAutomovil";
            btnAutomovil.Text = "Automóvil";
            btnAutomovil.Location = new Point(20, 30);
            btnAutomovil.Size = new Size(145, 55);
            btnMotocicleta.Name = "btnMotocicleta";
            btnMotocicleta.Text = "Motocicleta";
            btnMotocicleta.Location = new Point(185, 30);
            btnMotocicleta.Size = new Size(145, 55);
            btnCamioneta.Name = "btnCamioneta";
            btnCamioneta.Text = "Camioneta";
            btnCamioneta.Location = new Point(350, 30);
            btnCamioneta.Size = new Size(145, 55);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(530, 135);
            Name = "FrmVehiculos";
            Text = "Vehículos: selecciona el tipo";
            Controls.Add(btnAutomovil);
            Controls.Add(btnMotocicleta);
            Controls.Add(btnCamioneta);
            ResumeLayout(false);
        }
    }
}
