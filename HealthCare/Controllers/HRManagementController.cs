using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class HRManagementController : Controller
    {
        private HealthcareContext GetStaffPayroll;

        public HRManagementController(HealthcareContext GetPayroll)
        {
            this.GetStaffPayroll = GetPayroll;
        }

        public async Task<IActionResult> GetAttendance(StaffAttendanceModel model)
        {

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();

            var existingAtt = await GetStaffPayroll.SHStaffAttendance.FindAsync(model.StaffID,model.AttendanceID,model.Date);
            if (existingAtt != null)
            {
                existingAtt.AttendanceID = model.AttendanceID;
                existingAtt.StaffID = model.StaffID;
                existingAtt.Date = model.Date;
                existingAtt.CheckInTime = model.CheckInTime;
                existingAtt.CheckOuTtime = model.CheckOuTtime;
                existingAtt.Status= model.Status;
                existingAtt.lastUpdatedDate = DateTime.Now.ToString();
                existingAtt.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingAtt.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.SHStaffAttendance.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("SurgeryTypeMaster", model);
        }







        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Payroll()
        {
            return View();
        }

        public IActionResult StaffAttendance() 
        {
            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();

            return View();
        
        }

        public IActionResult StaffLeave()
        {
            return View();
        }

        public IActionResult StaffBankDetail()
        {
            return View();
        }

        public IActionResult LeaveTypeMaster()
        {
            return View();
        }

        public IActionResult EmployeeHierarchymaster()
        {
            return View();
        }

        public IActionResult StaffTaxMaster()
        {
            return View();
        }

        public IActionResult PayrollTaxMaster()
        {
            return View();
        }

    }
}
