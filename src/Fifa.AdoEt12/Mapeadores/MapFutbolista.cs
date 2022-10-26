using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;

namespace Fifa.AdoEt12.Mapeadores;
public class MapFutbolista : Mapeador<Futbolista>
{
    public MapFutbolista(AdoAGBD ado):base(ado) 
    {
        Tabla = "Futbolista";
    }
    public override Futbolista ObjetoDesdeFila(DataRow fila) 
        => new Futbolista()
    {
        IdFutbolista = Convert.ToInt32(fila["idFutbolista"]),
        Nombre = fila["nombre"].ToString(),
        Apellido = fila["apellido"].ToString(),
        Nacimiento = Convert.ToDateTime(fila["nacimiento"]),
        Velocidad = Convert.ToByte(fila["velocidad"]),
        Remate = Convert.ToByte(fila["remate"]),
        Pase = Convert.ToByte(fila["pase"]),
        Defensa = Convert.ToByte(fila["defensa"])
    };
    public void AltaFutbolista(Futbolista futbolista)
        => EjecutarComandoCon("altaFutbolista", ConfigurarAltaFutbolista, PostAltaFutbolista, futbolista);
    
    public void ConfigurarAltaFutbolista(Futbolista futbolista)
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
}