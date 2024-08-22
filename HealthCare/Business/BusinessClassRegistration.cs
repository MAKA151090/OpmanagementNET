using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;

namespace HealthCare.Business
{
    public class BusinessClassRegistration
    {

        private readonly HealthcareContext objDbContext;

        public BusinessClassRegistration(HealthcareContext serviceContext)
        {
            objDbContext = serviceContext;
        }
        public async Task<PatientRegistrationModel> GetPatientObjectiveSubmit(string patientID, string FacilityID)
        {
           
            var patitentRegDataSubmit = await objDbContext.SHPatientRegistration.FirstOrDefaultAsync(x =>
                    x.PatientID == patientID && x.FacilityID == FacilityID);

            return patitentRegDataSubmit;
        }

        //Patient Scheduling DropDown

        public List<StaffAdminModel> GetStaffDropDown()
        {
            var staffDPD = (
                    from pr in objDbContext.SHclnStaffAdminModel
                    join p in objDbContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor"
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName,

                    }
                ).ToList();

            return staffDPD;

           
        }
        public List<PatientRegistrationModel> GetpatientIDDPD()
        {
            var patIDDPD = (
                    from pr in objDbContext.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName
                    }
                ).ToList();

            return patIDDPD;
        }

        public List<ClinicAdminModel> GetFacilityID()
        {
            var FacDPD = (
                    from pr in objDbContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID,
                        ClinicName = pr.ClinicName,
                    }
                ).ToList();

            return FacDPD;
        }

        public IEnumerable<PatientShceduleViewModel> GetAvailableSchedules(string staffID, string facilityID, string date)
        {
            var query = from s in objDbContext.SHclnResourceSchedule
                        join sa in objDbContext.SHclnStaffAdminModel on s.StaffID equals sa.StrStaffID
                        join ca in objDbContext.SHclnClinicAdmin on s.FacilityID equals ca.FacilityID
                        where s.StaffID == staffID && s.FacilityID == facilityID && s.Date == date
                              && s.Holiday == false && s.Blocker == false && s.StrInActive == false && s.PatientID == null
                        select new PatientShceduleViewModel
                        {
                            ScheduleID = s.SlotsID,
                            StaffID = s.StaffID,
                            StaffName = sa.StrFullName,
                            FacilityName = ca.ClinicName,
                            StartTime = s.StartTime,
                            Duration = s.Duration
                        };

            return query.ToList();
        }

        public IEnumerable<PatientShceduleViewModel> GetPatientSlot(string patientID, string facilityID, string date, string staffID)
        {
            var patientslot = from s in objDbContext.SHclnResourceSchedule
                              join sa in objDbContext.SHclnStaffAdminModel on s.StaffID equals sa.StrStaffID
                              join ca in objDbContext.SHclnClinicAdmin on s.FacilityID equals ca.FacilityID
                              where s.StaffID == staffID
                              && s.FacilityID == facilityID
                              && s.Date == date
                              && s.PatientID == patientID
                        select new PatientShceduleViewModel
                        {
                            ScheduleID = s.SlotsID,
                            PatientID = s.PatientID,
                            StaffID = s.StaffID,
                            FacilityID = s.FacilityID,
                            Date = s.Date,
                            StartTime=s.StartTime,
                            Duration = s.Duration,
                            StaffName = sa.StrFullName,
                            FacilityName = ca.ClinicName

                        };

            return patientslot.ToList();
        }


        public void SaveSelectedSchedules(string patientID, List<string> selectedSchedules)
        {
            foreach (var selectslot in selectedSchedules)
            {
                var schedules = objDbContext.SHclnResourceSchedule
                         .Where(schedules => schedules.SlotsID == selectslot).First();

                schedules.PatientID = patientID;


            }
            objDbContext.SaveChanges();
        }

        public void CancelScheduleSlot (string patientID, List<string> selectedSchedules)
        {
            foreach(var selectslot in selectedSchedules)
            {
                var schedules = objDbContext.SHclnResourceSchedule
                        .Where(schedules => schedules.SlotsID == selectslot).First();
              
                schedules.PatientID = null;

            }
            objDbContext.SaveChanges();
        }



        ///blood group  
        ///

        public List<BloodGroupModel> GetBloodGroup()
        {
            var bldgrpid = (
                    from pr in objDbContext.SHclnBloodGroup
                    select new BloodGroupModel
                    {
                        BloodGroup = pr.BloodGroup
                    }
               ).ToList();

            return bldgrpid;
        }


        public List<ClinicAdminModel> GetFacilityid()
        {
            var Facid = (
                    from pr in objDbContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID,
                        ClinicName = pr.ClinicName,
                    }
                ).ToList();

            return Facid;



        }


        public List<String> GetRoll(string userid)
        {
            var query = from sm in objDbContext.SHClnScreenMaster
                        join rac in objDbContext.SHClnRollAccess on sm.ScreenId equals rac.ScreenID
                        join ram in objDbContext.ShclnrollAccessmaster on rac.RollID equals ram.RollID
                        join sam in objDbContext.SHclnStaffAdminModel on ram.StaffID equals sam.StrStaffID
                        where rac.Authorized == "1" && sam.StrUserName == userid
                        select sm.ScreenName;

            var result = query.ToList();
            return result;
        }



    }


}
