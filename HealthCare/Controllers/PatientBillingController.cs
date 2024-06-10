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

        public async Task<IActionResult> PatientPayment(PatientPaymentModel model)
        {
            var existingpayment = await _healthcareContext.SHPatientPayment.FindAsync(model.PaymentID);
            if (existingpayment != null)
            {
               existingpayment.PatientID = model.PaymentID;
                existingpayment.CaseVisitID = model.CaseVisitID;
                existingpayment.BillID = model.BillID;
                existingpayment.PaymentID = model.PaymentID;
                existingpayment.lastUpdatedDate = DateTime.Now.ToString();
                existingpayment.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingpayment.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                    _healthcareContext.Entry(existingpayment).State = EntityState.Modified;
            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHPatientPayment.Add(model);

            }

           await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully.";
            return View(model);
        }
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientBilling()
        {
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

