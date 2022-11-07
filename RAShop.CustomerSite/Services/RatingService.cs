using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace RAShop.CustomerSite.Services
{
    public class RatingService : IRating
    {
        private readonly IHttpClientFactory _clientFactory;
        public RatingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<RatingDTO>> GetProductRatings(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = $"/rating/getproductratings/{id}";
            var response =  httpClient.GetAsync(url).Result;
            var jsonData =  response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<RatingDTO>>(jsonData);
            return data;

        }
        public async Task<RatingDTO> CreateRating(AddRatingDTO newRating)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/rating/createrating";
            var jsonString = JsonConvert.SerializeObject(newRating);
            HttpContent content = new StringContent(jsonString,Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<RatingDTO>(jsonData);
            return data;
        }
    }
}