using Microsoft.AspNetCore.Identity;

namespace RAShop.Backend.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
