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
                           from o in _healthcareContext.SHfdOpCheckingModel
                          from  ds in _healthcareContext.SHclnResourceSchedule 
                          join dr in _healthcareContext.SHclnStaffAdminModel on ds.StaffID equals dr.StrStaffID
                          join pr in _healthcareContext.SHPatientRegistration on ds.PatientID equals pr.PatientID
                         
                          where ds.PatientID == PatienId
                          select new OpCheckingModelResult
                          {   
                              PatientName = pr.FullName,
                              DoctorName = dr.StrFullName,
                              AppoinmentDate = ds.Date,
                              AppoinmentTime = ds.StartTime,
                              VisitStatus=o.VisitStatus,
                              
                              
                          }).ToListAsync().Result;

            return OpCheckingData;

        }





        public async Task <StaffAttendanceViewModel> GetStaffAttendancebus(string pstaffID)
        {
            StaffAttendanceViewModel staffBusModel = new StaffAttendanceViewModel();

            staffBusModel.StfAttedance = GetViewAttendence(pstaffID);

            var result =
                await (
                        from op in _healthcareContext.SHStaffAttendance
                        select new StaffAttendanceViewModel
                        {
                            StaffID = op.StaffID,
                            Date = op.Date,
                            Office = op.Office,
                            CheckInTime = op.CheckInTime,
                            CheckOuTtime = op.CheckOuTtime,
                        }
                ).FirstOrDefaultAsync();
            staffBusModel.StaffID = result.StaffID;
            staffBusModel.Date = result.Date;
            staffBusModel.Office = result.Office;
            staffBusModel.CheckInTime = result.CheckInTime;
            staffBusModel.CheckOuTtime = result.CheckOuTtime;

            return staffBusModel;
        }

        public List<StaffAttendanceModel> GetViewAttendence(string pstaffID)
        {
            var result = (
                        from op in _healthcareContext.SHStaffAttendance
                        where op.StaffID == pstaffID
                        select new StaffAttendanceModel
                        {
                            StaffID = op.StaffID,
                            Date = op.Date,
                            Office = op.Office,
                            CheckInTime = op.CheckInTime,
                            CheckOuTtime = op.CheckOuTtime,
                        }
                ).ToList();
            return result;
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