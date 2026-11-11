namespace Proyecto_4_parcial.Modelos
{
    public class DetalleRefaccion
    {
        public DetalleRefaccion() { }

        public DetalleRefaccion(int refaccionId, int cantidad, decimal precio)
        {
            RefaccionId = refaccionId;
            Cantidad = cantidad;
            Precio = precio;
        }

        public int RefaccionId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get { return Cantidad * Precio; } }
    }
}
