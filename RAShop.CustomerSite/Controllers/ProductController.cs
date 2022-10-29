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

        public async Task<IActionResult> Index(string sortOrder = "desc", int pageCurrent = 1)
        {
            if (pageCurrent > 1)
                ViewData["page"] = pageCurrent;
            else
                ViewData["page"] = 1;
            if (sortOrder != "0")
                ViewData["sort"] = sortOrder;
            else
                ViewData["sort"] = "0";
            var data = await _productService.GetAll(sortOrder, pageCurrent);
            ViewData["totalPage"] = data.TotalPages;
            ViewBag.Products = data.Products;
            return View();
        }
        public async Task<IActionResult> GetProductByCateId(int cateid, string sortOrder = "0", int pageCurrent = 1)
        {
            if (pageCurrent > 1)
                ViewData["page"] = pageCurrent;
            else
                ViewData["page"] = 1;
            if (sortOrder != "0")
                ViewData["sort"] = sortOrder;
            else
                ViewData["sort"] = "0";
            var data = await _productService.GetProductByCateId(cateid, sortOrder, pageCurrent);
            ViewData["totalPage"] = data.TotalPages;
            ViewData["cateId"] = cateid;
            ViewBag.Products = data.Products;
            return View();
        }

        public async Task<IActionResult> GetProductBySubCateId(int cateid, string sortOrder = "0", int pageCurrent = 1)
        {
            if (pageCurrent > 1)
                ViewData["page"] = pageCurrent;
            else
                ViewData["page"] = 1;
            if (sortOrder != "0")
                ViewData["sort"] = sortOrder;
            else
                ViewData["sort"] = "0";
            var data = await _productService.GetProductBySubCateId(cateid, sortOrder, pageCurrent);
            ViewData["totalPage"] = data.TotalPages;
            ViewData["subCateId"] = cateid;
            ViewBag.Products = data.Products;
            return View();
        }
        public async Task<IActionResult> SearchProducts(string searchString, string sortOrder = "0", int pageCurrent = 1)
        {
            if (pageCurrent > 1)
                ViewData["page"] = pageCurrent;
            else
                ViewData["page"] = 1;
            if (sortOrder != "0")
                ViewData["sort"] = sortOrder;
            else
                ViewData["sort"] = "0";
            searchString = Request.Query["searchString"];
            var data = await _productService.SearchProducts(searchString, sortOrder, pageCurrent);
            ViewData["totalPage"] = data.TotalPages;
            ViewData["searchString"] = searchString;
            ViewBag.Products = data.Products;
            return View();
        }
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var product = await _productService.GetProductDetail(id);
            var ratingAvg = await _productService.GetRatingAVG(id);
            if (ratingAvg != 0)
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