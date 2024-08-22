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


        /*public async Task<IActionResult> Prescription(PatientEPrescriptionModel pPres,string buttonType,PrescriptionTableModel Model)
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


        }*/


        public async Task<IActionResult> Prescription(PatientEPrescriptionModel pPres, string buttonType, PrescriptionTableModel Model, string PatientID, string CaseVisitID, string OrderID, string DoctorID)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

          

            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid();



            if (buttonType == "Print")
            {
                String Query = "SELECT \r\n    SD.FullName As PatientName,\r\n    CONVERT(varchar(10), SB.PrescriptionDate, 101) AS Date,\r\n    DI.ModelName AS DrugName ,\r\n    DI.Dosage,\r\n    SB.Frequency,\r\n    SB.Instructions,\r\n\tSB.FillDate AS FollowUpDate\r\n    \r\nFROM \r\n    SHPatientRegistration SD\r\nINNER JOIN \r\n    SHprsPrescription SB ON SD.PatientID = SB.PatientID\r\nInner JOIN\r\n    SHstkDrugInventory DI ON SB.DrugID = DI.DrugId\r\n   \r\nWHERE \r\n      SD.PatientID = '" + PatientID + "' AND SB.CaseVisitID = '" + CaseVisitID + "'  AND SB.OrderID='" + OrderID + "' AND SB.DoctorID ='" + DoctorID + "' AND SB.IsDelete= 0 ";

                var Table = BusinessClassCommon.DataTable(GetPrescription, Query);

                BusinessClassPatientPrescription objbilling = new BusinessClassPatientPrescription(GetPrescription);

                return File(objbilling.PrintBillDetails(Table), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Patient Prescription" + TempData["BillID"] + ".docx");
            }

            if (buttonType == "Get")
            {

                var exresult = GetPrescription.SHprsPrescription.FirstOrDefault(x => x.PatientID == pPres.PatientID && x.IsDelete == false &&x.CaseVisitID ==pPres.CaseVisitID && x.OrderID == pPres.OrderID);
                if (exresult != null)
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

                    return View("PatientEPrescription", Model);
                }
                else
                {
                    ViewBag.ErrorMessage = " PatientID Not Found";
                }

                return View("PatientEPrescription");
            }


            if (string.IsNullOrEmpty(pPres.DrugID))
            {
                ViewBag.DrugMessage = "Please enter DrugID.";
                return View("PatientEPrescription");
            }

            var existingCat = await GetPrescription.SHprsPrescription.FindAsync(pPres.PatientID, pPres.CaseVisitID, pPres.OrderID, pPres.DrugID);
            if (existingCat != null)
            {

                existingCat.PatientID = pPres.PatientID;
                // existingCat.EpressID = existingCat.EpressID;
                existingCat.CaseVisitID = pPres.CaseVisitID;
                existingCat.OrderID = pPres.OrderID;
                existingCat.DrugID = pPres.DrugID;
                existingCat.DoctorID = pPres.DoctorID;
                existingCat.PrescriptionDate = pPres.PrescriptionDate;
                existingCat.Unit = pPres.Unit;
                existingCat.UnitCategory = pPres.UnitCategory;
                existingCat.Frequency = pPres.Frequency;
                existingCat.FrequencyUnit = pPres.FrequencyUnit;
                existingCat.Duration = pPres.Duration;
                existingCat.Quantity = pPres.Quantity;
                existingCat.EndDate = pPres.EndDate;
                existingCat.RouteAdmin = pPres.RouteAdmin;
                existingCat.Instructions = pPres.Instructions;
                existingCat.Comments = pPres.Comments;
                existingCat.FillDate = pPres.FillDate;
                existingCat.Result = pPres.Result;
                existingCat.lastupdatedDate = DateTime.Now.ToString();
                existingCat.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingCat.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                // GetPrescription.SHprsPrescription.Update(existingCat);
                //GetPrescription.Entry(existingCat).State = EntityState.Modified;
            }
            else
            {
                if (string.IsNullOrEmpty(pPres.DrugID))
                {
                    ViewBag.DrugMessage = "Please enter DrugID.";
                    return View("PatientEPrescription");
                }


                pPres.lastupdatedDate = DateTime.Now.ToString();
                pPres.lastUpdatedUser = User.Claims.First().Value.ToString();
                pPres.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetPrescription.SHprsPrescription.Add(pPres);

            }



            await GetPrescription.SaveChangesAsync();
            var allPrescriptions = prescription.GetPrescription(pPres.PatientID, pPres.CaseVisitID, pPres.OrderID, pPres.DrugID);
            var allViewModels = allPrescriptions.Select(p => new PrescriptionViewModel
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

            Model.Viewprescription = allViewModels;
            ViewBag.Message = "Saved Successfully.";
            return View("PatientEPrescription", Model);


        }

        public async Task<IActionResult> Edit(string patientId, string caseVisitId, string orderId, string drugId)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }


            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid();

            var prescriptionEdit = await GetPrescription.SHprsPrescription.FindAsync(patientId, caseVisitId, orderId, drugId);
            if (prescriptionEdit == null)
            {
                ViewBag.ErrorMessage = " PatientID Not Found";
            }

            var prescriptionTableModel = new PrescriptionTableModel
            {
                PatientID = prescriptionEdit.PatientID,
                CaseVisitID = prescriptionEdit.CaseVisitID,
                OrderID = prescriptionEdit.OrderID,
                DrugID = prescriptionEdit.DrugID,
                DoctorID = prescriptionEdit.DoctorID,
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

        public async Task<IActionResult> Delete(string patientId, string caseVisitId, string orderId, string drugId, PatientEPrescriptionModel pPres)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }


            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid();

            var exresult = GetPrescription.SHprsPrescription.FirstOrDefault(x => x.PatientID == pPres.PatientID && x.IsDelete == false);
            if (exresult != null)
            {

                var prescriptionDel = await GetPrescription.SHprsPrescription.FindAsync(patientId, caseVisitId, orderId, drugId);
                if (prescriptionDel != null)
                {
                    prescriptionDel.IsDelete = true;
                    await GetPrescription.SaveChangesAsync();
                    ViewBag.Delete = "Deleted  Successfully.";
                }

                ViewBag.Delete = "Deleted  Successfully.";
                return View("PatientEPrescription");
            }
            else
            {
                ViewBag.ErrorMessage = " PatientID Not Found";

            }

            return View("PatientEPrescription");
        }





        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientEPrescription()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }


            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid();
            return View();
        }
        public IActionResult PatientEPrescriptionPrint()
        {
            return View();
        }

    }
}
