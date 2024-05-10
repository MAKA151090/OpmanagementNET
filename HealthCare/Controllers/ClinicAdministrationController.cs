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

        public IActionResult BloodGroupAdministration()
        {
            return View();
        }
        public IActionResult RollAccess()
        {
            return View();
        }
        public IActionResult DoctorRegistration()
        {
            return View();
        }
        public IActionResult DoctorSchedule()
        {
            return View();
        }

    }
}
