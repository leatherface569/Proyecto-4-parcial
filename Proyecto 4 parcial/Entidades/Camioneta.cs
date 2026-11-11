namespace Proyecto_4_parcial.Entidades
{
    public class Camioneta : Vehiculo
    {
        public decimal CapacidadCarga { get; set; } = 750;
        public override string Tipo { get { return "Camioneta"; } }
        public override string Describir() { return "Camioneta de " + CapacidadCarga + " kg de carga. Revisar suspensión y neumáticos cada 5,000 km."; }
        public override void ValidarInformacion()
        {
            if (CapacidadCarga <= 0 || CapacidadCarga > 10000) throw new ArgumentException("La capacidad debe estar entre 1 y 10,000 kg.");
        }
    }
}
