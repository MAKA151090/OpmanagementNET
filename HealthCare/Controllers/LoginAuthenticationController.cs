using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers
{
   
    public class LoginAuthenticationController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "ClinicAdministration");

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "LoginAuthentication");
        }

        [ResponseCache(Duration =0, Location = ResponseCacheLocation.None , NoStore = true)]


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel modellogin)
        {
            if (modellogin.Email == "user@example.com" &&
                modellogin.Password == "1231")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, modellogin.Email),
                    new Claim("OtherProperties", "Example Role")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
            CookieAuthenticationDefaults.AuthenticationScheme
            );
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "ClinicAdministration");
            }
            ViewData["ValidateMessage"] = "user not found";

            return View();

        }
    }
}


