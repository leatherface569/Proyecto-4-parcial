namespace Proyecto_4_parcial.Modelos
{
    public class Automovil : Vehiculo
    {
        public Automovil() 
        { 
        
        }

        public Automovil(int id, int clienteId, string numeroSerie, string placa, string marca, string modelo, int anio, int kilometraje, int puertas) : base(id, clienteId, numeroSerie, placa, marca, modelo, anio, kilometraje)
        {
            Puertas = puertas;
        }

        public int Puertas { get; set; } = 4;
        public override string Tipo { get { return "Automóvil"; } }
        public override string Describir() { return "Automóvil de " + Puertas + " puertas. Revisar frenos y aceite cada 10,000 km."; }
        public override void ValidarInformacion()
        {
            if (Puertas < 2 || Puertas > 5) throw new ArgumentException("El automóvil debe tener entre 2 y 5 puertas.");
        }
    }
}
