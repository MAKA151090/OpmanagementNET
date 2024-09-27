using ClassLibrary1;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HealthCare.Controllers
{
    [Authorize]
    public class PatientPrescriptionController : Controller
    {

        private HealthcareContext GetPrescription;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PatientPrescriptionController(HealthcareContext _GetPrescription, IHttpContextAccessor httpContextAccessor)
        {
            GetPrescription = _GetPrescription;
            _httpContextAccessor = httpContextAccessor;
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

        [HttpPost]
        public async Task<IActionResult> Prescription(PatientEPrescriptionModel pPres, string buttonType, PrescriptionTableModel Model, string PatientID, string CaseVisitID, string OrderID, string DoctorID)
        {
           
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }

            BusinessClassPatientPrescription docpres = new BusinessClassPatientPrescription(GetPrescription);

            var doctorid = docpres.Getdocid(facilityId, docid).FirstOrDefault()?.StrStaffID;
            var daocfac = docpres.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;

            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);


          
            if (buttonType == "Print")
            {
                String Query = "SELECT \r\n    SD.FullName AS PatientName,\r\n    CONVERT(varchar(10), SB.PrescriptionDate, 101) AS Date,\r\n    DI.ModelName AS DrugName,\r\n    SB.Instructions,\r\n    SB.FillDate AS FollowUpDate,\r\n\tSD.Age,\r\n\tSD.Gender,\r\n\tSB.Comments,\r\n\tSB.Morningunit,\r\n\tSB.Eveningunit,\r\n\tSB.Afternoonunit,\r\n\tSB.Nightunit,\r\n\t SB.RouteAdmin As [When]\r\n,\tCA.Template FROM \r\n    SHPatientRegistration SD\r\nINNER JOIN \r\n    SHprsPrescription SB ON SD.PatientID = SB.PatientID\r\nINNER JOIN\r\n    SHstkDrugInventory DI ON SB.DrugID = DI.DrugId\r\nINNER JOIN\r\n    SHclnClinicAdmin CA ON SB.FacilityID = CA.FacilityID  WHERE \r\n    SD.PatientID ='" + PatientID + "'\r\n    AND SB.CaseVisitID = '" + CaseVisitID + "' \r\n    AND SB.OrderID = '" + OrderID + "'\r\n    AND SB.DoctorID = '" + doctorid + "' \r\n    AND SB.IsDelete = 0\r\n\tAND SB.FacilityID ='" + daocfac + "'\r\n ";

                var Table = BusinessClassCommon.DataTable(GetPrescription, Query);

                BusinessClassPatientPrescription objbilling = new BusinessClassPatientPrescription(GetPrescription);

                string facilityTemplate = Table.Rows[0]["Template"].ToString();

                return File(objbilling.PrintBillDetails(Table, facilityTemplate), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Patient Prescription" + TempData["BillID"] + ".docx");
            }

            if (buttonType == "Get")
            {

                var exresult = GetPrescription.SHprsPrescription.FirstOrDefault(x => x.PatientID == PatientID && x.IsDelete == false && x.CaseVisitID == CaseVisitID  && x.FacilityID == daocfac);
                if (exresult != null)
                {

                    var result = prescription.GetPrescription(pPres.PatientID, pPres.CaseVisitID, pPres.DrugID, daocfac);
                    var viewModelList = result.Select(p => new PrescriptionViewModel
                    {
                        PatientID = p.PatientID,
                        CaseVisitID = p.CaseVisitID,
                        OrderID = p.OrderID,
                        DrugID = p.DrugID,
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin
                    }).ToList();
                    Model.Viewprescription = viewModelList;

                    Model.Items = await GetDistinctCaseVisitID(pPres.PatientID);

                    ViewBag.SelectedPatientID = PatientID;
                    Model.SelectedItemId = CaseVisitID;

                    return View("PatientEPrescription", Model);
                }
                else
                {

                    ViewBag.ErrorMessage = " PatientID Not Found";
                }

                Model.Items = await GetDistinctCaseVisitID(pPres.PatientID) ?? new List<PatientEPrescriptionModel>();
                Model.Viewprescription = new List<PrescriptionViewModel>();

                ViewBag.SelectedPatientID = PatientID;

                    Model.SelectedItemId = CaseVisitID;
                return View("PatientEPrescription",Model);
            }


            if (string.IsNullOrEmpty(pPres.DrugID))
            {
                ViewBag.DrugMessage = "Please enter DrugID.";

                Model.Items = await GetDistinctCaseVisitID(pPres.PatientID) ?? new List<PatientEPrescriptionModel>();

                var prescriptionTable = prescription.GetPrescriptionTable(pPres.PatientID, CaseVisitID, daocfac);

                // Map to PrescriptionViewModel
                Model.Viewprescription = prescriptionTable.Select(p => new PrescriptionViewModel
                {
                    PatientID = p.PatientID,
                    CaseVisitID = p.CaseVisitID,
                    OrderID = p.OrderID,
                    DrugID = p.DrugID,
                    DrugName = p.DrugName,
                    Morningunit = p.Morningunit,
                    Afternoonunit = p.Afternoonunit,
                    Eveningunit = p.Eveningunit,
                    Nightunit = p.Nightunit,
                    RouteAdmin = p.RouteAdmin
                }).ToList();

                ViewBag.SelectedPatientID = PatientID;
                Model.SelectedItemId = CaseVisitID;

                return View("PatientEPrescription", Model);

            }

            var existingCat = await GetPrescription.SHprsPrescription.FindAsync(pPres.PatientID, pPres.CaseVisitID, pPres.DrugID, daocfac);


            if (existingCat != null)
            {
                if (existingCat.IsDelete)
                {
                    ViewBag.ErrorMessage = "Cannot update. Prescription is marked as deleted.";
                    Model.Items = await GetDistinctCaseVisitID(pPres.PatientID) ?? new List<PatientEPrescriptionModel>();

                    var prescriptionTable = prescription.GetPrescriptionTable(pPres.PatientID, CaseVisitID, daocfac);

                    // Map to PrescriptionViewModel
                    Model.Viewprescription = prescriptionTable.Select(p => new PrescriptionViewModel
                    {
                        PatientID = p.PatientID,
                        CaseVisitID = p.CaseVisitID,
                        OrderID = p.OrderID,
                        DrugID = p.DrugID,
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin
                    }).ToList();

                    ViewBag.SelectedPatientID = PatientID;
                    Model.SelectedItemId = CaseVisitID;

                    return View("PatientEPrescription", Model);
                   
                }

               
                existingCat.FacilityID = daocfac;
                existingCat.PatientID = pPres.PatientID;
                // existingCat.EpressID = existingCat.EpressID;
                existingCat.CaseVisitID = pPres.CaseVisitID;
                existingCat.OrderID = pPres.OrderID;
                existingCat.DrugID = pPres.DrugID;
                existingCat.DoctorID = doctorid;
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
                existingCat.Morningunit = pPres.Morningunit;
                existingCat.Afternoonunit = pPres.Afternoonunit;
                existingCat.Eveningunit = pPres.Eveningunit;
                existingCat.Nightunit = pPres.Nightunit;
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

                   
                    Model.Items = await GetDistinctCaseVisitID(pPres.PatientID) ?? new List<PatientEPrescriptionModel>();

                    var prescriptionTable = prescription.GetPrescriptionTable(pPres.PatientID, CaseVisitID, daocfac);

                    // Map to PrescriptionViewModel
                    Model.Viewprescription = prescriptionTable.Select(p => new PrescriptionViewModel
                    {
                        PatientID = p.PatientID,
                        CaseVisitID = p.CaseVisitID,
                        OrderID = p.OrderID,
                        DrugID = p.DrugID,
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin
                    }).ToList();

                    ViewBag.SelectedPatientID = PatientID;
                    Model.SelectedItemId = CaseVisitID;

                    return View("PatientEPrescription",Model);
                }

                pPres.FacilityID = daocfac;
                pPres.DoctorID = doctorid;
                pPres.lastupdatedDate = DateTime.Now.ToString();
                pPres.lastUpdatedUser = User.Claims.First().Value.ToString();
                pPres.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetPrescription.SHprsPrescription.Add(pPres);

            }



            await GetPrescription.SaveChangesAsync();
            var allPrescriptions = prescription.GetPrescription(pPres.PatientID, pPres.CaseVisitID, pPres.DrugID, daocfac);
            var allViewModels = allPrescriptions.Select(p => new PrescriptionViewModel
            {
                PatientID = p.PatientID,
                CaseVisitID = p.CaseVisitID,
                OrderID = p.OrderID,
                DrugID = p.DrugID,
                DrugName = p.DrugName,
                Morningunit = p.Morningunit,
                Afternoonunit = p.Afternoonunit,
                Eveningunit = p.Eveningunit,
                Nightunit = p.Nightunit,
                RouteAdmin = p.RouteAdmin

            }).ToList();

            Model.Viewprescription = allViewModels;

            Model.Items = await GetDistinctCaseVisitID(pPres.PatientID);

            ViewBag.SelectedPatientID = PatientID;
            Model.SelectedItemId = CaseVisitID;

            ViewBag.Message = "Saved Successfully.";
            return View("PatientEPrescription", Model);


        }

        private async Task<List<PatientEPrescriptionModel>> GetDistinctCaseVisitID(string patientId)
        {
            return await GetPrescription.SHprsPrescription
                .Where(cv => cv.PatientID == patientId)
                .Select(cv => new PatientEPrescriptionModel
                {
                    CaseVisitID = cv.CaseVisitID
                    // Add other properties if needed
                })
                .Distinct()
                .ToListAsync();
        }

        public async Task<IActionResult> Edit(string patientId, string caseVisitId, string orderId, string drugId, string facility,PrescriptionTableModel tabmod)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }

            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);

            var daocfac = prescription.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;

            var prescriptionEdit = await GetPrescription.SHprsPrescription.FindAsync(patientId, caseVisitId, drugId, daocfac);
            if (prescriptionEdit == null)
            {
                ViewBag.ErrorMessage = " PatientID Not Found";
                tabmod.Items = await GetDistinctCaseVisitID(patientId) ?? new List<PatientEPrescriptionModel>();
                tabmod.Viewprescription = new List<PrescriptionViewModel>();

                return View("PatientEPrescription", tabmod);
            }

            var prescriptionTableModel = new PrescriptionTableModel
            {
                Morningunit = prescriptionEdit.Morningunit,
                Eveningunit = prescriptionEdit.Eveningunit,
                Afternoonunit = prescriptionEdit.Afternoonunit,
                Nightunit = prescriptionEdit.Nightunit,
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


            var result = prescription.GetPrescription(prescriptionEdit.PatientID, prescriptionEdit.CaseVisitID,  prescriptionEdit.DrugID, daocfac);
            if (result != null && result.Any())
            {
                var viewModelList = result.Select(p => new PrescriptionViewModel
                {
                    PatientID = p.PatientID,
                    CaseVisitID = p.CaseVisitID,
                    OrderID = p.OrderID,
                    DrugID = p.DrugID,
                    DrugName = p.DrugName,
                    Morningunit = p.Morningunit,
                    Afternoonunit = p.Afternoonunit,
                    Eveningunit = p.Eveningunit,
                    Nightunit = p.Nightunit,
                    RouteAdmin = p.RouteAdmin

                }).ToList();
                prescriptionTableModel.Viewprescription = viewModelList;
            }

            // Populate Items in the model for dropdown selection
            prescriptionTableModel.Items = await GetDistinctCaseVisitID(prescriptionEdit.PatientID);

            // Set ViewBag and Model properties for the view
            ViewBag.SelectedPatientID = prescriptionEdit.PatientID;

            prescriptionTableModel.SelectedItemId = prescriptionEdit.CaseVisitID;

            return View("PatientEPrescription", prescriptionTableModel);


        }

        public async Task<IActionResult> Delete(string patientId, string caseVisitId, string orderId, string drugId, PatientEPrescriptionModel pPres, string facility,PrescriptionTableModel model)
        {


            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }


            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }


            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);

            var daocfac = prescription.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;

            var exresult = GetPrescription.SHprsPrescription.FirstOrDefault(x => x.PatientID == pPres.PatientID && x.IsDelete == false && x.CaseVisitID == caseVisitId && x.FacilityID == daocfac);
            if (exresult != null)
            {

                var prescriptionDel = await GetPrescription.SHprsPrescription.FindAsync(patientId, caseVisitId, drugId, daocfac);
                if (prescriptionDel != null)
                {
                    prescriptionDel.IsDelete = true;
                    await GetPrescription.SaveChangesAsync();
                    ViewBag.Delete = "Deleted  Successfully.";
                }

                var prescriptionTable = prescription.GetPrescriptionTable(pPres.PatientID, caseVisitId, daocfac);

                // Map to PrescriptionViewModel
                model.Viewprescription = prescriptionTable.Select(p => new PrescriptionViewModel
                {
                    PatientID = p.PatientID,
                    CaseVisitID = p.CaseVisitID,
                    OrderID = p.OrderID,
                    DrugID = p.DrugID,
                    DrugName = p.DrugName,
                    Morningunit = p.Morningunit,
                    Afternoonunit = p.Afternoonunit,
                    Eveningunit = p.Eveningunit,
                    Nightunit = p.Nightunit,
                    RouteAdmin = p.RouteAdmin
                }).ToList();



                model.Items = await GetDistinctCaseVisitID(pPres.PatientID);

                ViewBag.SelectedPatientID = pPres.PatientID;
                model.SelectedItemId = caseVisitId;

                return View("PatientEPrescription",model);
            }
            else
            {
                ViewBag.ErrorMessage = " PatientID Not Found";

            }

            var prescriptionTable1 = prescription.GetPrescriptionTable(pPres.PatientID, caseVisitId, daocfac);

            // Map to PrescriptionViewModel
            model.Viewprescription = prescriptionTable1.Select(p => new PrescriptionViewModel
            {
                PatientID = p.PatientID,
                CaseVisitID = p.CaseVisitID,
                OrderID = p.OrderID,
                DrugID = p.DrugID,
                DrugName = p.DrugName,
                Morningunit = p.Morningunit,
                Afternoonunit = p.Afternoonunit,
                Eveningunit = p.Eveningunit,
                Nightunit = p.Nightunit,
                RouteAdmin = p.RouteAdmin
            }).ToList();


            model.Items = await GetDistinctCaseVisitID(pPres.PatientID);

            ViewBag.SelectedPatientID = pPres.PatientID;
            model.SelectedItemId = caseVisitId;

            return View("PatientEPrescription",model);
        }





        public IActionResult Index()
        {
            return View();
        }


        public List<PatientEPrescriptionModel> GetCaseVisitopt(string facilityid)
        {

            return GetPrescription.SHprsPrescription.Where(x => x.FacilityID == facilityid).Select(x => new PatientEPrescriptionModel
            {
                CaseVisitID = x.CaseVisitID
            }).ToList();
        }

        public  async Task<IActionResult> PatientEPrescription()
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            string docid = string.Empty;
            if (TempData["DoctorID"] != null)
            {
                docid = TempData["DoctorID"].ToString();
                TempData.Keep("DoctorID");
            }




            BusinessClassPatientPrescription prescription = new BusinessClassPatientPrescription(GetPrescription);
            ViewData["patientid"] = prescription.GetPatientId();
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);

            var model = new PrescriptionTableModel(); // Replace with your actual model type
            model.Items = new List<PatientEPrescriptionModel>();


            var viewModelList = new List<PrescriptionViewModel>();

           
            model.Viewprescription = viewModelList;


            return View("PatientEPrescription", model);
        }
        public IActionResult PatientEPrescriptionPrint()
        {
            return View();
        }



        public async Task<IActionResult> AddPatientPop(PatientRegistrationModel model)
        {


            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            BusinessClassPatientPrescription docpres = new BusinessClassPatientPrescription(GetPrescription);

            var daocfac = docpres.Getdocfacility(facilityId).FirstOrDefault()?.FacilityID;

            // Use _httpContextAccessor to access HttpContext.Session
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("FacilityID", daocfac);
            }
            else
            {
                TempData["ErrorMessage"] = "Session is not available. Please try again.";
                return RedirectToAction("ErrorPage"); // Replace with your error handling action
            }

            var existingPatient = await GetPrescription.SHPatientRegistration.FirstOrDefaultAsync(x => x.PatientID == model.PatientID && x.FacilityID == daocfac && x.IsDelete == false);

            if (existingPatient != null)
            {
                existingPatient.FullName = model.FullName;
                existingPatient.PhoneNumber = model.PhoneNumber;
                existingPatient.Age = model.Age;
                existingPatient.Gender = model.Gender;
                existingPatient.FacilityID = daocfac;
                existingPatient.PatientID = model.PatientID;

                GetPrescription.Entry(existingPatient).State = EntityState.Modified;
            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.FacilityID = daocfac;
                GetPrescription.SHPatientRegistration.Add(model);


            }

            await GetPrescription.SaveChangesAsync();

           // PrescriptionTableModel mod = new PrescriptionTableModel();

            return View("PatientEPrescription");

        }


       

        public async Task<IActionResult> GetCaseVisitIDs(string patientId)
             
            {

            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            var caseVisitIds = GetPrescription.SHprsPrescription
                .Where(cv => cv.PatientID == patientId && cv.IsDelete == false && cv.FacilityID == facilityId)
                .Select(cv => cv.CaseVisitID).Distinct()
                .ToList();

            return Json(caseVisitIds);
        }

        public async Task<IActionResult> AddNewVisitID(string patientId)
        {
            try
            {
                // Fetch the last visit ID for the selected patient
                var lastVisitIdEntry = await GetPrescription.SHprsPrescription
                    .Where(cv => cv.PatientID == patientId)
                    .OrderByDescending(cv => cv.CaseVisitID)
                    .FirstOrDefaultAsync();

                int nextVisitNumber = 1;

                // If a visit ID exists, increment the number
                if (lastVisitIdEntry != null)
                {
                    var lastVisitId = lastVisitIdEntry.CaseVisitID;
                    var lastVisitNumber = int.Parse(lastVisitId.Split('_')[0]);
                    nextVisitNumber = lastVisitNumber + 1;
                }

                // Create the new visit ID with the current date in YYYY-MM-DD format
                string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
                string newVisitId = $"{nextVisitNumber}__{currentDate}";

                // Insert the new visit ID in the database for that patient
                var newVisit = new PrescriptionTableModel
                {
                    PatientID = patientId,
                    CaseVisitID = newVisitId,
                    // Include other necessary fields as needed
                };

               
                return Json(new { success = true, newVisitId = newVisitId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while adding the new visit ID." });
            }
        }

    }
 }
