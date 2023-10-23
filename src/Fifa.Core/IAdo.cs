namespace Fifa.Core;

public interface IAdo
{
    public void AltaHabilidad(Habilidad habilidad);
    Task AltaHabilidadAsync(Habilidad habilidad);
    public List<Habilidad> ObtenerHabilidades();
    public Task<List<Habilidad>> ObtenerHabilidadesAsync();
    public void AltaPosicion(Posicion posicion);
    Task AltaPosicionAsync(Posicion posicion);
    public List<Posicion> ObtenerPosiciones();
    public Task<List<Posicion>> ObtenerPosicionesAsync();
    public void AltaUsuario(Usuario usuario);
    Task AltaUsuarioAsync(Usuario Usuario);
    public List<Usuario> ObtenerUsuarios();
    public Task<List<Usuario>> ObtenerUsuariosAsync();
    public void AltaFutbolista(Futbolista futbolista);
    Task AltaFutbolistaAsync(Futbolista futbolista);
    public List<Futbolista> ObtenerFutbolistas();
    public Task<List<Futbolista>> ObtenerFutbolistasAsync();
    public void AltaTransferencia(Transferencia transferencia);
    Task AltaTransferenciaAsync(Transferencia transferencia);
    public List<Transferencia> TransferenciasActivas();


}