using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Interfaces;
using RAShop.Shared.DTO.Auth;

namespace RAShop.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> LoginAsync(LoginRequestDTO userLogin)
        {
            var account = await _authRepository.LoginAsync(userLogin);
            if (account == null)
            {
                return BadRequest("Username or Password is incorrect. Please try again");
            }
            return Ok(account);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterAsync([FromForm] RegisterRequestDTO userRegister)
        {
            var resultCheckUserName = await _authRepository.CheckUserNameAsync(userRegister.UserName);
            if (!resultCheckUserName)
            {
                return BadRequest("UserName already exists");
            }
            if (userRegister.Password != userRegister.ConfirmPassword)
            {
                return BadRequest("Password is incorrect with confirmpassword");
            }
            var result = await _authRepository.RegisterAsync(userRegister);
            if (result == null)
            {
                return BadRequest("Register is unsuccessful");
            }
            return Ok(userRegister);
        }
        [HttpPost]
        public async Task<IActionResult> CheckUserIsNotAvailableAsync([FromForm] string userName)
        {
            var result = await _authRepository.CheckUserNameAsync(userName);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }
    }
}
