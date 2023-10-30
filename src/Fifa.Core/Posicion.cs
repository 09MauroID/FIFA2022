using System.Diagnostics.CodeAnalysis;

namespace Fifa.Core;

public class Posicion
{
    public byte IdPosicion { get; set; }
    public required string Nombre { get; set; }
    [SetsRequiredMembers]
    public Posicion(byte idPosicion, string nombre)
    {
        IdPosicion = idPosicion;
        Nombre = nombre;
    }
    public Posicion() { }
}