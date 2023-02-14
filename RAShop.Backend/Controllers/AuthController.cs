﻿using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<AccountDTO>> LoginAsync([FromBody] LoginRequestDTO userLogin)
        {
            var account = await _authRepository.LoginAsync(userLogin);
            if(account == null)
            {
                return BadRequest("Username or Password is incorrect. Please try again");
            }
            return Ok(account);
        }
        [HttpPost]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterRequestDTO userRegister)
        {
            var result = await _authRepository.RegisterAsync(userRegister);
            if(!result)
            {
                return BadRequest("Register is unsuccessful");
            }
            return Ok();
        }
    }
}
