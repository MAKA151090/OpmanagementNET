using HealthCare.Business;
using HealthCare.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using DocumentFormat.OpenXml.Wordprocessing;


namespace HealthCare.Controllers
{
    [Authorize]
    public class PatientRegistrationController : Controller
    {
        private HealthcareContext _healthcareContext;

        public PatientRegistrationController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;

        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientRegistrationModel model)
        {
         
            var exitingpatient = await _healthcareContext.SHPatientRegistration.FindAsync(model.PatientID);
            if (exitingpatient != null)
            {
                exitingpatient.PatientID = model.PatientID;
                exitingpatient.FacilityID = model.FacilityID;
                exitingpatient.FirstName = model.FirstName;
                exitingpatient.MidName = model.MidName;
                exitingpatient.LastName = model.LastName;
                exitingpatient.FullName = model.FullName;
                exitingpatient.Initial = model.Initial;
                exitingpatient.Prefix = model.Prefix;
                exitingpatient.Dob = model.Dob;
                exitingpatient.Age = model.Age;
                exitingpatient.Gender = model.Gender;
                exitingpatient.BloodGroup = model.BloodGroup;
                exitingpatient.PhoneNumber = model.PhoneNumber;
                exitingpatient.MaritalStatus = model.MaritalStatus;
                exitingpatient.Address1 = model.Address1;
                exitingpatient.Address2 = model.Address2;
                exitingpatient.Country = model.Country;
                exitingpatient.City = model.City;
                exitingpatient.State = model.State;
                exitingpatient.Pin = model.Pin;
                exitingpatient.IDPrfName = model.IDPrfName;
                exitingpatient.IDPrfNumber = model.IDPrfNumber;
                exitingpatient.CnctPrsnName = model.CnctPrsnName;
                exitingpatient.Rlnpatient = model.Rlnpatient;
                exitingpatient.EmgcyCntNum = model.EmgcyCntNum;
                exitingpatient.lastUpdatedDate = DateTime.Now.ToString();
                exitingpatient.lastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.Entry(exitingpatient).State = EntityState.Modified;


            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.SHPatientRegistration.Add(model);
            }
                await _healthcareContext.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";

              BusinessClassRegistration schedule = new BusinessClassRegistration(_healthcareContext);
            ViewData["bldgrpid"] = schedule.GetBloodGroup();
            ViewData["Facid"] = schedule.GetFacilityid();

            return View("PatientRegister" , model);           

        }


        public async Task<IActionResult> GetPatient(string patientID, string facilityID)
        {

            BusinessClassRegistration schedule = new BusinessClassRegistration(_healthcareContext);
               var patient = await schedule.GetPatientObjectiveSubmit(patientID, facilityID);
            if (patient != null)
            {
                ViewData["bldgrpid"] = schedule.GetBloodGroup();
                ViewData["Facid"] = schedule.GetFacilityid();
                return View("PatientRegister", patient);
            }

            return View("PatientRegister");
        }

        [HttpPost]
        public async Task<IActionResult> PatientScheduling(DoctorScheduleModel model, string action, List<string> selectedSchedules,string staffID,string FacilityID,string Date,String patientID)
        {
            BusinessClassRegistration schedule = new BusinessClassRegistration(_healthcareContext);
            ViewData["FacDPD"] = schedule.GetFacilityID();
            ViewData["patIDDPD"] = schedule.GetpatientIDDPD();
            ViewData["staffDPD"] = schedule.GetStaffDropDown();


            if (action == "GetSchedule")
            {
                var availableSchedules = schedule.GetAvailableSchedules(model.StaffID, model.FacilityID, model.Date);
                ViewBag.Schedules = availableSchedules;
                return View(model);
            }
            else if (action == "SaveSchedule" && selectedSchedules != null && selectedSchedules.Any())
            {
                schedule.SaveSelectedSchedules(model.PatientID, selectedSchedules);
                ViewBag.Message = "Slot Confirmed Successfully";
                return View("PatientScheduling");
            }
            else if (action == "GetPatientSchedule")
            {
                var patientslots = schedule.GetPatientSlot(model.PatientID, model.FacilityID, model.Date, model.StaffID);
                ViewBag.Schedules = patientslots;
                return View(model);
            }

            else if (action == "CancelSchedule")
            {
                schedule.CancelScheduleSlot(model.PatientID, selectedSchedules);
                ViewBag.Message = "Slot Cancel Successfully";
                return View("PatientScheduling");
            }

           
            return View(model);

           

        }



        

       public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientRegister()
        {
            BusinessClassRegistration schedule = new BusinessClassRegistration(_healthcareContext);
            ViewData["bldgrpid"] = schedule.GetBloodGroup();
            ViewData["Facid"] = schedule.GetFacilityid();
            return View();
        }

        
        public IActionResult PatientScheduling()
        {
            BusinessClassRegistration schedule = new BusinessClassRegistration(_healthcareContext);
            ViewData["FacDPD"] = schedule.GetFacilityID();
            ViewData["patIDDPD"] = schedule.GetpatientIDDPD();
            ViewData["staffDPD"] = schedule.GetStaffDropDown();
            return View();
        }
    }
}
