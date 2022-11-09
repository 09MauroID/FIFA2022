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
        var usuario = new Usuarios(0, "Muralla", "Ultima defensa");
        Ado.AltaUsuario(usuario);
        Assert.Equal(5, usuario.IdUsuario);
    }

    [Fact]
    public void TraerUsuarios()
    {
        var usuario = Ado.MapUsuario.FiltrarPorPK("idUsuario", 4);
        if (usuario is null)
            throw new ArgumentNullException("Usuario es null");
        Assert.True(usuario.IdUsuario == 4 && usuario.Nombre == "Muralla");
    }
}