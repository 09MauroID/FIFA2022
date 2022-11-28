using et12.edu.ar.AGBD.Ado;
using Fifa.Core;

namespace Fifa.AdoEt12.Test;

public class PosicionTest
{
    public AdoFifa Ado { get; set; }
    public PosicionTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }

    [Fact]
    public void AltaPosicion()
    {
        var posicion = new Posicion(4, "Arquero");
        Ado.AltaPosicion(posicion);
        Assert.Equal(4, posicion.IdPosicion);
    }

    [Fact]
    public void TraerPosiciones()
    {
        var posicion = Ado.MapPosicion.FiltrarPorPK("idPosicion", 1);
        if (posicion is null)
            throw new ArgumentNullException("Posicion es null");
        Assert.True(posicion.IdPosicion == 1 && posicion.Nombre == "Defensa");
    }
}