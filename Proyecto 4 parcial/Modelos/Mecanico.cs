namespace Proyecto_4_parcial.Modelos
{
    public class Mecanico : Entidad
    {
        public Mecanico() { }

        public Mecanico(int id, string nombre, string especialidad, bool disponible) : base(id)
        {
            Nombre = nombre;
            Especialidad = especialidad;
            Disponible = disponible;
        }

        public string Nombre { get; set; } = "";
        public string Especialidad { get; set; } = "";
        public bool Disponible { get; set; } = true;
        public override string ToString() { return Nombre; }
    }
}
