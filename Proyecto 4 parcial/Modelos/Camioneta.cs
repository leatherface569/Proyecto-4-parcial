namespace Proyecto_4_parcial.Modelos
{
    public class Camioneta : Vehiculo
    {
        public Camioneta() { }

        public Camioneta(int id, int clienteId, string numeroSerie, string placa, string marca, string modelo, int anio, int kilometraje, decimal capacidadCarga) : base(id, clienteId, numeroSerie, placa, marca, modelo, anio, kilometraje)
        {
            CapacidadCarga = capacidadCarga;
        }

        public decimal CapacidadCarga { get; set; } = 750;
        public override string Tipo { get { return "Camioneta"; } }
        public override string Describir() { return "Camioneta de " + CapacidadCarga + " kg de carga. Revisar suspensión y neumáticos cada 5,000 km."; }
        public override void ValidarInformacion()
        {
            if (CapacidadCarga <= 0 || CapacidadCarga > 10000) throw new ArgumentException("La capacidad debe estar entre 1 y 10,000 kg.");
        }
    }
}
