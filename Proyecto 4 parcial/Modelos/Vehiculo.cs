namespace Proyecto_4_parcial.Modelos
{
    public abstract class Vehiculo : Entidad
    {
        protected Vehiculo() { }

        protected Vehiculo(int id, int clienteId, string numeroSerie, string placa, string marca, string modelo, int anio, int kilometraje) : base(id)
        {
            ClienteId = clienteId;
            NumeroSerie = numeroSerie;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Kilometraje = kilometraje;
        }

        public int ClienteId { get; set; }
        public string NumeroSerie { get; set; } = "";
        public string Placa { get; set; } = "";
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public int Anio { get; set; } = DateTime.Today.Year;
        public int Kilometraje { get; set; }
        public abstract string Tipo { get; }
        public abstract string Describir();
        public abstract void ValidarInformacion();
        public override string ToString() { return Placa + " - " + Marca + " (" + Tipo + ")"; }
    }
}
