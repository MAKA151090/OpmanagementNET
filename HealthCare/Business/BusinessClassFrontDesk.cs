using HealthCare.Context;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassFrontDesk
    {
        private readonly HealthcareContext _healthcareContext;
        private BusinessClassFrontDesk getSubmit;

        public BusinessClassFrontDesk(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }


        public BusinessClassFrontDesk(BusinessClassFrontDesk getSubmit)
        {
            this.getSubmit = getSubmit;
        }

        public List<OpCheckingModelResult> GetOpCheckingModel(string PatienId)
        {
            var OpCheckingData = (
                          from op in _healthcareContext.SHfdOpCheckingModel
                          join ds in _healthcareContext.SHclnResourceSchedule on op.PatientId equals ds.PatientID
                          join dr in _healthcareContext.SHclnStaffAdminModel on ds.StaffID equals dr.StrStaffID
                          join pr in _healthcareContext.SHPatientRegistration on op.PatientId equals pr.PatientID
                          where op.PatientId == PatienId
                          select new OpCheckingModelResult
                          {   
                              PatientName = pr.FullName,
                              DoctorName = dr.StrFullName,
                              AppoinmentDate = ds.Date,
                              AppoinmentTime = ds.StartTime
                          }).ToListAsync().Result;

            return OpCheckingData;

        }

        public List<OtScheduleViewModel> GetOtScheduleViews(string FacilityID)
        {
            var OpCheckingData = (
                          from op in _healthcareContext.SHPatientRegistration 
                          join ds in _healthcareContext.SHotScheduling on op.PatientID equals ds.PatientID
                          join dc in _healthcareContext.SHotInternalDepartmentMaster on ds.InchrgDepID equals dc.DepartmentID
                         where ds.FacilityID == FacilityID
                          select new OtScheduleViewModel
                           {
                               OtSchedulingId= ds.OtScheduleID,
                               PatientName=op.FullName,
                               ScheduleDateTime=ds.StartDate,
                               StartTime=ds.StartTime,
                               Duration=ds.Duration,
                               IncharegeDeparment1=dc.DepartmentName,
                               IsConformed=ds.Confirm,
                               TeamName=ds.TeamName
                          }).ToListAsync().Result;

            return OpCheckingData;

        }





        public async Task UpdateOpChecking(String OpChecking, String VisitStatus)
        {
            var OpCheking = await _healthcareContext.SHfdOpCheckingModel.FirstOrDefaultAsync(x => VisitStatus == VisitStatus);
            if (OpCheking != null)
            {
                VisitStatus = "CheckedOut";
            }
            _healthcareContext.SHfdOpCheckingModel.Update(OpCheking);
            await _healthcareContext.SaveChangesAsync();

        }


            public List<StaffAdminModel> GetStaffid()
        {
            var staffid = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName,

                    }
                ).ToList();

            return staffid;
        }


    }

}