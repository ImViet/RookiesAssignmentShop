using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using RAShop.CustomerSite.Extensions;
namespace RAShop.CustomerSite.Services
{
    public class CategoryService: ICategory
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        //Lay danh muc cho customer
        public async Task<List<CategoryDTO>> GetAll()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/category/getallcategory";
            var data = httpClient.GetDataFromAPIAsync<List<CategoryDTO>>(url);
            return data;
        }
    }
}
