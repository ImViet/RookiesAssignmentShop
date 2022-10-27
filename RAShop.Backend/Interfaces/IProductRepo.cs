using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface IProductRepo
    {
        Task<PagingDTO> GetAllProduct(int pageNumber, int pageSize);
        Task<ProductDTO> GetProductById(int id);
        Task<List<ProductDTO>> GetProductByCateId(int cateid);
        Task<List<ProductDTO>> SearchProducts(string searchString, int pageNumber, int pageSize);
        Task<double> RatingAVG(int id);
        Task<Product> CreateProduct(Product newProduct);
        Task<Product> EditProduct(int id, Product newProduct);
        Task<Product> DeleteProduct(int id);

    }
}