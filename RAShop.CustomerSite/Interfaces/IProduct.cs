using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        List<ProductDTO> GetAll();
        List<ProductDTO> GetProductByCateId(int id);
        List<ProductDTO> SearchProducts(string searchString);
        ProductDTO GetProductDetail(int id);
        double GetRatingAVG(int id);

    }
}