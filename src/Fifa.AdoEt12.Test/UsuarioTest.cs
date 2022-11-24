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
        var usuario = new Usuario(7, "Serafina", "0234567", "Soledaad", "Sola", 1000);
        Ado.AltaUsuario(usuario);
        Assert.Equal(7, usuario.IdUsuario);
    }

    [Fact]
    public void TraerUsuarios()
    {
        var usuario = Ado.MapUsuario.FiltrarPorPK("idUsuario", 1);
        if (usuario is null)
            throw new ArgumentNullException("Usuario es null");

        Assert.Equal(1, usuario.IdUsuario);
        Assert.Equal("LuciaMijal22", usuario.User);
    }
}