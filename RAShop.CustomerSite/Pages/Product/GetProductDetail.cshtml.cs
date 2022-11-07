using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
namespace RAShop.CustomerSite.Pages.Home
{
    public class GetProductDetail : PageModel
    {
        private readonly IProduct _productService;
        private readonly IRating _ratingService;
        [BindProperty]
        public ProductDTO product { get; set; } = new ProductDTO();
        public GetProductDetail(IProduct productService, IRating ratingService)
        {
            _productService = productService;
            _ratingService = ratingService;
        }
        public async Task<IActionResult> OnGetAsync(int id, string sortOrder = "0", int pageCurrent = 1)
        {
            product = await _productService.GetProductDetail(id);
            var ratingAvg = await _productService.GetRatingAVG(id);
            ViewData["listRatings"] = await _ratingService.GetProductRatings(id);
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
        public async Task<IActionResult> OnPostCreateRating()
        {
            AddRatingDTO newRating = new AddRatingDTO();
            newRating.ProductId = Convert.ToInt32(Request.Form["ProductId"]);
            newRating.Star = Convert.ToInt32(Request.Form["Star"]);
            newRating.Comment = Request.Form["Comment"];
            await _productService.CreateRating(newRating);
            return RedirectToPage(new {id = newRating.ProductId});
        }
    }
}