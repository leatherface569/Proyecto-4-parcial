namespace Proyecto_4_parcial.Modelos
{
    public class Cliente : Entidad
    {
        public Cliente() { }

        public Cliente(int id, string nombre, string telefono, string correo) : base(id)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }

        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Correo { get; set; } = "";
        public override string ToString() { return Nombre; }
    }
}
