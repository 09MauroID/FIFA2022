using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fifa.Mvc.Views.Habilidad
{
    public class AltaHabilidad : PageModel
    {
        private readonly ILogger<AltaHabilidad> _logger;

        public AltaHabilidad(ILogger<AltaHabilidad> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}