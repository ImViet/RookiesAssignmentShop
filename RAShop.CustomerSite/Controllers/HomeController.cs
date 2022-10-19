using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RAShop.CustomerSite.Models;
using RAShop.Shared.DTO;
using System.Diagnostics;
using System.Text.Json;

namespace RAShop.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var response = httpClient.GetAsync("/category/getallcategory").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<CategoryDTO> data = JsonConvert.DeserializeObject<List<CategoryDTO>>(jsonData);
            if (data == null)
            {
                return BadRequest();
            }
            ViewBag.Categories = data;
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