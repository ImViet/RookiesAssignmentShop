using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        PagingDTO GetAll(int pageNumber);
        PagingDTO GetProductByCateId(int id, int pageNumber);
        PagingDTO GetProductBySubCateId(int id, int pageNumber);
        PagingDTO SearchProducts(string searchString, int pageNumber);
        ProductDTO GetProductDetail(int id);
        double GetRatingAVG(int id);

    }
}