using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.AdoEt12.Mapeadores;
{
    public class MapHabilidad : Mapeador<Habilidad>
{
    public MapHabilidad(AdoAGBD ADO) : base(ado)
    {
        Tabla = "Habilidad";
    }
    public override Habilidad ObjetoDesdeFila(DataRow fila)
        => new Habilidad
        (
            IdHabilidad: Convert.ToByte(fila["idHabilidad"]),

            Nombre: fila["Nombre"].ToString(),
            Descripcion: fila["Descripcion"].ToString(),
        )
        {
            Nombre = fila["Habilidad"].ToString(),
            Descripcion = fila["Habilidad"].ToString(),
        };
    public void AltaHabilidad(Posicion posicion)
        => EjecutarComandoCon("AltaHablidad", ConfigurarAltaHabilidad, PostAltaHabilidad, Habilidad);
    public void ConfigurarAltaHabilidad(Habilidad habilidad)
    {
        SetComandoSP("AltaHabilidad");
        BP.CrearParametroSalida("unidHabilidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
            .AgregarParametro();
        BP.CrearParametro("unHabilidad")
            .SetTipoVarchar(45)
            .SetValor(habilidad.Nombre)
            .AgregarParametro();
        BP.CrearParametro("unHabiliad")
            .SetTipoVarchar(45)
            .SetValor(habilidad.Descripcion)
            .AgregarParametro();
    }
    public void PostAltaHabilidad(Habilidad habilidad)

}


}
