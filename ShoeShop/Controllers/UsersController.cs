using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoeShop.Businness.Abstract;
using ShoeShop.Dtos;

namespace ShoeShopWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userManager;

        public UsersController(IUserService userService)
        {
            _userManager = userService;
        }

        public IActionResult Login(string returnURL)
        {
            ViewBag.ReturnURL = returnURL;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto, string returnURL)
        {
            returnURL = returnURL+"/1";
            if (ModelState.IsValid)
            {
                var user = _userManager.ValidateUser(userDto.Email,userDto.Password);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Name,user.FullName),
                            new Claim(ClaimTypes.Role,user.Role),
                            new Claim(ClaimTypes.StreetAddress, user.Address),
                            new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                        };
                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        if (Url.IsLocalUrl(returnURL))
                        {
                            return Redirect(returnURL);
                        }
                }
                ModelState.AddModelError("Login", "kullanıcı adı veya şifre hatalı!");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Details(string username)
        {
            var userDto = _userManager.GetUserByName(username);
            return View(userDto);
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl=returnUrl;
            return View();
        }
    }
}
