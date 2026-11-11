namespace Proyecto_4_parcial.Negocio
{
    public class EstadoOrdenException : Exception
    {
        public EstadoOrdenException() : base("La operación no está permitida en el estado actual de la orden.") { }
    }
}
