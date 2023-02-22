using RAShop.Shared.DTO;
using RAShop.Shared.DTO.Auth;

namespace RAShop.CustomerSite.Interfaces
{
    public interface IAuth
    {
        Task<AccountDTO> LoginAsync(LoginRequestDTO userLogin);
        Task<RegisterRequestDTO> RegisterAsync(RegisterRequestDTO userRegister);
    }
}