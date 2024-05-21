
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> StaffAttendance(StaffAttendanceModel model)
        {
            var existingClinic = await GetFrontDeskData.SHStaffAttendance.FindAsync(model.StaffID);

            if (existingClinic != null)
            {
                existingClinic.StaffID = model.StaffID;
                existingClinic.Date = model.Date;
                existingClinic.Office = model.Office;
                existingClinic.CheckInTime = model.CheckInTime;
                existingClinic.CheckOuTtime = model.CheckOuTtime;
                existingClinic.lastUpdatedDate = DateTime.Now.ToString();
                existingClinic.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingClinic.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();


            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetFrontDeskData.SHStaffAttendance.Add(model);
            }
                await GetFrontDeskData.SaveChangesAsync();
                ViewBag.Message = "Saved Successfully.";
                return View("StaffAttendance", model);
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
            public IActionResult StaffAttendance()
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
                    LastupdatedUser = User.Claims.First().Value.ToString(),
                    LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString()

        });


                await GetFrontDeskData.SaveChangesAsync();

                ViewBag.Message = "Saved Successfully";
                return View("TestMaster", model);


            }






        }
    }

