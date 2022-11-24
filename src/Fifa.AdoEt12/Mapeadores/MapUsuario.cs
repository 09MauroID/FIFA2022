using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;

namespace Fifa.AdoEt12.Mapeadores
{
    public class MapUsuario : Mapeador<Usuario>
    {
        public MapUsuario(AdoAGBD ado) : base(ado)
        {
            Tabla = "Usuario";
        }
        public override Usuario ObjetoDesdeFila(DataRow fila)
            => new Usuario
            (
                idUsuario: Convert.ToByte(fila["idUsuario"]),
                user: fila["user"].ToString(),
                contrasena: fila["contrasena"].ToString(),
                nombre: fila["nombre"].ToString(),
                apellido: fila["apellido"].ToString(),
                monedas: Convert.ToInt32(fila["monedas"])
            );

        public void AltaUsuario(Usuario usuario)
            => EjecutarComandoCon("altaUsuario", ConfigurarAltaUsuario, PostAltaUsuario, usuario);

        public void ConfigurarAltaUsuario(Usuario usuario)
        {
            SetComandoSP("altaUsuario");

            BP.CrearParametroSalida("unIdUsuario")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

            BP.CrearParametro("unUser")
            .SetValor(usuario.User)
            .SetTipoVarchar(15)
            .AgregarParametro();

            BP.CrearParametro("unaContrasena")
            .SetValor(usuario.Contrasena)
            .SetTipoChar(64)
            .AgregarParametro();

            BP.CrearParametro("unNombre")
            .SetValor(usuario.Nombre)
            .SetTipoVarchar(45)
            .AgregarParametro();

            BP.CrearParametro("unApellido")
            .SetValor(usuario.Apellido)
            .SetTipoVarchar(45)
            .AgregarParametro();

            BP.CrearParametro("unaMonedas")
            .SetValor(usuario.Monedas)
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();
        }

        public void PostAltaUsuario(Usuario usuario)
        {
            var paramIdUsuario = GetParametro("unIdUsuario");
            usuario.IdUsuario = Convert.ToInt32(paramIdUsuario.Value);
        }

        public Usuario UsuarioPorIdUsuario(int IdUsuario)
        {
            SetComandoSP("UsuarioPorIdUsuario");

            BP.CrearParametro("unIdUsuario")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(IdUsuario)
            .AgregarParametro();

            return ElementoDesdeSP();
        }
        public List<Usuario> ObtenerUsuarios() => ColeccionDesdeTabla();
    }
}
