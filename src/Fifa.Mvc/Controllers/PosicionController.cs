using Fifa.Core;
using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class PosicionController : Controller
{
    public PosicionController(ILogger<PosicionController> logger)
    {

    }

    public IActionResult Index()
    {
        //Magia para recibir una lista de posiciones
        var posiciones = new List<Posicion>
        {
            new Posicion(1, "Defensor")
        };
        return View("Listado", posiciones);
    }

    [HttpGet]
    public IActionResult Alta() => View();
}