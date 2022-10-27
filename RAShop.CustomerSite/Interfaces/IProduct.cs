using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        PagingDTO GetAll(int pageNumber);
        List<ProductDTO> GetProductByCateId(int id);
        List<ProductDTO> SearchProducts(string searchString);
        ProductDTO GetProductDetail(int id);
        double GetRatingAVG(int id);

    }
}