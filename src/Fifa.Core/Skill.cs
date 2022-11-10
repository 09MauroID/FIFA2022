namespace Fifa.Core;

public class Skill
{
    public Habilidad Habilidad { get; set; }
    public Habilidad Futbolista { get; set; }
    public Skill(Habilidad habilidad, Habilidad futbolista)
    {
        Habilidad = habilidad;
        Futbolista = futbolista;
    }
}