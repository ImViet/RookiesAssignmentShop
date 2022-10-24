using Microsoft.AspNetCore.Mvc;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Services;
using RAShop.CustomerSite.Models;
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
            CountCart.countItem = _cartService.CountItem(); 
            return RedirectToAction("Index", "Product");
        }
        public IActionResult RemoveItem(int prodid)
        {
            _cartService.RemoveItem(prodid);
            CountCart.countItem = _cartService.CountItem(); 
            return RedirectToAction("Index");
        }
    }
}