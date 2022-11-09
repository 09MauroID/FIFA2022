namespace Fifa.Core;

public interface IAdo
{
    public void AltaHabilidad (Futbolista habilidad);
    public List<Futbolista> ObtenerHabilidades();
}