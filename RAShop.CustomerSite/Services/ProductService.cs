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
        public List<ProductDTO> GetAll()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = "/product/getallproduct";
            var data = httpClient.GetDataFromAPIAsync<List<ProductDTO>>(url);
            return data;
        }
        //Lay san pham theo danh muc
        public List<ProductDTO> GetProductByCateId(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbycateid/{id}";
            var data = httpClient.GetDataFromAPIAsync<List<ProductDTO>>(url);
            return data;
        }

        //Tim kiem san pham
         public List<ProductDTO> SearchProducts(string searchString)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/searchproducts/{searchString}";
            var data = httpClient.GetDataFromAPIAsync<List<ProductDTO>>(url);
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
