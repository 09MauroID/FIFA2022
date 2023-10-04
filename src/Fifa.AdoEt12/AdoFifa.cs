using et12.edu.ar.AGBD.Ado;
using Fifa.AdoEt12.Mapeadores;
using Fifa.Core;

namespace Fifa.AdoEt12;
public class AdoFifa : IAdo
{
    public AdoAGBD AdoAGBD { get; set; }
    public MapHabilidad MapHabilidad { get; set; }
    public MapPosicion MapPosicion { get; set; }
    public MapUsuario MapUsuario { get; set; }
    public MapFutbolista MapFutbolista { get; set; }
    public MapTransferencia MapTransferencia { get; set; }
    public AdoFifa(AdoAGBD adoAGBD)
    {
        AdoAGBD = adoAGBD;
        MapHabilidad = new MapHabilidad(adoAGBD);
        MapPosicion = new MapPosicion(adoAGBD);
        MapUsuario = new MapUsuario(adoAGBD);
        MapFutbolista = new MapFutbolista(MapUsuario, MapPosicion);
        MapTransferencia = new MapTransferencia(MapUsuario, MapFutbolista);
    }
    public void AltaHabilidad(Habilidad habilidad)
        => MapHabilidad.AltaHabilidad(habilidad);

    public async Task AltaHabilidadAsync(Habilidad habilidad)
    {
        await MapHabilidad.AltaHabilidadAsync(habilidad);
    }

    public List<Habilidad> ObtenerHabilidades()
        => MapHabilidad.ColeccionDesdeTabla();

    public Task<List<Habilidad>> ObtenerHabilidadesAsync()
        => MapHabilidad.ColeccionDesdeTablaAsync();

    public void AltaPosicion(Posicion posicion)
        => MapPosicion.AltaPosicion(posicion);
    public async Task AltaPosicionAsync(Posicion posicion)
    {
        await MapPosicion.AltaPosicionAsync(posicion);
    }

    public List<Posicion> ObtenerPosiciones()
        => MapPosicion.ColeccionDesdeTabla();
    public Task<List<Posicion>> ObtenerPosicionesAsync()
        => MapPosicion.ColeccionDesdeTablaAsync();

    public void AltaUsuario(Usuario usuario)
        => MapUsuario.AltaUsuario(usuario);
    public async Task AltaUsuarioAsync(Usuario usuario)
    {
        await MapUsuario.AltaUsuarioAsync(usuario);
    }
    public List<Usuario> ObtenerUsuarios()
        => MapUsuario.ColeccionDesdeTabla();

    public Task<List<Usuario>> ObtenerUsuariosAsync()
        => MapUsuario.ColeccionDesdeTablaAsync();

    public void AltaFutbolista(Futbolista futbolista)
        => MapFutbolista.AltaFutbolista(futbolista);

    public async Task AltaFutbolistaAsync(Futbolista futbolista)
    {
        await MapFutbolista.AltaFutbolistaAsync(futbolista);
    }

    public List<Futbolista> ObtenerFutbolistas()
        => MapFutbolista.ColeccionDesdeTabla();

    public Task<List<Futbolista>> ObtenerFutbolistasAsync()
        => MapFutbolista.ColeccionDesdeTablaAsync();

    public void AltaTransferencia(Transferencia transferencia)
        => MapTransferencia.Publicar(transferencia);

    public async Task AltaTransferenciaAsync(Transferencia transferencia)
        => await MapTransferencia.PublicarAsync(transferencia);

    public List<Transferencia> TransferenciasActivas()
        => MapTransferencia.ColeccionDesdeSP();
}
