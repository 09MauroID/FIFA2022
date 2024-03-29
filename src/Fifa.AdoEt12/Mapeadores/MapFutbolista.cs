using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;

namespace Fifa.AdoEt12.Mapeadores;
public class MapFutbolista : Mapeador<Futbolista>
{
    public MapPosicion MapPosicion { get; set; }
    public MapUsuario MapUsuario { get; set; }
    public MapFutbolista(MapUsuario mapUsuario, MapPosicion mapPosicion) : base(mapUsuario.AdoAGBD)

    {
        Tabla = "Futbolista";
        MapUsuario = mapUsuario;
        MapPosicion = mapPosicion;
    }
    public override Futbolista ObjetoDesdeFila(DataRow fila)
        => new Futbolista
        (
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
    public void AltaFutbolista(Futbolista futbolista)
        => EjecutarComandoCon("altaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);
    internal async Task AltaFutbolistaAsync(Futbolista futbolista)
    {
        await EjecutarComandoAsync("altaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);
    }
    public void ConfigurarAltaFutbolista(Futbolista futbolista)
    {
        SetComandoSP("altaFutbolista");

        BP.CrearParametroSalida("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unIdPosicion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(futbolista.Posicion.IdPosicion)
            .AgregarParametro();

        BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(futbolista.Nombre)
            .AgregarParametro();

        BP.CrearParametro("unApellido")
            .SetTipoVarchar(45)
            .SetValor(futbolista.Apellido)
            .AgregarParametro();

        BP.CrearParametro("unNacimiento")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Date)
            .SetValor(futbolista.Nacimiento)
            .AgregarParametro();

        BP.CrearParametro("unaVelocidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.Velocidad)
            .AgregarParametro();

        BP.CrearParametro("unRemate")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.Remate)
            .AgregarParametro();

        BP.CrearParametro("unPase")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.Pase)
            .AgregarParametro();

        BP.CrearParametro("unaDefensa")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(futbolista.Defensa)
            .AgregarParametro();

    }
    public void PostAltaFutbolista(Futbolista futbolista)
    {
        var paramIdFutbolista = GetParametro("unIdFutbolista");
        futbolista.IdFutbolista = Convert.ToInt32(paramIdFutbolista.Value);
    }
    public Futbolista FutbolistaPorId(int id)
    {
        SetComandoSP("FutbolistaPorId");

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(id)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Futbolista> ObtenerFutbolistas() => ColeccionDesdeTabla();
    public List<Futbolista> FutbolistasDe(Usuario usuario)
    {
        /* Paso 1; saber que futbolistas posee el usuario, esa informacion
        la tiene la Tabla Propietario, pero de todas sus filas, solo me
        interesa las de un determinado idUsuario  */
        var tablaPropietario = FilasFiltradasRAW("idUsuario", usuario.IdUsuario, "Propietario");
        var futbolistas = new List<Futbolista>();

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