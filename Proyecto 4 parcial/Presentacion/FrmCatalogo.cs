using System.Reflection;
using Proyecto_4_parcial.Datos;
using Proyecto_4_parcial.Entidades;
using Proyecto_4_parcial.Negocio;
namespace Proyecto_4_parcial.Presentacion;
// Formulario reutilizable; los controles se construyen en código.
public class FrmCatalogo<T> : Form where T : Entidad {
 protected readonly TallerServicio negocio;
 private readonly IRepositorio<T> repo;
 private readonly Func<T> crear;
 private readonly Dictionary<string,Control> campos=new();
 private readonly ErrorProvider errores=new();
 private readonly DataGridView tabla=new() { Dock=DockStyle.Fill,ReadOnly=true,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill,SelectionMode=DataGridViewSelectionMode.FullRowSelect,MultiSelect=false,AllowUserToAddRows=false };
 private readonly FlowLayoutPanel editor=new() { Dock=DockStyle.Top,Height=205,AutoScroll=true,Padding=new Padding(12),WrapContents=true };
 private int actual;
 public FrmCatalogo(string titulo,TallerServicio servicio,IRepositorio<T> repositorio,Func<T> fabrica) {
 Text=titulo; negocio=servicio; repo=repositorio; crear=fabrica; Width=1050; Height=650; Font=new Font("Segoe UI",10); errores.ContainerControl=this;
 Controls.Add(tabla); Controls.Add(editor);
 foreach(var p in typeof(T).GetProperties().Where(x=>x.CanWrite && x.Name!="Id")) {
 Control? c=null;
 if(p.Name=="Servicios" || p.Name=="Refacciones") {
 var lista=new CheckedListBox { Width=260,Height=100,CheckOnClick=true };
 if(p.Name=="Servicios") foreach(var x in negocio.Datos.Servicios.Todos()) lista.Items.Add(x);
 else foreach(var x in negocio.Datos.Refacciones.Todos()) lista.Items.Add(x);
 c=lista;
 } else if(p.Name.EndsWith("Id")) {
 var combo=new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList,Width=220 };
 IEnumerable<Entidad> items=p.Name switch { "ClienteId"=>negocio.Datos.Clientes.Todos(),"VehiculoId"=>negocio.Datos.Vehiculos.Todos(),"MecanicoId"=>negocio.Datos.Mecanicos.Todos(),_=>Array.Empty<Entidad>() };
 foreach(var x in items) combo.Items.Add(x); c=combo;
 } else if(p.PropertyType.IsEnum) { c=new ComboBox { DataSource=Enum.GetValues(p.PropertyType),DropDownStyle=ComboBoxStyle.DropDownList,Width=200 }; }
 else if(p.PropertyType==typeof(DateTime)) c=new DateTimePicker { Width=220 };
 else if(p.PropertyType==typeof(int) || p.PropertyType==typeof(decimal)) c=new NumericUpDown { Minimum=0,Maximum=10000000,DecimalPlaces=p.PropertyType==typeof(decimal)?2:0,Width=180,Value=p.Name=="Anio"?DateTime.Today.Year:0 };
 else if(p.PropertyType==typeof(string)) c=new TextBox { Width=220,MaxLength=250 };
 if(c==null) continue;
 campos[p.Name]=c;
 var panel=new FlowLayoutPanel { FlowDirection=FlowDirection.TopDown,Width=c.Width+12,Height=c.Height+40,WrapContents=false };
 panel.Controls.Add(new Label { Text=p.Name.Replace("Id",""),AutoSize=true }); panel.Controls.Add(c); editor.Controls.Add(panel);
 }
 var botones=new FlowLayoutPanel { Dock=DockStyle.Bottom,Height=52,Padding=new Padding(8) }; Controls.Add(botones);
 void Boton(string texto,Action accion) { var b=new Button { Text=texto,AutoSize=true }; b.Click+=(_,_)=>Seguro(accion); botones.Controls.Add(b); }
 Boton("Nuevo",Limpiar); Boton("Guardar",Guardar); Boton("Cerrar",Close);
 Boton(typeof(T)==typeof(OrdenServicio)?"Cancelar orden":"Eliminar",()=> {
 var e=repo.Todos().FirstOrDefault(x=>x.Id==actual)??throw new InvalidOperationException("Selecciona una fila.");
 if(MessageBox.Show("¿Confirmar la operación?",Text,MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
 if(e is OrdenServicio orden) { orden.Estado=EstadoOrden.Cancelada; repo.Guardar(e); } else negocio.Eliminar(e,repo);
 Limpiar(); Recargar();
 });
 tabla.CellClick+=(_,e)=>Seguro(() => { if(e.RowIndex>=0 && tabla.Rows[e.RowIndex].DataBoundItem is T item) Cargar(item); });
 Recargar();
 }
 private void Seguro(Action a) { errores.Clear(); try { a(); } catch(ValidacionException ex) { if(campos.TryGetValue(ex.Campo,out var c)) { errores.SetError(c,ex.Message); c.Focus(); } else MessageBox.Show(ex.Message); } catch(Exception ex) { MessageBox.Show(ex.Message,"Operación no realizada",MessageBoxButtons.OK,MessageBoxIcon.Warning); } }
 private void Guardar() {
 var anterior=repo.Todos().FirstOrDefault(x=>x.Id==actual);
 if(anterior is OrdenServicio { Estado:EstadoOrden.Cancelada }) throw new InvalidOperationException("La orden cancelada no se puede modificar.");
 var e=anterior is Vehiculo ? (T)Activator.CreateInstance(anterior.GetType())! : crear(); e.Id=actual;
 foreach(var par in campos) {
 var p=typeof(T).GetProperty(par.Key)!; var c=par.Value;
 object? valor=c switch {
 TextBox t=>t.Text,
 NumericUpDown n=>p.PropertyType==typeof(int)?(object)(int)n.Value:n.Value,
 DateTimePicker d=>d.Value,
 ComboBox b=>p.Name.EndsWith("Id")?(b.SelectedItem as Entidad)?.Id??0:b.SelectedItem,
 CheckedListBox l when par.Key=="Servicios"=>l.CheckedItems.Cast<Servicio>().Select(s=>new DetalleServicio { ServicioId=s.Id,Precio=anterior is OrdenServicio a?a.Servicios.FirstOrDefault(d=>d.ServicioId==s.Id)?.Precio??s.Precio:s.Precio }).ToList(),
 CheckedListBox l=>l.CheckedItems.Cast<Refaccion>().Select(r=>new DetalleRefaccion { RefaccionId=r.Id,Cantidad=1,Precio=anterior is OrdenServicio a?a.Refacciones.FirstOrDefault(d=>d.RefaccionId==r.Id)?.Precio??r.Precio:r.Precio }).ToList(),
 _=>null }; p.SetValue(e,valor);
 }
 negocio.Guardar(e,repo); Recargar(); Limpiar();
 }
 private void Cargar(T e) { actual=e.Id; errores.Clear(); foreach(var par in campos) {
 var valor=typeof(T).GetProperty(par.Key)!.GetValue(e);
 switch(par.Value) {
 case TextBox t: t.Text=valor?.ToString(); break;
 case NumericUpDown n: n.Value=Convert.ToDecimal(valor); break;
 case DateTimePicker d: d.Value=(DateTime)valor!; break;
 case ComboBox b: if(par.Key.EndsWith("Id")) b.SelectedItem=b.Items.Cast<Entidad>().FirstOrDefault(x=>x.Id==Convert.ToInt32(valor)); else b.SelectedItem=valor; break;
 case CheckedListBox l: for(int i=0;i<l.Items.Count;i++) { var id=((Entidad)l.Items[i]).Id; l.SetItemChecked(i,valor is List<DetalleServicio> ds?ds.Any(x=>x.ServicioId==id):((List<DetalleRefaccion>)valor!).Any(x=>x.RefaccionId==id)); } break;
 }
 } }
 private void Limpiar() { actual=0; errores.Clear(); foreach(var c in campos.Values) { if(c is TextBox t)t.Clear(); if(c is ComboBox b)b.SelectedIndex=-1; if(c is CheckedListBox l)for(int i=0;i<l.Items.Count;i++)l.SetItemChecked(i,false); if(c is NumericUpDown n)n.Value=n.DecimalPlaces==0 && n.Maximum>2000 && campos.GetValueOrDefault("Anio")==n?DateTime.Today.Year:0; } }
 private void Recargar() { tabla.DataSource=null; tabla.DataSource=repo.Todos().ToList(); }
 protected override void Dispose(bool disposing) { if(disposing) errores.Dispose(); base.Dispose(disposing); }
}