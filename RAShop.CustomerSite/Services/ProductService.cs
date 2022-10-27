using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using RAShop.CustomerSite.Extensions;
namespace RAShop.CustomerSite.Services
{
    public class ProductService: IProduct
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //Lay tat ca san pham
        public PagingDTO GetAll(int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getallproduct?pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
            return data;
        }
        //Lay san pham theo danh muc
        public PagingDTO GetProductBySubCateId(int id, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbysubcateid?cateid={id}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
            return data;
        }

        //Tim kiem san pham
         public PagingDTO SearchProducts(string searchString, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/searchproducts?searchstring={searchString}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
            return data;
        }

        //Lay 1 san pham, chi tiet
         public ProductDTO GetProductDetail(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbyid/{id}";
            var data = httpClient.GetDataFromAPIAsync<ProductDTO>(url);
            return data;
        }

        //Lay so sao trung binh
        public double GetRatingAVG(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/ratingavg/{id}";
            var data = httpClient.GetDataFromAPIAsync<double>(url);
            return data;
        }
    }
}
