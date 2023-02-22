using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Backend.Data;
using RAShop.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;

namespace RAShop.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepo;
        public RatingController(IRatingRepository ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }
        [HttpGet("{id}")]
        public async Task<List<RatingDTO>> GetProductRatings(int id)
        {
            return await _ratingRepo.GetProductRatings(id);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<RatingDTO> CreateRating(AddRatingDTO newRating)
        {
            return await _ratingRepo.CreateRating(newRating);
        }
    }
}