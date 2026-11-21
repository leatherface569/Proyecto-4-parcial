namespace Proyecto_4_parcial
{
    partial class Form1
    {
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem clientesMenu;
        private ToolStripMenuItem vehiculosMenu;
        private void InitializeComponent()
        {
            menuPrincipal = new MenuStrip();
            clientesMenu = new ToolStripMenuItem();
            vehiculosMenu = new ToolStripMenuItem();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.ImageScalingSize = new Size(20, 20);
            menuPrincipal.Items.AddRange(new ToolStripItem[] { clientesMenu, vehiculosMenu });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1200, 28);
            menuPrincipal.TabIndex = 1;
            // 
            // clientesMenu
            // 
            clientesMenu.Name = "clientesMenu";
            clientesMenu.Size = new Size(75, 24);
            clientesMenu.Text = "Clientes";
            clientesMenu.Click += clientesMenu_Click;
            // 
            // vehiculosMenu
            // 
            vehiculosMenu.Name = "vehiculosMenu";
            vehiculosMenu.Size = new Size(85, 24);
            vehiculosMenu.Text = "Vehículos";
            vehiculosMenu.Click += vehiculosMenu_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 750);
            Controls.Add(menuPrincipal);
            Font = new Font("Segoe UI", 10F);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Taller mecánico ";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
