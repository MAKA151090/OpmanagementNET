using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        private HealthcareContext _healthcareContext;

        public ErrorController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }
        public IActionResult Error()
        {
           //Record error from context session
            WebErrorsModel webErrors = new WebErrorsModel();
            webErrors.ErrDateTime = DateTime.Now.ToString();
            webErrors.ErrodDesc = HttpContext.Session.GetString("ErrorMessage").ToString();
            webErrors.Username = User.Claims.First().Value.ToString();
            webErrors.ScreenName = HttpContext.Session.GetString("ScreenName").ToString();
            webErrors.MachineName = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            //Saving error into database
            _healthcareContext.SHWebErrors.Add(webErrors);
            _healthcareContext.SaveChangesAsync();
            
            return View(webErrors);
        }
    }
}
