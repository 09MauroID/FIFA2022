namespace Fifa.Core;

public class Futbolista
{
    public Usuario Usuario { get; set; }
    public int IdFutbolista { get; set; }
    public Posicion Posicion { get; set; }
    public Habilidad Habilidad { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime Nacimiento { get; set; }
    public byte Velocidad { get; set; }
    public byte Remate { get; set; }
    public byte Pase { get; set; }
    public byte Defensa { get; set; }
    public Futbolista(Usuario usuario, int idFutbolista, Posicion posicion, Habilidad habilidad, string nombre, string apellido, DateTime nacimiento, byte velocidad, byte remate, byte pase, byte defensa)
    {
        IdFutbolista = idFutbolista;
        Nombre = nombre;
        Apellido = apellido;
        Nacimiento = nacimiento;
        Velocidad = velocidad;
        Remate = remate;
        Pase = pase;
        Defensa = defensa;
        Usuario = usuario;
        Habilidad = habilidad;
        Posicion = posicion;
    }
}