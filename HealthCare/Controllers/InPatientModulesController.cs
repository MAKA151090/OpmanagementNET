using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
    public class InPatientModulesController : Controller
    {

        private HealthcareContext _healthcareContext;

        public InPatientModulesController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }


        public async Task<IActionResult> GetPatientAdmission(InpatientAdmissionModel model)
        {
            var existingPatientAdmission = await _healthcareContext.SHInpatientAdmission.FindAsync(model.PatientID, model.CaseID);

            if (existingPatientAdmission != null)
            {
                existingPatientAdmission.Location = model.Location;
                existingPatientAdmission.PatientID = model.PatientID;
                existingPatientAdmission.CaseID = model.CaseID;
                existingPatientAdmission.ConsultDoctorID = model.ConsultDoctorID;
                existingPatientAdmission.DutyDoctorID = model.DutyDoctorID;
                existingPatientAdmission.ReferredByDoctorID = model.ReferredByDoctorID;
                existingPatientAdmission.BedID = model.BedID;
                existingPatientAdmission.Purpose = model.Purpose;
                existingPatientAdmission.AdditionConsultDoctorID = model.AdditionConsultDoctorID;
                existingPatientAdmission.ConsultantDepartmentID = model.ConsultantDepartmentID;
                existingPatientAdmission.AttenderName = model.AttenderName;
                existingPatientAdmission.AttenderContact = model.AttenderContact;
                existingPatientAdmission.AttenderEmail = model.AttenderEmail;
                existingPatientAdmission.DocInstruction = model.DocInstruction;
                existingPatientAdmission.InpatientType = model.InpatientType;
                existingPatientAdmission.AdmissionDate = model.AdmissionDate;
                existingPatientAdmission.lastupdatedDate = DateTime.Now.ToString();
                existingPatientAdmission.lastUpdatedUser = "Admin";
                existingPatientAdmission.lastUpdatedMachine = "Lap";

                _healthcareContext.Entry(existingPatientAdmission).State = EntityState.Modified;
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                model.lastUpdatedMachine = "Lap";
                _healthcareContext.SHInpatientAdmission.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";
            return View("InPatientAdmission", model);

        }

       public async Task<IActionResult> GetInpatientViewResult(InpatientObservationModel Model, string buttonType)
        {
            BusinessClassInpatient ObjViewINP = new BusinessClassInpatient(_healthcareContext);
            
            if(buttonType == "get") 
            {
                var result = await ObjViewINP.GetInpatientObs(Model.BedNoID,Model.PatientID,Model.ObservationID);
                return View("InPatientObservation", result);

            }
            else if (buttonType == "save")
            {
                var objadd = await _healthcareContext.SHipmInpatientobservation.FindAsync(Model.BedNoID, Model.PatientID);
                objadd.ObservationID = Model.ObservationID;
                objadd.NurseID=Model.NurseID;
                objadd.DateTime=Model.DateTime;
                objadd.lastupdatedDate=DateTime.Now.ToString();
                objadd.lastUpdatedUser = "Kumar";
                objadd.lastUpdatedMachine = "Lap";
                await _healthcareContext.SaveChangesAsync();
            }
          
            ViewBag.Message = "Saved Successfully";
            return View("InPatientObservation", Model);

        }
        [HttpPost]
        public async Task<IActionResult> InPatientCaseSheet(InPatientCaseSheetModel model)
        {
            var existingInPatientCaseSheet = await _healthcareContext.SHipmInPatientCaseSheet.FindAsync(model.StrPatientId,model.StrCaseId);

            if (existingInPatientCaseSheet != null)
            {
                existingInPatientCaseSheet.StrPatientId = model.StrPatientId;
                existingInPatientCaseSheet.StrCaseId = model.StrCaseId;
                existingInPatientCaseSheet.StrBedId = model.StrBedId;
                existingInPatientCaseSheet.StrPostMedHistory = model.StrPostMedHistory;
                existingInPatientCaseSheet.StrAllergicTo = model.StrAllergicTo;
                existingInPatientCaseSheet.StrHeight = model.StrHeight;
                existingInPatientCaseSheet.StrWeight = model.StrWeight;
                existingInPatientCaseSheet.StrDiagnosis = model.StrDiagnosis;
                existingInPatientCaseSheet.StrTreatment = model.StrTreatment;
                existingInPatientCaseSheet.LastupdatedDate = DateTime.Now.ToString();
                existingInPatientCaseSheet.LastupdatedUser = "Admin";
                existingInPatientCaseSheet.LastUpdatedMachine = "Lap";

                _healthcareContext.Entry(existingInPatientCaseSheet).State = EntityState.Modified;
            }
            else
            {
                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = "Admin";
                model.LastUpdatedMachine = "Lap";
                _healthcareContext.SHipmInPatientCaseSheet.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";
            return View("InPatientCaseSheet", model);

        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InPatientAdmission()
        {
            return View();
        }

        public IActionResult WardManagement()
        {
            return View();
        }

        public IActionResult InPatientCaseSheet()
        {
            return View();
        }

        public IActionResult InPatientDischarge()
        {
            return View();
        }
        public IActionResult InPatientObservation()
        {
            return View();
        }
        
    }
}

