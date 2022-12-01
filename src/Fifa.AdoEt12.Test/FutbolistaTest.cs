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
        var defensa = Ado.MapPosicion.FiltrarPorPK("idposicion", 1);
        if (defensa is null)
            throw new Exception("No hay defensas");
        var futbolista = new Futbolista(
            idFutbolista: 0, posicion: defensa, nombre: "Kun", apellido: "Aguero", nacimiento: new DateTime(1998, 4, 9), velocidad: 70, remate: 90, pase: 60, defensa: 99);
        Ado.AltaFutbolista(futbolista);
        Assert.Equal(3, futbolista.IdFutbolista);
    }

    [Fact]
    public void TraerFutbolistas()
    {
        var futbolista = Ado.MapFutbolista.FiltrarPorPK("idFutbolista", 2);
        if (futbolista is null)
            throw new ArgumentNullException("Futbolista es null");
        Assert.True(futbolista.IdFutbolista == 2 && futbolista.Nombre == "Leo");
    }
}