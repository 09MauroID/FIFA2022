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
        MapFutbolista = MapFutbolista;
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
        vendedor: (Convert.ToInt32(fila["idVendedor"])),
        comprador: (Convert.ToInt32(fila["idComprador"])),
        futbolista: (Convert.ToInt32(fila["idFutbolista"])),
        publicacion: Convert.ToDateTime(fila["publicacion"]),
        confirmacion: Convert.ToDateTime(fila["confirmacion"]),
        preciomonedas: Convert.ToInt32(fila["preciomonedas"])

    );

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
        => EjecutarComandoCon("TransferenciasActivas", ConfigurarTransferenciasActivas, PostTransferenciasActivas, transferencia);

    public void ConfigurarTransferenciasActivas(Transferencia transferencia)
    {
        SetComandoSP("TransferenciasActivas");
        
        BP.CrearParametroSalida("unIdFutbolista")
          .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
          .AgregarParametro();

        BP.CrearParametro("unConfirmacion")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
              .SetValor(transferencia.Confirmacion)
              .AgregarParametro();
    }
    public void PostTransferenciasActivas(Transferencia transferencia)
    {
        var paramConfirmacion  = GetParametro("unaConfirmacion");
        transferencia.Confirmacion = Convert.ToDateTime(paramConfirmacion.Value);
    }
        public Transferencia FutbolistaPorid(int Id)
    {
        SetComandoSP("FutbolistaPorId");
        
        BP.CrearParametro("unIdFutbolista")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
            .SetValor(Id)
            .AgregarParametro();

        return ElementoDesdeSP();
    }
    public List<Transferencia> ObtenerTransferencias() => ColeccionDesdeTabla();

    internal void AltaTransferencia(Transferencia transferencia)
    {
        throw new NotImplementedException();
    }

    //public List<Transferencia> ObtenerTransferencias(Usuario usuario);
}