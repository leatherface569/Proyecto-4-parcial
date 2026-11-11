namespace Proyecto_4_parcial.Modelos
{
    public class Servicio : Entidad
    {
        public Servicio() { }

        public Servicio(int id, string nombre, string descripcion, decimal precio, int duracionMinutos) : base(id)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            DuracionMinutos = duracionMinutos;
        }

        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; } = 30;
        public override string ToString() { return Nombre + " ($" + Precio.ToString("N2") + ")"; }
    }
}
