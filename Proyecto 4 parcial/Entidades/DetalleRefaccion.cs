namespace Proyecto_4_parcial.Entidades
{
    public class DetalleRefaccion
    {
        public int RefaccionId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get { return Cantidad * Precio; } }
    }
}
