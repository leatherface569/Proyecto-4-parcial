namespace Proyecto_4_parcial.Entidades
{
    public class CambioEstado
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public EstadoOrden Estado { get; set; }
    }
}
