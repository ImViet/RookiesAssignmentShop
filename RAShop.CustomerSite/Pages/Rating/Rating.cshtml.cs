using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
namespace RAShop.CustomerSite.Pages.Home
{
    public class Rating : PageModel
    {
        private readonly IRating _ratingService;
        public Rating(IRating ratingService)
        {
            _ratingService = ratingService;
        }
        public async Task<IActionResult> OnGetCreateRating()
        {
            AddRatingDTO newRating = new AddRatingDTO();
            newRating.ProductId = Int32.Parse(Request.Form["ProductId"]);
            newRating.Star = Int32.Parse(Request.Form["Star"]);
            newRating.Comment = Request.Form["Comment"];
            await _ratingService.CreateRating(newRating);
            return Page();
        }
    }
}