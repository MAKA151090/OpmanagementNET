using Azure;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    public class ClinicAdministrationController : Controller
    {
      
        private HealthcareContext _healthcareContext;

        public ClinicAdministrationController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        [HttpPost]
        public async Task<ClinicAdminModel> AddClinic(ClinicAdminModel model)
        {
            //BusinessClass businessClass = new BusinessClass(_healthcareContext);
            //try
            //{

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                _healthcareContext.SHclnClinicAdmin.Add(model);
                await _healthcareContext.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
                //businessClass = new BusinessClass(_healthcareContext);
                //businessClass.ErrorHandlers("ClinicRegistraion", ex.Message.ToString());
            //}
            return model;
        }
        [HttpPost]
        public async Task<IActionResult> GetClinic(ClinicAdminModel model)
        {
            


            return View("GetClinic");
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
