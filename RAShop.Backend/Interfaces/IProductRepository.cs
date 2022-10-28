using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface IProductRepository
    {
        Task<PagingDTO> GetAllProduct(string sortOrder, int pageNumber, int pageSize);
        Task<ProductDTO> GetProductById(int id);
        Task<PagingDTO> GetProductByCateId(int cateid, string sortOrder, int pageNumber, int pageSize);
        Task<PagingDTO> GetProductBySubCateId(int cateid, string sortOrder, int pageNumber, int pageSize);
        Task<PagingDTO> SearchProducts(string searchString, string sortOrder, int pageNumber, int pageSize);
        Task<double> RatingAVG(int id);
        Task<Product> CreateProduct(Product newProduct);
        Task<Product> EditProduct(int id, Product newProduct);
        Task<Product> DeleteProduct(int id);

    }
}