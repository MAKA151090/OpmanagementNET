using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class ClinicAdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClinicRegistration()
        {
            return View();
        }

        public IActionResult BloodGroupMaster()
        {
            return View();
        }
    }
}
