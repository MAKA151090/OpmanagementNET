using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
    public class LabRadController : Controller
    {
        private HealthcareContext GetlabData;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LabRadController(HealthcareContext GetlabData, IHttpContextAccessor httpContextAccessor)
        {
            this.GetlabData = GetlabData;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> TestCreation(PatientTestModel pPatientTest,PatientTestTableModel model, string PatientID, string VisitcaseID,string buttonType)
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



            ClinicAdminBusinessClass clinicAd = new ClinicAdminBusinessClass(GetlabData);
            ViewData["resoruseid"] = clinicAd.GetResourceid(facilityId);

            if (buttonType == "Get")
            {

                var exresult = GetlabData.SHPatientTest.FirstOrDefault(x => x.PatientID == PatientID && x.Isdelete == false && x.VisitcaseID == VisitcaseID && x.FacilityID == pPatientTest.FacilityID && x.TsampleCltDateTime == pPatientTest.TsampleCltDateTime);
                if (exresult != null)
                {

                    var result = business.Gettest(exresult.PatientID, exresult.VisitcaseID, exresult.TestID, exresult.FacilityID, exresult.TsampleCltDateTime);


                    var viewModelList = result.Select(p => new PatientTestViewModel
                    {
                        PatientID = p.PatientID,
                        VisitcaseID = p.VisitcaseID,
                        TestName = p.TestName,
                        TsampleCltDateTime = p.TsampleCltDateTime,
                        DbpatientID = p.DbpatientID,
                        TestID = p.TestID

                    }).ToList();
                    model.ViewTest = viewModelList;

                    model.Items = await GetDistinctCaseVisitID(pPatientTest.PatientID);

                    ViewBag.SelectedPatientID = PatientID;
                    model.SelectedItemId = VisitcaseID;

                    // Set TempData for use in the view
                    TempData["TestID"] = viewModelList.FirstOrDefault()?.TestID;
                    TempData["DbpatientID"] = viewModelList.FirstOrDefault()?.DbpatientID;

                    return View("TestCreation", model);
                }
                else
                {

                    ViewBag.Message = " PatientID Not Found";
                }

                model.Items = await GetDistinctCaseVisitID(pPatientTest.PatientID) ?? new List<PatientTestModel>();
                model.ViewTest = new List<PatientTestViewModel>();

                ViewBag.SelectedPatientID = PatientID;


                model.SelectedItemId = VisitcaseID;
                return View("TestCreation", model);
            }


            if (string.IsNullOrEmpty(pPatientTest.TestID))
            {
                ViewBag.Message = "Please enter TestID.";

                model.Items = await GetDistinctCaseVisitID(pPatientTest.PatientID) ?? new List<PatientTestModel>();

                var prescriptionTable = business.Gettest(pPatientTest.PatientID, pPatientTest.VisitcaseID, pPatientTest.TestID, pPatientTest.FacilityID, pPatientTest.TsampleCltDateTime);

                // Map to PrescriptionViewModel
                model.ViewTest = prescriptionTable.Select(p => new PatientTestViewModel
                {
                    PatientID = p.PatientID,
                    VisitcaseID = p.VisitcaseID,
                    TestName = p.TestName,
                    TsampleCltDateTime = p.TsampleCltDateTime,
                    DbpatientID = p.DbpatientID,
                    TestID = p.TestID

                }).ToList();

                ViewBag.SelectedPatientID = PatientID;
                model.SelectedItemId = VisitcaseID;

                return View("TestCreation", model);

            }


            //PatientTestModel = new PatientTestModel();
            var existingPatientTest = await GetlabData.SHPatientTest.FirstOrDefaultAsync(x=>x.PatientID==pPatientTest.PatientID && x.FacilityID == pPatientTest.FacilityID && x.TestID ==  pPatientTest.TestID && x.TestDateTime == pPatientTest.TestDateTime && x.VisitcaseID == pPatientTest.VisitcaseID);
            if (existingPatientTest != null)
            {

                existingPatientTest.PatientID = pPatientTest.PatientID;
                existingPatientTest.FacilityID = pPatientTest.FacilityID;
                existingPatientTest.TestID = pPatientTest.TestID;
                existingPatientTest.VisitcaseID = pPatientTest.VisitcaseID;
                existingPatientTest.TestResult = pPatientTest.TestResult;
                existingPatientTest.TestDateTime = pPatientTest.TestDateTime;
                existingPatientTest.TsampleCltDateTime = pPatientTest.TsampleCltDateTime;
                existingPatientTest.TsampleClt = pPatientTest.TsampleClt;
                existingPatientTest.ExptRsltDateTime = pPatientTest.ExptRsltDateTime;
                existingPatientTest.ResultPublish = pPatientTest.ResultPublish;
                existingPatientTest.ReferDate = pPatientTest.ReferDate;
                existingPatientTest.ReferDocID = pPatientTest.ReferDocID;
                existingPatientTest.ResultDate = pPatientTest.ResultDate;
                existingPatientTest.BarcodeID = pPatientTest.BarcodeID;
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

            var alltest = business.Gettest(pPatientTest.PatientID, pPatientTest.VisitcaseID, pPatientTest.TestID,facilityId,pPatientTest.TsampleCltDateTime);
            var allViewModels = alltest.Select(p => new PatientTestViewModel
            {
                PatientID = p.PatientID,
                VisitcaseID = p.VisitcaseID,
                TestName = p.TestName,
               TsampleCltDateTime = p.TsampleCltDateTime,
                DbpatientID = p.DbpatientID,
                TestID = p.TestID

            }).ToList();

            model.ViewTest = allViewModels;

            model.Items = await GetDistinctCaseVisitID(pPatientTest.PatientID);

            ViewBag.SelectedPatientID = PatientID;
            model.SelectedItemId = VisitcaseID;
            ViewBag.SelecteddoctorID = pPatientTest.ReferDocID;

            return View("TestCreation", model);
        }


        public async Task<IActionResult> Edit(string patientId, string VisitcaseID, string testId, string tsampledate, string facility, PatientTestTableModel tabmod)
        {

            if (string.IsNullOrEmpty(patientId) || string.IsNullOrEmpty(testId))
            {
                ViewBag.ErrorMessage = "PatientID or DrugID is missing!";
                tabmod.Items = await GetDistinctCaseVisitID(patientId) ?? new List<PatientTestModel>();
                tabmod.ViewTest = new List<PatientTestViewModel>();

                return View("TestCreation", tabmod); // Handle the error gracefully
            }


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

            ClinicAdminBusinessClass clinicAd = new ClinicAdminBusinessClass(GetlabData);
            ViewData["resoruseid"] = clinicAd.GetResourceid(facilityId);




            var testEdit = await GetlabData.SHPatientTest.FirstOrDefaultAsync(x=>x.PatientID == patientId && x.VisitcaseID == VisitcaseID && x.TestID == testId && x.TsampleCltDateTime == tsampledate && x.FacilityID == facilityId);
            if (testEdit == null)
            {
                ViewBag.Message = " PatientID Not Found";
                tabmod.Items = await GetDistinctCaseVisitID(patientId) ?? new List<PatientTestModel>();
                tabmod.ViewTest = new List<PatientTestViewModel>();

                return View("TestCreation", tabmod);
            }

            var testTableModel = new PatientTestTableModel
            {
                VisitcaseID = testEdit.VisitcaseID,
                PatientID = testEdit.PatientID,
                TestID = testEdit.TestID,
                FacilityID = testEdit.FacilityID,
                TestDateTime = testEdit.TestDateTime,
                TestResult = testEdit.TestResult,
                TsampleClt = testEdit.TsampleClt,
                TsampleCltDateTime = testEdit.TsampleCltDateTime,
                ExptRsltDateTime = testEdit.ExptRsltDateTime,
                ResultPublish = testEdit.ResultPublish,
                ReferDocID = testEdit.ReferDocID,
                ReferDate = testEdit.ResultDate,
                ResultDate = testEdit.ResultDate,
                BarcodeID = testEdit.BarcodeID,

                ViewTest = new List<PatientTestViewModel>()

            };


            var result = business.Gettest(testEdit.PatientID, testEdit.VisitcaseID, testEdit.TestID, facilityId, testEdit.TsampleCltDateTime);
            if (result != null && result.Any())
            {
                var viewModelList = result.Select(p => new PatientTestViewModel
                {
                    PatientID = p.PatientID,
                    VisitcaseID = p.VisitcaseID,
                    TestName = p.TestName,
                    TsampleCltDateTime = p.TsampleCltDateTime,
                    DbpatientID = p.DbpatientID,
                    TestID = p.TestID

                }).ToList();
                testTableModel.ViewTest = viewModelList;
            }

            // Populate Items in the model for dropdown selection
            testTableModel.Items = await GetDistinctCaseVisitID(testEdit.PatientID);

            // Set ViewBag and Model properties for the view
            ViewBag.SelectedPatientID = testEdit.PatientID;

            ViewBag.SelecteddoctorID = testEdit.ReferDocID;

            testTableModel.SelectedItemId = testEdit.VisitcaseID;

            ViewBag.SelectedTestID = testEdit.TestID;

            

            return View("TestCreation", testTableModel);


        }


        public async Task<IActionResult> Delete(string patientId, string VisitcaseID, string testId, string tsampledate, PatientTestModel model, PatientTestTableModel tabmod,string facility)
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



            ClinicAdminBusinessClass clinicAd = new ClinicAdminBusinessClass(GetlabData);
            ViewData["resoruseid"] = clinicAd.GetResourceid(facilityId);

            var exresult = GetlabData.SHPatientTest.FirstOrDefaultAsync(x => x.PatientID == patientId && x.VisitcaseID == VisitcaseID && x.TestID == testId && x.TsampleCltDateTime == tsampledate && x.FacilityID == facilityId);
            if (exresult != null)
            {

                var testDel = await GetlabData.SHPatientTest.FirstOrDefaultAsync(x => x.PatientID == patientId && x.VisitcaseID == VisitcaseID && x.TestID == testId && x.TsampleCltDateTime == tsampledate && x.FacilityID == facilityId);
                if (testDel != null)
                {
                    testDel.Isdelete = true;
                    await GetlabData.SaveChangesAsync();
                    ViewBag.Message = "Deleted  Successfully.";
                }

                var testTable = business.Gettest(patientId, VisitcaseID, testId, facilityId, tsampledate);

                // Map to PrescriptionViewModel
                tabmod.ViewTest = testTable.Select(p => new PatientTestViewModel
                {
                    PatientID = p.PatientID,
                    VisitcaseID = p.VisitcaseID,
                    TestName = p.TestName,
                    TsampleCltDateTime = p.TsampleCltDateTime,
                    DbpatientID = p.DbpatientID,
                    TestID = p.TestID
                }).ToList();



                tabmod.Items = await GetDistinctCaseVisitID(model.PatientID);

                ViewBag.SelectedPatientID = model.PatientID;
                tabmod.SelectedItemId = VisitcaseID;

                return View("TestCreation", tabmod);
            }
            else
            {
                ViewBag.ErrorMessage = " PatientID Not Found";

            }

            var prescriptionTable1 = business.Gettest(patientId, VisitcaseID, testId, facilityId, tsampledate);

            // Map to PrescriptionViewModel
            tabmod.ViewTest = prescriptionTable1.Select(p => new PatientTestViewModel
            {
                PatientID = p.PatientID,
                VisitcaseID = p.VisitcaseID,
                TestName = p.TestName,
                TsampleCltDateTime = p.TsampleCltDateTime,
                DbpatientID = p.DbpatientID,
                TestID = p.TestID

            }).ToList();


            tabmod.Items = await GetDistinctCaseVisitID(model.PatientID);

            ViewBag.SelectedPatientID = model.PatientID;
            tabmod.SelectedItemId = VisitcaseID;

            return View("TestCreation", tabmod);
        }

        private async Task<List<PatientTestModel>> GetDistinctCaseVisitID(string patientId)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }


            return await GetlabData.SHPatientTest
                .Where(cv => cv.PatientID == patientId && cv.FacilityID == facilityId)
                .Select(cv => new PatientTestModel
                {
                    VisitcaseID = cv.VisitcaseID
                    // Add other properties if needed
                })
                .Distinct()
                .ToListAsync();
        }



        public async Task<IActionResult> GetCaseTestVisitIDs(string patientId)

        {

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }

           


            var caseVisitIds = GetlabData.SHPatientTest
                .Where(cv => cv.PatientID == patientId && cv.FacilityID == facilityId)
                .Select(cv => cv.VisitcaseID).Distinct()
                .ToList();

            return Json(caseVisitIds);
        }


        public async Task<IActionResult> GetVisitDate(string visitId)

        {

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }




            var visitDetails = await GetlabData.SHPatientTest
        .Where(v => v.VisitcaseID == visitId && v.FacilityID == facilityId && v.Isdelete == false)
        .Select(v => new
        {
            SampleCollectDateTime = v.TsampleCltDateTime
        })
        .FirstOrDefaultAsync();

            return Json(visitDetails);
        }



        public async Task<IActionResult> AddNewTestVisitID(string patientId)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            try
            {
                // Fetch the last visit ID for the selected patient
                var lastVisitIdEntry = await GetlabData.SHPatientTest
                    .Where(cv => cv.PatientID == patientId && cv.FacilityID == facilityId)
                    .OrderByDescending(cv => cv.VisitcaseID)
                    .FirstOrDefaultAsync();

                int nextVisitNumber = 1;

                // If a visit ID exists, increment the number
                if (lastVisitIdEntry != null)
                {
                    var lastVisitId = lastVisitIdEntry.VisitcaseID;

                    // Extract the numeric part from the visit ID (assuming the format is 'Visit-<number>_<date>')
                    var visitPrefix = "Visit-";
                    if (lastVisitId.StartsWith(visitPrefix))
                    {
                        var lastVisitNumberString = lastVisitId.Substring(visitPrefix.Length).Split('_')[0];

                        // Parse the numeric part safely
                        if (int.TryParse(lastVisitNumberString, out int lastVisitNumber))
                        {
                            nextVisitNumber = lastVisitNumber + 1;
                        }
                        else
                        {
                            return Json(new { success = false, message = "Invalid visit number format. Unable to generate the next visit number." });
                        }
                    }
                }

                // Create the new visit ID with the current date in DD-MM-YYYY format
                string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
                string newVisitId = $"Visit-{nextVisitNumber}_{currentDate}";

                // Insert the new visit ID in the database for that patient
                var newVisit = new PrescriptionTableModel
                {
                    PatientID = patientId,
                    CaseVisitID = newVisitId,
                    // Include other necessary fields as needed
                };

                // Add newVisit to the database (implement the logic to save it here)

                return Json(new { success = true, newVisitId = newVisitId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while adding the new visit ID." });
            }
        }





        public async Task<IActionResult> AddTestPatientPop(PatientRegistrationModel model)
        {
            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }


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


            ClinicAdminBusinessClass clinicAd = new ClinicAdminBusinessClass(GetlabData);
            ViewData["resoruseid"] = clinicAd.GetResourceid(facilityId);

            BusinessClassLabRad docpres = new BusinessClassLabRad(GetlabData);

            var daocfac = docpres.Gettestfacility(facilityId).FirstOrDefault()?.FacilityID;

            // Use _httpContextAccessor to access HttpContext.Session
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FacilityID", daocfac);
            }
            else
            {
                TempData["ErrorMessage"] = "Session is not available. Please try again.";
                return RedirectToAction("ErrorPage"); // Replace with your error handling action
            }

            var existingPatient = await GetlabData.SHPatientRegistration.FirstOrDefaultAsync(x => x.PatientID == model.PatientID && x.FacilityID == daocfac && x.IsDelete == false);

            if (existingPatient != null)
            {
                existingPatient.FullName = model.FullName;
                existingPatient.PhoneNumber = model.PhoneNumber;
                existingPatient.Age = model.Age;
                existingPatient.Gender = model.Gender;
                existingPatient.FacilityID = daocfac;
                existingPatient.PatientID = model.PatientID;

                GetlabData.Entry(existingPatient).State = EntityState.Modified;
            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.FacilityID = daocfac;
                GetlabData.SHPatientRegistration.Add(model);


            }

            await GetlabData.SaveChangesAsync();

            var modelview = new PatientTestTableModel(); // Replace with your actual model type
            modelview.Items = new List<PatientTestModel>();


            var viewModelList = new List<PatientTestViewModel>();


            modelview.ViewTest = viewModelList;

            return View("TestCreation", modelview);

        }


        public async Task<IActionResult> AdddoctorPop(StaffAdminModel model)
        {
            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }


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


            ClinicAdminBusinessClass clinicAd = new ClinicAdminBusinessClass(GetlabData);
            ViewData["resoruseid"] = clinicAd.GetResourceid(facilityId);

            BusinessClassLabRad docpres = new BusinessClassLabRad(GetlabData);

            var daocfac = docpres.Gettestfacility(facilityId).FirstOrDefault()?.FacilityID;


          

            // Use _httpContextAccessor to access HttpContext.Session
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FacilityID", daocfac);
            }
            else
            {
                TempData["ErrorMessage"] = "Session is not available. Please try again.";
                return RedirectToAction("ErrorPage"); // Replace with your error handling action
            }

            var existingstaff = await GetlabData.SHclnStaffAdminModel.FirstOrDefaultAsync(x => x.StrStaffID == model.StrStaffID && x.FacilityID == daocfac && x.IsDelete == false);

            if (existingstaff != null)
            {
                existingstaff.StrFullName = model.StrFullName;
                existingstaff.StrPhoneNumber = model.StrPhoneNumber;
                existingstaff.ResourceTypeID = model.ResourceTypeID;
                existingstaff.StrGender = model.StrGender;
                existingstaff.FacilityID = daocfac;
                existingstaff.StrStaffID = model.StrStaffID;

                GetlabData.Entry(existingstaff).State = EntityState.Modified;
            }
            else
            {

                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.FacilityID = daocfac;
                GetlabData.SHclnStaffAdminModel.Add(model);


            }

            await GetlabData.SaveChangesAsync();

            var modelview = new PatientTestTableModel(); // Replace with your actual model type
            modelview.Items = new List<PatientTestModel>();


            var viewModelList = new List<PatientTestViewModel>();


            modelview.ViewTest = viewModelList;

            return View("TestCreation", modelview);

        }





        public async Task<IActionResult> ViewResult(TestresultTablemodel Model,PatientTestModel Tmodel,PatientTestTableModel Mod,string buttonType,TestresultupdateModel Updmod)
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
            ViewData["refdocidlab"] = business.getrefdocidlab(facilityId);
            ViewData["refdocidlabInc"] = business.getrefdocidlabInc(facilityId);

            var refDocLabList = business.getrefdocidlab(facilityId);
            ViewData["refdocidlab"] = refDocLabList.Select(x => new SelectListItem
            {
                Value = x.StrStaffID,    // Assuming StrStaffID is the ID
                Text = x.StrFullName      // Assuming StrFullName is the name to display
            }).ToList();

            // Convert Lab Incharge list to SelectListItem
            var refDocLabIncList = business.getrefdocidlabInc(facilityId);
            ViewData["refdocidlabInc"] = refDocLabIncList.Select(x => new SelectListItem
            {
                Value = x.StrStaffID,    // Assuming StrStaffID is the ID
                Text = x.StrFullName      // Assuming StrFullName is the name to display
            }).ToList();




            if (buttonType == "save")
            {

                var checkresultupd = await GetlabData.Shtestresultupd.FirstOrDefaultAsync(x => x.PatientID == Model.PatientID && x.Isdelete == false && x.VisitcaseID == Model.VisitcaseID && x.FacilityID == facilityId && x.TestID == Model.TestID && x.TsampleCltDateTime == Model.TsampleCltDateTime);

                Updmod.TestID = Model.TestID;

                if(checkresultupd != null)
                {

                    checkresultupd.PatientID = Updmod.PatientID;
                    checkresultupd.VisitcaseID = Updmod.VisitcaseID;
                    checkresultupd.FacilityID = Updmod.FacilityID;
                    checkresultupd.TsampleCltDateTime = Updmod.TsampleCltDateTime;
                    checkresultupd.Result = Updmod.Result;
                    checkresultupd.Resultby = Updmod.Resultby;
                    checkresultupd.Verifiedby = Updmod.Verifiedby;
                    checkresultupd.Verifieddate = Updmod.Verifieddate;
                    checkresultupd.LastupdatedDate = DateTime.Now.ToString();
                    checkresultupd.LastupdatedUser = User.Claims.First().Value.ToString();
                    
                }
                else
                {
                    Updmod.LastupdatedDate = DateTime.Now.ToString();
                    Updmod.LastupdatedUser = User.Claims.First().Value.ToString();

                }

                  GetlabData.Shtestresultupd.Add(Updmod);

                await GetlabData.SaveChangesAsync();

                // Retrieve and display existing results
                var getresultret = await GetlabData.SHPatientTest.FirstOrDefaultAsync(x =>
                    x.PatientID == Model.PatientID &&
                    x.Isdelete == false &&
                    x.VisitcaseID == Model.VisitcaseID &&
                    x.FacilityID == facilityId &&
                    x.TsampleCltDateTime == Model.TsampleCltDateTime);

                if (getresultret != null)
                {
                    var testTabledata = business.Gettestresult(Model.PatientID, Model.VisitcaseID, facilityId, Model.TsampleCltDateTime);

                    // Map each TestresultTablemodel to TestresultviewModel
                    Model.Viewtestresult = testTabledata.Select(item => new TestresultviewModel
                    {
                        TestName = item.TestName,
                        Range = item.Range,
                        Unit = item.Unit,
                        // Add other necessary mappings
                    }).ToList();
                }

                Mod.Items = await GetDistinctCaseVisitID(Tmodel.PatientID);
                Model.Items = Mod.Items.Select(item => new TestresultupdateModel
                {
                    VisitcaseID = item.VisitcaseID,
                    // Add other necessary property mappings if needed
                }).ToList();

                ViewBag.SelectedPatientID = Model.PatientID;
                Model.SelectedItemId = Model.VisitcaseID;

                return View("PrintTestResults", Model);


            }


             
            var getresult = await GetlabData.SHPatientTest.FirstOrDefaultAsync(x=>x.PatientID == Model.PatientID && x.Isdelete == false && x.VisitcaseID == Model.VisitcaseID && x.FacilityID == facilityId  && x.TsampleCltDateTime == Model.TsampleCltDateTime);
            if(getresult != null)
            {
                var testTabledata = business.Gettestresult(Model.PatientID, Model.VisitcaseID, facilityId,Model.TsampleCltDateTime);

                // Create a new list to store TestresultviewModel
                List<TestresultviewModel> viewTestResult = new List<TestresultviewModel>();

                // Map each TestresultTablemodel to TestresultviewModel
                foreach (var item in testTabledata)
                {
                    var viewModel = new TestresultviewModel
                    {
                        TestName = item.TestName,
                        
                        Range = item.Range,
                        Unit = item.Unit,
                        // Add other necessary mappings between models
                    };

                    viewTestResult.Add(viewModel);
                }

                // Now assign the mapped list to Model.Viewtestresult
                Model.Viewtestresult = viewTestResult;



            }


            Mod.Items = await GetDistinctCaseVisitID(Tmodel.PatientID);

            Model.Items = Mod.Items.Select(item => new TestresultupdateModel
            {
                VisitcaseID = item.VisitcaseID,
                // Add other necessary property mappings if needed
            }).ToList();

            ViewBag.SelectedPatientID = Model.PatientID;
            Model.SelectedItemId = Model.VisitcaseID;

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



            ClinicAdminBusinessClass clinicAd = new ClinicAdminBusinessClass(GetlabData);
            ViewData["resoruseid"] = clinicAd.GetResourceid(facilityId);

            var model = new PatientTestTableModel();
            model.Items = new List<PatientTestModel>();


            var viewModelList = new List<PatientTestViewModel>();


            model.ViewTest = viewModelList;


            return View("TestCreation",model);
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
            BusinessClassLabRad business = new BusinessClassLabRad(GetlabData);
            ViewData["testid"] = business.GetTestid(facilityId);
            ViewData["patid"] = business.Getpatid(facilityId);
            ViewData["facid"] = business.GetFacid(facilityId);
            ViewData["refdocidlab"] = business.getrefdocidlab(facilityId);
            ViewData["refdocidlabInc"] = business.getrefdocidlabInc(facilityId);


            var model = new TestresultTablemodel();
            model.Items = new List<TestresultupdateModel>();


            var viewModelList = new List<TestresultviewModel>();


            model.Viewtestresult = viewModelList;

            return View("PrintTestResults", model);
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
