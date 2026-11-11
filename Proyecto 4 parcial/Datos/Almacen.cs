using Proyecto_4_parcial.Modelos;
namespace Proyecto_4_parcial.Datos
{
    public class Almacen
    {
        public IRepositorio<Cliente> Clientes { get; } = new RepositorioMemoria<Cliente>();
        public IRepositorio<Vehiculo> Vehiculos { get; } = new RepositorioMemoria<Vehiculo>();
        public IRepositorio<Mecanico> Mecanicos { get; } = new RepositorioMemoria<Mecanico>();
        public IRepositorio<Servicio> Servicios { get; } = new RepositorioMemoria<Servicio>();
        public IRepositorio<Categoria> Categorias { get; } = new RepositorioMemoria<Categoria>();
        public IRepositorio<Refaccion> Refacciones { get; } = new RepositorioMemoria<Refaccion>();
        public IRepositorio<OrdenServicio> Ordenes { get; } = new RepositorioMemoria<OrdenServicio>();
        public IRepositorio<MovimientoInventario> Movimientos { get; } = new RepositorioMemoria<MovimientoInventario>();
    }
}
