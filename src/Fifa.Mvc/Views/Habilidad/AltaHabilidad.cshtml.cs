using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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