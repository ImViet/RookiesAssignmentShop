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
    public class ProductController : Controller
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.Products = _productService.GetAll();
            return View();
        }

        public IActionResult GetProductByCateId(int cateid)
        {
            ViewBag.Products = _productService.GetProductByCateId(cateid);
            return View("Index");
        }
        public IActionResult SearchProducts(string searchString)
        {
            searchString = Request.Query["searchString"];
            ViewBag.Products = _productService.SearchProducts(searchString);
            return View("Index");
        }
         public IActionResult GetProductDetail(int id)
        {
            var product = _productService.GetProductDetail(id);
            var ratingAvg = _productService.GetRatingAVG(id);
            if(ratingAvg != 0)
            {
                ViewData["ratingAvg"] = ratingAvg;
            }
            else
            {
                ViewData["ratingAvg"] = 0;
            }
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}