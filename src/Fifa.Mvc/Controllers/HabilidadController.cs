using Fifa.Core;
using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class HabilidadController : Controller
{

    public HabilidadController(ILogger<HabilidadController> logger)
    {

    }

    public IActionResult Index()
    {
        var habilidades = new List<Habilidad>
        {
            new Habilidad(1, "Correcaminos", "Velocista")
        };
        return View("Listado", habilidades);
    }
    
    [HttpGet]
    public IActionResult Alta() => View();
}
