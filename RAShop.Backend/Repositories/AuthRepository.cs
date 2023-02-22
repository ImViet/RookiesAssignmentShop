using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RAShop.Backend.Interfaces;
using RAShop.Backend.Models;
using RAShop.Shared.DTO.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RAShop.Backend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
         RoleManager<AppRole> roleManager, IConfiguration config, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _mapper = mapper;
        }
        public async Task<AccountDTO> LoginAsync(LoginRequestDTO userLogin)
        {
            var user = await _userManager.FindByNameAsync(userLogin.UserName);
            if (user == null)
            {
                throw new Exception("Cannot find this user");
            }
            var result = await _signInManager.PasswordSignInAsync(user, userLogin.Password, true, true);
            if (!result.Succeeded)
            {
                return null;
            }
            string token = CreateToken(user);
            var account = _mapper.Map<AccountDTO>(user);
            account.Token = token;
            return account;
        }

        public async Task<RegisterRequestDTO> RegisterAsync(RegisterRequestDTO userRegister)
        {
            var user = _mapper.Map<AppUser>(userRegister);
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, userRegister.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            return userRegister;
        }
        private string CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserName", user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
