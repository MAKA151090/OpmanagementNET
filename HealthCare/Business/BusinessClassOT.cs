using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassOT : Controller
    {

        private readonly HealthcareContext objSearchContext;

        public BusinessClassOT(HealthcareContext serviceContext)
        {
            objSearchContext = serviceContext;
        }

        ///ot scheduling 
        public List<PatientRegistrationModel> GetPatientID()
        {
            var patientid = (
                    from pr in objSearchContext.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName,
                    }
                ).ToList();

            return patientid;
        }

        public List<ClinicAdminModel> GetFacilityid()
        {
            var facilityid = (
                from pr in objSearchContext.SHclnClinicAdmin
                select new
                ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName,
                }
                ).ToList();
            return facilityid;
        }

        public List<OtTableMasterModel> gettableid()
        {
            var tableid = (
                from pr in objSearchContext.SHotTableMaster
                select new OtTableMasterModel
                {
                    TableID = pr.TableID,
                    TableName = pr.TableName,
                }
                ).ToList();
            return tableid;
        }


        ///otconfirmation  
    
        public List<OtScheduleViewModel> getscheduleid()
        {
            var getscheduleid = (
                from pr in objSearchContext.SHotScheduling
                select new OtScheduleViewModel
                {
                    OtSchedulingId = pr.OtScheduleID
                }
                ).ToList();

            return getscheduleid;
        }

        ///ot notes
        public List<PatientRegistrationModel> getpatid()
        {
            var patientID = (
                from pr in objSearchContext.SHPatientRegistration
                select new PatientRegistrationModel
                {
                   PatientID = pr.PatientID,
                   FullName = pr.FullName,
                }
                ).ToList();

            return patientID;
        }

        public List<OtScheduleViewModel> getschedluid()
        {
            var getscheduleid = (
                from pr in objSearchContext.SHotScheduling
                select new OtScheduleViewModel
                {
                    OtSchedulingId = pr.OtScheduleID
                }
                ).ToList();

            return getscheduleid;
        }

        ///ot summary  
        ///


        public List<OtScheduleViewModel> getscheduleID()
        {
            var getscheduleID = (
                from pr in objSearchContext.SHotScheduling
                select new OtScheduleViewModel
                {
                    OtSchedulingId = pr.OtScheduleID
                }
                ).ToList();

            return getscheduleID;
        }



        ///ot schedule view 
        ///

        public List<ClinicAdminModel> Getfacid()
        {
            var facilityid = (
                from pr in objSearchContext.SHclnClinicAdmin
                select new
                ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName,
                }
                ).ToList();
            return facilityid;
        }


        public List<OtScheduleViewModel> GetOtScheduleViews(string FacilityID)
        {
            var OpCheckingData = (
                          from op in objSearchContext.SHPatientRegistration
                          join ds in objSearchContext.SHotScheduling on op.PatientID equals ds.PatientID
                          join dc in objSearchContext.SHotInternalDepartmentMaster on ds.InchrgDepID equals dc.DepartmentID
                          where ds.FacilityID == FacilityID
                          select new OtScheduleViewModel
                          {
                              OtSchedulingId = ds.OtScheduleID,
                              PatientName = op.FullName,
                              ScheduleDateTime = ds.StartDate,
                              StartTime = ds.StartTime,
                              Duration = ds.Duration,
                              IncharegeDeparment1 = dc.DepartmentName,
                              IsConformed = ds.Confirm,
                              TeamName = ds.TeamName
                          }).ToListAsync().Result;

            return OpCheckingData;

        }




        public async Task<OTConfirmationModel> GetOTConfirmation(string potScheduleID)
        {
            OTConfirmationModel oTConfirmation = new OTConfirmationModel();

            oTConfirmation.OtviewModel = GetOtViewdata(potScheduleID);

            var result = await (from ot in objSearchContext.SHotScheduling
                                join t in objSearchContext.SHotTableMaster on ot.TableID equals t.TableID
                                select new OTConfirmationModel
                                {
                                    OtScheduleID = ot.OtScheduleID,
                                    TableName = t.TableName,
                                    TeamName = ot.TeamName,
                                    Date = ot.StartDate,
                                    Duration = ot.Duration,
                                    RoomName = t.RoomName,
                                    ConfirmDate = ot.ConfirmDate,
                                    ConfirmBy = ot.ConfirmBy


                                }).FirstOrDefaultAsync();

            oTConfirmation.OtScheduleID =
                result.OtScheduleID;
            oTConfirmation.TableName = result.TableName;
            oTConfirmation.TeamName = result.TeamName;
            oTConfirmation.Date = result.Date;
            oTConfirmation.Duration = result.Duration;
            oTConfirmation.RoomName = result.RoomName;
            oTConfirmation.ConfirmDate = result.ConfirmDate;
            oTConfirmation.ConfirmBy = result.ConfirmBy;


            return oTConfirmation;


        }

        public List<OtConfirmViewModel> GetOtViewdata(string potscheduleID)
        {

            var result = (from ot in objSearchContext.SHotScheduling
                          join sm in objSearchContext.OtSurgeryModel on ot.OtScheduleID equals sm.OtScheduleID
                          join ots in objSearchContext.SHclnSurgeryMaster on sm.SurgeryID equals ots.SurgeryID

                          join t in objSearchContext.SHotTableMaster on ot.TableID equals t.TableID
                          where ot.OtScheduleID == potscheduleID && ot.IsDeleted != false && ot.Status != "Confirmed"
                          select new OtConfirmViewModel
                          {
                              OtscheduleID = ot.OtScheduleID,
                              SurgeryName = ots.SurgeryName,
                              TeamName = ot.TeamName,
                              Date = ot.StartDate,
                              Duration = ot.Duration,
                              TableName = ot.TeamName,
                              RoomName = t.TableName,



                          }).ToList();
            return result;

        }

        public async Task<bool> UpdateOTConfirmation(string otScheduleID, string status)
        {

            var scheduling = await objSearchContext.SHotScheduling.FirstOrDefaultAsync(x => x.OtScheduleID == otScheduleID);

            if (scheduling != null)
            {
                if (status == "Confirmed")
                {
                    scheduling.Status = "Confirmed";
                    scheduling.IsDeleted = true;

                }
                else if (status == "cancel")
                {
                    scheduling.Status = "cancel";
                    scheduling.IsDeleted = false;
                }

                await objSearchContext.SaveChangesAsync();

            }
            return true;
        }


        public List<OTSummaryModel> GetOtSummaryview(string potScheduleID, string answer)
        {


            var objnew = (objSearchContext.SHOTsummary.Where(x =>
                x.OtscheduleID == potScheduleID).Count());

            if (objnew <= 0)
            {
                var addSumm = objSearchContext.SHclnOtSummaryMaster.Select(e => e).ToList();

                foreach (var item in addSumm)
                {
                    var newObservation = new OTSummaryModel
                    {
                        QuestionID = item.QuestionID,
                        Question = item.Question,
                        Answer = answer,
                        OtscheduleID = potScheduleID
                    };
                    objSearchContext.SHOTsummary.Add(newObservation);

                }
                objSearchContext.SaveChanges();
            }

            var result = (
           from e in objSearchContext.SHclnOtSummaryMaster
           join o in objSearchContext.SHOTsummary
               on e.QuestionID equals o.QuestionID into otGroup
           from o in otGroup.DefaultIfEmpty()
           where (o.OtscheduleID == potScheduleID)
           select new OTSummaryModel
           {
               Question = e.Question,
               QuestionID = e.QuestionID,
               Answer = o != null ? o.Answer : string.Empty,

           }).ToList();

            return result;
        }



    }
}
