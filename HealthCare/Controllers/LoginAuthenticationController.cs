using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using HealthCare.Context;
using Microsoft.EntityFrameworkCore;
using HealthCare.Business;
using Newtonsoft.Json;

namespace HealthCare.Controllers
{
   
    public class LoginAuthenticationController : Controller
    {
        private HealthcareContext _healthcareContext;

        public LoginAuthenticationController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "ClinicAdministration");

            return View();
        }
        public IActionResult Index()
        {
            if (TempData["RollAccess"] != null)
            {
                var rollAccess = JsonConvert.DeserializeObject<List<RollAccessModel>>(TempData["RollAccess"].ToString());
                ViewData["RollAccess"] = rollAccess;
            }

            return View();
        }
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "LoginAuthentication");
        }

        [ResponseCache(Duration =0, Location = ResponseCacheLocation.None , NoStore = true)]


        [HttpPost]
        public async Task<IActionResult> Login(StaffAdminModel model ,string screenid,string rollid)
        {


            var login = await _healthcareContext.SHclnStaffAdminModel.FirstOrDefaultAsync(x => x.StrUserName == model.StrUserName);

            if (login != null)
            {
                if (login.StrPassword == model.StrPassword)
                {
                    login.StrUserName = model.StrUserName;

                    login.StrPassword = model.StrPassword;

                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, model.StrUserName),
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

                    BusinessClassRegistration Busreg = new BusinessClassRegistration(_healthcareContext);
                    
                    var rolldetail = Busreg.GetRoll(model.StrUserName);

                    // Set TempData with the filtered roll details
                    TempData["RollAccess"] = JsonConvert.SerializeObject(rolldetail); ;


                    return RedirectToAction("Index", "ClinicAdministration");
                }

            }
            ViewBag.Message = " Username Not Found";
            
            return View();

        }
     
    }
}


