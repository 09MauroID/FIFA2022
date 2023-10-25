using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class HabilidadController : Controller
{

    public HabilidadController(ILogger<HabilidadController> logger)
    {
    
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Alta() => View("AltaHabilidad");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}