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
        public async Task<PagingDTO> GetAll(string sortOrder, int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getallproduct?sort={sortOrder}&pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
            return data;
        }
          //Lay san pham theo danh muc
        public async Task<PagingDTO> GetProductByCateId(int id, string sortOrder, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbycateid?cateid={id}&sort={sortOrder}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
            return data;
        }
        //Lay san pham theo danh muc con
        public async Task<PagingDTO> GetProductBySubCateId(int id, string sortOrder, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbysubcateid?cateid={id}&sort={sortOrder}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
            return data;
        }

        //Tim kiem san pham
         public async Task<PagingDTO> SearchProducts(string searchString, string sortOrder, int pageCurrent)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/searchproducts?searchstring={searchString}&sort={sortOrder}&pageCurrent={pageCurrent}";
            var data = httpClient.GetDataFromAPIAsync<PagingDTO>(url);
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
    }
}
