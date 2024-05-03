using HealthCare.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    public class ClinicAdministrationController : Controller
    {
        private readonly HealthcareContext _healthcareContext;

        public ClinicAdministrationController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        [HttpPost]

        public async Task<ClinicAdminModel> AddClinic(ClinicAdminModel model)
        {
           
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                _healthcareContext.SHclnClinicAdmin.Add(model);
                await _healthcareContext.SaveChangesAsync();
           
            return model;
        }
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
