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
     /*   [HttpPatch]
        public async Task<ActionResult<ClinicAdminModel>> UpdateClinic(int id, ClinicAdminModel updatedModel)
        {
            var existingClinic = await _healthcareContext.SHclnClinicAdmin.FindAsync(id);

            if (existingClinic == null)
            {
                return NotFound(); // Return HTTP 404 Not Found if clinic with the given ID is not found
            }

            // Update properties of the existing clinic
            existingClinic.ClinicName = updatedModel.ClinicName;
            existingClinic.ClinicPhoneNumber = updatedModel.ClinicPhoneNumber;
            // Update other properties as needed

            _healthcareContext.Entry(existingClinic).State = EntityState.Modified;
            await _healthcareContext.SaveChangesAsync();

            return Ok(existingClinic); // Return HTTP 200 OK with the updated clinic model
        }*/

        [HttpPatch]

        public async Task<ClinicAdminModel> UpdateClinic(ClinicAdminModel updatedModel)
        {
            _healthcareContext.Entry(updatedModel).State = EntityState.Modified;
            await _healthcareContext.SaveChangesAsync();

            return updatedModel;
        }

        /*[HttpPatch]
        //[Authorize]
        [Route("UdateEmployee/{EmpId}")]

        public async Task<Employee> UpdateEmployee(Employee objEmployee)
        {
            try
            {
                _employeeDbContext.Entry(objEmployee).State = EntityState.Modified;
                await _employeeDbContext.SaveChangesAsync();

            }
            catch
            {
                Console.WriteLine("Update error");
            }
            return objEmployee;
        }*/

        [HttpPost]
        public async Task<IActionResult> GetClinic(ClinicAdminModel model)
        {
            
            return View("GetClinic");
        }

        public async Task<ActionResult> HandleForm(string clinicID, string clinicName , string buttonType)
        {
            ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(_healthcareContext);

            if(buttonType == "select")
            {
                var clinicreg = await business.GetClinicRegister(clinicID, clinicName);

                if(clinicreg != null)
                {
                    ViewBag.ClinicRegistration = clinicreg;
                    return View("GetClinic");
                }
                else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs.";
                    return View("GetClinic");
                }
            }
            return View();
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
