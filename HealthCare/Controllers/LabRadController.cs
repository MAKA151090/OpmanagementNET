using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class LabRadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestCreation()
        {
            return View();
        }
        public IActionResult UpdateTestResults()
        {
            return View();
        }
        public IActionResult PrintTestResults()
        
        {
            return View();
        }
        public IActionResult RadiologyCreation()
        {
            return View();
        }
        public IActionResult UpdateRadiologyResults()
        {
            return View();
        }
        public IActionResult PrintRadiologyResults()
        {
            return View();
        }
    }
}
