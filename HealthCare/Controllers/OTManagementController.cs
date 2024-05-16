using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class OTManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OTScheduling()
        {
            return View();
        }
        public IActionResult OTConformation()
        {
            return View();
        }
        public IActionResult OTNotes()
        {
            return View();
        }
        public IActionResult OTSummary()
        {
            return View();
        }
    }
}
