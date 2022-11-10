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
        MapFutbolista = new MapFutbolista(adoAGBD);
        MapTransferencia = new MapTransferencia(adoAGBD);
    }
    public void AltaHabilidad(Habilidad habilidad)
        => MapHabilidad.AltaHabilidad(habilidad);

    public List<Habilidad> ObtenerHabilidades()
        => MapHabilidad.ColeccionDesdeTabla();

    public void AltaPosicion(Posicion posicion)
        => MapPosicion.AltaPosicion(posicion);

    public List<Posicion> ObtenerPosiciones()
        => MapPosicion.ColeccionDesdeTabla();

    public void AltaUsuario(Usuario usuario)
        => MapUsuario.AltaUsuario(usuario);

    public List<Usuario> obtenerUsuarios()
        => MapUsuario.ColeccionDesdeTabla();

    public void AltaFutbolista(Futbolista futbolista)
        => MapFutbolista.AltaFutbolista(futbolista);

    public List<Futbolista> obtenerFutbolistas()
        => MapFutbolista.ColeccionDesdeTabla();

    public void AltaTransferencia(Transferencia transferencia)
        => MapTransferencia.AltaTransferencia(transferencia);

    public List<Transferencia> obtenerTransferencias()
        => MapTransferencia.ColeccionDesdeTabla();

}
