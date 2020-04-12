using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TecLibras.Services.Api.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TecLibras.Services.Api.Models;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Repositories;

namespace TecLibras.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly AppSettings _appSettings;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserApplicationRepository userApplicationRepository,
            IOptions<AppSettings> appSettings) : base()
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _userApplicationRepository = userApplicationRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userRegistration);
            }

            var user = new ApplicationUser
            {
                Firstname = userRegistration.Firstname,
                Lastname = userRegistration.Lastname,
                UserName = userRegistration.Username,
                Email = userRegistration.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {

                }

                return Response(userRegistration);
            }

            await _signInManager.SignInAsync(user, false);
            var token = await GenerateJwt(userRegistration.Email);

            LoggedinReponse loggedin = new LoggedinReponse()
            {
                Success = true,
                UserName = userRegistration.Username,
                Email = userRegistration.Email,
                UserId = user.Id,
                Token = token
            };

            return Response(loggedin);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userLogin);
            }

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                var userApplication = _userApplicationRepository.GetByUserName(userLogin.Email);
                var token = await GenerateJwt(userApplication.Email);
                LoggedinReponse loggedin = new LoggedinReponse()
                {
                    Success = true,
                    UserName = userApplication.UserName,
                    Email = userApplication.Email,
                    UserId = userApplication.Id,
                    Token = token
                };

                return Response(loggedin);
            }

            return Response(new LoggedinReponse()
            {
                Success = false
            });
        }

        private async Task<string> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }

    public class LoggedinReponse
    {
        public bool Success { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
