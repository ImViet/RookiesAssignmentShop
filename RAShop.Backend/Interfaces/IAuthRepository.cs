using RAShop.Shared.DTO.Auth;

namespace RAShop.Backend.Interfaces
{
    public interface IAuthRepository
    {
        Task<AccountDTO> LoginAsync(LoginRequestDTO userLogin);
        Task<RegisterRequestDTO> RegisterAsync(RegisterRequestDTO userRegister);
        Task<bool> CheckUserNameAsync(string userName);
    }
}
