namespace Fifa.Core;

public class Transferencia
{
    private int vendedor;
    private int comprador;
    private int futbolista;

    public Usuario Vendedor { get; set; }
    public Usuario? Comprador { get; set; }
    public Futbolista Futbolista { get; set; }
    public DateTime Publicacion { get; set; }
    public DateTime? Confirmacion { get; set; }
    public int PrecioMonedas { get; set; }
    public Transferencia(Usuario vendedor, Usuario? comprador, Futbolista futbolista, DateTime publicacion, DateTime? confirmacion, int preciomonedas)
    {
        Vendedor = vendedor;
        Comprador = comprador;
        Futbolista = futbolista;
        Publicacion = publicacion;
        Confirmacion = confirmacion;
        PrecioMonedas = preciomonedas;
    }

    public Transferencia(int vendedor, Usuario? comprador, int futbolista, DateTime publicacion, DateTime? confirmacion, int preciomonedas)
    {
        this.vendedor = vendedor;
        comprador = comprador;
        this.futbolista = futbolista;
        Publicacion = publicacion;
        Confirmacion = confirmacion;
        PrecioMonedas = preciomonedas;
    }
}