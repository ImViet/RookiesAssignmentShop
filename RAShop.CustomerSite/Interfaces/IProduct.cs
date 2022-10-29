using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        Task<PagingDTO> GetAll(string sortOrder, int pageNumber);
        Task<PagingDTO> GetProductByCateId(int id, string sortOrder, int pageNumber);
        Task<PagingDTO> GetProductBySubCateId(int id, string sortOrder, int pageNumber);
        Task<PagingDTO> SearchProducts(string searchString, string sortOrder, int pageNumber);
        Task<ProductDTO> GetProductDetail(int id);
        Task<double> GetRatingAVG(int id);

    }
}