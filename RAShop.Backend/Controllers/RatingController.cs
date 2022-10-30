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
        [HttpPost]
        public async Task<RatingDTO> CreateRating(AddRatingDTO newRating)
        {
            return await _ratingRepo.CreateRating(newRating);
        }
    }
}