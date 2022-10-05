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
    public int Velocidad { get; set; }
    public int Remate { get; set; }
    public int Pase { get; set; }
    public int Defensa { get; set; }
    public Futbolista(Usuario usuario, int idFutbolista, Posicion posicion, Habilidad habilidad, string nombre, string apellido, DateTime nacimiento, int velocidad, int remate, int pase, int defensa)
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