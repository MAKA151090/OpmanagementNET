    
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static HealthCare.Models.OTSchedulingModel;
namespace HealthCare.Controllers
{
    [Authorize]
    public class FrontDeskController : Controller
    {



        private HealthcareContext GetFrontDeskData;

        public FrontDeskController(HealthcareContext healthCare)
        {
        GetFrontDeskData = healthCare;
        }


        [HttpPost]
        public async Task<IActionResult> StaffAttendance(StaffAttendanceViewModel Model,string buttonType)
        {
            BusinessClassFrontDesk objstaff = new BusinessClassFrontDesk(GetFrontDeskData);

            ViewData["staffid"] = objstaff.GetStaffid();

            if (buttonType == "Save")
            {



                var existingAttendance = await GetFrontDeskData.SHStaffAttendance.FirstOrDefaultAsync(x => x.StaffID == Model.StaffID && x.Date == Model.Date);
                if (existingAttendance != null)
                {
                    existingAttendance.StaffID = Model.StaffID;
                    existingAttendance.Date = Model.Date;
                    existingAttendance.Office = Model.Office;
                    existingAttendance.CheckInTime = Model.CheckInTime;
                    existingAttendance.CheckOuTtime = Model.CheckOuTtime;
                  //  GetFrontDeskData.Entry(existingAttendance).State = EntityState.Modified;
                }
                else
                {
                    var newattendance = new StaffAttendanceModel
                    {
                        StaffID = Model.StaffID,
                        Date = Model.Date,
                        Office = Model.Office,
                        CheckInTime = Model.CheckInTime,
                        CheckOuTtime = Model.CheckOuTtime,
                        lastUpdatedDate = DateTime.Now.ToString(),
                        lastUpdatedUser = User.Claims.First().Value.ToString(),
                        lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                    };
                    GetFrontDeskData.SHStaffAttendance.Add(newattendance);
                }

               
                   

                await GetFrontDeskData.SaveChangesAsync();
                 ViewBag.Message = "Saved Successfully.";

            }
            if(buttonType== "Get")
            {
                var result = await objstaff.GetStaffAttendancebus(Model.StaffID);
              
                return View("StaffAttendance", result);
            }
               
              
            var updatedModel = await GetUpdatedModelAsync();

            return View("StaffAttendance");
        }
        private async Task<StaffAttendanceViewModel> GetUpdatedModelAsync()
        {
            var updatedModel = new StaffAttendanceViewModel
            {
                StfAttedance = await GetFrontDeskData.SHStaffAttendance.ToListAsync()
            };
            return updatedModel;
        }



        public IActionResult Index()
            {
                return View();
            }
            public IActionResult OpChecking()
            {
            BusinessClassFrontDesk ObjTestResult = new BusinessClassFrontDesk(GetFrontDeskData);
            ViewData["patid"] = ObjTestResult.GetPatid();
            return View();
            }
                    
            public IActionResult StaffAttendance()
            {
            BusinessClassFrontDesk business = new BusinessClassFrontDesk(GetFrontDeskData);
            ViewData["staffid"] = business.GetStaffid();
            return View();
            }



       /* public async Task<IActionResult> Getstaffattendance(StaffAttendanceViewModel model)
        {
            BusinessClassFrontDesk business = new BusinessClassFrontDesk(GetFrontDeskData);

            var result = business.GetStaffAttendancebus(model.StaffID);
            var viewModel = new StaffAttendanceViewModel
            {

                StaffID = model.StaffID,
                Date = model.Date,
                Office = model.Office,
                CheckInTime = model.CheckInTime,
                CheckOuTtime = model.CheckOuTtime,
                StfAttedance = result
            };


            return View("StaffAttendance",viewModel);

        }*/

        public async Task<IActionResult> ViewResult(OpCheckingViewModel Model)
            {

                BusinessClassFrontDesk ObjTestResult = new BusinessClassFrontDesk(GetFrontDeskData);
                ViewData["patid"] = ObjTestResult.GetPatid();

            if (ObjTestResult != null)
                {
                    var testResults = ObjTestResult.GetOpCheckingModel(Model.PatientId,Model.CurrentDate);
                    Model.Results = testResults;
                    return View("OpChecking", Model);
                }


                return View(Model);

            }

            public int GetNextVisitIdForPatient(String patientId)
            {

                var existingIds = GetFrontDeskData.SHExmPatientObjective
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


        public async Task<IActionResult> OpChecking(OpCheckingViewModel model, string buttonType)
        {
            //var existingTest = await GetFrontDeskData.SHcllDoctorScheduleModel.FindAsync(model.PatientId,model.CurrentDate);

            var visitID = GetNextVisitIdForPatient(model.PatientId).ToString();

            if (buttonType == "checkIn")
            {
                var existingvalue = await GetFrontDeskData.SHfdOpCheckingModel.FirstOrDefaultAsync(e => e.PatientId==model.PatientId );
                {
                    if(existingvalue!=null)
                    {
                        ViewBag.ExistingValue = "Patient Already CheckedOut";
                        BusinessClassFrontDesk ObjTestResults = new BusinessClassFrontDesk(GetFrontDeskData);
                        ViewData["patid"] = ObjTestResults.GetPatid();
                        return View("OpChecking");
                    }
                }


                var newOpCheckIn = new OpCheckingModel
                {
                    PatientId = model.PatientId,
                    VisitId = visitID,
                    VisitStatus = "CheckedIn",
                    LastupdatedDate = DateTime.Now.ToString(),
                    LastupdatedUser = User.Claims.First().Value.ToString(),
                    LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString()

                };

                GetFrontDeskData.SHfdOpCheckingModel.Add(newOpCheckIn);

                await GetFrontDeskData.SaveChangesAsync();
                ViewBag.Message = "CheckedIn Successfully";
                BusinessClassFrontDesk ObjTestResult = new BusinessClassFrontDesk(GetFrontDeskData);
                ViewData["patid"] = ObjTestResult.GetPatid();
                return View("OpChecking");
            }

            else if (buttonType == "checkOut")
            {
                var existingOpChecking = await GetFrontDeskData.SHfdOpCheckingModel
            .FirstOrDefaultAsync(x => x.PatientId == model.PatientId && x.VisitId == visitID);

                if (existingOpChecking != null)
                {

                    existingOpChecking.VisitStatus = "CheckedOut";
                    existingOpChecking.LastupdatedDate = DateTime.Now.ToString();
                    existingOpChecking.LastupdatedUser = User.Claims.First().Value.ToString();
                    existingOpChecking.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                    GetFrontDeskData.SHfdOpCheckingModel.Update(existingOpChecking);

                }

                await GetFrontDeskData.SaveChangesAsync();
                ViewBag.CancelMessage = "Checked Out Successfully";
                BusinessClassFrontDesk ObjTestResult = new BusinessClassFrontDesk(GetFrontDeskData);
                ViewData["patid"] = ObjTestResult.GetPatid();
                return View("OpChecking");

            }


            BusinessClassFrontDesk businessFront = new BusinessClassFrontDesk(GetFrontDeskData);

            var data = businessFront.GetOpCheckingModel(model.PatientId, model.CurrentDate);
            model.Results = data;

            return View("OpChecking", model);

            

                


        }


    }
}

