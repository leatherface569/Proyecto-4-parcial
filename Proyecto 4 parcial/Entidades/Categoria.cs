namespace Proyecto_4_parcial.Entidades
{
    public class Categoria : Entidad
    {
        public string Nombre { get; set; } = "";
        public override string ToString() { return Nombre; }
    }
}
