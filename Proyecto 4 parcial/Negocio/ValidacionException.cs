namespace Proyecto_4_parcial.Negocio;

public class ValidacionException : Exception
{
    public string Campo { get; }
    public ValidacionException(string campo, string mensaje) : base(mensaje) { Campo = campo; }
}