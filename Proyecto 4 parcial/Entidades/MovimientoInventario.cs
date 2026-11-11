namespace Proyecto_4_parcial.Entidades
{
    public class MovimientoInventario : Entidad
    {
        public int RefaccionId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Motivo { get; set; } = "";
    }
}
