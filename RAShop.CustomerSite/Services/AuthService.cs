using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using RAShop.CustomerSite.Extensions;
using RAShop.Shared.DTO.Auth;
using System.Text;

namespace RAShop.CustomerSite.Services
{
    public class AuthService : IAuth
    {
        private readonly IHttpClientFactory _clientFactory;
        public AuthService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<AccountDTO> LoginAsync(LoginRequestDTO userLogin)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/auth/login";
            var jsonString = JsonConvert.SerializeObject(userLogin);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<AccountDTO>(jsonData);
            return data;
        }

        public async Task<RegisterRequestDTO> RegisterAsync(RegisterRequestDTO userRegister)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/auth/register";
            var jsonString = JsonConvert.SerializeObject(userRegister);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<RegisterRequestDTO>(jsonData);
            return data;
        }
    }
}
