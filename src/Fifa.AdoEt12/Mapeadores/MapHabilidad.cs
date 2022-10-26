using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa.AdoEt12.Mapeadores;

    public class MapHabilidad : Mapeador<Habilidad>
{
    public MapHabilidad(AdoAGBD ADO) : base(ADO)
    {
        Tabla = "Habilidad";
    }
    public override Habilidad ObjetoDesdeFila(DataRow fila)
        => new Habilidad
        (
            idHabilidad: Convert.ToByte(fila["idHabilidad"]),

            nombre: fila["Nombre"].ToString(),
            descripcion: fila["Descripcion"].ToString()
        )
        {
            Nombre = fila["Habilidad"].ToString(),
            Descripcion = fila["Habilidad"].ToString(),
        };
    public void AltaHabilidad(Habilidad habilidad)
        => EjecutarComandoCon("altaHablidad", ConfigurarAltaHabilidad, PostAltaHabilidad, habilidad);

    private void PostAltaHabilidad(Habilidad obj)
    {
        throw new NotImplementedException();
    }

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
    public void PostAltahabilidad(Habilidad habilidad)
        {
            var paramIdHabilidad = GetParametro("unIdHabilidad");
            habilidad.IdHabilidad = Convert.ToByte(paramIdHabilidad.Value);
        }

        public Habilidad HabilidadPorIdHabilidad(byte idHabilidad)
        {
            SetComandoSP("HabilidadPorIdHabilidad");

        BP.CrearParametro("unIdHabilidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(idHabilidad)
        .AgregarParametro();

            return ElementoDesdeSP();
        }

        public List<Habilidad> ObtenerHabilidad() => ColeccionDesdeTabla();
    }

