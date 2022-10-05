namespace Fifa.Core;

public class Skill
{
    public Habilidad Habilidad { get; set; }
    public Futbolista Futbolista { get; set; }
    public Skill(Habilidad habilidad, Futbolista futbolista)
    {
        Habilidad = habilidad;
        Futbolista = futbolista;
    }
}