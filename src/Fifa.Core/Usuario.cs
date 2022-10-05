namespace Fifa.Core;
public class Usuario
{
    public int IdUsuario { get; set; }
    public string User { get; set; }
    public string Contrasena { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Monedas { get; set; }
    public Usuario(int idUsuario, string user, string contrasena, string nombre, string apellido, int monedas)
    {
        IdUsuario = idUsuario;
        User = user;
        Contrasena = contrasena;
        Nombre = nombre;
        Apellido = apellido;
        Monedas = monedas;
    }

}

