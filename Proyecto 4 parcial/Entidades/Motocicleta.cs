namespace Proyecto_4_parcial.Entidades
{
    public class Motocicleta : Vehiculo
    {
        public int Cilindrada { get; set; } = 150;
        public override string Tipo { get { return "Motocicleta"; } }
        public override string Describir() { return "Motocicleta de " + Cilindrada + " cc. Revisar cadena y lubricación cada 3,000 km."; }
        public override void ValidarInformacion()
        {
            if (Cilindrada <= 0 || Cilindrada > 2500) throw new ArgumentException("La cilindrada debe estar entre 1 y 2,500 cc.");
        }
    }
}
