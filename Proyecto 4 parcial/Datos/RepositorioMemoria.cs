using Proyecto_4_parcial.Entidades;
namespace Proyecto_4_parcial.Datos;
// Sustituir por repositorios EF Core + SQLite en la siguiente entrega.
public interface IRepositorio<T> where T : Entidad { IReadOnlyList<T> Todos(); void Guardar(T entidad); void Eliminar(int id); }
public class RepositorioMemoria<T> : IRepositorio<T> where T : Entidad {
 private readonly List<T> datos = new(); private int siguiente = 1;
 public IReadOnlyList<T> Todos() => datos.AsReadOnly();
 public void Guardar(T entidad) { if(entidad.Id == 0) { entidad.Id = siguiente++; datos.Add(entidad); } else { int i=datos.FindIndex(x=>x.Id==entidad.Id); if(i<0) throw new InvalidOperationException("Registro inexistente."); datos[i]=entidad; } }
 public void Eliminar(int id) => datos.RemoveAll(x => x.Id == id);
}
public class Almacen {
 public IRepositorio<Cliente> Clientes { get; } = new RepositorioMemoria<Cliente>();
 public IRepositorio<Vehiculo> Vehiculos { get; } = new RepositorioMemoria<Vehiculo>();
 public IRepositorio<Mecanico> Mecanicos { get; } = new RepositorioMemoria<Mecanico>();
 public IRepositorio<Servicio> Servicios { get; } = new RepositorioMemoria<Servicio>();
 public IRepositorio<Refaccion> Refacciones { get; } = new RepositorioMemoria<Refaccion>();
 public IRepositorio<OrdenServicio> Ordenes { get; } = new RepositorioMemoria<OrdenServicio>();
}