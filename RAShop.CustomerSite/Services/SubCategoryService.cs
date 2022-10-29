using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using RAShop.CustomerSite.Extensions;
namespace RAShop.CustomerSite.Services
{
    public class SubCategoryService: ISubCategory
    {
        private readonly IHttpClientFactory _clientFactory;
        public SubCategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<SubCateDTO>> GetAll()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/subcate/getallsubcategory";
            var data = httpClient.GetDataFromAPIAsync<List<SubCateDTO>>(url);
            return data;
        }
    }
}
