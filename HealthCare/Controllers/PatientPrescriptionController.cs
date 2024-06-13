using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
    public class PatientPrescriptionController : Controller
    {

        private HealthcareContext GetPrescription;

        public PatientPrescriptionController(HealthcareContext GetPrescription)
        {
            this.GetPrescription = GetPrescription;
        }


        public async Task<IActionResult> Prescription(PatientEPrescriptionModel pPres,string buttonType,PrescriptionTableModel Model)
        {

            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid();
            ViewData["docid"] = prescription.Getdocid();

            if (buttonType=="Get")
            {

                var result = prescription.GetPrescription(pPres.PatientID, pPres.CaseVisitID, pPres.OrderID, pPres.DrugID);
                var viewModelList = result.Select(p => new PrescriptionViewModel
                {
                    PatientID = p.PatientID,
                    CaseVisitID = p.CaseVisitID,
                    OrderID = p.OrderID,
                    DrugID = p.DrugID,
                    DrugName = p.DrugName,
                    Frequency = p.Frequency,
                    Duration = p.Duration,
                    Dosage = p.Dosage,
                    Unit = p.Unit
                }).ToList();
                Model.Viewprescription = viewModelList;

                return View ("PatientEPrescription",Model);
            }



            var existingCat = await GetPrescription.SHprsPrescription.FindAsync(pPres.PatientID,pPres.CaseVisitID, pPres.OrderID, pPres.DrugID);
            if (existingCat != null)
            {

                existingCat.PatientID = pPres.PatientID;
               // existingCat.EpressID = existingCat.EpressID;
                existingCat.CaseVisitID = pPres.CaseVisitID;
                existingCat.OrderID=pPres.OrderID;
                existingCat.DrugID=pPres.DrugID;
                existingCat.DoctorID=pPres.DoctorID;
                existingCat.PrescriptionDate=pPres.PrescriptionDate;
                existingCat.Unit=pPres.Unit;
                existingCat.UnitCategory=pPres.UnitCategory;
                existingCat.Frequency=pPres.Frequency;
                existingCat.FrequencyUnit=pPres.FrequencyUnit;
                existingCat.Duration=pPres.Duration;
                existingCat.Quantity=pPres.Quantity;
                existingCat.EndDate=pPres.EndDate;
                existingCat.RouteAdmin=pPres.RouteAdmin;
                existingCat.Instructions=pPres.Instructions;
                existingCat.Comments=pPres.Comments;
                existingCat.FillDate=pPres.FillDate;
                existingCat.Result=pPres.Result;
                existingCat.lastupdatedDate = DateTime.Now.ToString();
                existingCat.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingCat.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
               // GetPrescription.SHprsPrescription.Update(existingCat);
                //GetPrescription.Entry(existingCat).State = EntityState.Modified;
            }
            else
            {
                pPres.lastupdatedDate = DateTime.Now.ToString();
                pPres.lastUpdatedUser = User.Claims.First().Value.ToString();
                pPres.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetPrescription.SHprsPrescription.Add(pPres);

            }

         

            await GetPrescription.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("PatientEPrescription");


        }


       /* public async Task<IActionResult> PatientEPrescriptionview(PrescriptionTableModel Model)
        {

            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid();
            ViewData["docid"] = prescription.Getdocid();

            var result = prescription.GetPrescription(Model.PatientID,Model.CaseVisitID,Model.OrderID,Model.DrugID);

            return View(result);
        }*/

        public async Task<IActionResult> Edit(string patientId, string caseVisitId, string orderId, string drugId)
        {
            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid();
            ViewData["docid"] = prescription.Getdocid();

            var prescriptionEdit = await GetPrescription.SHprsPrescription.FindAsync(patientId, caseVisitId, orderId, drugId);
            if (prescriptionEdit == null)
            {
                ViewBag.ErrorMessage = "Not Found";
            }

            var prescriptionTableModel = new PrescriptionTableModel
            {
                PatientID = prescriptionEdit.PatientID,
                CaseVisitID = prescriptionEdit.CaseVisitID,
                OrderID = prescriptionEdit.OrderID,
                DrugID = prescriptionEdit.DrugID,
                DoctorID=prescriptionEdit.DoctorID,
                PrescriptionDate = prescriptionEdit.PrescriptionDate,
                Unit = prescriptionEdit.Unit,
                UnitCategory = prescriptionEdit.UnitCategory,
                Frequency = prescriptionEdit.Frequency,
                FrequencyUnit = prescriptionEdit.FrequencyUnit,
                Duration = prescriptionEdit.Duration,
                Quantity = prescriptionEdit.Quantity,
                EndDate = prescriptionEdit.EndDate,
                RouteAdmin = prescriptionEdit.RouteAdmin,
                Instructions = prescriptionEdit.Instructions,
                Comments = prescriptionEdit.Comments,
                FillDate = prescriptionEdit.FillDate,
                Result = prescriptionEdit.Result,
                Viewprescription = new List<PrescriptionViewModel>()

            };


            var result = prescription.GetPrescription(prescriptionEdit.PatientID, prescriptionEdit.CaseVisitID, prescriptionEdit.OrderID, prescriptionEdit.DrugID);
            if (result != null && result.Any())
            {
                var viewModelList = result.Select(p => new PrescriptionViewModel
                {
                    PatientID = p.PatientID,
                    CaseVisitID = p.CaseVisitID,
                    OrderID = p.OrderID,
                    DrugID = p.DrugID,
                    DrugName = p.DrugName,
                    Frequency = p.Frequency,
                    Duration = p.Duration,
                    Dosage = p.Dosage,
                    Unit = p.Unit
                }).ToList();
                prescriptionTableModel.Viewprescription = viewModelList;
            }


            return View("PatientEPrescription", prescriptionTableModel);


        }

        public async Task<IActionResult> Delete(string patientId, string orderId, string caseVisitId, string drugId)
        {
            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid();
            ViewData["docid"] = prescription.Getdocid();

            var prescriptionDel = await GetPrescription.SHprsPrescription.FindAsync(patientId, orderId, caseVisitId, drugId);
            if (prescriptionDel != null)
            {
                prescriptionDel.IsDelete = true;
                await GetPrescription.SaveChangesAsync();
            }
            ViewBag.Delete = "Deleted  Successfully.";
            return View("PatientEPrescription");
        }


        public async Task<IActionResult> PrescriptionPrint (PatientEPrescriptionPrintModel Model)
        {
            BusinessClassPatientPrescription ObjPrintResult = new BusinessClassPatientPrescription(GetPrescription);

            if (ObjPrintResult != null)
            {
                var prescription = await ObjPrintResult.GetPrescriptionPrint(Model.PatientID, Model.OrderID,Model.CaseVisitID);
                return View("PatientEPrescriptionPrint", prescription);
            }
            return View(Model);
        }





        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientEPrescription()
        {
            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid();
            ViewData["docid"] = prescription.Getdocid();
            return View();
        }
        public IActionResult PatientEPrescriptionPrint()
        {
            return View();
        }

    }
}
