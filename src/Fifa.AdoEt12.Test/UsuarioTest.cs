using et12.edu.ar.AGBD.Ado;
using Fifa.Core;

namespace Fifa.AdoEt12.Test;

public class UsuarioTest
{
    public AdoFifa Ado { get; set; }
    public UsuarioTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
    }
    
    [Fact]
    public void AltaUsuario()
    {
        var usuario = new Usuario( 0, "Serafin", "02345678", "Melisa", "Soledad", 1000);
        Ado.AltaUsuario(usuario);
        Assert.Equal(0, usuario.IdUsuario);
    }
    
    [Fact]
    public void TraerUsuarios()
    {
        var usuario = Ado.MapUsuario.FiltrarPorPK("idUsuario", 0);
        if (usuario is null)
            throw new ArgumentNullException("Usuario es null");
        Assert.True(usuario.IdUsuario == 0 && usuario.Nombre == "Serafin");
    }
}