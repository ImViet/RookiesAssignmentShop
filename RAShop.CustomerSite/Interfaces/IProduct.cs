using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        public List<ProductDTO> GetAll();
        public List<ProductDTO> GetProductByCateId(int id);
        public List<ProductDTO> SearchProducts(string searchString);
        public ProductDTO GetProductDetail(int id);
    }
}