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
        public async Task<IActionResult> AddClinic(ClinicAdminModel model)
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

            ViewBag.Message = "Saved Successfully";
            return View("ClinicRegistration",model);
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
                        return View("GetClinic");
                    }
                }    
            }
            return View();
        }
            public async Task<IActionResult> BloodGroupList(BloodGroupModel model)

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


            ViewBag.Message = "Saved Successfully";
            return View("BloodGroupAdministration", model);
            // Pass the list to the view
        }

        public async Task<IActionResult> AddDoctor(DoctorAdminModel model)
        {
            var existingDoctor = await _healthcareContext.SHclnDoctorAdmin.FindAsync(model.DoctorID);

            if (existingDoctor != null)
            {
                existingDoctor.DoctorID = model.DoctorID;
                existingDoctor.FirstName = model.FirstName;
                existingDoctor.LastName = model.LastName;
                existingDoctor.FullName = model.FullName;
                existingDoctor.Gender = model.Gender;
                existingDoctor.DateofBirth = model.DateofBirth;
                existingDoctor.Address1 = model.Address1;
                existingDoctor.Address2 = model.Address2;
                existingDoctor.PhoneNumber = model.PhoneNumber;
                existingDoctor.EmailId = model.EmailId;
                existingDoctor.Nationality = model.Nationality;
                existingDoctor.MedialLicenseNumber = model.MedialLicenseNumber;
                existingDoctor.lastUpdatedDate = DateTime.Now.ToString();
                existingDoctor.lastUpdatedUser = "Admin";
            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                _healthcareContext.SHclnDoctorAdmin.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("DoctorRegistration", model);

        }

        [HttpPost]

        public async Task<IActionResult> GetDoctor()
        {
            return View();
        }

        public async Task<ActionResult> Doctoradmin(string doctorid , string buttonType)
        {
            ClinicAdminBusinessClass businessClass = new ClinicAdminBusinessClass(_healthcareContext);
            if (buttonType == "submit")
            {
               var doctor = await businessClass.GetDoctorRegister(doctorid);
                if (doctor != null) 
                {
                    doctorid = doctor.DoctorID;

                    return View("DoctorRegistration" , doctor);
                }
               else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs.";
                    return View(GetDoctor);
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
