namespace Fifa.Core;

public class Propietario
{
    public Usuario Usuario { get; set; }
    public Habilidad Futbolista { get; set; }
    public Propietario(Usuario usuario, Habilidad futbolista)
    {
        Usuario = usuario;
        Futbolista = futbolista;
    }
}