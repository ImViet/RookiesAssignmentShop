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

        public List<CategoryDTO> GetAll()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/category/getallcategory";
            // var response = httpClient.GetAsync("/category/getallcategory").Result;
            // var jsonData = response.Content.ReadAsStringAsync().Result;
            // List<CategoryDTO> data = JsonConvert.DeserializeObject<List<CategoryDTO>>(jsonData);
            //if (data == null)
            //{
            //   data = new List<CategoryDTO>();
            //}
            var data = httpClient.GetDataFromAPIAsync<List<CategoryDTO>>(url);
            return data;
        }
    }
}
