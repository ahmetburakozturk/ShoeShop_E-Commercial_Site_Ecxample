using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ShoeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userManager;

        public UsersController(IUserService userService)
        {
            _userManager = userService;
        }


        [HttpPost]
        public IActionResult Login(UserDto userDto)
        {
            var user = _userManager.ValidateUser(userDto.Email, userDto.Password);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.StreetAddress, user.Address),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ShoeShop-secret-info"));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

                var token = new JwtSecurityToken(
                    issuer:"turkcell.bootcamp",
                    audience:"turkcell.bootcamp",
                    claims:claims,
                    notBefore:DateTime.Now,
                    expires:DateTime.Now.AddMinutes(25),
                    signingCredentials:credential
                    );


                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest(new { message = "Hatalı Kullanıcı Adı Veya Şifre!" });
        }
    }
}
