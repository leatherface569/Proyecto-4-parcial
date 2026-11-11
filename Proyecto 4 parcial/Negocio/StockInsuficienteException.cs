namespace Proyecto_4_parcial.Negocio
{
    public class StockInsuficienteException : Exception
    {
        public StockInsuficienteException() : base("No hay suficientes refacciones en inventario.") { }
    }
}
