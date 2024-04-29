using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class PatientRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
