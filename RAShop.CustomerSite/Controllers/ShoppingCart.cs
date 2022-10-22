using Microsoft.AspNetCore.Mvc;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Services;

namespace RAShop.CustomerSite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICart _cartService;

        public ShoppingCartController(ICart cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {      
            return View(_cartService.GetCart());
        }
        public IActionResult AddProdToCart(int prodid)
        {
            _cartService.AddToCart(prodid);
            return RedirectToAction("Index");
        }
    }
}