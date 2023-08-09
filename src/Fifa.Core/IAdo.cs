namespace Fifa.Core;

public interface IAdo
{
    public void AltaHabilidad(Habilidad habilidad);
    Task AltaHabilidadAsync(Habilidad habilidad);
    public List<Habilidad> ObtenerHabilidades();
    public Task<List<Habilidad>> ObtenerHabilidadesAsync();
}