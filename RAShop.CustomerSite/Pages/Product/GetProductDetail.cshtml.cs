using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
namespace RAShop.CustomerSite.Pages.Home
{
    public class GetProductDetail : PageModel
    {
        private readonly IProduct _productService;
        [BindProperty]
        public ProductDTO product {get; set;} = new ProductDTO();
        public GetProductDetail(IProduct productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> OnGetAsync(int id, string sortOrder = "0", int pageCurrent = 1)
        {
            product = await _productService.GetProductDetail(id);
            var ratingAvg = await _productService.GetRatingAVG(id);
            if (ratingAvg != 0)
            {
                ViewData["ratingAvg"] = ratingAvg;
            }
            else
            {
                ViewData["ratingAvg"] = 0;
            }
            return Page();
        }
    }
}