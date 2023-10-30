using Microsoft.AspNetCore.Mvc;

namespace Fifa.Mvc.Controllers;
public class PosicionController : Controller
{
    public PosicionController(ILogger<PosicionController> logger)
    {

    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Alta() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}