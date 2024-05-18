using HealthCare.Business;
using HealthCare.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


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
                exitingpatient.ClinicID = model.ClinicID;
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
                exitingpatient.lastUpdatedUser = "Myself";
                _healthcareContext.Entry(exitingpatient).State = EntityState.Modified;


            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                _healthcareContext.SHPatientRegistration.Add(model);
            }
                await _healthcareContext.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";
            return View("PatientRegister" , model);

            

        }

        public async Task<IActionResult> GetPatient()
        {
            return View();
        }

        public async Task<ActionResult> HandleReg(string patientID, string clinicID, string buttonType)
        {
            BusinessClassRegistration business = new BusinessClassRegistration (_healthcareContext);


            if (buttonType == "submit")
            {
                var patientReg = await business.GetPatientObjectiveSubmit(patientID, clinicID);

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
        public async Task<PatientScheduleModel> PatientScedule(PatientScheduleModel model)
        {
            model.lastUpdatedDate = DateTime.Now.ToString() ;
            model.lastUpdatedUser = "Admin";
            _healthcareContext.SHPatientSchedule.Add(model);
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
        public IActionResult PatientScheduling()
        {
            return View();
        }
    }
}
