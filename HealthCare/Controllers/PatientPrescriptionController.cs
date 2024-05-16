using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class PatientPrescriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientEPrescription()
        {
            return View();
        }
        public IActionResult PatientEPrescriptionPrint()
        {
            return View();
        }

    }
}
