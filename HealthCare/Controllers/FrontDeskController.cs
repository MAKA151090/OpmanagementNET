using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class FrontDeskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpChecking()
        {
            return View();
        }
        public IActionResult IpRegistration()
        {
            return View();
        }
        public IActionResult OpDischarge()
        {
            return View();
        }
        
    }
}
