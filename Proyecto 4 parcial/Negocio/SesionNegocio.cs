namespace Proyecto_4_parcial.Negocio
{
    public class SesionNegocio
    {
        public string Perfil { get; private set; } = "";
        public bool Iniciar(string usuario, string clave)
        {
            if (usuario == "admin" && clave == "demo123") Perfil = "Administrador";
            else if (usuario == "consulta" && clave == "demo123") Perfil = "Consulta";
            else return false;
            return true;
        }
    }
}
