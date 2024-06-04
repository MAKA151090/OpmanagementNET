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

        public async Task<IActionResult> GetPatient()
        {
            return View();
        }

        public async Task<IActionResult> PatSearch(PatientRegistrationModel patient)
        {
            var patSearchResult = (from pat in _healthcareContext.SHPatientRegistration
                                   where pat.FullName.Contains(patient.FullName) select pat).ToList();

            ViewData["PatSearch"] = patSearchResult;


            return View("PatientRegister", patient);
        }

        public async Task<ActionResult> HandleReg(string patientID, string FacilityID, string buttonType)
        {
            BusinessClassRegistration business = new BusinessClassRegistration (_healthcareContext);


            if (buttonType == "submit")
            {
                var patientReg = await business.GetPatientObjectiveSubmit(patientID, FacilityID);

                if (patientReg != null)
                {
                    return View("PatientRegister", patientReg);
                }
                else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs.";
                    return View("CreateGet");
                }
            }
            return View();
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
