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
        var usuario = new Usuario(5, "IsmaJoel25", 12345679, "Guemes", "Rosarino", 1000
        );
        Ado.AltaUsuario(usuario);
        Assert.Equal(5, usuario.IdUsuario);
    }

    [Fact]
    public void TraerUsuarios()
    {
        var usuario = Ado.MapUsuario.FiltrarPorPK("idUsuario", 5);
        if (usuario is null)
            throw new ArgumentNullException("Usuario es null");
        Assert.True(usuario.IdUsuario == 4 && usuario.Nombre == "IsmaJoel25");
    }
}