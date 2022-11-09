using et12.edu.ar.AGBD.Ado;
using Fifa.Core;

namespace Fifa.AdoEt12.Test;
public class FutbolistaTest
{
    public AdoFifa Ado { get; set; }
    public FutbolistaTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }

    [Fact]
    public void AltaFutbolista()
    {
        var Futbolista = new Futbolista(2, "Carlos", "Zantana", new DateTime(1996-04-09));
        Ado.AltaFutbolista(futbolista);
        Assert.Equal(2, futbolista.IdFutbolista);
    }

    [Fact]
    public void TraerFutbolistas()
    {
        var futbolista = Ado.MapHabilidad.FiltrarPorPK("idFutbolista", 2);
        if (futbolista is null)
            throw new ArgumentNullException("Futbolista es null");
        Assert.True(futbolista.IdFutbolista == 2 && futbolista.Nombre == "Carlos");
    }
}