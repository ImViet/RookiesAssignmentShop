using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IRating
    {
        Task<RatingDTO> CreateRating(AddRatingDTO newRating);
    }
}