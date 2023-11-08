using Fifa.Core;
using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class HabilidadController : Controller
{

    private readonly Servicio _servicio;
    public HabilidadController(Servicio servicio) => _servicio = servicio;

    public IActionResult Index()
    {
        var habilidades = _servicio.ObtenerHabilidades();
        return View("Listado", habilidades);
    }
    
    [HttpGet]
    public IActionResult Alta() => View();
}
