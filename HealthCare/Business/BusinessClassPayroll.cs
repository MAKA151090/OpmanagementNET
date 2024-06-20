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
                ).ToList();

            return levId;
                
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
