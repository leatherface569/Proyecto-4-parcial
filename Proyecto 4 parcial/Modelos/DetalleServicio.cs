namespace Proyecto_4_parcial.Modelos
{
    public class DetalleServicio
    {
        public DetalleServicio() { }

        public DetalleServicio(int servicioId, decimal precio)
        {
            ServicioId = servicioId;
            Precio = precio;
        }

        public int ServicioId { get; set; }
        public decimal Precio { get; set; }
    }
}
