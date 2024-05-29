using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HealthCare.Controllers
{
    [Authorize]
    public class OTManagementController : Controller
    {

        private HealthcareContext Getotschedule;

        public OTManagementController(HealthcareContext Getotschedule)
        {
            this.Getotschedule = Getotschedule;
        }
        public async Task<IActionResult> OtSchedule(OTSchedulingModel pSchedule)
        {
            //PatientTestModel = new PatientTestModel();
            var existingSchedule = await Getotschedule.SHotScheduling.FindAsync(pSchedule.OtScheduleID);
            if (existingSchedule != null)
            {

                existingSchedule.PatientID = pSchedule.PatientID;
                existingSchedule.FacilityID = pSchedule.FacilityID;
                existingSchedule.CaseVisitID = pSchedule.CaseVisitID;
                existingSchedule.OtScheduleID = pSchedule.OtScheduleID;
                existingSchedule.TableID = pSchedule.TableID;
                existingSchedule.OperationType = pSchedule.OperationType;
                existingSchedule.Priority = pSchedule.Priority;
                existingSchedule.InchrgDepID = pSchedule.InchrgDepID;
                existingSchedule.AdditionalNotes = pSchedule.AdditionalNotes;
                existingSchedule.Comments = pSchedule.Comments;
                existingSchedule.StartDate = pSchedule.StartDate;
                existingSchedule.StartTime = pSchedule.StartTime;
                existingSchedule.BookedBy = pSchedule.BookedBy;
                existingSchedule.Status = pSchedule.Status;
                existingSchedule.Duration = pSchedule.Duration;
                existingSchedule.TeamID = pSchedule.TeamID;
                existingSchedule.Confirm = pSchedule.Confirm;
                existingSchedule.ConfirmDate = pSchedule.ConfirmDate;
                existingSchedule.ConfirmBy = pSchedule.ConfirmBy;
                existingSchedule.IsDeleted =pSchedule.IsDeleted;
                existingSchedule.lastupdatedDate = DateTime.Now.ToString();
                existingSchedule.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingSchedule.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                Getotschedule.Entry(existingSchedule).State = EntityState.Modified;
            }
            else
            {
                pSchedule.lastupdatedDate = DateTime.Now.ToString();
                pSchedule.lastUpdatedUser = User.Claims.First().Value.ToString();
                pSchedule.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                Getotschedule.SHotScheduling.Add(pSchedule);

            }
            await Getotschedule.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";

            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["patientid"] = classOT.GetPatientID();
            ViewData["facilityid"] = classOT.GetFacilityid();
            ViewData["Depid"] = classOT.GetDepid();
            ViewData["tableid"] = classOT.Gettableid();
            return View("OTScheduling", pSchedule);


        }

        public async Task<IActionResult> OtNotespatient(OTNotesModel pNotes)
        {
            //PatientTestModel = new PatientTestModel();
            var existingNotes = await Getotschedule.SHotNotes.FindAsync(pNotes.OtScheduleID);
            if (existingNotes != null)
            {

                existingNotes.PatientID = pNotes.PatientID;
                existingNotes.OtScheduleID = pNotes.OtScheduleID;
                existingNotes.PreOtNotes = pNotes.PostOtNotes;
                existingNotes.IntraOtNotes = pNotes.IntraOtNotes;
                existingNotes.PostOtNotes = pNotes.PostOtNotes;
                existingNotes.FinalOtNotes = pNotes.FinalOtNotes;
                existingNotes.PreOtAnesthesiaNotes = pNotes.PreOtAnesthesiaNotes;
                existingNotes.IntraOtAnesthesiaNotes = pNotes.IntraOtAnesthesiaNotes;
                existingNotes.PostOtAnesthesiaNotes = pNotes.PostOtAnesthesiaNotes;
                existingNotes.ObservationNotes = pNotes.ObservationNotes;
                existingNotes.OtherComments = pNotes.OtherComments;
                existingNotes.lastupdatedDate = DateTime.Now.ToString();
                existingNotes.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingNotes.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                Getotschedule.Entry(existingNotes).State = EntityState.Modified;

            }
            else
            {
                pNotes.lastupdatedDate = DateTime.Now.ToString();
                pNotes.lastUpdatedUser = User.Claims.First().Value.ToString();
                pNotes.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                Getotschedule.SHotNotes.Add(pNotes);

            }
            await Getotschedule.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["patientID"] = classOT.getpatid();
            ViewData["getscheduleid"] = classOT.getschedluid();

            return View("OTNotes", pNotes);


        }
        public async Task<IActionResult> GetviewOT(OtConfirmViewModel Model , string buttonType,OTSchedulingModel pConfirm)
        {
            BusinessClassOT ObjViewOT = new BusinessClassOT(Getotschedule);

            var objconfirm = await Getotschedule.SHotScheduling.FindAsync(pConfirm.OtScheduleID);

            if (buttonType == "Confirm")
            {
                await ObjViewOT.UpdateOTConfirmation(Model.OtscheduleID, "Confirmed");
                objconfirm.ConfirmBy=pConfirm.ConfirmBy;
                objconfirm.ConfirmDate = pConfirm.ConfirmDate;
                Getotschedule.SHotScheduling.Update(objconfirm);
                await Getotschedule.SaveChangesAsync();
            }
            else if (buttonType == "cancel")
            {
                await ObjViewOT.UpdateOTConfirmation(Model.OtscheduleID, "cancel");
            }

            
                var result = await ObjViewOT.GetOTConfirmation(Model.OtscheduleID);

            ViewData["getscheduleid"] = ObjViewOT.getscheduleid();

            return View("OTConfirmation", result);
            

        }
        public async Task<IActionResult>OtsummaryView(OTSummaryViewModel Model, string buttonType)
        {
            BusinessClassOT ObjViewOTSum = new BusinessClassOT(Getotschedule);


           // var objSumm = await Getotschedule.SHOTsummary.FindAsync(Model.OtscheduleID);

            if (buttonType == "Save")
            {
                foreach (var summary in Model.SHotsumm)
                {
                    var objadd = await Getotschedule.SHOTsummary.FindAsync(Model.OtscheduleID,summary.QuestionID);
                    if (objadd != null)
                    {
                        objadd.Answer = summary.Answer;
                        objadd.lastUpdatedDate = DateTime.Now.ToString();
                        objadd.OtscheduleID = Model.OtscheduleID;
                        objadd.lastUpdatedUser = "Kumar";
                        objadd.lastUpdatedMachine = "Lap";
                        Getotschedule.SHOTsummary.Update(objadd);

                    }
                    else
                    {
                        objadd = new OTSummaryModel
                        {
                            QuestionID = summary.QuestionID,
                            Question = summary.Question,
                            Answer = summary.Answer,
                            OtscheduleID = Model.OtscheduleID,
                            lastUpdatedDate = DateTime.Now.ToString(),
                            lastUpdatedUser = "Kumar",
                            lastUpdatedMachine = "Lap"
                        };
                        Getotschedule.SHOTsummary.Add(objadd);
                    }
                }

                await Getotschedule.SaveChangesAsync();
            }
            else if (buttonType == "Print")
            {
               
            }


            var result = ObjViewOTSum.GetOtSummaryview(Model.OtscheduleID,Model.Answer);
            var viewModel = new OTSummaryViewModel
            {
                OtscheduleID = Model.OtscheduleID,
                Answer = Model.Answer,
                SHotsumm = result
            };
            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["getscheduleID"] = classOT.getscheduleID();
            return View("OTSummary", viewModel);


        }

        public async Task<IActionResult> GetReport(OtScheduleViewModel Model,string Date)
        {

            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);

            ViewData["facilityid"] = classOT.Getfacid();
            

            if (classOT != null)
            {
                var testResults = classOT.GetOtScheduleViews(Model.FacilityID , Model.Date);
                return View("OtScheduleView", testResults);
            }


            return View("OtScheduleView",Model);

        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OTScheduling()
        {

            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["patientid"] = classOT.GetPatientID();
            ViewData["facilityid"] = classOT.GetFacilityid();
            ViewData["Depid"] = classOT.GetDepid();
            ViewData["tableid"] = classOT.Gettableid();
            return View();
        }
        public IActionResult OTConfirmation()
        {
            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["getscheduleid"] = classOT.getscheduleid();
            return View();
        }
        public IActionResult OTNotes()
        {
            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["patientID"] = classOT.getpatid();
            ViewData["getscheduleid"] = classOT.getschedluid();
            return View();
        }
        public IActionResult OTSummary()
        {
            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["getscheduleID"] = classOT.getscheduleID();

            return View();
        }

        public IActionResult OtScheduleView()
        {

            BusinessClassOT classOT = new BusinessClassOT(Getotschedule);
            ViewData["facilityid"] = classOT.Getfacid();
            return View();
        }
    }
}
