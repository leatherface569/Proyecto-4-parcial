#nullable enable
namespace Proyecto_4_parcial;
partial class Form1 {
 private System.ComponentModel.IContainer? components=null;
 private MenuStrip menuPrincipal=null!;
 private StatusStrip barraEstado=null!;
 private ToolStripStatusLabel estadoLabel=null!;
 private ToolStripMenuItem clientesMenu=null!;
 private ToolStripMenuItem vehiculosMenu=null!;
 private ToolStripMenuItem mecanicosMenu=null!;
 private ToolStripMenuItem serviciosMenu=null!;
 private ToolStripMenuItem refaccionesMenu=null!;
 private ToolStripMenuItem ordenesMenu=null!;
 protected override void Dispose(bool disposing) { if(disposing) components?.Dispose(); base.Dispose(disposing); }
 private void InitializeComponent() {
 components=new System.ComponentModel.Container();
 menuPrincipal=new MenuStrip(); barraEstado=new StatusStrip(); estadoLabel=new ToolStripStatusLabel();
 clientesMenu=new ToolStripMenuItem();
 vehiculosMenu=new ToolStripMenuItem();
 mecanicosMenu=new ToolStripMenuItem();
 serviciosMenu=new ToolStripMenuItem();
 refaccionesMenu=new ToolStripMenuItem();
 ordenesMenu=new ToolStripMenuItem();
 menuPrincipal.SuspendLayout(); barraEstado.SuspendLayout(); SuspendLayout();
 menuPrincipal.Items.AddRange(new ToolStripItem[] {clientesMenu,vehiculosMenu,mecanicosMenu,serviciosMenu,refaccionesMenu,ordenesMenu});
 menuPrincipal.Name="menuPrincipal"; menuPrincipal.Location=new Point(0,0); menuPrincipal.TabIndex=0;
 clientesMenu.Name="clientesMenu"; clientesMenu.Text="Clientes"; clientesMenu.Click+=clientesMenu_Click;
 vehiculosMenu.Name="vehiculosMenu"; vehiculosMenu.Text="Vehículos"; vehiculosMenu.Click+=vehiculosMenu_Click;
 mecanicosMenu.Name="mecanicosMenu"; mecanicosMenu.Text="Mecánicos"; mecanicosMenu.Click+=mecanicosMenu_Click;
 serviciosMenu.Name="serviciosMenu"; serviciosMenu.Text="Servicios"; serviciosMenu.Click+=serviciosMenu_Click;
 refaccionesMenu.Name="refaccionesMenu"; refaccionesMenu.Text="Refacciones"; refaccionesMenu.Click+=refaccionesMenu_Click;
 ordenesMenu.Name="ordenesMenu"; ordenesMenu.Text="Órdenes"; ordenesMenu.Click+=ordenesMenu_Click;
 barraEstado.Items.AddRange(new ToolStripItem[] {estadoLabel}); barraEstado.Name="barraEstado";
 estadoLabel.Text="Avance del taller | Datos temporales en memoria";
 AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font;
 ClientSize=new Size(1150,720); Controls.Add(barraEstado); Controls.Add(menuPrincipal);
 IsMdiContainer=true; MainMenuStrip=menuPrincipal; Name="Form1";
 StartPosition=FormStartPosition.CenterScreen; Text="Proyecto 4 parcial - Taller mecánico";
 WindowState=FormWindowState.Maximized;
 menuPrincipal.ResumeLayout(false); menuPrincipal.PerformLayout(); barraEstado.ResumeLayout(false); barraEstado.PerformLayout(); ResumeLayout(false); PerformLayout();
 }
}

