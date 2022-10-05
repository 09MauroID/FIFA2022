namespace Fifa.Core;

public class Habilidad
{
    public int IdHabilidad { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public Habilidad(int idHabilidad, string nombre, string descripcion)
    {
        IdHabilidad = idHabilidad;
        Nombre = nombre;
        Descripcion = descripcion;
    }
}