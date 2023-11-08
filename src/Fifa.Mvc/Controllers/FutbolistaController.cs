using AspNetCore;
using Fifa.Core;
using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class FutbolistaController : Controller
{
    private readonly Servicio _servicio;
    public FutbolistaController(Servicio servicio) => _servicio = servicio;

    public IActionResult Index()
    {
        var futbolistas = _servicio.ObtenerFutbolistas();
        return View("Listado", futbolistas);
    }

    [HttpGet]
    public IActionResult Alta() => View();

    [HttpPost]
    public ActionResult Post ([FromBody] Views_Futbolista_Alta Futbolista)
}