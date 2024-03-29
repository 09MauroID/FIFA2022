namespace Fifa.Core;

public class Futbolista
{
    public int IdFutbolista { get; set; }
    public Posicion Posicion { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime Nacimiento { get; set; }
    public byte Velocidad { get; set; }
    public byte Remate { get; set; }
    public byte Pase { get; set; }
    public byte Defensa { get; set; }
    public Futbolista(int idFutbolista, Posicion posicion, string nombre, string apellido, DateTime nacimiento, byte velocidad, byte remate, byte pase, byte defensa)
    {
        IdFutbolista = idFutbolista;
        Nombre = nombre;
        Apellido = apellido;
        Nacimiento = nacimiento;
        Velocidad = velocidad;
        Remate = remate;
        Pase = pase;
        Defensa = defensa;
        Posicion = posicion;
    }
}