using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                GetStaffPayroll.Entry(existingAtt).State = EntityState.Modified;
                
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
            return View("StaffAttendance", model);
        }


        public async Task<IActionResult> GetStaffLeave(StaffLeaveModel model)
        {

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
            ViewData["levId"] = payroll.GetlevId();

            var existingLev = await GetStaffPayroll.SHStaffLeave.FindAsync(model.StaffID, model.LeaveID, model.LeaveType);
            var exleaveTypeMas = await GetStaffPayroll.SHLeaveTypeMaster.FindAsync(model.StaffID, model.LeaveType);

            if (existingLev != null)
            {
                int existingNoOfDays = int.Parse(existingLev.NoOfDays);
                int newNoOfDays = int.Parse(model.NoOfDays);

                // Calculate the difference in leave days
                int daysDifference = newNoOfDays - existingNoOfDays;

                existingLev.StaffID = model.StaffID;
                existingLev.LeaveID = model.LeaveID;
                existingLev.LeaveType = model.LeaveType;
                existingLev.StartDate = model.StartDate;
                existingLev.NoOfDays = model.NoOfDays;
                existingLev.ApprovalStatus= model.ApprovalStatus;
                existingLev.AppliedDate=model.AppliedDate;
                existingLev.LastUppdatedDate = DateTime.Now.ToString();
                existingLev.LastUpdatedUser = User.Claims.First().Value.ToString();
                existingLev.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.Entry(existingLev).State = EntityState.Modified;

                if (exleaveTypeMas != null)
                {
                    int currentBalance = int.Parse(exleaveTypeMas.Balance);
                    currentBalance -= daysDifference;
                    exleaveTypeMas.Balance = currentBalance.ToString();
                    GetStaffPayroll.Entry(exleaveTypeMas).State = EntityState.Modified;
                }

            }

            else
            {
                int newNoOfDays = int.Parse(model.NoOfDays);

                // Update the leave balance for a new leave entry
                if (exleaveTypeMas != null)
                {
                    int currentBalance = int.Parse(exleaveTypeMas.Balance);
                    currentBalance -= newNoOfDays;
                    exleaveTypeMas.Balance = currentBalance.ToString();
                    GetStaffPayroll.Entry(exleaveTypeMas).State = EntityState.Modified;
                }

                model.LastUppdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.SHStaffLeave.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("StaffLeave", model);
        }

        public async Task<IActionResult> GetStaffLeaveMaster(LeaveTypeMaster model)
        {

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
         
            var existingLevmas = await GetStaffPayroll.SHLeaveTypeMaster.FindAsync(model.StaffID,model.LeaveType);
            if (existingLevmas != null)
            {
                existingLevmas.StaffID = model.StaffID;
                existingLevmas.Total = model.Total;
                existingLevmas.LeaveType = model.LeaveType;
                existingLevmas.Balance = model.Balance;
                existingLevmas.LastUpdatedDate = DateTime.Now.ToString();
                existingLevmas.LastUpdatedUser = User.Claims.First().Value.ToString();
                existingLevmas.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.Entry(existingLevmas).State = EntityState.Modified;

            }

            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.SHLeaveTypeMaster.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("LeaveTypeMaster", model);
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

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
            ViewData["levId"] = payroll.GetlevId();

            return View();
        }

        public IActionResult StaffBankDetail()
        {
            return View();
        }

        public IActionResult LeaveTypeMaster()
        {
            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
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
