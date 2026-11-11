namespace Proyecto_4_parcial.Modelos
{
    public abstract class Entidad
    {
        protected Entidad() { }

        protected Entidad(int id, bool activo = true)
        {
            Id = id;
            Activo = activo;
        }

        public int Id { get; set; }
        public bool Activo { get; set; } = true;
    }
}
