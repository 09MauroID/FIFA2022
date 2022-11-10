using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;

namespace Fifa.AdoEt12.Mapeadores;
public class MapFutbolista : Mapeador<Habilidad>
{
    public MapPosicion MapPosicion { get; set; }
    public MapUsuario MapUsuario { get; set; }
    public MapFutbolista(MapPosicion mapPosicion) : base(mapPosicion.AdoAGBD) { }
    public MapFutbolista(MapUsuario mapUsuario) : base(mapUsuario.AdoAGBD)
    {
        Tabla = "Futbolista";
        MapUsuario = mapUsuario;
    }
    public override Habilidad ObjetoDesdeFila(DataRow fila)
        => new Habilidad
        (
            idUsuario: Convert.ToInt32(fila["idFutbolista"]),
            idFutbolista: Convert.ToInt32(fila["idFutbolista"]),
            nombre: fila["nombre"].ToString(),
            apellido: fila["apellido"].ToString(),
            nacimiento: Convert.ToDateTime(fila["nacimiento"]),
            velocidad: Convert.ToByte(fila["velocidad"]),
            remate: Convert.ToByte(fila["remate"]),
            pase: Convert.ToByte(fila["pase"]),
            defensa: Convert.ToByte(fila["defensa"]),

            posicion: MapPosicion.FiltrarPorPK("idPosicion", fila["idPosicion"])
        );
    public void AltaFutbolista(Habilidad futbolista)
        => EjecutarComandoCon("altaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);

    public void ConfigurarAltaFutbolista(Habilidad futbolista)
    {
        SetComandoSP("altaFutbolista");

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .AgregarParametro();

        BP.CrearParametro("unApellido")
            .SetTipoVarchar(45)
            .AgregarParametro();

        BP.CrearParametro("unNacimiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Date)
            .AgregarParametro();

        BP.CrearParametro("unVelocidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();

        BP.CrearParametro("unRemate")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();

        BP.CrearParametro("unPase")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();

        BP.CrearParametro("unDefensa")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();

    }
    public void PostAltaFutbolista(Habilidad futbolista)
    {
        var paramIdFutbolista = GetParametro("unIdFutbolista");
        futbolista.IdFutbolista = Convert.ToInt32(paramIdFutbolista.Value);
    }
    public Habilidad FutbolistaPorId(int id)
    {
        SetComandoSP("FutbolistaPorId");

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(id)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Habilidad> ObtenerFutbolistas() => ColeccionDesdeTabla();
    public List<Habilidad> FutbolistasDe(Usuario usuario)
    {
        /* Paso 1; saber que futbolistas posee el usuario, esa informacion
        la tiene la Tabla Propietario, pero de todas sus filas, solo me
        interesa las de un determinado idUsuario  */
        var tablaPropietario = FilasFiltradasRAW("idUsuario", usuario.IdUsuario, "Propietario");
        var futbolistas = new List<Habilidad>();

        /*Paso 2: Recorrer las filas de la tabla devuelta, quedarme con el idFutbolista de cada fila
        devuelta y usarlo para FiltrarPorPK
        */
        for (int i = 0; i < tablaPropietario.Rows.Count; i++)
        {
            var idFutbolista = Convert.ToInt32(tablaPropietario.Rows[i]["idFutbolista"]);
            futbolistas.Add(FiltrarPorPK("idFutbolista", idFutbolista)!);
        }

        //Devuelvo la lista que cree y complete.
        return futbolistas;
    }
}