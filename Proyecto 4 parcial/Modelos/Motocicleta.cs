namespace Proyecto_4_parcial.Modelos
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta() { }

        public Motocicleta(int id, int clienteId, string numeroSerie, string placa, string marca, string modelo, int anio, int kilometraje, int cilindrada) : base(id, clienteId, numeroSerie, placa, marca, modelo, anio, kilometraje)
        {
            Cilindrada = cilindrada;
        }

        public int Cilindrada { get; set; } = 150;
        public override string Tipo { get { return "Motocicleta"; } }
        public override string Describir() { return "Motocicleta de " + Cilindrada + " cc. Revisar cadena y lubricación cada 3,000 km."; }
        public override void ValidarInformacion()
        {
            if (Cilindrada <= 0 || Cilindrada > 2500) throw new ArgumentException("La cilindrada debe estar entre 1 y 2,500 cc.");
        }
    }
}
