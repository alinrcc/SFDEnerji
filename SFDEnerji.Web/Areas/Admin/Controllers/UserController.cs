using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SFDEnerji.Models;
using SFDEnerji.Models.DTOs;
using SFDEnerji.Repository.Shared.Abstract;
using System.Security.Claims;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class UserController : ControllerBase
    {
     

        public UserController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
         
        }
        
        public IActionResult Index()
        {
            
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            AppUser user = unitOfWork.Users.GetFirstOrDefault(u=>u.Name==loginDto.UserName && u.Password==loginDto.Password);
            if (user == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");

            }
            else
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name));  
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent=loginDto.RememberMe});

                return RedirectToAction("Index", "Dashboard");
               
            }


            
        }


    }
}
