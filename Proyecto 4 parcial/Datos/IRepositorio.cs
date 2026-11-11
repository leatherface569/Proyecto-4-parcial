using Proyecto_4_parcial.Modelos;
namespace Proyecto_4_parcial.Datos
{
    public interface IRepositorio<T> where T : Entidad
    {
        IReadOnlyList<T> Todos();
        void Guardar(T entidad);
        void Eliminar(int id);
    }
}
