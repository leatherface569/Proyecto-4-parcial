namespace Proyecto_4_parcial.Entidades
{
    public class Refaccion : Entidad
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public decimal ValorInventario { get { return Stock * Precio; } }
        public string EstadoInventario { get { return Stock <= StockMinimo ? "Stock bajo" : "Disponible"; } }
        public override string ToString() { return Nombre + " ($" + Precio.ToString("N2") + ")"; }
    }
}
