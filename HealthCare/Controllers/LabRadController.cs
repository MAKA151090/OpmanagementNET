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

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["testid"] = business.GetTestid(facilityId);
            ViewData["patid"] = business.Getpatid(facilityId);
            ViewData["facid"] = business.GetFacid(facilityId);

            ViewData["refdocid"] = business.getrefdocid(facilityId);

            //PatientTestModel = new PatientTestModel();
            var existingPatientTest = await GetlabData.SHPatientTest.FindAsync(pPatientTest.PatientID, pPatientTest.FacilityID, pPatientTest.TestID, pPatientTest.TestDateTime);
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

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad ObjBusTestResult = new BusinessClassLabRad(GetlabData);

            ViewData["visitid"] = ObjBusTestResult.GetVisitid(facilityId);
            ViewData["Patientid"] = ObjBusTestResult.GetPatID(facilityId);
            ViewData["Facilityid"] = ObjBusTestResult.GetFacilityid(facilityId);

            if (ObjBusTestResult != null)
            {
                var testResults = await ObjBusTestResult.GetTestResults(Model.PatientID, Model.FacilityID, Model.VisitcaseID);
                return View("PrintTestResults", testResults);
            }


            return View("PrintTestResults", Model);

        }

        public async Task<IActionResult> GetRadio(string visitcaseid, string patientid, string facilityid)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);

            ViewData["patid"] = business.Getpid(facilityId);
            ViewData["facid"] = business.Getfacid(facilityId);
            ViewData["visitcaseid"] = business.Getvisitcaseid(facilityId);



            if (business != null)
            {
                var Radiologydata = await business.GetRadiologData(visitcaseid, patientid, facilityid);
                return View("PrintRadiologyResults", Radiologydata);

            }
            return View();
        }


        public async Task<IActionResult> GetPatientRadio(PatientRadiolodyModel model)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad businessClass = new BusinessClassLabRad(GetlabData);
            ViewData["radioid"] = businessClass.GetRadioid(facilityId);
            ViewData["facilityid"] = businessClass.Getfacilityid(facilityId);
            ViewData["refdocid"] = businessClass.Getrefdocid(facilityId);
            ViewData["patientid"] = businessClass.Getpatiientid(facilityId);

            var existingPatientRadiology = await GetlabData.SHPatientRadiology.FindAsync(model.RadioID, model.FacilityID, model.PatientID, model.ScreeningDate);
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
        public async Task<IActionResult> TestRadiologyResult(UpdateRadiologyResultsModel model, IFormFile imageFile, string buttontype)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad classLabRad = new BusinessClassLabRad(GetlabData);
            ViewData["updpatid"] = classLabRad.Getupdpatid(facilityId);
            ViewData["updfacid"] = classLabRad.Getupdfacid(facilityId);
            ViewData["updradid"] = classLabRad.Getupdradid(facilityId);

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
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["testid"] = business.GetTestid(facilityId);
            ViewData["patid"] = business.Getpatid(facilityId);
            ViewData["facid"] = business.GetFacid(facilityId);

            ViewData["refdocid"] = business.getrefdocid(facilityId);

            return View();
        }
        public IActionResult UpdateTestResults()
        {
            return View();
        }
        public IActionResult PrintTestResults()

        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad businessClassLabRad = new BusinessClassLabRad(GetlabData);
            ViewData["visitid"] = businessClassLabRad.GetVisitid(facilityId);
            ViewData["Patientid"] = businessClassLabRad.GetPatID(facilityId);
            ViewData["Facilityid"] = businessClassLabRad.GetFacilityid(facilityId);
            return View();
        }
        public IActionResult RadiologyCreation()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad businessClass = new BusinessClassLabRad(GetlabData);
            ViewData["radioid"] = businessClass.GetRadioid(facilityId);
            ViewData["facilityid"] = businessClass.Getfacilityid(facilityId);
            ViewData["refdocid"] = businessClass.Getrefdocid(facilityId);
            ViewData["patientid"] = businessClass.Getpatiientid(facilityId);
            return View();
        }
        public IActionResult UpdateRadiologyResults()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad classLabRad = new BusinessClassLabRad(GetlabData);
            ViewData["updpatid"] = classLabRad.Getupdpatid(facilityId);
            ViewData["updfacid"] = classLabRad.Getupdfacid(facilityId);
            ViewData["updradid"] = classLabRad.Getupdradid(facilityId);
            return View();
        }
        public IActionResult PrintRadiologyResults()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["patid"] = business.Getpid(facilityId);
            ViewData["facid"] = business.Getfacid(facilityId);
            ViewData["visitcaseid"] = business.Getvisitcaseid(facilityId);
            return View();
        }
    }
}
