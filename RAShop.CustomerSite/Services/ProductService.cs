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

        public List<ProductDTO> GetAll()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = "/product/getallproduct";
            var data = httpClient.GetDataFromAPIAsync<List<ProductDTO>>(url);
            return data;
        }
        public List<ProductDTO> GetProductByCateId(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbycateid/{id}";
            var data = httpClient.GetDataFromAPIAsync<List<ProductDTO>>(url);
            return data;
        }
    }
}
