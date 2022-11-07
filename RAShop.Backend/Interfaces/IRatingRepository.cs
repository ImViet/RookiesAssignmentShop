using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface IRatingRepository
    {
        Task<RatingDTO> CreateRating(AddRatingDTO rating);
        Task<List<RatingDTO>> GetProductRatings(int id);
    }
}