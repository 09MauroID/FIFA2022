using et12.edu.ar.AGBD.Ado;
using Fifa.AdoEt12.Mapeadores;
using Fifa.Core;
namespace Fifa.AdoEt12.Test;

public class ServicioTest
{
    private readonly IAdo _ado;
    public Servicio prueba { get; set; }
    public ServicioTest () => prueba = new Servicio(_ado);
    
    [Fact]
    public void AltaHabilidadAsync()
    {
        var habilidad = new Habilidad(0, "Corredor", "Lateral Izquierdo");
        prueba.AltaHabilidad(habilidad);
        Assert.Equal(0, habilidad.IdHabilidad);
    }
}