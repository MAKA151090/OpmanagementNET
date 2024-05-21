using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


        public async Task<IActionResult> Prescription(PatientEPrescriptionModel pPres)
        {

            var existingCat = await GetPrescription.SHprsPrescription.FindAsync(pPres.PatientID,pPres.OrderID,pPres.CaseVisitID,pPres.DrugID);
            if (existingCat != null)
            {

                existingCat.PatientID = pPres.PatientID;
                existingCat.EpressID = pPres.EpressID;
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
            return View("PatientEPrescription", pPres);


        }

        public async Task<IActionResult> PrescriptionPrint (PatientEPrescriptionPrintModel Model)
        {
            BusinessClassExamination ObjPrintResult = new BusinessClassExamination(GetPrescription);

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
            return View();
        }
        public IActionResult PatientEPrescriptionPrint()
        {
            return View();
        }

    }
}
