namespace Proyecto_4_parcial.Entidades
{
    public class Servicio : Entidad
    {
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; } = 30;
        public override string ToString() { return Nombre + " ($" + Precio.ToString("N2") + ")"; }
    }
}
