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
        public async Task<IActionResult> CreateOrUpdate(PatientRegistrationModel model,string buttonType, string patientID, string facilityID)
        {
            var schedule = new BusinessClassRegistration(_healthcareContext);
            var patient = await schedule.GetPatientObjectiveSubmit(patientID, facilityID);

            // Pass necessary view data
            ViewData["bldgrpid"] = schedule.GetBloodGroup();
            ViewData["Facid"] = schedule.GetFacilityid();


            await _healthcareContext.SaveChangesAsync();
            // Check if the patientID and facilityID are provided
            if (!string.IsNullOrEmpty(patientID) && !string.IsNullOrEmpty(facilityID))
            {
                // Retrieve existing patient data if available
                var existingPatient = await _healthcareContext.SHPatientRegistration.FindAsync(patientID);
            if (existingPatient != null)
            {
                if(buttonType == "getPatientBtn")
                      
                    return View("PatientRegister",existingPatient);

                // Update existing patient data
                existingPatient.FacilityID = model.FacilityID;
                existingPatient.FirstName = model.FirstName;
                existingPatient.MidName = model.MidName;
                existingPatient.LastName = model.LastName;
                existingPatient.FullName = model.FullName;
                existingPatient.Initial = model.Initial;
                existingPatient.Prefix = model.Prefix;
                existingPatient.Dob = model.Dob;
                existingPatient.Age = model.Age;
                existingPatient.Gender = model.Gender;
                existingPatient.BloodGroup = model.BloodGroup;
                existingPatient.PhoneNumber = model.PhoneNumber;
                existingPatient.MaritalStatus = model.MaritalStatus;
                existingPatient.Address1 = model.Address1;
                existingPatient.Address2 = model.Address2;
                existingPatient.Country = model.Country;
                existingPatient.City = model.City;
                existingPatient.State = model.State;
                existingPatient.Pin = model.Pin;
                existingPatient.IDPrfName = model.IDPrfName;
                existingPatient.IDPrfNumber = model.IDPrfNumber;
                existingPatient.CnctPrsnName = model.CnctPrsnName;
                existingPatient.Rlnpatient = model.Rlnpatient;
                existingPatient.EmgcyCntNum = model.EmgcyCntNum;
                existingPatient.lastUpdatedDate = DateTime.Now.ToString();
                existingPatient.lastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.Entry(existingPatient).State = EntityState.Modified;
            }
            else
            {
                // Create new patient data
                model.PatientID = patientID;
                model.FacilityID = facilityID;
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.SHPatientRegistration.Add(model);
            }

        }

            // Fetch patient data for the provided patientID and facilityID
           
            ViewBag.Message = "Saved Successfully";
            // Return the view with the patient data
            return View("PatientRegister", patient ?? new PatientRegistrationModel());


          
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
                if (availableSchedules.Any())
                {
                    ViewBag.Schedules = availableSchedules;
                }
                else
                {
                    ViewBag.NoSlotsMessage = "No slots available";
                }
                return View("PatientScheduling",model);

            }


            else if (action == "SaveSchedule")
            {
                if (selectedSchedules == null || !selectedSchedules.Any())
                {
                    ViewBag.ErrorMessage = "No slot is selected! Please select a slot";
                    var availableSchedules = schedule.GetAvailableSchedules(model.StaffID, model.FacilityID, model.Date);
                    ViewBag.Schedules = availableSchedules;
                    return View(model);
                }
                schedule.SaveSelectedSchedules(model.PatientID, selectedSchedules);
                ViewBag.Message = "Slot Confirmed Successfully";
                return View("PatientScheduling",model);
            }


            else if (action == "GetPatientSchedule")
            {

                var patientslots = schedule.GetPatientSlot(model.PatientID, model.FacilityID, model.Date, model.StaffID);
                if (patientslots.Any())
                {
                    ViewBag.Schedules = patientslots;
                }
                else
                {
                    ViewBag.NoSlotsMessage = "No slots available";
                }
                return View("PatientScheduling",model);

               
            }

            else if (action == "CancelSchedule")
            {
                if (selectedSchedules == null || !selectedSchedules.Any())
                {
                    ViewBag.ErrorMessage = "No slot is selected! Please select a slot";
                    var availableSchedules = schedule.GetAvailableSchedules(model.StaffID, model.FacilityID, model.Date);
                    ViewBag.Schedules = availableSchedules;
                    return View(model);
                }

                schedule.CancelScheduleSlot(model.PatientID, selectedSchedules);
                ViewBag.Message = "Slot Cancel Successfully";
                return View("PatientScheduling",model);
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
