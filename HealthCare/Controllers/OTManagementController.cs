using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                existingSchedule.lastUpdatedUser = "Myself";
                existingSchedule.lastUpdatedMachine = "Lap";
            }
            else
            {
                pSchedule.lastupdatedDate = DateTime.Now.ToString();
                pSchedule.lastUpdatedUser = "Myself";
                pSchedule.lastUpdatedMachine = "Lap";
                Getotschedule.SHotScheduling.Add(pSchedule);

            }
            await Getotschedule.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
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
                existingNotes.lastUpdatedUser = "Myself";
                existingNotes.lastUpdatedMachine = "Lap";
            }
            else
            {
                pNotes.lastupdatedDate = DateTime.Now.ToString();
                pNotes.lastUpdatedUser = "Myself";
                pNotes.lastUpdatedMachine = "Lap";
                Getotschedule.SHotNotes.Add(pNotes);

            }
            await Getotschedule.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("OTNotes", pNotes);


        }
        public async Task<IActionResult> GetviewOT(OtConfirmViewModel Model , string buttonType,OTSchedulingModel pConfirm)
        {
            BusinessClassExamination ObjViewOT = new BusinessClassExamination(Getotschedule);

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
                return View("OTConfirmation", result);
            

        }



            public IActionResult Index()
        {
            return View();
        }
        public IActionResult OTScheduling()
        {
            return View();
        }
        public IActionResult OTConfirmation()
        {
            return View();
        }
        public IActionResult OTNotes()
        {
            return View();
        }
        public IActionResult OTSummary()
        {
            return View();
        }
    }
}
