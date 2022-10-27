using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Models;
using RAShop.CustomerSite.Services;
using RAShop.Shared.DTO;
using System.Diagnostics;
using System.Text.Json;

namespace RAShop.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _productService;

        public HomeController(IProduct productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            // ViewBag.Products = _productService.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}