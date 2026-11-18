namespace Proyecto_4_parcial.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Correo { get; set; } = "";
        public bool Activo { get; set; } = true;

        public Cliente() { }
        public Cliente(int id, string nombre, string telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }
        public override string ToString() { return Nombre; }
    }
}
