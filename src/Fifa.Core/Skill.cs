namespace Fifa.Core;

public class Skill
{
    public Futbolista Habilidad { get; set; }
    public Futbolista Futbolista { get; set; }
    public Skill(Futbolista habilidad, Futbolista futbolista)
    {
        Habilidad = habilidad;
        Futbolista = futbolista;
    }
}