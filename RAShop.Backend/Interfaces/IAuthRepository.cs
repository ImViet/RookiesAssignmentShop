using RAShop.Shared.DTO.Auth;

namespace RAShop.Backend.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> Login(LoginRequestDTO userLogin);
        Task<bool> Register(RegisterRequestDTO userRegister);
    }
}
