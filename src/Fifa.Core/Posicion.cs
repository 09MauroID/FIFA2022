namespace Fifa.Core;

public class Posicion
{
    public byte IdPosicion { get; set; }
    public string Nombre { get; set; }
    public Posicion(byte idPosicion, string nombre)
    {
        IdPosicion = idPosicion;
        Nombre = nombre;
    }
}