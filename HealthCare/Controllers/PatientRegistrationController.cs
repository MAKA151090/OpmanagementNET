using HealthCare.Context;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class PatientRegistrationController : Controller
    {
        private HealthcareContext _healthcareContext;

        public PatientRegistrationController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        [HttpPost]

        public async Task<PatientRegistrationModel> Create(PatientRegistrationModel model)
        {
            model.lastUpdatedDate = DateTime.Now.ToString();
            model.lastUpdatedUser = "Myself";
            _healthcareContext.SHPatientRegistration.Add(model);
             await _healthcareContext.SaveChangesAsync();

            return model;

        }

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
