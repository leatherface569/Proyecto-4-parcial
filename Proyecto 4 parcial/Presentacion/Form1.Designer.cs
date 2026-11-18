namespace Proyecto_4_parcial
{
    partial class Form1
    {
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem clientesMenu;
        private ToolStripMenuItem vehiculosMenu;
        private StatusStrip barraEstado;
        private ToolStripStatusLabel estadoLabel;
        private void InitializeComponent()
        {
            menuPrincipal = new MenuStrip();
            clientesMenu = new ToolStripMenuItem();
            vehiculosMenu = new ToolStripMenuItem();
            barraEstado = new StatusStrip();
            estadoLabel = new ToolStripStatusLabel();
            SuspendLayout();
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Items.AddRange(new ToolStripItem[] { clientesMenu, vehiculosMenu });
            clientesMenu.Name = "clientesMenu";
            clientesMenu.Text = "Clientes";
            clientesMenu.Click += clientesMenu_Click;
            vehiculosMenu.Name = "vehiculosMenu";
            vehiculosMenu.Text = "Vehículos";
            vehiculosMenu.Click += vehiculosMenu_Click;
            barraEstado.Items.Add(estadoLabel);
            estadoLabel.Text = "Avance: clientes y vehículos | Datos temporales en memoria";
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1200, 750);
            Controls.Add(barraEstado);
            Controls.Add(menuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Name = "Form1";
            Text = "Taller mecánico - Avance";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
