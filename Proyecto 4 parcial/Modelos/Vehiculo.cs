namespace Proyecto_4_parcial.Modelos
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Tipo { get; set; } = "Automóvil";
        public string NumeroSerie { get; set; } = "";
        public string Placa { get; set; } = "";
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public int Anio { get; set; } = DateTime.Today.Year;
        public int Kilometraje { get; set; }
        public bool Activo { get; set; } = true;

        public Vehiculo() { }

        public Vehiculo(int id, int clienteId, string tipo, string numeroSerie,
            string placa, string marca, string modelo, int anio, int kilometraje)
        {
            Id = id;
            ClienteId = clienteId;
            Tipo = tipo;
            NumeroSerie = numeroSerie;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Kilometraje = kilometraje;
        }
    }
}
