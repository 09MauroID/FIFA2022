namespace Fifa.Core;

public interface IAdo
{
    public void AltaHabilidad(Habilidad habilidad);
    Task AltaHabilidadAsync(Habilidad habilidad);
    public List<Habilidad> ObtenerHabilidades();
    public Task<List<Habilidad>> ObtenerHabilidadesAsync();
    public void AltaTransferencia(Transferencia transferencia);
    Task AltaTransferenciaAsync(Transferencia transferencia);
    public List<Usuario> ObtenerUsuarios();
    public void ObtenerPosiciones(Posicion posicion);
    public Task<List<Posicion>> ObtenerPosicionesASync();
    public void ObtenerFutbolistas(Futbolista futbolista);
    public Task<List<Futbolista>> ObtenerFutbolistasAync();
    public void AltaUsuario(Usuario usuario);
    Task AltaUsuarioAsync(Usuario Usuario);
    public void AltaFutbolista(Futbolista futbolista);
    Task AltaFutbolistaAsync(Futbolista futbolista);
    public List<Posicion> ObtenerPosiciones();
    public Task<List<Posicion>> ObtenerPosicionesAsync();
    public List<Transferencia> TransferenciasActivas();

}