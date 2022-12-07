using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using et12.edu.ar.AGBD.Ado;
using static System.Convert;

namespace Fifa.AdoEt12.Mapeadores;

public class MapTransferencia : Mapeador<Transferencia>
{
    public MapUsuario MapUsuario { get; set; }
    public MapFutbolista MapFutbolista { get; set; }
    public MapTransferencia(MapUsuario mapUsuario, MapFutbolista mapFutbolista) : base(mapUsuario.AdoAGBD)
    {
        Tabla = "Transferencia";
        MapUsuario = mapUsuario;
        MapFutbolista = mapFutbolista;
    }
    public override Transferencia ObjetoDesdeFila(DataRow fila)
    => new Transferencia
    (
        vendedor: ToInt32(fila["idVendedor"]),
        comprador: CompradorNuLL(fila["idComprador"]),
        futbolista: ToInt32(fila["idFutbolista"]),
        publicacion: ToDateTime(fila["publicacion"]),
        confirmacion: FechaONull(fila["confirmacion"]),
        preciomonedas: ToInt32(fila["preciomonedas"])
    );

    private DateTime? FechaONull(object celda)
        => IsDBNull(celda) ? null : ToDateTime(celda);
    private Usuario? CompradorNuLL(object celda)
        => IsDBNull(celda) ? null : MapUsuario.FiltrarPorPK("idUsuario", (celda));

    public void Publicar(Transferencia transferencia)
        => EjecutarComandoCon("publicar", ConfigurarPublicar, transferencia);

    public void ConfigurarPublicar(Transferencia transferencia)
    {
        SetComandoSP("Publicar");

        BP.CrearParametro("unIdVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unaPublicacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .AgregarParametro();

        BP.CrearParametro("unConfirmacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .AgregarParametro();

        BP.CrearParametro("unPrecioMonedas")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

    }
    public Transferencia VendedorPorId(int id)
    {
        SetComandoSP("VendedorPorId");

        BP.CrearParametro("unIdVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(id)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
    public void ConfigurarComprar(Transferencia transferencia)
    {
        SetComandoSP("Comprar");

        BP.CrearParametro("unIdVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unIdComprador")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unaPublicacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .AgregarParametro();
    }
    public Transferencia CompradorPorId(int id)
    {
        SetComandoSP("VendedorPorId");

        BP.CrearParametro("unIdVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(id)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
    public void TransferenciasActivas(Transferencia transferencia)
        => EjecutarComandoCon("TransferenciasActivas", ConfigurarTransferenciasActivas, transferencia);

    public void ConfigurarTransferenciasActivas(Transferencia transferencia)
    {
        SetComandoSP("TransferenciasActivas");

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();
    }
    public List<Transferencia> ObtenerTransferencias() => ColeccionDesdeTabla();
    internal void AltaTransferencia(Transferencia transferencia)
    {
        throw new NotImplementedException();
    }
    public List<Transferencia> TransferenciasActivas() => ColeccionDesdeSP();

    //public List<Transferencia> ObtenerTransferencias(Usuario usuario);
}