using System.IO.Compression;

namespace Fifa.Core;

public class Servicio
{
    private readonly IAdo _ado;
    public Servicio(IAdo ado) => _ado = ado;
    public void AltaHabilidad(Habilidad habilidad)
    {
        if (habilidad.IdHabilidad != 0)
            throw new ArgumentException("IdHabilidad, no debe tener valor");

        if (string.IsNullOrEmpty(habilidad.Descripcion) || string.IsNullOrEmpty(habilidad.Nombre))
            throw new ArgumentException("Nombre o habilidad no puede ser vacio");

        _ado.AltaHabilidad(habilidad);
    }

    public List<Habilidad> ObtenerHabilidades() => _ado.ObtenerHabilidades();

    public Task<List<Habilidad>> ObtenerHabilidadesAsync() => _ado.ObtenerHabilidadesAsync();

    public void AltaTransferencia(Transferencia transferencia)
    {
        if (transferencia.Vendedor.IdUsuario != 0)
            throw new ArgumentException("Vendedor, no debe tener valor");

        //Comprador pueder ser nulo? SI, TIENE QUE SER NULO
        if (transferencia.Comprador is not null)
            throw new ArgumentException("Comprador no debe tener valor");

        if (transferencia.PrecioMonedas <= 0)
            throw new ArgumentException("Precio monedas no puede ser nulo o negativo");

        if (transferencia.Confirmacion is not null)
            throw new ArgumentException("Confirmación no debe tener valor");
            
    }
    public List<Usuario> ObtenerUsuarios() => _ado.ObtenerUsuarios();

}
