﻿using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Authorize]
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
            var existingPatientTest = await GetlabData.SHPatientTest.FindAsync(pPatientTest.PatientID, pPatientTest.FacilityID, pPatientTest.TestID,pPatientTest.TestDateTime);
            if (existingPatientTest != null)
            {

                existingPatientTest.PatientID = pPatientTest.PatientID;
                existingPatientTest.FacilityID = pPatientTest.FacilityID;
                existingPatientTest.TestID = pPatientTest.TestID;
                existingPatientTest.VisitcaseID1 = pPatientTest.VisitcaseID1;
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
                existingPatientTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingPatientTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                pPatientTest.lastUpdatedDate = DateTime.Now.ToString();
                pPatientTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                pPatientTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                var testResults = await ObjBusTestResult.GetTestResults(Model.PatientID, Model.FacilityID);
                return View("PrintTestResults", testResults);
            }
            return View(Model); 

        }

 
        public async Task<IActionResult>  GetPatientRadio(PatientRadiolodyModel model)
        {
            var existingPatientRadiology = await GetlabData.SHPatientRadiology.FindAsync(model.RadioID , model.FacilityID , model.PatientID , model.ScreeningDate);
            if (existingPatientRadiology != null)
            {
                    existingPatientRadiology.RadioID = model.RadioID;
                existingPatientRadiology.FacilityID = model.FacilityID;
                existingPatientRadiology.PatientID = model.PatientID;
                existingPatientRadiology.VisitcaseID = model.VisitcaseID;
                existingPatientRadiology.ReferralDoctorID = model.ReferralDoctorID;
                existingPatientRadiology.ReferralDoctorName = model.ReferralDoctorName;
                existingPatientRadiology.ScreeningDate = model.ScreeningDate;
                existingPatientRadiology.Result = model.Result;
                existingPatientRadiology.lastUpdatedDate = DateTime.Now.ToString();
                existingPatientRadiology.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingPatientRadiology.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                existingPatientRadiology.ScreeningCompleted = model.ScreeningCompleted;
                existingPatientRadiology.ScreeningCompletedDate = model.ScreeningCompletedDate;

            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetlabData.SHPatientRadiology.Add(model);
            }
            await GetlabData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("RadiologyCreation", model);
        }

        public async Task<IActionResult> GetRadio(string radioID, string FacilityID, string patientName, string radioName, string screeingDate, string result, string referralDoctorName, string buttonType)
        {
            ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(GetlabData);

            if (buttonType == "select")
            {
                var Radiologydata = await business.GetRadiologData(radioID , FacilityID, patientName, radioName , screeingDate , result , referralDoctorName);
                
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



        private bool IsImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            // Check the file's MIME type to confirm it's an image
            if (file.ContentType.ToLower().StartsWith("image/"))
                return true;

            // You can add more checks here depending on your requirements

            return false;
        }

        [HttpPost]
        public async Task<IActionResult> TestRadiologyResults(UpdateRadiologyResultsModel model, IFormFile imageData)
        {
            if (ModelState.IsValid)
            {
                // Process the uploaded image
                if (imageData != null && imageData.Length > 0)
                {
                    // Validate that the uploaded file is an image (optional)
                    if (!IsImage(imageData))
                    {
                        ModelState.AddModelError(string.Empty, "Uploaded file is not an image.");
                        return View(model);
                    }

                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await imageData.CopyToAsync(memoryStream);
                            // Convert memory stream to byte array
                            model.ImageData = memoryStream.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions (e.g., file upload or database saving errors)
                        ModelState.AddModelError(string.Empty, "An error occurred while processing the uploaded image.");
                        // Log the exception for debugging
                        Console.WriteLine(ex.Message);
                        return View(model);
                    }
                }

                var existingUpdateRadiologyResult = await GetlabData.SHUpdateRadiologyResult.FindAsync(model.FacilityID, model.PatientID, model.RadioID);
                if (existingUpdateRadiologyResult != null)
                {
                    existingUpdateRadiologyResult.PatientID = model.PatientID;
                    existingUpdateRadiologyResult.FacilityID = model.FacilityID;
                    existingUpdateRadiologyResult.RadioID = model.RadioID;
                    existingUpdateRadiologyResult.ImageID = model.ImageID;
                    existingUpdateRadiologyResult.ImageData = model.ImageData;
                    existingUpdateRadiologyResult.lastUpdatedDate = DateTime.Now.ToString();
                    existingUpdateRadiologyResult.lastUpdatedUser = User.Claims.First().Value.ToString();
                }
                else
                {
                    model.lastUpdatedDate = DateTime.Now.ToString();
                    model.lastUpdatedUser = User.Claims.First().Value.ToString();
                    GetlabData.SHUpdateRadiologyResult.Add(model);
                }

                try
                {
                    await GetlabData.SaveChangesAsync();
                    ViewBag.Message = "Saved Successfully.";
                    return View("UpdateRadiologyResults", model);
                }
                catch (Exception ex)
                {
                    // Handle database save error
                    ModelState.AddModelError(string.Empty, "An error occurred while saving data to the database.");
                    // Log the exception for debugging
                    Console.WriteLine(ex.Message);
                    return View(model);
                }
            }
            // If ModelState is not valid, return the view with errors
            return View(model);
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
