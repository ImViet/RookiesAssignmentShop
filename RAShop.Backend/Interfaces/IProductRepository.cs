using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface IProductRepository
    {
        Task<PagingDTO<ProductDTO>> GetProductAdmin(string query, string sortOrder, int pageNumber, int pageSize, int cateId, int subCateId);
        Task<PagingDTO<ProductDTO>> GetAllProduct(string sortOrder, int pageNumber, int pageSize);
        Task<ProductDTO> GetProductById(int id);
        Task<PagingDTO<ProductDTO>> GetProductByCateId(int cateid, string sortOrder, int pageNumber, int pageSize);
        Task<PagingDTO<ProductDTO>> GetProductBySubCateId(int cateid, string sortOrder, int pageNumber, int pageSize);
        Task<PagingDTO<ProductDTO>> SearchProducts(string searchString, string sortOrder, int pageNumber, int pageSize);
        Task<double> RatingAVG(int id);
        Task<ProductDTO> CreateProduct(CreateProductDTO newProduct);
        Task<ProductDTO> EditProduct(EditProductDTO newProduct);
        Task<ProductDTO> DeleteProduct(int id);

    }
}