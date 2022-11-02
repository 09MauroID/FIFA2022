using et12.edu.ar.AGBD.Ado;
using Fifa.AdoEt12.Mapeadores;
using Fifa.Core;

namespace Fifa.AdoEt12;
public class AdoFifa : IAdo
{
    public AdoAGBD AdoAGBD { get; set; }
    public MapHabilidad MapHabilidad { get; set; }
    public AdoFifa(AdoAGBD adoAGBD)
    {
        AdoAGBD = adoAGBD;
        MapHabilidad = new MapHabilidad(adoAGBD);
    }
    public void AltaHabilidad(Habilidad habilidad)
        => MapHabilidad.AltaHabilidad(habilidad);

    public List<Habilidad> ObtenerHabilidades()
        => MapHabilidad.ColeccionDesdeTabla();
}
