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
        var posicion = new Posicion(1, "Defensa");
        Ado.AltaPosicion(posicion);
        Assert.Equal(3, posicion.IdPosicion);
    }

    [Fact]
    public void TraerPosiciones()
    {
        var posicion = Ado.MapPosicion.FiltrarPorPK("idPosicion", 3);
        if (posicion is null)
            throw new ArgumentNullException("Posicion es null");
        Assert.True(posicion.IdPosicion == 3 && posicion.Nombre == "Defensa");
    }
}