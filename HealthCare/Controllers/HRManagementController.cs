using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Globalization;

namespace HealthCare.Controllers
{
    public class HRManagementController : Controller
    {
        private HealthcareContext GetStaffPayroll;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;


        public HRManagementController(HealthcareContext GetStaffPayroll, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.GetStaffPayroll = GetStaffPayroll;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }



        public async Task<IActionResult> PayHead()
        {
            PayHeadMaster cln = new PayHeadMaster();

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            ViewData["Payheaddata"] = await AdditionalPayheadMasterFun(facilityId);

            return View("PayHead", cln);
        }

        public async Task<DataTable> AdditionalPayheadMasterFun(string facilityId)
        {

            // Step 1: Perform the query
            var entities = GetStaffPayroll.SHpayhead
                                  .Where(e => e.FacilityID == facilityId && e.IsDelete == false).OrderByDescending(e => e.LastUpdatedDate)
                                  .ToList();

            // Step 2: Convert to DataTable
            return BusinessClassPayroll.convertToDataTableCategoryMaster(entities);


        }


        [HttpPost]
        public async Task<IActionResult> Addpayhead(PayHeadMaster model, string buttonType)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPatientPrescription docpres = new BusinessClassPatientPrescription(GetStaffPayroll);

            //var daocfac = docpres.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;

            // Use _httpContextAccessor to access HttpContext.Session
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FacilityID", facilityId);
            }
            else
            {
                TempData["ErrorMessage"] = "Session is not available. Please try again.";
                return RedirectToAction("ErrorPage");
            }


            if (buttonType == "Get")
            {
                var getpayheDdata = await GetStaffPayroll.SHpayhead.FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.PayheadID == model.PayheadID && x.IsDelete == false);
                if (getpayheDdata != null)
                {
                    var dataTable = await AdditionalPayheadMasterFun(facilityId);

                    // Store the DataTable in ViewData for access in the view
                    ViewData["Payheaddata"] = dataTable;
                    return View("PayHead", getpayheDdata);
                }
                else
                {
                    ViewBag.Message = "Payhead Not Found";
                }
                PayHeadMaster stf = new PayHeadMaster();

                var dataTable2 = await AdditionalPayheadMasterFun(facilityId);
                ViewData["Payheaddata"] = dataTable2;

