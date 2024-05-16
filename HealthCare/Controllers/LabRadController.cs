using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class LabRadController : Controller
    {
        private HealthcareContext GetlabData;

        public LabRadController(HealthcareContext GetlabData)
        {
            this.GetlabData = GetlabData;
        }

        [HttpPost]
        public async Task<IActionResult> TestCreation(PatientTestModel pPatientTest)
        {
            //PatientTestModel = new PatientTestModel();
            var existingPatientTest = await GetlabData.SHPatientTest.FindAsync(pPatientTest.PatientID, pPatientTest.ClinicID, pPatientTest.TestID);
            if (existingPatientTest != null)
            {

                existingPatientTest.PatientID = pPatientTest.PatientID;
                existingPatientTest.ClinicID = pPatientTest.ClinicID;
                existingPatientTest.TestID = pPatientTest.TestID;
                existingPatientTest.TestResult = pPatientTest.TestResult;
                existingPatientTest.TestDateTime = pPatientTest.TestDateTime;
                existingPatientTest.TsampleCltDateTime = pPatientTest.TsampleCltDateTime;
                existingPatientTest.TsampleClt = pPatientTest.TsampleClt;
                existingPatientTest.ExptRsltDateTime = pPatientTest.ExptRsltDateTime;
                existingPatientTest.ResultPublish = pPatientTest.ResultPublish;
                existingPatientTest.ReferDate = pPatientTest.ReferDate;
                existingPatientTest.ReferDocID = pPatientTest.ReferDocID;
                existingPatientTest.ResultDate = pPatientTest.ResultDate;
                existingPatientTest.lastUpdatedDate = DateTime.Now.ToString();
                existingPatientTest.lastUpdatedUser = "Myself";
                existingPatientTest.lastUpdatedMachine = "Lap";
            }
            else
            {
                pPatientTest.lastUpdatedDate = DateTime.Now.ToString();
                pPatientTest.lastUpdatedUser = "Myself";
                pPatientTest.lastUpdatedMachine = "Lap";
                GetlabData.SHPatientTest.Add(pPatientTest);

            }
            await GetlabData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("TestCreation", pPatientTest);


        }
        public async Task<IActionResult> ViewResult(PatientViewResultModel Model)
        {
            BusinessClassExamination ObjBusTestResult = new BusinessClassExamination(GetlabData);

            if (ObjBusTestResult!=null)
            {
                var testResults = await ObjBusTestResult.GetTestResults(Model.PatientID, Model.ClinicID);
                return View("PrintTestResults", testResults);
            }
            return View(Model); 


        }

 
        public async Task<IActionResult>  GetPatientRadio(PatientRadiolodyModel model)
        {
            var existingPatientRadiology = await GetlabData.SHPatientRadiology.FindAsync(model.RadioID , model.ClinicID , model.PatientID , model.ScreeningDate);
            if (existingPatientRadiology != null)
            {
                    existingPatientRadiology.RadioID = model.RadioID;
                existingPatientRadiology.ClinicID = model.ClinicID;
                existingPatientRadiology.PatientID = model.PatientID;
                existingPatientRadiology.ReferralDoctorID = model.ReferralDoctorID;
                existingPatientRadiology.ReferralDoctorName = model.ReferralDoctorName;
                existingPatientRadiology.ScreeningDate = model.ScreeningDate;
                existingPatientRadiology.Result = model.Result;
                existingPatientRadiology.lastUpdatedDate = DateTime.Now.ToString();
                existingPatientRadiology.lastUpdatedUser = "Admin";
                existingPatientRadiology.lastUpdatedMachine = "Lap";
                existingPatientRadiology.ScreeningCompleted = model.ScreeningCompleted;
                existingPatientRadiology.ScreeningCompletedDate = model.ScreeningCompletedDate;

            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                model.lastUpdatedMachine = "Lap";
                GetlabData.SHPatientRadiology.Add(model);
            }
            await GetlabData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("RadiologyCreation", model);
        }

        public async Task<IActionResult> GetRadio(string radioID, string clinicID, string patientName, string radioName, string screeingDate, string result, string referralDoctorName, string buttonType)
        {
            ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(GetlabData);

            if (buttonType == "select")
            {
                var Radiologydata = await business.GetRadiologData(radioID , clinicID , patientName, radioName , screeingDate , result , referralDoctorName);
                
                if (Radiologydata != null)
                {
                    ViewBag.RadiologData = Radiologydata;

                    return View("PrintRadiologyResults",Radiologydata);
                }
                else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs";
                    return View();
                }
            }
            return View();
        }
            public IActionResult LabTest()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestCreation()
        {
            return View();
        }
        public IActionResult UpdateTestResults()
        {
            return View();
        }
        public IActionResult PrintTestResults()

        {
            return View();
        }
        public IActionResult RadiologyCreation()
        {
            return View();
        }
        public IActionResult UpdateRadiologyResults()
        {
            return View();
        }
        public IActionResult PrintRadiologyResults()
        {
            return View();
        }
    }
}
