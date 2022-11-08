using Microsoft.AspNetCore.Identity;
using RAShop.Backend.Models;

namespace RAShop.Backend.Interfaces
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
