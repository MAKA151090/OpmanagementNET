using DocumentFormat.OpenXml.InkML;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
    public class PatientBillingController : Controller
    {
        private HealthcareContext _healthcareContext;

        public PatientBillingController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public async Task<IActionResult> GetBill(string patientID, string visitID, string OrderID, string Medication, string Unit, String Price)
        {
            BusinessClassPharmacybilling business = new BusinessClassPharmacybilling(_healthcareContext);

            
                var PharmacyData = await business.GetPharmacy(patientID , visitID , Medication, Unit , Price , OrderID);

                if (PharmacyData != null)
                {

                    return View("PharmacyBilling", PharmacyData);
                }
                else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs";

                ViewData["patientid"] = business.GetPatientId();
                ViewData["orderid"] = business.Getorderid();
                ViewData["visitcaseid"] = business.Getvisitcaseid();


                return View();
                }
            
        }


        [HttpPost]
        public async Task< IActionResult> SaveSlots(string PatientID, string CaseVisitID, string BillID, string BillDate, string action, List<PatientBillDetailsModel> billDetails)
        {
            ViewBag.PatientID = PatientID;
            ViewBag.CaseVisitID = CaseVisitID;
            ViewBag.BillID = BillID;
            ViewBag.BillDate = BillDate;
            BusinessClassPharmacybilling clinicAdmin = new BusinessClassPharmacybilling(_healthcareContext);
            ViewData["patientid"] = clinicAdmin.GetPatientId();

            if (billDetails == null)
            {
                billDetails = new List<PatientBillDetailsModel>();
            }

            if (action == "Add Bill")
            {
                var newDetail = new PatientBillDetailsModel
                {
                    PatientID = PatientID,

                    BillID = BillID,
                    DateandTime = BillDate,
                    Particulars = string.Empty,
                    Rate = string.Empty,
                    Units = string.Empty,
                    Tax = string.Empty,
                    TotalAmount = string.Empty,
                    IsDelete = false
                };

                _healthcareContext.SHPatientBillDetails.Add(newDetail);
                _healthcareContext.SaveChanges();


                ViewBag.Slots = _healthcareContext.SHPatientBillDetails.Where(b => b.PatientID == PatientID && b.BillID == BillID).ToList();
            }


            else if (action == "Get Bill")
            {

                var getbillDetails = await _healthcareContext.SHPatientBillDetails
                .Where(b => b.PatientID == PatientID && b.BillID == BillID)
                .ToListAsync();

                if (getbillDetails != null && getbillDetails.Any())
                {  
              
                    ViewBag.Slots = getbillDetails;
                }

                /* var patientBill = await _healthcareContext.SHPatientBill.FirstOrDefaultAsync(b => b.PatientID == PatientID && b.BillID == BillID && b.CaseVisitID == CaseVisitID);

                 if (patientBill != null)
                 {
                     // Assign patient bill properties to ViewBag
                     ViewBag.PatientID = patientBill.PatientID;
                     ViewBag.CaseVisitID = patientBill.CaseVisitID;
                     ViewBag.BillID = patientBill.BillID;
                     ViewBag.BillDate = patientBill.BillDate;

                     // Retrieve bill details
                     var getbillDetails =  _healthcareContext.SHPatientBillDetails.Where(bd => bd.PatientID == PatientID && bd.BillID == BillID).ToList();

                     ViewBag.Slots = getbillDetails;

                     return View("PatientBilling", patientBill); 
                 }*/

            }

            else if (action == "Delete Bill")
            {
                // Delete the bill
                var billsToDelete = _healthcareContext.SHPatientBill
                    .Where(b => b.PatientID == PatientID && b.BillID == BillID)
                    .ToList();

                if (billsToDelete == null)
                {
                    //Model.IsDelete = true;
                }

                _healthcareContext.SaveChanges();
            }
            else if (action == "Save")
            {
                foreach (var detail in billDetails)
                {

                    detail.lastUpdatedDate = DateTime.Now.ToString();
                    detail.lastUpdatedUser = User.Claims.First().Value.ToString();
                    detail.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();


                    _healthcareContext.SHPatientBillDetails.Update(detail);
                }
                _healthcareContext.SaveChanges();



                string totalAmount = billDetails.FirstOrDefault()?.TotalAmount ?? "0";

                var patientBill = new PatientBillModel
                {
                    PatientID = PatientID,
                    CaseVisitID = CaseVisitID,
                    BillID = BillID,
                    BillDate = BillDate,
                    TotalBillAmount = totalAmount,
                    lastUpdatedUser = User.Claims.First().Value.ToString(),
                    lastUpdatedDate = DateTime.Now.ToString(),
                    lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                };
                _healthcareContext.SHPatientBill.Add(patientBill);

                _healthcareContext.SaveChanges();
                return View("PatientBilling");
            }
           
            return View("PatientBilling");
        }








public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientBilling()
        {
     
            BusinessClassPharmacybilling clinicAdmin = new BusinessClassPharmacybilling(_healthcareContext);
            ViewData["patientid"] = clinicAdmin.GetPatientId();
            return View();


        }
        public IActionResult PharmacyBilling()
        {
            BusinessClassPharmacybilling clinicAdmin = new BusinessClassPharmacybilling(_healthcareContext);
            ViewData["patientid"] = clinicAdmin.GetPatientId();
            ViewData["orderid"] = clinicAdmin.Getorderid();
            ViewData["visitcaseid"] = clinicAdmin.Getvisitcaseid();
            return View();
        }
        
        public IActionResult PatientPayments()
        {
            return View();
        }
    }
}

