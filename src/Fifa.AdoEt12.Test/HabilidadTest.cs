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
        var habilidad = new Habilidad("");
    }
}