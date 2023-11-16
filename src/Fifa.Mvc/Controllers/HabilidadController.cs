using Fifa.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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


    [HttpGet]
    public async Task<IActionResult> Detalle(byte? id)
    {
        if (id is null || id == 0)
            return NotFound();
        
        var habilidad = (await _servicio.ObtenerHabilidadesAsync())
            .FirstOrDefault(h=>h.IdHabilidad == id);
        
        return habilidad is null ? NotFound() : View(habilidad);
    }
}
