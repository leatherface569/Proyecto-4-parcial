namespace Proyecto_4_parcial.Modelos
{
    public class MovimientoInventario : Entidad
    {
        public MovimientoInventario() { }

        public MovimientoInventario(int id, int refaccionId, int cantidad, DateTime fecha, string motivo) : base(id)
        {
            RefaccionId = refaccionId;
            Cantidad = cantidad;
            Fecha = fecha;
            Motivo = motivo;
        }

        public int RefaccionId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Motivo { get; set; } = "";
    }
}
