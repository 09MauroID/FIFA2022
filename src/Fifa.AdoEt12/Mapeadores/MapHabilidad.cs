using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;

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
        );
    public void AltaHabilidad(Habilidad habilidad)
        => EjecutarComandoCon("altaHablidad", ConfigurarAltaHabilidad, PostAltaHabilidad, habilidad);

    private void PostAltaHabilidad(Habilidad habilidad)
    {
        var paramIdHabilidad = GetParametro("unIdHabilidad");
        habilidad.IdHabilidad = Convert.ToByte(paramIdHabilidad.Value);
    }

    public void ConfigurarAltaHabilidad(Habilidad habilidad)
    {
        SetComandoSP("AltaHabilidad");
        BP.CrearParametroSalida("unidHabilidad")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .AgregarParametro();
        BP.CrearParametro("unNombre")
            .SetTipoVarchar(45)
            .SetValor(habilidad.Nombre)
            .AgregarParametro();
        BP.CrearParametro("unaDescripcion")
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

    public List<Habilidad> HabilidadesDe(Futbolista futbolista)
    {
        /* Paso 1; saber que futbolistas posee el usuario, esa informacion
        la tiene la Tabla Propietario, pero de todas sus filas, solo me
        interesa las de un determinado idUsuario  */
        var tablaSkill = FilasFiltradasRAW("idFutbolista", futbolista.IdFutbolista, "Skill");
        var habilidades = new List<Habilidad>();

        /*Paso 2: Recorrer las filas de la tabla devuelta, quedarme con el idFutbolista de cada fila
        devuelta y usarlo para FiltrarPorPK
        */
        for (int i = 0; i < tablaSkill.Rows.Count; i++)
        {
            var idHabilidad = Convert.ToByte(tablaSkill.Rows[i]["idHabilidad"]);
            habilidades.Add(FiltrarPorPK("idHabilidad", idHabilidad)!);
        }

        //Devuelvo la lista que cree y complete.
        return habilidades;
    }
}

