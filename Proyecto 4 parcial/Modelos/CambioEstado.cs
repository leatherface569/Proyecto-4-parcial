namespace Proyecto_4_parcial.Modelos
{
    public class CambioEstado
    {
        public CambioEstado() { }

        public CambioEstado(DateTime fecha, EstadoOrden estado)
        {
            Fecha = fecha;
            Estado = estado;
        }

        public DateTime Fecha { get; set; } = DateTime.Now;
        public EstadoOrden Estado { get; set; }
    }
}
