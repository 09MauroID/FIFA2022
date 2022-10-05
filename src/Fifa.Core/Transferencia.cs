namespace Fifa.Core;

public class Transferencia
{
    public Usuario Vendedor { get; set; }
    public Usuario? Comprador { get; set; }
    public Futbolista Futbolista { get; set;}
    public DateTime Publicacion { get; set; }
    public DateTime Confirmacion { get; set; }
    public int PrecioMonedas { get; set; }
    public Transferencia(Usuario vendedor, Usuario? comprador, Futbolista futbolista, DateTime publicidad, DateTime confirmacion, int preciomonedas)
    {
        Vendedor = vendedor;
        Comprador = comprador;
        Futbolista = futbolista;
        Publicacion = publicidad;
        Confirmacion = confirmacion;
        PrecioMonedas = preciomonedas;
    }
}