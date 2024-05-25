using DocumentFormat.OpenXml.Vml.Office;
using HealthCare.Business;
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
            
            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["testid"] = business.GetTestid();
            ViewData["patid"] = business.Getpatid();
            ViewData["facid"] = business.GetFacid();


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

            BusinessClassLabRad businessClass = new BusinessClassLabRad(GetlabData);
            ViewData["radioid"] = businessClass.GetRadioid();
            ViewData["facilityid"] = businessClass.Getfacilityid();
            ViewData["refdocid"] = businessClass.Getrefdocid();
            ViewData["patientid"] = businessClass.Getpatiientid();


            return View("RadiologyCreation", model);
        }

        public async Task<IActionResult> GetRadio(string radioID, string FacilityID, string patientName, string radioName, string screeingDate, string result, string referralDoctorName, string buttonType)
        {
            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);

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

                    ViewData["patid"] = business.Getpid();
                    ViewData["facid"] = business.Getfacid();
                    ViewData["visitcaseid"] = business.Getvisitcaseid();

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
        public async Task<IActionResult> TestRadiologyResult(UpdateRadiologyResultsModel model, IFormFile imageFile,string buttontype)
        {
            
            var UpdatingRadRecord = await GetlabData.SHUpdateRadiologyResult.FindAsync(model.PatientID, model.FacilityID, model.RadioID, model.ImageID);
            if (buttontype == "Create")
            {
                // Process the uploaded image
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Validate that the uploaded file is an image (optional)
                    if (!IsImage(imageFile))
                    {
                        ModelState.AddModelError(string.Empty, "Uploaded file is not an image.");
                        return View(model);
                    }

                    try
                    {
                        using (var memoryStream = new MemoryStream())
                        {

                            await imageFile.CopyToAsync(memoryStream);

                            if (UpdatingRadRecord != null)
                            {
                                // Convert memory stream to byte array
                                UpdatingRadRecord.lastUpdatedDate = DateTime.Now.ToString();
                                UpdatingRadRecord.lastUpdatedUser = User.Claims.First().Value.ToString();
                                UpdatingRadRecord.ResultImage = memoryStream.ToArray();
                            }
                            else
                            {
                                model.lastUpdatedDate = DateTime.Now.ToString();
                                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                                model.ResultImage = memoryStream.ToArray();
                                GetlabData.SHUpdateRadiologyResult.Add(model);
                            }


                            await GetlabData.SaveChangesAsync();
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

                try
                {

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
            else
            {
              
               return File(UpdatingRadRecord.ResultImage, "image/jpeg", "image.jpg");
                

              
            }
            
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
            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["testid"] = business.GetTestid();
            ViewData["patid"] = business.Getpatid();
            ViewData["facid"] = business.GetFacid();

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
            BusinessClassLabRad businessClass = new BusinessClassLabRad(GetlabData);
            ViewData["radioid"] = businessClass.GetRadioid();
            ViewData["facilityid"] = businessClass.Getfacilityid();
            ViewData["refdocid"] = businessClass.Getrefdocid();
            ViewData["patientid"] = businessClass.Getpatiientid();
            return View();
        }
        public IActionResult UpdateRadiologyResults()
        {
            return View();
        }
        public IActionResult PrintRadiologyResults()
        {
             BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["patid"] = business.Getpid();
            ViewData["facid"] = business.Getfacid();
            ViewData["visitcaseid"] = business.Getvisitcaseid();
            return View();
        }
    }
}
