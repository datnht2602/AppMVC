using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AppMVC.Pages
{
    public class Razor : PageModel
    {
        private readonly ILogger<Razor> _logger;

        public Razor(ILogger<Razor> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}