                return View("PayHead", stf);

            }

            if (buttonType == "Delete")
            {
                var checkdelete = await GetStaffPayroll.SHpayhead.FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.PayheadID == model.PayheadID && x.IsDelete == false);
                if (checkdelete != null)
                {
                    checkdelete.IsDelete = true;
                    await GetStaffPayroll.SaveChangesAsync();


                    ViewBag.Message = "Deleted Successfully";


                }
                else
                {
                    ViewBag.Message = "No Data found";
                }

                PayHeadMaster cln = new PayHeadMaster();

                var dataTable2 = await AdditionalPayheadMasterFun(facilityId);
                ViewData["Payheaddata"] = dataTable2;


                return View("PayHead", cln);
            }

            var existinghead = await GetStaffPayroll.SHpayhead.FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.PayheadID == model.PayheadID);
            if (existinghead != null)
            {
                existinghead.PayheadName = model.PayheadName;
                existinghead.PayheadType = model.PayheadType;
                existinghead.PayheadCalculationType = model.PayheadCalculationType;
                existinghead.LastUpdatedDate = DateTime.Now.ToString();
                existinghead.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                existinghead.LastUpdatedUser = User.Claims.First().Value.ToString();
                existinghead.FacilityID = facilityId;
                GetStaffPayroll.Entry(existinghead).State = EntityState.Modified;
            }
            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.FacilityID = facilityId;
                GetStaffPayroll.SHpayhead.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            var dataTable3 = await AdditionalPayheadMasterFun(facilityId);
            ViewData["Payheaddata"] = dataTable3;


            return View("PayHead", model);
        }


        [HttpPost]
        public async Task<IActionResult> Addemployeepaymaster(EmployeePayMaster model, string buttonType, List<string> SelectedRollNames)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPatientPrescription docpres = new BusinessClassPatientPrescription(GetStaffPayroll);

           // var daocfac = docpres.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;


            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["alldocid"] = payroll.AllStaff(facilityId);
            ViewData["getpayhead"] = payroll.getPayhead(facilityId);

            // Use _httpContextAccessor to access HttpContext.Session
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FacilityID", facilityId);
            }
            else
            {
                TempData["ErrorMessage"] = "Session is not available. Please try again.";
                return RedirectToAction("ErrorPage");
            }

            if (buttonType == "Delete")
            {
                foreach (var payheadname in SelectedRollNames)
                {
                    // Find the record to delete
                    var recordToDelete = await GetStaffPayroll.SHemployeepay
                        .FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.Staffname == model.Staffname && x.Payhead == payheadname);

                    if (recordToDelete != null)
                    {
                        // Remove the record from the database
                        GetStaffPayroll.SHemployeepay.Remove(recordToDelete);
                        // Confirm deletion
                        ViewBag.Message = "Selected records deleted successfully.";
                    }
                    else
                    {
                        // Log or display a message for entries not found
                        ViewBag.Message = $"No data found for Payhead: {payheadname}";
                    }
                }

                // Save changes to apply all deletions
                await GetStaffPayroll.SaveChangesAsync();

              
                return View("EmployeePayMaster", model);
            }



            if (buttonType == "Get")
            {
                // Retrieve all Payhead names for the specified staff member
                var checkpayhead = await GetStaffPayroll.SHemployeepay
                    .Where(x => x.Staffname == model.Staffname && x.FacilityID == facilityId)
                    .Select(x => x.Payhead) // Get only the Payhead names
                    .ToListAsync();

                if (checkpayhead.Any())
                {
                    // Pass the list of selected Payhead names to the view
                    ViewData["SelectedPayheads"] = checkpayhead;
                    return View("EmployeePayMaster", model);
                }
                else
                {
                    ViewBag.Message = "No Data Found";
                }

                return View("EmployeePayMaster", model);
            }


            foreach (var payheadname in SelectedRollNames)
            {
                // Retrieve the Payhead details
                var payHeadDetails = await GetStaffPayroll.SHpayhead
                    .FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.PayheadName == payheadname && x.IsDelete == false);

                if (payHeadDetails == null)
                {
                    ViewBag.Message = "Invalid Payhead selected.";
                    return View("EmployeePayMaster", model);
                }

                // Determine Dr or Cr based on Headtype
                string drValue = payHeadDetails.PayheadType switch
                {
                    "Earningsforemployee" => "Dr",
                    "Deductionfromemployee" => "Cr",
                    _ => null
                };

                if (drValue == null)
                {
                    ViewBag.Message = "Invalid Headtype selected.";
                    return View("EmployeePayMaster", model);
                }

                // Check for existing record
                var existingPay = await GetStaffPayroll.SHemployeepay
                    .FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.Staffname == model.Staffname && x.Payhead == payheadname);

                if (existingPay != null)
                {
                    // Update existing record
                    existingPay.Staffname = model.Staffname;
                    existingPay.Payhead = payheadname;
                    existingPay.Headtype = drValue;
                    existingPay.LastUpdatedDate = DateTime.Now.ToString();
                    existingPay.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    existingPay.LastUpdatedUser = User.Claims.First().Value.ToString();
                    existingPay.FacilityID = facilityId;
                    GetStaffPayroll.Entry(existingPay).State = EntityState.Modified;
                }
                else
                {
                    // Add a new record
                    var newPay = new EmployeePayMaster
                    {
                        Staffname = model.Staffname,
                        Payhead = payheadname,
                        Headtype = drValue,
                        LastUpdatedDate = DateTime.Now.ToString(),
                        LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        LastUpdatedUser = User.Claims.First().Value.ToString(),
                        FacilityID = facilityId
                    };

                    GetStaffPayroll.SHemployeepay.Add(newPay);
                }
            }

            // Save all changes at once
            await GetStaffPayroll.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";
            return View("EmployeePayMaster", model);
        }
    


            [HttpPost]
        public async Task<IActionResult> Addemployeepayroll(EmployeePayrollModel model, string buttonType, string PayheadType, string headtype, EmployeePayrollView viewmodel)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPatientPrescription docpres = new BusinessClassPatientPrescription(GetStaffPayroll);
          //  var daocfac = docpres.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["alldocid"] = payroll.AllStaff(facilityId);

            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FacilityID", facilityId);
            }
            else
            {
                TempData["ErrorMessage"] = "Session is not available. Please try again.";
                return RedirectToAction("ErrorPage");
            }

            if (buttonType == "Print")
            {

                var checkdata =  (from ep in GetStaffPayroll.SHemployeepayroll
                                                 join ea in GetStaffPayroll.SHemployeeattendance on ep.StaffID equals ea.StaffID
                                                 where ep.StaffID == model.StaffID
                                                       && ep.Month == model.Month
                                                       && ep.Year == model.Year
                                                       && ep.FacilityID == facilityId
                                                       && ea.Month == model.Month
                                                       && ea.Year == model.Year
                                                       && ea.FacilityID == facilityId
                                                       && ea.StaffID == model.StaffID
                                                 select ep).FirstOrDefault();

                if (checkdata != null)
                {





                    // Define the query to execute the stored procedure
                    var query = "CALL GetEmployeePayrollDetails(@StaffID, @Month, @Year, @FacilityID)";

                    var gettemplate = await GetStaffPayroll.SHclnClinicAdmin.Where(x => x.FacilityID == facilityId).Select(x => x.Template).FirstOrDefaultAsync();


                    string connectionString = _configuration.GetConnectionString("ClsPatientObjective");

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            // Open the connection
                            await connection.OpenAsync();

                            // Create a MySqlCommand to execute the stored procedure
                            using (var command = new MySqlCommand(query, connection))
                            {
                                // Add parameters to the command
                                command.Parameters.AddWithValue("@StaffID", viewmodel.StaffID);
                                command.Parameters.AddWithValue("@Month", viewmodel.Month);
                                command.Parameters.AddWithValue("@Year", viewmodel.Year);
                                command.Parameters.AddWithValue("@FacilityID", facilityId);

                                // Execute the command and read the data
                                using (var reader = await command.ExecuteReaderAsync())
                                {
                                    DataTable datatable = new DataTable();

                                    datatable.Load(reader);


                                    // Extract the template path from the results
                                    string facilityTemplate = gettemplate;

                                    // Generate and return the document
                                    BusinessClassPatientPrescription objBilling = new BusinessClassPatientPrescription(GetStaffPayroll);
                                    return File(
                                        objBilling.PrintpayrollDetails(facilityTemplate, datatable),
                                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                                        "Patient_Payroll_Details.docx"
                                    );
                                }

                            }
                        }

                        catch (Exception ex)
                        {
                            // Log the error and show an appropriate message
                            ViewBag.ErrorMessage = "An error occurred while fetching payroll details: " + ex.Message;
                        }

                    }
                }
                                else
                {

                    ViewBag.Message = "Employee Data Not Available";
                }
            return View("EmployeePayroll");
            }


                if (buttonType == "Delete")
            {
                // Fetch all payroll entries to delete that match the criteria
                var payrollsToDelete = await GetStaffPayroll.SHemployeepayroll
                    .Where(x =>
                        x.FacilityID == facilityId &&
                        x.StaffID == model.StaffID &&
                        x.Month == model.Month &&
                        x.Year == model.Year)
                    .ToListAsync();

                if (payrollsToDelete.Any())
                {
                    // Loop through and remove each matching record
                    foreach (var payrolll in payrollsToDelete)
                    {
                        GetStaffPayroll.SHemployeepayroll.Remove(payrolll);
                    }

                    // Save changes to the database
                    await GetStaffPayroll.SaveChangesAsync();

                    ViewBag.Message = "Deleted Successfully";

                    return View("EmployeePayroll");
                }
                else
                {
                    ViewBag.Message = "No matching records found to delete.";
                }

                return View("EmployeePayroll");
            }

            foreach (var item in viewmodel.Shpayrollview)
            {
                // Try to find an existing payroll entry for this payhead
                var existingemppayroll = await GetStaffPayroll.SHemployeepayroll.FirstOrDefaultAsync(x =>
                    x.FacilityID == facilityId &&
                    x.StaffID == model.StaffID &&
                    x.Month == model.Month &&
                    x.Year == model.Year &&
                    x.PayheadType == item.PayheadType);

                if (existingemppayroll != null)
                {
                    // Update the existing payroll entry
                    existingemppayroll.StaffID = model.StaffID;
                    existingemppayroll.Month = model.Month;
                    existingemppayroll.Year = model.Year;
                    existingemppayroll.Amount = item.Amount; // Update amount from the viewmodel
                    existingemppayroll.Total = model.Total;  // Update total
                    existingemppayroll.LastUpdatedDate = DateTime.Now.ToString();
                    existingemppayroll.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    existingemppayroll.LastUpdatedUser = User.Claims.First().Value.ToString();
                    existingemppayroll.FacilityID = facilityId;

                    GetStaffPayroll.Entry(existingemppayroll).State = EntityState.Modified;
                }
                else
                {
                    // Create a new payroll entry
                    var payrollEntry = new EmployeePayrollModel
                    {
                        StaffID = model.StaffID,
                        Month = model.Month,
                        Year = model.Year,
                        PayheadType = item.PayheadType, // Payhead for each item in the viewmodel
                        Amount = item.Amount,          // Amount from the viewmodel
                        Total = model.Total,           // Total value
                        LastUpdatedDate = DateTime.Now.ToString(),
                        LastUpdatedUser = User.Claims.First().Value.ToString(),
                        LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        FacilityID = facilityId
                    };

                    // Add the new payroll entry
                    GetStaffPayroll.SHemployeepayroll.Add(payrollEntry);
                }
            }

            // Save changes to the database
            await GetStaffPayroll.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";

            EmployeePayrollView pv = new EmployeePayrollView();

            return View("EmployeePayroll",pv);
        }


        [HttpPost]
        public async Task<IActionResult> Addleavemaster(LeaveMasterModel model, string buttonType)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            if(buttonType == "Delete")
            {
                var leavedelete = await GetStaffPayroll.SHleaveMaster.FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.LeaveName == model.LeaveName && x.IsDelete == false);

                if(leavedelete!=null)
                {
                    leavedelete.IsDelete = true;
                    await GetStaffPayroll.SaveChangesAsync();

                    ViewBag.Message = "Deleted Successfully";

                  
                }
                else
                {
                    ViewBag.Message = "No matching records found to delete.";
                }

                return View("LeaveMaster");
            }
        
            

            var existinghead = await GetStaffPayroll.SHleaveMaster.FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.LeaveName == model.LeaveName);
            if (existinghead != null)
            {
                existinghead.AttendanceType = model.AttendanceType;
                existinghead.LastUpdatedDate = DateTime.Now.ToString();
                existinghead.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                existinghead.LastUpdatedUser = User.Claims.First().Value.ToString();
                existinghead.FacilityID = facilityId;
                GetStaffPayroll.Entry(existinghead).State = EntityState.Modified;
            }
            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.FacilityID = facilityId;
                GetStaffPayroll.SHleaveMaster.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("LeaveMaster", model);
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

            var totalTax = TempData["TotalTax"]?.ToString();
            model.TaxDeduction = totalTax;

            var TaxExist = GetStaffPayroll.SHpayrollTax.FirstOrDefault(s => s.PayrollID==model.PayrollID);
            if(TaxExist==null)
            {
                ViewBag.TaxMessage = "Please enter tax deduction";
                return View("Payroll");
            }


            var staff = GetStaffPayroll.SHclnStaffAdminModel.FirstOrDefault(s => s.StrStaffID == model.StaffID);

            if (staff != null)
            {
                model.StaffName = staff.StrFullName;

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
                    existingPay.TaxDeduction = totalTax;
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

                    GetStaffPayroll.SHpayroll.Add(model);
                    await GetStaffPayroll.SaveChangesAsync();
                    return View("Payroll", model);
                }
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
                    ViewBag.getTax = "No Tax is available for this ID";
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

                ViewBag.DelTotal = "Deleted Tax Successfully";
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

       

        public IActionResult EmployeePayMaster()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["alldocid"] = payroll.AllStaff(facilityId);
            ViewData["getpayhead"] = payroll.getPayhead(facilityId);

            return View();
        }

        [HttpGet]
        public IActionResult GetPayheadsByStaffId(string staffId, string month, string year)
        {
            if (string.IsNullOrEmpty(staffId))
                return BadRequest("Invalid staff ID.");

            // Query SHemployeepayroll with the given month, year, and staffId
            var payrollEntries = (from emp in GetStaffPayroll.SHemployeepayroll
                                  where emp.StaffID == staffId && emp.Month == month && emp.Year == year
                                  select new
                                  {
                                      emp.PayheadType,
                                      emp.Amount,
                                      emp.Total
                                  }).ToList();

            // Query SHemployeepay for all payheads associated with the staffId
            var payheads = (from p in GetStaffPayroll.SHemployeepay
                            join h in GetStaffPayroll.SHpayhead on p.Payhead equals h.PayheadName
                            where p.Staffname == staffId && p.IsDelete == false
                            select new
                            {
                                p.Payhead,
                                p.Headtype
                            }).ToList();

            // Combine and ensure unique results
            var combinedResults = (from p in payheads
                                   join emp in payrollEntries on p.Payhead equals emp.PayheadType into payrollGroup
                                   from emp in payrollGroup.DefaultIfEmpty()
                                   select new
                                   {
                                       p.Payhead,
                                       p.Headtype,
                                       Amount = emp != null && !string.IsNullOrEmpty(emp.Amount) ? emp.Amount : string.Empty,
                                     

                                       Total = payrollEntries.FirstOrDefault()?.Total
                                   }).Distinct().ToList();

            return Json(combinedResults);
        }



        public IActionResult EmployeePayroll()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            var staffList = payroll.AllStaff(facilityId);
            ViewData["alldocid"] = staffList;

            return View();
        }

        public IActionResult LeaveMaster()
        {
            return View();
        }


        public IActionResult EmployeeAttendance()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            var staffList = payroll.AllStaff(facilityId);
            var leave = payroll.leavelist(facilityId);
            ViewData["alldocid"] = staffList;
            ViewData["leave"] = leave;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Addnoofleave(EmployeeAttendance model, string buttonType)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPatientPrescription docpres = new BusinessClassPatientPrescription(GetStaffPayroll);

          //  var daocfac = docpres.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;


            BusinessClassPayroll payroll = new BusinessClassPayroll(GetStaffPayroll);
            ViewData["alldocid"] = payroll.AllStaff(facilityId);
            ViewData["leave"] = payroll.leavelist(facilityId);


            var leaveMaster = await GetStaffPayroll.SHleaveMaster
       .FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.LeaveName == model.LeaveName);

            if (leaveMaster != null)
            {
                model.Attendancetype = leaveMaster.AttendanceType; 
            }
            else
            {
                // If no matching LeaveName is found, you might want to handle this case (e.g., show an error or default AttendanceType)
                TempData["ErrorMessage"] = "Invalid Leave Name.";
                return RedirectToAction("ErrorPage");
            }


            var leaveDetails = await GetStaffPayroll.SHemployeeattendance
                .FirstOrDefaultAsync(x => x.FacilityID == facilityId && x.StaffID == model.StaffID && x.LeaveName == model.LeaveName && x.Month == model.Month && x.Year == model.Year);


            if (leaveDetails != null)
            {
                leaveDetails.Numberofdays = model.Numberofdays;
                leaveDetails.Month = model.Month;
                leaveDetails.Year = model.Year;
                leaveDetails.Attendancetype = model.Attendancetype;
                leaveDetails.LastUpdatedDate = DateTime.Now.ToString();
                leaveDetails.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                leaveDetails.LastUpdatedUser = User.Claims.First().Value.ToString();
                leaveDetails.FacilityID = facilityId;
                GetStaffPayroll.Entry(leaveDetails).State = EntityState.Modified;
            }
            else
            {
                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                model.FacilityID = facilityId;
                model.Attendancetype = model.Attendancetype ;
                GetStaffPayroll.SHemployeeattendance.Add(model);
            }
            await GetStaffPayroll.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("EmployeeAttendance", model);
        }
    }
}
