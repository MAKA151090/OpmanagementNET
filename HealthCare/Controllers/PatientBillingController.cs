﻿using DocumentFormat.OpenXml.InkML;
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
        public async Task< IActionResult> SaveSlots(string PatientID, string CaseVisitID, string BillID, string BillDate, string action, List<PatientBillDetailsModel> billDetails, string selectedSlotId)
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
               

                ViewBag.Slots = _healthcareContext.SHPatientBillDetails.Where(b => b.PatientID == PatientID && b.BillID == BillID &&b.IsDelete==false).ToList();
            }


            else if (action == "Get Bill")
            {

                var getbillDetails = await _healthcareContext.SHPatientBillDetails
                .Where(b => b.PatientID == PatientID && b.BillID == BillID && b.IsDelete == false)
                .ToListAsync();

                if (getbillDetails != null && getbillDetails.Any())
                {  
              
                    ViewBag.Slots = getbillDetails;
                }
                else
                {
                    ViewBag.getbill = "No Bill is available for this ID";
                }

            }

            else if (action == "Delete Bill")
            {

                var detailsToDelete = _healthcareContext.SHPatientBillDetails
            .Where(b => b.PatientID == PatientID && b.BillID == BillID)
            .ToList();

                foreach (var detail in detailsToDelete)
                {
                    detail.IsDelete = true;
                    _healthcareContext.SHPatientBillDetails.Update(detail);
                }
              

                var billToDelete = _healthcareContext.SHPatientBill
              .FirstOrDefault(b => b.PatientID == PatientID && b.BillID == BillID&& b.CaseVisitID==CaseVisitID);

                if (billToDelete != null)
                {
                    billToDelete.IsDelete = true;
                    _healthcareContext.SHPatientBill.Update(billToDelete);
                   
                }
                ViewBag.DelTotal = "Deleted  Bill Successfully";
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


                var expatbill = _healthcareContext.SHPatientBill.FirstOrDefault(b=>b.PatientID==PatientID &&b.CaseVisitID== CaseVisitID &&b.BillID==BillID);
                if (expatbill == null)
                {

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
                }
                ViewBag.Message = "Bill Saved Successfully";
            }

            else if (action == "Delete Selected")
            {
                if (!string.IsNullOrEmpty(selectedSlotId))
                {
                    var detailToDelete = _healthcareContext.SHPatientBillDetails
                        .FirstOrDefault(b => b.DetailID == selectedSlotId);

                    if (detailToDelete != null)
                    {
                        detailToDelete.IsDelete = true;
                        _healthcareContext.SHPatientBillDetails.Update(detailToDelete);
                        
                    }
                    _healthcareContext.SaveChanges();
                }
                ViewBag.DelSelected = "Delete selected bill Successfully";
            }
           
            return View("PatientBilling");
            
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

