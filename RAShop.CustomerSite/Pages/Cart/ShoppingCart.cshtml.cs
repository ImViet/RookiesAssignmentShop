using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Models;
using RAShop.Shared.DTO;
namespace RAShop.CustomerSite.Pages.Home
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ICart _cartService;
        [BindProperty]
        public List<CartDTO> cart {get; set;} = new List<CartDTO>();
        public ShoppingCartModel(ICart cartService)
        {
            _cartService = cartService;
        }
        public ActionResult OnGetAsync()
        {
            cart = _cartService.GetCart();
            return Page();
        }
        public IActionResult OnGetAddToCart(int id)
        {
            _cartService.AddToCart(id);
            CountCart.countItem = _cartService.CountItem(); 
            return RedirectToPage("ShoppingCart");
        }
           public IActionResult OnGetRemoveItem(int id)
        {
            _cartService.RemoveItem(id);
            CountCart.countItem = _cartService.CountItem(); 
            return RedirectToPage("ShoppingCart");
        }
    }
}