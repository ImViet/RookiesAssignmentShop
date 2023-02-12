using Microsoft.AspNetCore.Identity;

namespace RAShop.Backend.Repositories
{
    public class AuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
    }
}
