using Proyecto_4_parcial.Entidades;
namespace Proyecto_4_parcial.Datos
{
    // Datos temporales: se pierden al cerrar la aplicación.
    public class RepositorioMemoria<T> : IRepositorio<T> where T : Entidad
    {
        private List<T> datos = new List<T>();
        private int siguienteId = 1;
        public IReadOnlyList<T> Todos()
        {
            return datos.Where(d => d.Activo).ToList().AsReadOnly();
        }
        public void Guardar(T entidad)
        {
            if (entidad.Id == 0)
            {
                entidad.Id = siguienteId++;
                datos.Add(entidad);
            }
            else
            {
                int posicion = datos.FindIndex(d => d.Id == entidad.Id);
                if (posicion < 0) throw new InvalidOperationException("Registro inexistente.");
                datos[posicion] = entidad;
            }
        }
        public void Eliminar(int id)
        {
            T entidad = datos.First(d => d.Id == id);
            entidad.Activo = false;
        }
    }
}
