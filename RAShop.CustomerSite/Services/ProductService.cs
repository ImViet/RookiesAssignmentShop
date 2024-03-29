using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using RAShop.CustomerSite.Extensions;
using System.Text;
using System.Net.Http.Headers;

namespace RAShop.CustomerSite.Services
{
    public class ProductService : IProduct
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        //Lay tat ca san pham
        public async Task<PagingDTO<ProductDTO>> GetAll(string sortOrder, int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getallproduct?sort={sortOrder}&pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO<ProductDTO>>(url);
            return data;
        }
        //Lay san pham theo danh muc
        public async Task<PagingDTO<ProductDTO>> GetProductByCateId(int id, string sortOrder, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbycateid?cateid={id}&sort={sortOrder}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO<ProductDTO>>(url);
            return data;
        }
        //Lay san pham theo danh muc con
        public async Task<PagingDTO<ProductDTO>> GetProductBySubCateId(int id, string sortOrder, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbysubcateid?cateid={id}&sort={sortOrder}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO<ProductDTO>>(url);
            return data;
        }

        //Tim kiem san pham
        public async Task<PagingDTO<ProductDTO>> SearchProducts(string searchString, string sortOrder, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/searchproducts?searchstring={searchString}&sort={sortOrder}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO<ProductDTO>>(url);
            return data;
        }

        //Lay 1 san pham, chi tiet
        public async Task<ProductDTO> GetProductDetail(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbyid/{id}";
            var data = httpClient.GetDataFromAPIAsync<ProductDTO>(url);
            return data;
        }

        //Lay so sao trung binh
        public async Task<double> GetRatingAVG(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/ratingavg/{id}";
            var data = httpClient.GetDataFromAPIAsync<double>(url);
            return data;
        }

        //Tao rating
        public async Task<RatingDTO> CreateRating(AddRatingDTO newRating)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/rating/createrating";
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWTToken");
            var jsonString = JsonConvert.SerializeObject(newRating);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<RatingDTO>(jsonData);
            return data;
        }
    }
}
