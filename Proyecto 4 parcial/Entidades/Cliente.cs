namespace Proyecto_4_parcial.Entidades
{
    public class Cliente : Entidad
    {
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Correo { get; set; } = "";
        public override string ToString() { return Nombre; }
    }
}
