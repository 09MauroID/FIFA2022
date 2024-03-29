using Fifa.Core;
using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class PosicionController : Controller
{
    private readonly Servicio _servicio;
    public PosicionController(Servicio servicio) => _servicio = servicio;

    public IActionResult Index()
    {
        var posiciones = _servicio.ObtenerPosiciones();
        return View("Listado", posiciones);
    }

    [HttpGet]
    public IActionResult Alta() => View();
}