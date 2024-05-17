
﻿using HealthCare.Business;
using HealthCare.Context;

﻿using HealthCare.Context;

using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    public class FrontDeskController : Controller
    {


        private HealthcareContext GetFrontDeskData;

        public FrontDeskController(HealthcareContext healthCare) {
        GetFrontDeskData = healthCare;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpChecking()
        {
            return View();
        }
        public IActionResult IpRegistration()
        {
            return View();
        }
        public IActionResult OpDischarge()
        {
            return View();
        }





        public async Task<IActionResult> ViewResult(OpCheckingViewModel Model)
        {

            BusinessClassFrontDesk ObjTestResult = new BusinessClassFrontDesk(GetFrontDeskData);

            if (ObjTestResult != null)
            {
                var testResults = ObjTestResult.GetOpCheckingModel(Model.PatientId);
                Model.Results = testResults;
                return View("OpChecking", Model);
            }
            return View(Model);

        }

        public int GetNextVisitIdForPatient(String patientId)
        {

            var existingIds =GetFrontDeskData.SHExmPatientObjective
                .Where(v => v.PatientID == patientId && !string.IsNullOrEmpty(v.VisitID))
                .Select(v => v.VisitID)
                .ToList();



            if (existingIds.Count == 0)
            {
                return 1;
            }
            else
            {


                List<int> idIntegers = existingIds.Select(int.Parse).ToList();
                int maxId = idIntegers.Max();
                return maxId + 1;
            }
        }

        [HttpPost]
        public async Task<IActionResult> OpChecking(OpCheckingViewModel model)
        {
            //var existingTest = await GetFrontDeskData.SHcllDoctorScheduleModel.FindAsync(model.PatientId,model.CurrentDate);

           var visitID = GetNextVisitIdForPatient(model.PatientId).ToString();

            GetFrontDeskData.SHfdOpCheckingModel.Add(new OpCheckingModel
            {
                PatientId = model.PatientId,
                VisitId = visitID,
                VisitStatus = "CheckedIn",
                LastupdatedDate = DateTime.Now.ToString(),
                LastupdatedUser="Admin",
                LastUpdatedMachine="My"
            
           });


            await GetFrontDeskData.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("TestMaster", model);


        }






    }
}
