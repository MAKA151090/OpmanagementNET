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
            var existingClinic = await _healthcareContext.SHclnClinicAdmin.FindAsync(model.ClinicId);

            if (existingClinic != null)
            {
                existingClinic.ClinicId = model.ClinicId;
                existingClinic.ClinicName = model.ClinicName;
                existingClinic.ClinicAddress = model.ClinicAddress;
                existingClinic.City = model.City;
                existingClinic.State = model.State;
                existingClinic.PostalCode = model.PostalCode;
                existingClinic.ClinicPhoneNumber = model.ClinicPhoneNumber;
                existingClinic.ClinicEmailAddress = model.ClinicEmailAddress;
                existingClinic.FromHour = model.FromHour;
                existingClinic.ToHour = model.ToHour;
                existingClinic.lastUpdatedDate = DateTime.Now.ToString();
                existingClinic.lastUpdatedUser = "Myself";

                _healthcareContext.Entry(existingClinic).State = EntityState.Modified;
            }
            else
            {

                //BusinessClass businessClass = new BusinessClass(_healthcareContext);
                //try
                //{

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                _healthcareContext.SHclnClinicAdmin.Add(model);
                
            }
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
        public async Task<IActionResult> GetClinic()
        {

            return View();
        }

        public async Task<ActionResult> ClinicAdmin(string clinicid, string clinicname, string buttonType)
        {

            {
                ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(_healthcareContext);
                if (buttonType == "submit")
                {
                    var Clinic = await business.GetClinicRegister(clinicid, clinicname);

                    if (Clinic != null)
                    {
                        clinicid = Clinic.ClinicId;
                        clinicname = Clinic.ClinicName;

                        return View("ClinicRegistration", Clinic);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "No data found for the entered IDs.";
                        return View("CreateGet");
                    }
                }    
            }
            return View();
        }
            public async Task<BloodGroupModel> BloodGroupList(BloodGroupModel model)

        {
            var existingBloodGroup = await _healthcareContext.SHclnBloodGroup.FindAsync(model.IntBg_Id,model.BloodGroup);

            if (existingBloodGroup != null)
            {
                existingBloodGroup.IntBg_Id =   model.IntBg_Id;
                existingBloodGroup.BloodGroup = model.BloodGroup;
                existingBloodGroup.lastUpdatedUser = "Admin";
                existingBloodGroup.lastUpdatedDate = DateTime.Now.ToString();
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                // Retrieve the list of blood groups from the database

                _healthcareContext.SHclnBloodGroup.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            return model;
            // Pass the list to the view
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
