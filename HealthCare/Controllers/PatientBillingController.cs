using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class PatientBillingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientBilling()
        {
            return View();
        }
    }
}
