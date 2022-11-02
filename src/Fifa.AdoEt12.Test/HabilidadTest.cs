using et12.edu.ar.AGBD.Ado;

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
    public void Test1()
    {
        
    }
}