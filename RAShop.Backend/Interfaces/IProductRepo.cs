using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface IProductRepo
    {
        Task<List<ProductDTO>> GetAllProduct();
        Task<ProductDTO> GetProductById(int id);
        Task<List<ProductDTO>> GetProductByCateId(int cateid);
        Task<List<ProductDTO>> SearchProducts(string searchString);
        Task<double> RatingAVG(int id);
        Task<Product> CreateProduct(Product newProduct);
        Task<Product> EditProduct(int id, Product newProduct);
        Task<Product> DeleteProduct(int id);

    }
}