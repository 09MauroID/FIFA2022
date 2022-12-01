using et12.edu.ar.AGBD.Ado;
using Fifa.Core;

namespace Fifa.AdoEt12.Test;

public class HabilidadTest
{
    public AdoFifa Ado { get; set; }
    public HabilidadTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }

    [Fact]
    public void AltaHabilidad()
    {
        var habilidad = new Habilidad(0, "Corredor", "Lateral Izquierdo");
        Ado.AltaHabilidad(habilidad);
        Assert.Equal(2, habilidad.IdHabilidad);
    }

    [Fact]
    public void TraerHabilidades()
    {
        var habilidad = Ado.MapHabilidad.FiltrarPorPK("idHabilidad", 1);
        if (habilidad is null)
            throw new ArgumentNullException("Habilidad es null");
        Assert.True(habilidad.IdHabilidad == 1 && habilidad.Nombre == "Muralla");
    }
}