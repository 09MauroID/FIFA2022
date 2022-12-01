namespace Fifa.Core;

public class Transferencia
{
    public int Vendedor { get; set; }
    public int Comprador { get; set; }
    public Habilidad Futbolista { get; set; }
    public DateTime Publicacion { get; set; }
    public DateTime Confirmacion { get; set; }
    public int PrecioMonedas { get; set; }
    public Transferencia(int vendedor, int comprador,DateTime publicacion, DateTime confirmacion, int preciomonedas)
    {
        Vendedor = vendedor;
        Comprador = comprador;
        Publicacion = publicacion;
        Confirmacion = confirmacion;
        PrecioMonedas = preciomonedas;
    }

    public Transferencia(Usuario vendedor, Usuario comprador, Futbolista futbolista, DateTime publicacion, DateTime confirmacion, int preciomonedas)
    {
        PrecioMonedas = preciomonedas;
    }
}