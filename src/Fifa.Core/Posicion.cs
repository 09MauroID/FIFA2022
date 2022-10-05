namespace Fifa.Core;

public class Posicion
{
    public int IdPosicion { get; set; }
    public string Nombre { get; set; }
    public Posicion(int idPosicion, string nombre)
    {
        IdPosicion = idPosicion;
        Nombre = nombre;
    }
}