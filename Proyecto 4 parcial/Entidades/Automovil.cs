namespace Proyecto_4_parcial.Entidades
{
    public class Automovil : Vehiculo
    {
        public int Puertas { get; set; } = 4;
        public override string Tipo { get { return "Automóvil"; } }
        public override string Describir() { return "Automóvil de " + Puertas + " puertas. Revisar frenos y aceite cada 10,000 km."; }
        public override void ValidarInformacion()
        {
            if (Puertas < 2 || Puertas > 5) throw new ArgumentException("El automóvil debe tener entre 2 y 5 puertas.");
        }
    }
}
