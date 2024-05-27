using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

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


    }
}
