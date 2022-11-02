using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        Task<PagingDTO<ProductDTO>> GetAll(string sortOrder, int pageNumber);
        Task<PagingDTO<ProductDTO>> GetProductByCateId(int id, string sortOrder, int pageNumber);
        Task<PagingDTO<ProductDTO>> GetProductBySubCateId(int id, string sortOrder, int pageNumber);
        Task<PagingDTO<ProductDTO>> SearchProducts(string searchString, string sortOrder, int pageNumber);
        Task<ProductDTO> GetProductDetail(int id);
        Task<double> GetRatingAVG(int id);
        Task<RatingDTO> CreateRating(AddRatingDTO newRating);


    }
}