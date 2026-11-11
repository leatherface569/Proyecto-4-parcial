namespace Proyecto_4_parcial.Entidades
{
    public class Mecanico : Entidad
    {
        public string Nombre { get; set; } = "";
        public string Especialidad { get; set; } = "";
        public bool Disponible { get; set; } = true;
        public override string ToString() { return Nombre; }
    }
}
