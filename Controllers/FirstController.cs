using System.IO.Compression;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppMVC.Services;

namespace AppMVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger , IWebHostEnvironment environment,ProductService productService){
            _logger = logger;
            _environment = environment;
            _productService = productService;
        }
        public string Index(){
            _logger.LogInformation("Index Action");
            return "Toi la Index cua First";
        }
        public void Nothing(){
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("hi","xin chao cac ban");
        }
        public IActionResult Readme(){
            var content = @"
            xin chao cac ban,
            Thanh Dat";
            return Content(content,"text/plain");
        }
        public IActionResult Bird()
        {
            string filePath = Path.Combine(_environment.ContentRootPath,"Files","Bird.jpeg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpeg");
        }
        public IActionResult IphonePrice()
        {
            return Json(
                new{
                    productName= "Iphone X",
                    Price = 1000
                }
            );
        }
        public IActionResult HelloView(string username)
        {
            if(string.IsNullOrEmpty(username))
            {
                username = "Khach";
            }
            return View("xinchao2", username);
        }
        public IActionResult ViewProduct(int? id){
            var product = _productService.FirstOrDefault( p=> p.Id == id);
            if(product == null){
                TempData["Thongbao"]= "NotFound";
                return Redirect(Url.Action("Index","Home"));
            }
            // this.ViewData["product"] = product;
            ViewBag.product = product;
            return View("ViewProduct3");
        }
    }
    
}