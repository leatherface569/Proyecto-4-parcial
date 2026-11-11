namespace Proyecto_4_parcial.Modelos
{
    public class Categoria : Entidad
    {
        public Categoria() { }

        public Categoria(int id, string nombre) : base(id)
        {
            Nombre = nombre;
        }

        public string Nombre { get; set; } = "";
        public override string ToString() { return Nombre; }
    }
}
