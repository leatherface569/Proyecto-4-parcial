using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
public class FrmVehiculos : Form {
 public FrmVehiculos(TallerServicio n) {
 Text="Vehículos: selecciona el tipo"; Width=550; Height=180;
 var panel=new FlowLayoutPanel { Dock=DockStyle.Fill,Padding=new Padding(20) }; Controls.Add(panel);
 void Agregar(string texto,Func<Vehiculo> crear) { var b=new Button { Text=texto,Width=145,Height=55 }; b.Click += (_, _) => {
 try {
  // El diálogo bloquea el selector de tipos hasta que se cierre.
  using var formulario = new FrmCatalogo<Vehiculo>(texto,n,n.Datos.Vehiculos,crear);
  formulario.StartPosition = FormStartPosition.CenterParent;
  formulario.ShowDialog(this);
 } catch (Exception ex) {
  MessageBox.Show(this, "No se pudo abrir el catálogo. " + ex.Message,
   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 }; panel.Controls.Add(b); }
 Agregar("Automóvil",()=>new Automovil()); Agregar("Motocicleta",()=>new Motocicleta()); Agregar("Camioneta",()=>new Camioneta());
 }
}