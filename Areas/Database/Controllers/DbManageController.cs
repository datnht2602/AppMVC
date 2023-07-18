using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public DbManageController(ApplicationDBContext dBContext){
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDB()
        {
            return View();
        }
        [TempData]
        public string StatusMessage { get; set; }
        [HttpPost]
        public async Task<IActionResult> DeleteDBAsync(){
           var success= await _dbContext.Database.EnsureDeletedAsync();
           StatusMessage = success ? "Successfully" : "Failed";
           return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Migrate(){
           await _dbContext.Database.MigrateAsync();
           StatusMessage = "Successfully";
           return RedirectToAction(nameof(Index));
        }
    }
}