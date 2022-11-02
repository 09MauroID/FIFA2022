using Fifa.Core;
using et12.edu.ar.AGBD.Mapeadores;
using System.Data;
using et12.edu.ar.AGBD.Ado;

namespace Fifa.AdoEt12.Mapeadores;

public class MapTransferencia : Mapeador<Transferencia>
{
    public MapUsuario MapUsuario { get; set; }
    public MapFutbolista MapFutbolista { get; set; }
    public MapTransferencia(AdoAGBD ado) : base(ado)
    {
        Tabla = "Transferencia";
    }
    public MapTransferencia(MapUsuario mapUsuario) : this(mapUsuario.AdoAGBD)
    {
        MapUsuario = mapUsuario;
    }
    public MapTransferencia(MapFutbolista mapFutbolista) : this(mapFutbolista.AdoAGBD)
    {
        MapFutbolista = mapFutbolista;
    }
    public override Transferencia ObjetoDesdeFila(DataRow fila)
    => new Transferencia
    (
        vendedor : MapUsuario.UsuarioPorIdUsuario(Convert.ToInt32(fila["idVendedor"])),
        comprador : MapUsuario.UsuarioPorIdUsuario(Convert.ToInt32(fila["idComprador"])),
        futbolista : MapFutbolista.FutbolistaPorId(Convert.ToInt32(fila["idFutbolista"])),
        publicacion : Convert.ToDateTime(fila["publicacion"]),
        confirmacion : Convert.ToDateTime(fila["confirmacion"]),
        preciomonedas : Convert.ToInt32(fila["preciomonedas"])
    )
    {
        Vendedor = MapUsuario.UsuarioPorIdUsuario(Convert.ToInt32(fila["idVendedor"])),
        Comprador = MapUsuario.UsuarioPorIdUsuario(Convert.ToInt32(fila["idComprador"])),
        Futbolista = MapFutbolista.FutbolistaPorId(Convert.ToInt32(fila["idFutbolista"])),
        Publicacion = Convert.ToDateTime(fila["publicacion"]),
        Confirmacion = Convert.ToDateTime(fila["confirmacion"]),
        PrecioMonedas = Convert.ToInt32(fila["preciomonedas"])
    };
    public void Publicar(Transferencia transferencia)
        => EjecutarComandoCon("publicar", ConfigurarPublicar, PostPublicar, transferencia);

    public void ConfigurarPublicar(Transferencia transferencia)
    {
        SetComandoSP("Publicar");

        BP.CrearParametro("unIdVendedor")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unIdComprador")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

        BP.CrearParametro("Publicacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .AgregarParametro();

        BP.CrearParametro("Confirmacion")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
            .AgregarParametro();

        BP.CrearParametro("PrecioMonedas")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .AgregarParametro();

    }
    public void PostPublicar(Transferencia transferencia)
    {
        var paramIdVendedor = GetParametro("unIdVendedor");
        transferencia.Vendedor = Convert.ToInt32(GetParametro(paramIdVendedor.Value));
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
    public List<Transferencia> ObtenerTransferencias() => ColeccionDesdeTabla();
    public List<Transferencia> ObtenerTransferencias(Usuario usuario);
}

