using et12.edu.ar.AGBD.Ado;
using Fifa.AdoEt12.Mapeadores;
using Fifa.Core;
namespace Fifa.AdoEt12.Test;

public class ServicioTest
{
    private readonly IAdo _ado;
    public Servicio servicio { get; set; }

    public ServicioTest ()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        _ado = new AdoFifa(adoAGBD);
        servicio = new Servicio(_ado);
    }
    
    [Fact]
    public void AltaHabilidadNoValida()
    {
        var habilidad = new Habilidad(1, "Corredor", "Lateral Izquierdo");
        var excep = Assert.Throws<ArgumentException>(()=>servicio.AltaHabilidad(habilidad));

        habilidad.IdHabilidad = 0;
        habilidad.Nombre = string.Empty;        

        excep = Assert.Throws<ArgumentException>(()=>servicio.AltaHabilidad(habilidad));

        habilidad.Descripcion = string.Empty;

        excep = Assert.Throws<ArgumentException>(()=>servicio.AltaHabilidad(habilidad));
    }

    [Fact]
    public void AltaTransferenciaNoValida()
    {
        var LuciaMijal = servicio.ObtenerUsuarios().FirstOrDefault(u=>u.User == "LuciaMijal22");
        var IsmaJoel25 = servicio.ObtenerUsuarios().FirstOrDefault(u=>u.User == "IsmaJoel25");
        var Futbolista1 = servicio.ObtenerFutbolistas().FirstOrDefault(f=>f.IdFutbolista == 1);
        
        var trans1 = new Transferencia(LuciaMijal, IsmaJoel25, Futbolista1, DateTime.Now, null, 250);
        
        var excep = Assert.Throws<ArgumentException>(()=>servicio.AltaTransferencia(trans1));
        
        Assert.Equal("Vendedor, debe tener valor",excep.Message);
    }
}