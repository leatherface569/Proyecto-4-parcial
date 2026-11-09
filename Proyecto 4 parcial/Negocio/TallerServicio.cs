using Proyecto_4_parcial.Datos;
using Proyecto_4_parcial.Entidades;
namespace Proyecto_4_parcial.Negocio;
public class TallerServicio {
 public Almacen Datos { get; } = new();
 public void Guardar<T>(T e, IRepositorio<T> repo) where T : Entidad {
 foreach(var p in e.GetType().GetProperties().Where(x=>x.PropertyType==typeof(string) && x.CanWrite)) {
 var texto=((string?)p.GetValue(e)??"").Trim(); p.SetValue(e,texto);
 if(p.Name!="Correo" && p.Name!="Observaciones" && texto.Length==0) throw new ValidacionException(p.Name,"Campo obligatorio.");
 }
 if(e is Cliente c && c.Correo.Length>0 && !System.Net.Mail.MailAddress.TryCreate(c.Correo,out _)) throw new ValidacionException("Correo","Correo inválido.");
 if(e is Vehiculo v) {
 if(!Datos.Clientes.Todos().Any(x=>x.Id==v.ClienteId)) throw new ValidacionException("ClienteId","Selecciona un cliente.");
 if(v.Anio<1900 || v.Anio>DateTime.Today.Year+1) throw new ValidacionException("Anio","Año fuera de rango.");
 if(Datos.Vehiculos.Todos().Any(x=>x.Id!=v.Id && x.Placa.Equals(v.Placa,StringComparison.OrdinalIgnoreCase))) throw new ValidacionException("Placa","Placa duplicada.");
 }
 if(e is Servicio s && s.Precio<0 || e is Refaccion r && r.Precio<0) throw new ValidacionException("Precio","El precio no puede ser negativo.");
 if(e is OrdenServicio o) {
 if(!Datos.Clientes.Todos().Any(x=>x.Id==o.ClienteId)) throw new ValidacionException("ClienteId","Selecciona un cliente.");
 if(!Datos.Vehiculos.Todos().Any(x=>x.Id==o.VehiculoId && x.ClienteId==o.ClienteId)) throw new ValidacionException("VehiculoId","El vehículo debe pertenecer al cliente.");
 if(!Datos.Mecanicos.Todos().Any(x=>x.Id==o.MecanicoId)) throw new ValidacionException("MecanicoId","Selecciona un mecánico.");
 if(o.Servicios.Count==0) throw new ValidacionException("Servicios","Selecciona al menos un servicio.");
 }
 repo.Guardar(e);
 }
 public void Eliminar<T>(T e,IRepositorio<T> repo) where T:Entidad {
 bool usado=e switch {
 Cliente c => Datos.Vehiculos.Todos().Any(x=>x.ClienteId==c.Id) || Datos.Ordenes.Todos().Any(x=>x.ClienteId==c.Id),
 Vehiculo v => Datos.Ordenes.Todos().Any(x=>x.VehiculoId==v.Id),
 Mecanico m => Datos.Ordenes.Todos().Any(x=>x.MecanicoId==m.Id),
 Servicio s => Datos.Ordenes.Todos().Any(x=>x.Servicios.Any(d=>d.ServicioId==s.Id)),
 Refaccion r => Datos.Ordenes.Todos().Any(x=>x.Refacciones.Any(d=>d.RefaccionId==r.Id)), _=>false };
 if(usado) throw new InvalidOperationException("El registro está relacionado con otros datos y no puede eliminarse."); repo.Eliminar(e.Id);
 }
}
