using RAShop.Shared.DTO.Auth;

namespace RAShop.Backend.Interfaces
{
    public interface IAuthRepository
    {
        Task<AccountDTO> LoginAsync(LoginRequestDTO userLogin);
        Task<bool> RegisterAsync(RegisterRequestDTO userRegister);
    }
}
