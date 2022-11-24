using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;

namespace Fifa.AdoEt12.Mapeadores;
public class MapPosicion : Mapeador<Posicion>
{
    public MapPosicion(AdoAGBD ado) : base(ado)
    {
        Tabla = "Posicion";
    }
    public override Posicion ObjetoDesdeFila(DataRow fila)
        => new Posicion
        (
            idPosicion: Convert.ToByte(fila["idPosicion"]),
            nombre: fila["nombre"].ToString()
        )
        {

            Nombre = fila["posicion"].ToString()
        };
    public void AltaPosicion(Posicion posicion)
        => EjecutarComandoCon("altaPosicion", ConfigurarAltaPosicion, PostAltaPosicion, posicion);
    public void ConfigurarAltaPosicion(Posicion posicion)
    {
        SetComandoSP("altaPosicion");

        BP.CrearParametroSalida("unIdPosicion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .AgregarParametro();

        BP.CrearParametro("unPosicion")
            .SetTipoVarchar(45)
            .SetValor(posicion.Nombre)
            .AgregarParametro();
    }
    public void PostAltaPosicion(Posicion posicion)
    {
        var ParamIdPosicion = GetParametro("unIdPosicion");
        posicion.IdPosicion = Convert.ToByte(ParamIdPosicion.Value);
    }
    public Posicion PosicionPorid(Byte Id)
    {
        SetComandoSP("PosicionPorId");
        BP.CrearParametro("unIdPosicion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .SetValor(Id)
            .AgregarParametro();
        return ElementoDesdeSP();
    }
    public List<Posicion> ObtenerPosicion() => ColeccionDesdeTabla();

}

