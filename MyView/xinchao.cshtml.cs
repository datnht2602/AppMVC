using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AppMVC.MyView
{
    public class xinchao : PageModel
    {
        private readonly ILogger<xinchao> _logger;

        public xinchao(ILogger<xinchao> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}