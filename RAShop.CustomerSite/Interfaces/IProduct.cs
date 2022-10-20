using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        public List<ProductDTO> GetAll();
        public List<ProductDTO> GetProductByCateId(int id);

    }
}