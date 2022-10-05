namespace Fifa.Core;

public class Propietario
{
    public Usuario Usuario { get; set; }
    public Futbolista Futbolista { get; set; }
    public Propietario(Usuario usuario, Futbolista futbolista)
    {
        Usuario = usuario;
        Futbolista = futbolista;
    }
}