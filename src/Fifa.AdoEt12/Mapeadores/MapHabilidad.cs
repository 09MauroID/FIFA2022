using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System.Data;

namespace Fifa.AdoEt12.Mapeadores;

public class MapHabilidad : Mapeador<Futbolista>
{
    public MapHabilidad(AdoAGBD ADO) : base(ADO)
    {
        Tabla = "Habilidad";
    }
    public override Futbolista ObjetoDesdeFila(DataRow fila)
        => new Futbolista
        (
            idHabilidad: Convert.ToByte(fila["idHabilidad"]),
            nombre: fila["Nombre"].ToString(),
            descripcion: fila["Descripcion"].ToString()
        );
    public void AltaHabilidad(Futbolista habilidad)
        => EjecutarComandoCon("altaHablidad", ConfigurarAltaHabilidad, PostAltaHabilidad, habilidad);

    private void PostAltaHabilidad(Futbolista habilidad)
    {
        var paramIdHabilidad = GetParametro("unIdHabilidad");
        habilidad.IdHabilidad = Convert.ToByte(paramIdHabilidad);
    }

    public void ConfigurarAltaHabilidad(Futbolista habilidad)
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
    public void PostAltahabilidad(Futbolista habilidad)
    {
        var paramIdHabilidad = GetParametro("unIdHabilidad");
        habilidad.IdHabilidad = Convert.ToByte(paramIdHabilidad.Value);
    }

    public Futbolista HabilidadPorIdHabilidad(byte idHabilidad)
    {
        SetComandoSP("HabilidadPorIdHabilidad");

        BP.CrearParametro("unIdHabilidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Byte)
        .SetValor(idHabilidad)
        .AgregarParametro();

        return ElementoDesdeSP();
    }

    public List<Futbolista> ObtenerHabilidad() => ColeccionDesdeTabla();

    public List<Futbolista> HabilidadesDe(Futbolista futbolista)
    {
        /* Paso 1; saber que futbolistas posee el usuario, esa informacion
        la tiene la Tabla Propietario, pero de todas sus filas, solo me
        interesa las de un determinado idUsuario  */
        var tablaSkill = FilasFiltradasRAW("idFutbolista", futbolista.IdFutbolista, "Skill");
        var habilidades = new List<Futbolista>();

        /*Paso 2: Recorrer las filas de la tabla devuelta, quedarme con el idFutbolista de cada fila
        devuelta y usarlo para FiltrarPorPK
        */
        for (int i = 0; i < tablaSkill.Rows.Count; i++)
        {
            var idHabilidad = Convert.ToInt32(tablaSkill.Rows[i]["idHabilidad"]);
            habilidades.Add(FiltrarPorPK("idHabilidad", idHabilidad)!);
        }

        //Devuelvo la lista que cree y complete.
        return habilidades;
    }
}

