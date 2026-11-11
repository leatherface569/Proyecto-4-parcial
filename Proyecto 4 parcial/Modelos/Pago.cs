namespace Proyecto_4_parcial.Modelos
{
    public class Pago
    {
        public Pago() { }

        public Pago(DateTime fecha, decimal importe)
        {
            Fecha = fecha;
            Importe = importe;
        }

        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Importe { get; set; }
    }
}
