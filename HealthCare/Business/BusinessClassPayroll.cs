using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Business
{
    public class BusinessClassPayroll : Controller
    {

        private HealthcareContext _healthcareContext;

        public BusinessClassPayroll(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }


        public List<StaffAdminModel> AllStaff(string facility)
        {
            var alldocid = (
            from pr in _healthcareContext.SHclnStaffAdminModel
            where pr.FacilityID == facility
            select new StaffAdminModel
            {
                StrStaffID = pr.StrStaffID,
                StrFullName = pr.StrFullName
            }
                    ).ToList();

            return alldocid;
        }


        public List<PayHeadMaster> getPayhead(string facility)
        {
            var getpayhead = (
            from pr in _healthcareContext.SHpayhead
            where pr.FacilityID == facility
            select new PayHeadMaster
            {
                PayheadID = pr.PayheadID,
                PayheadName = pr.PayheadName
            }
                    ).ToList();

            return getpayhead;
        }

        public List<StaffAdminModel> Getdocid()
        {
            var docid = (
            from pr in _healthcareContext.SHclnStaffAdminModel
                    join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor"
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName
                    }
                    ).ToList();

            return docid;
        }


        public List<LeaveTypeMaster> GetlevId()
        {
            var levId=(
                 from l in _healthcareContext.SHLeaveTypeMaster
                 select new LeaveTypeMaster
                 {
                     LeaveType = l.LeaveType,
                    

                 }
                ).Distinct().ToList();

            return levId;
                
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
