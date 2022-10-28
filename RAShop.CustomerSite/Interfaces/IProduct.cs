using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IProduct
    {
        PagingDTO GetAll(string sortOrder, int pageNumber);
        PagingDTO GetProductByCateId(int id, string sortOrder, int pageNumber);
        PagingDTO GetProductBySubCateId(int id, string sortOrder, int pageNumber);
        PagingDTO SearchProducts(string searchString, string sortOrder, int pageNumber);
        ProductDTO GetProductDetail(int id);
        double GetRatingAVG(int id);

    }
}