using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger){
            _planetService = planetService;
            _logger = logger;
        }
        [Route("danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index()
        {
            return View();
        }
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set; }
        public IActionResult Mercury()
        {
            var planet = _planetService.FirstOrDefault(p => p.Name == Name);
            return View("Detail",planet);
        }
        [Route("sao/[action]")]
         public IActionResult Venus()
        {
            var planet = _planetService.FirstOrDefault(p => p.Name == Name);
            return View("Detail",planet);
        }
        [Route("hanhtinh/{id:int}")]
        public IActionResult PlanetInfo(int id){
            var planet = _planetService.FirstOrDefault(p => p.Id == id);
            return View("Detail",planet);
        }
    }
}