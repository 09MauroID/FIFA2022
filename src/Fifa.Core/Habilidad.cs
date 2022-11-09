namespace Fifa.Core;

public class Futbolista
{
    public byte IdHabilidad { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public Futbolista(byte idHabilidad, string nombre, string descripcion)
    {
        IdHabilidad = idHabilidad;
        Nombre = nombre;
        Descripcion = descripcion;
    }
}