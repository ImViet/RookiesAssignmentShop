using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Models;
using RAShop.CustomerSite.Services;
using RAShop.Shared.DTO;
using RAShop.Shared.DTO.Auth;

namespace RAShop.CustomerSite.Pages.Home
{
    public class Login : PageModel
    {
        private readonly IAuth _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Login(IAuth authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> OnPostLogin()
        {
            LoginRequestDTO userLogin = new LoginRequestDTO();
            userLogin.UserName = Request.Form["UserName"];
            userLogin.Password = Request.Form["Password"];
            var accountUserLogin = await _authService.LoginAsync(userLogin);
            string token = accountUserLogin.Token;
            var session = _httpContextAccessor.HttpContext?.Session;
            if (token == "Invalid credentials")
            {
                return null;
            }
            session?.SetString("JWTToken", token);
            session?.SetString("UserName", accountUserLogin.UserName);
            return Redirect("/Index");
        }
        public async Task<IActionResult> OnGetLogout()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
            CountCart.countItem = 0;
            return Redirect("/Auth/Login");
        }
    }
}