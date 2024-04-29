using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class PatientRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientRegister()
        {
            return View();
        }
    }
}
