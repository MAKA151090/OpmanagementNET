using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class PatientExaminationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientObjectiveData()
        {
            return View();
        }
        public IActionResult PatientHealthHistory()
        {
            return View();
        }
        public IActionResult PatientFamilyHistory()
        {
            return View();
        }
        public IActionResult PatientVisitIntoDocument()
        {
            return View();
        }
        public IActionResult PatientExamination()
        {
            return View();
        }
        

    }
}
