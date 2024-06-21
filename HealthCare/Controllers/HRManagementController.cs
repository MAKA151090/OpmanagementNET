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

            var existingAtt = await GetStaffPayroll.SHStaffAttendance.FindAsync(model.StaffID, model.Date, model.AttendanceID);
            if (existingAtt != null)
            {
                existingAtt.AttendanceID = model.AttendanceID;
                existingAtt.StaffID = model.StaffID;
                existingAtt.Date = model.Date;
                existingAtt.CheckInTime = model.CheckInTime;
                existingAtt.CheckOuTtime = model.CheckOuTtime;
                existingAtt.Status = model.Status;
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

            var existingLev = await GetStaffPayroll.SHStaffLeave.FindAsync(model.LeaveID, model.StaffID, model.LeaveType);

            int newNoOfDays = 0;

            if (int.TryParse(model.NoOfDays, out newNoOfDays))
            {
                int currentBalance = 0;

                if (existingLev != null)
                {
                    // Calculate days difference if existing leave record is found
                    int existingNoOfDays = 0;
                    if (int.TryParse(existingLev.NoOfDays, out existingNoOfDays))
                    {
                        int daysDifference = existingNoOfDays - newNoOfDays;

                        // Update existing leave record
                        existingLev.StaffID = model.StaffID;
                        existingLev.LeaveID = model.LeaveID;
                        existingLev.LeaveType = model.LeaveType;
                        existingLev.StartDate = model.StartDate;
                        existingLev.NoOfDays = model.NoOfDays;
                        existingLev.ApprovalStatus = model.ApprovalStatus;
                        existingLev.AppliedDate = model.AppliedDate;
                        existingLev.LastUppdatedDate = DateTime.Now.ToString();
                        existingLev.LastUpdatedUser = User.Claims.First().Value.ToString();
                        existingLev.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                        GetStaffPayroll.Entry(existingLev).State = EntityState.Modified;

                        //update balance
                        var extypebalance = await GetStaffPayroll.SHLeaveTypeMaster
                                                          .FirstOrDefaultAsync(ltm => ltm.LeaveType == model.LeaveType && ltm.StaffID == model.StaffID);

                        if (extypebalance != null)
                        {

                            int totalLeaveDays = int.Parse(extypebalance.Balance);
                            currentBalance = totalLeaveDays - newNoOfDays;


                            extypebalance.Balance = currentBalance.ToString();
                            GetStaffPayroll.Entry(extypebalance).State = EntityState.Modified;
                        }


                    }
                }
                else
                {

                    // Fetch total leave days directly from database
                    var leaveTypeRecord = await GetStaffPayroll.SHLeaveTypeMaster
                                                          .FirstOrDefaultAsync(ltm => ltm.LeaveType == model.LeaveType && ltm.StaffID == model.StaffID);

                    if (leaveTypeRecord != null)
                    {

                        int totalLeaveDays = int.Parse(leaveTypeRecord.Total);
                        currentBalance = totalLeaveDays - newNoOfDays;


                        leaveTypeRecord.Balance = currentBalance.ToString();
                        GetStaffPayroll.Entry(leaveTypeRecord).State = EntityState.Modified;
                    }

                    model.LastUppdatedDate = DateTime.Now.ToString();
                    model.LastUpdatedUser = User.Claims.First().Value.ToString();
                    model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                    GetStaffPayroll.SHStaffLeave.Add(model);
                }


                await GetStaffPayroll.SaveChangesAsync();


            }
            ViewBag.Message = "Saved Successfully";
            return View("StaffLeave", model);
        }

        public async Task<IActionResult> GetStaffLeaveMaster(LeaveTypeMaster model)
        {

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();

            var existingLevmas = await GetStaffPayroll.SHLeaveTypeMaster.FindAsync(model.StaffID, model.LeaveType);
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

        public async Task<IActionResult> GetHierarchy(EmployeeHierarchymaster model)
        {

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();

            var existingemph = await GetStaffPayroll.SHEmpHierarchy.FindAsync(model.EmpStaffID, model.MgrStaffID);
            if (existingemph != null)
            {
                existingemph.EmpStaffID = model.EmpStaffID;
                existingemph.MgrStaffID = model.MgrStaffID;
                existingemph.ExpiryDate = model.ExpiryDate;
                existingemph.LastUpdatedDate = DateTime.Now.ToString();
                existingemph.LastUpdatedUser = User.Claims.First().Value.ToString();
                existingemph.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.Entry(existingemph).State = EntityState.Modified;

            }

            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.SHEmpHierarchy.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("EmployeeHierarchymaster", model);
        }

        public async Task<IActionResult> GetStaffBank(StaffBankDetailsModel model)
        {
           

            var staff = GetStaffPayroll.SHclnStaffAdminModel.FirstOrDefault(s => s.StrStaffID == model.StaffID);

            if (staff != null)
            {
                // Assign StaffName from the fetched staff details
                model.StaffName = staff.StrFullName;

                BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
                ViewData["docid"] = payroll.Getdocid();

                var existingBank = await GetStaffPayroll.SHBankdetails.FindAsync(model.StaffID, model.AccountNumber);
                if (existingBank != null)
                {
                    existingBank.StaffID = model.StaffID;
                    existingBank.AccountNumber = model.AccountNumber;
                    existingBank.StaffName = model.StaffName;
                    existingBank.BankName = model.BankName;
                    existingBank.IFSCCode = model.IFSCCode;
                    existingBank.Primary = model.Primary;
                    existingBank.LastUpdatedDate = DateTime.Now.ToString();
                    existingBank.LastUpdatedUser = User.Claims.First().Value.ToString();
                    existingBank.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    GetStaffPayroll.Entry(existingBank).State = EntityState.Modified;

                }



                else
                {
                    model.LastUpdatedDate = DateTime.Now.ToString();
                    model.LastUpdatedUser = User.Claims.First().Value.ToString();
                    model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    GetStaffPayroll.SHBankdetails.Add(model);
                }
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("StaffBankDetail", model);
        }

        public async Task<IActionResult> GetTax(TaxModel model)
        {

            var existingTax = await GetStaffPayroll.SHTaxModel.FindAsync(model.TaxID, model.TaxType);
            if (existingTax != null)
            {
                existingTax.TaxID = model.TaxID;
                existingTax.TaxType = model.TaxType;
                existingTax.TaxAmount = model.TaxAmount;
                existingTax.ApplicablePeriod = model.ApplicablePeriod;
                existingTax.LastUpdatedDate = DateTime.Now.ToString();
                existingTax.LastUpdatedUser = User.Claims.First().Value.ToString();
                existingTax.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.Entry(existingTax).State = EntityState.Modified;

            }

            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.SHTaxModel.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("StaffTaxMaster", model);
        }


        public async Task<IActionResult> GetPayroll(PayrollModel model, string buttonType)
        {

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();

            if (buttonType == "PayrollTaxMaster")
            {
                TempData["PayrollID"] = model.PayrollID;
                TempData["StaffID"] = model.StaffID;
                TempData.Keep("PayrollID");
                TempData.Keep("StaffID");

                return RedirectToAction("PayrollTaxMaster");
            }


            if (string.IsNullOrEmpty(TempData["TotalTax"]?.ToString()))
            {
                ViewBag.TaxMessage = "Please enter tax deduction";
                return View("Payroll", model);
            }


            var existingPay = await GetStaffPayroll.SHpayroll.FindAsync(model.StaffID, model.PayrollID);
            if (existingPay != null)
            {
                existingPay.PayrollID = model.PayrollID;
                existingPay.StaffID = model.StaffID;
                existingPay.StaffName = model.StaffName;
                existingPay.PayPeriod = model.PayPeriod;
                existingPay.BasicSalary = model.BasicSalary;
                existingPay.Bonus = model.Bonus;
                existingPay.ProvidentFund = model.ProvidentFund;
                model.TaxDeduction = TempData["TotalTax"] != null ? TempData["TotalTax"].ToString() : model.TaxDeduction;
                existingPay.Allowances = model.Allowances;
                existingPay.GrossSalary = model.GrossSalary;
                existingPay.NetSalary = model.NetSalary;
                existingPay.PaymentDate = model.PaymentDate;
                existingPay.PaymentStatus = model.PaymentStatus;
                existingPay.HRA = model.HRA;
                existingPay.Remark = model.Remark;
                existingPay.LastUpdatedDate = DateTime.Now.ToString();
                existingPay.LastUpdatedUser = User.Claims.First().Value.ToString();
                existingPay.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetStaffPayroll.Entry(existingPay).State = EntityState.Modified;

            }

            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.TaxDeduction = TempData["TotalTax"] != null ? TempData["TotalTax"].ToString() : model.TaxDeduction;
                GetStaffPayroll.SHpayroll.Add(model);
                await GetStaffPayroll.SaveChangesAsync();
                return View("Payroll", model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("Payroll", model);
        }

        [HttpPost]
        public async Task<IActionResult> PayrollTaxMaster(string StaffID, string PayrollID, string action, List<PayrollTaxModel> taxDetails)
        {
            ViewBag.StaffID = StaffID;
            ViewBag.PayrollID = PayrollID;


            if (action == "Add Tax")
            {
                var newDetail = new PayrollTaxModel
                {
                    PayrollID = PayrollID,
                    StaffID = StaffID,
                    Taxtype = string.Empty,
                    Amount = string.Empty,
                    IsDelete = false
                };

                GetStaffPayroll.SHpayrollTax.Add(newDetail);
                GetStaffPayroll.SaveChanges();


                ViewBag.Slots = GetStaffPayroll.SHpayrollTax.Where(b => b.PayrollID == PayrollID && b.StaffID == StaffID && b.IsDelete == false).ToList();
            }


            else if (action == "Get Tax")
            {

                var gettaxDetails = await GetStaffPayroll.SHpayrollTax
                .Where(b => b.PayrollID == PayrollID && b.StaffID == StaffID && b.IsDelete == false)
                .ToListAsync();

                if (gettaxDetails != null && gettaxDetails.Any())
                {

                    ViewBag.Slots = gettaxDetails;
                }
                else
                {
                    ViewBag.getbill = "No Bill is available for this ID";
                }

            }

            else if (action == "Delete Tax")
            {

                var taxToDelete = GetStaffPayroll.SHpayrollTax
            .Where(b => b.PayrollID == PayrollID && b.StaffID == StaffID)
            .ToList();

                foreach (var detail in taxToDelete)
                {
                    detail.IsDelete = true;
                    GetStaffPayroll.SHpayrollTax.Update(detail);
                }

                ViewBag.DelTotal = "Deleted  Bill Successfully";
                GetStaffPayroll.SaveChanges();

            }
            else if (action == "Save")
            {

                foreach (var detail in taxDetails)
                {

                    detail.LastUpdatedDate = DateTime.Now.ToString();
                    detail.LastUpdatedUser = User.Claims.First().Value.ToString();
                    detail.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    detail.Amount = detail.Amount.ToString();


                    GetStaffPayroll.SHpayrollTax.Update(detail);
                }
                GetStaffPayroll.SaveChanges();

                var totalTax = taxDetails
            .Where(t => !t.IsDelete)
            .Sum(t => decimal.TryParse(t.Amount, out var amount) ? amount : 0);

                TempData["TotalTax"] = totalTax.ToString();


                return RedirectToAction("GetPayroll", new { StaffID = StaffID, PayrollID = PayrollID, buttonType = "" });

            }

            return View("PayrollTaxMaster");
        }





        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Payroll()
        {
            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
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

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
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
            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["docid"] = payroll.Getdocid();
            return View();
        }

        public IActionResult StaffTaxMaster()
        {
            return View();
        }


        public async Task<IActionResult> PayrollTaxMaster()
        {
            var model = new List<EmployeeTaxViewModel>();


            if (TempData["PayrollID"] != null && TempData["StaffID"] != null)
            {
                string payrollID = TempData["PayrollID"] as string;
                string staffID = TempData["StaffID"] as string;


                ViewBag.PayrollID = payrollID;
                ViewBag.StaffID = staffID;

                // Check if there are existing entries in the database
                var existingEntries = await GetStaffPayroll.SHpayrollTax
                    .Where(s => s.PayrollID == payrollID && s.StaffID == staffID)
                    .ToListAsync();

                if (existingEntries != null && existingEntries.Any())
                {
                    // Map existing entries to EmployeeTaxViewModel
                    model = existingEntries.Select(entry => new EmployeeTaxViewModel
                    {
                        PayrollID = entry.PayrollID,
                        StaffID = entry.StaffID,

                    }).ToList();

                    return View(model);
                }

                // If no existing entries found, create a new model instance with TempData values
                var taxModel = new EmployeeTaxViewModel
                {
                    PayrollID = payrollID,
                    StaffID = staffID
                };

                model.Add(taxModel);
            }

            // Pass the model to the view
            return View(model);
        }
    }
}
