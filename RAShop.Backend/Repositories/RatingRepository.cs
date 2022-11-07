using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public RatingRepository(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RatingDTO>> GetProductRatings(int id)
        {
            var rating = await _context.Ratings.Where(x => x.ProductId == id).OrderByDescending(p => p.DateCreated).ToListAsync();
            var listRatingDTO = _mapper.Map<List<RatingDTO>>(rating);
            return listRatingDTO;
        }
        public async Task<RatingDTO> CreateRating(AddRatingDTO newRating)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == newRating.ProductId);
            Rating rating = new Rating();
            if(product != null)
            {
                rating = _mapper.Map<Rating>(newRating);
                _context.Ratings.Add(rating);
            }
            await _context.SaveChangesAsync();         
            return _mapper.Map<RatingDTO>(rating);
        }
    }
}