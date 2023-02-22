using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Models;
using RAShop.CustomerSite.Services;
using RAShop.Shared.DTO;
using RAShop.Shared.DTO.Auth;

namespace RAShop.CustomerSite.Pages.Home
{
    public class Register : PageModel
    {
        private readonly IAuth _authService;
        public Register(IAuth authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> OnPostRegister()
        {
            RegisterRequestDTO userRegister = new RegisterRequestDTO();
            userRegister.UserName = Request.Form["UserName"];
            userRegister.Email = Request.Form["Email"];
            userRegister.Password = Request.Form["Password"];
            userRegister.ConfirmPassword = Request.Form["ConfirmPassword"];
            var result = await _authService.RegisterAsync(userRegister);
            if (result == null)
            {
                return null;
            }
            return Redirect("/Auth/Login");
        }
    }
}