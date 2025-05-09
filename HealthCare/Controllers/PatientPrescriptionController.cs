﻿using ClassLibrary1;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            ViewData["patientid"] = prescription.GetPatientId(facilityId);
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);



            if (buttonType == "Print")
            {

                var checkexpres = await GetPrescription.SHprsPrescription.FirstOrDefaultAsync(x => x.PatientID == PatientID && x.CaseVisitID == CaseVisitID && x.IsDelete == false && x.DoctorID == doctorid);

                if (checkexpres != null)
                {
                    
                 // String Query = "SELECT \r\n    SD.FullName AS PatientName,\r\n    CONVERT(varchar(10), SB.PrescriptionDate, 101) AS Date,\r\n    DI.ModelName AS MedicineName,\r\n    SB.Instructions As [Procedure],\r\n    SB.FillDate AS FollowUpDate,\r\n    SD.Age,\r\n    SD.Gender,\r\n\tDI.Dosage,\r\n    SB.Comments AS Complaint,\r\n    SB.Morningunit,\r\n    SB.Eveningunit,\r\n    SB.Afternoonunit,\r\n\tCA.ClinicName As FacilityName,\r\n\tCA.ClinicAddress As FacilityAddress,\r\n    SB.Nightunit,\r\n\tS.StrFullName As DoctorName,\r\n\tS.StrAddress2 As Suffix,\r\n\tSb.Result As Instruction ,\r\n\tsb.EndDate AS NoOfDays,\r\n    SB.RouteAdmin AS [When],\r\n    CA.Template \r\nFROM \r\n    SHPatientRegistration SD\r\nINNER JOIN \r\n    SHprsPrescription SB ON SD.PatientID = SB.PatientID\r\nINNER JOIN\r\n    SHstkDrugInventory DI ON SB.DrugID = DI.DrugId\r\nINNER JOIN\r\n    SHclnClinicAdmin CA ON SB.FacilityID = CA.FacilityID \r\nINNER JOIN\r\n SHclnStaffAdminModel S ON SB.DoctorID = S.StrStaffID\r\nWHERE \r\n    SD.PatientID ='" + PatientID + "'\r\n    AND SB.CaseVisitID ='" + CaseVisitID + "'\r\n    AND SB.DoctorID = '" + doctorid + "'\r\n\t AND SB.IsDelete = 0\r\n    AND SB.FacilityID = '" + daocfac + "'\r\n\tAND S.FacilityID = '" + daocfac + "'\r\n  AND DI.FacilityID = '" + daocfac + "'\r\n AND SD.FacilityID = '" + daocfac + "' ";

                   String Query = "SELECT \r\n    SD.FullName AS PatientName,\r\n    DATE_FORMAT(SB.PrescriptionDate, '%d/%m/%Y') AS Date,\r\n    DI.ModelName AS MedicineName,\r\n    SB.Instructions AS `Procedure`,\r\n     DATE_FORMAT(SB.FillDate , '%d/%m/%Y') AS FollowUpDate,\r\n    SD.Age,\r\n    SD.Gender,\r\n    DI.Dosage,\r\n    SB.Comments AS Complaint,\r\n    SB.Morningunit,\r\n    SB.Eveningunit,\r\n    SB.Afternoonunit,\r\n    CA.ClinicName AS FacilityName,\r\n    CA.ClinicAddress AS FacilityAddress,\r\n    SB.Nightunit,\r\n    S.StrFullName AS DoctorName,\r\n    S.StrAddress2 AS Suffix,\r\n    SB.Result AS Instruction,\r\n    SB.EndDate AS NoOfDays,\r\n    SB.RouteAdmin AS `When`,\r\n    CA.Template \r\nFROM \r\n    SHPatientRegistration SD\r\nINNER JOIN \r\n    SHprsPrescription SB ON SD.PatientID = SB.PatientID\r\nINNER JOIN\r\n    SHstkDrugInventory DI ON SB.DrugID = DI.DrugId\r\nINNER JOIN\r\n    SHclnClinicAdmin CA ON SB.FacilityID = CA.FacilityID \r\nINNER JOIN\r\n    SHclnStaffAdminModel S ON SB.DoctorID = S.StrStaffID\r\nWHERE \r\n    SD.PatientID = '" + PatientID + "' \r\n    AND SB.CaseVisitID = '" + CaseVisitID + "' \r\n    AND SB.DoctorID = '" + doctorid + "' \r\n    AND SB.IsDelete = 0 \r\n    AND SB.FacilityID = '" + daocfac + "' \r\n    AND S.FacilityID = '" + daocfac + "' \r\n    AND DI.FacilityID = '" + daocfac + "' \r\n    AND SD.FacilityID = '" + daocfac + "'";

                 
                    var Table = BusinessClassCommon.DataTable(GetPrescription, Query);

                    BusinessClassPatientPrescription objbilling = new BusinessClassPatientPrescription(GetPrescription);

                    string facilityTemplate = Table.Rows[0]["Template"].ToString();

                    return File(objbilling.PrintBillDetails(Table, facilityTemplate), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Patient Prescription" + TempData["BillID"] + ".docx");
                }

                else
                {
                    ViewBag.ErrorMessage = "No Data For this Patient";
                    Model.Items = await GetDistinctCaseVisitID(pPres.PatientID) ?? new List<PatientEPrescriptionModel>();

                    var prescriptionTable = prescription.GetPrescriptionTable(pPres.PatientID, CaseVisitID, daocfac);

                    // Map to PrescriptionViewModel
                    Model.Viewprescription = prescriptionTable.Select(p => new PrescriptionViewModel
                    {
                        PatientID = p.PatientID,
                        CaseVisitID = p.CaseVisitID,
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin,
                        Dosage = p.Dosage,
                        DrugID = p.DrugID,
                        DbpatientID = p.DbpatientID

                    }).ToList();

                    ViewBag.SelectedPatientID = PatientID;
                    Model.SelectedItemId = CaseVisitID;
                    return View("PatientEPrescription", Model);
                }
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
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin,
                        Dosage = p.Dosage,
                        DrugID = p.DrugID,
                        DbpatientID = p.DbpatientID

                    }).ToList();
                    Model.Viewprescription = viewModelList;

                    Model.Items = await GetDistinctCaseVisitID(pPres.PatientID);

                    ViewBag.SelectedPatientID = PatientID;
                    Model.SelectedItemId = CaseVisitID;

                    // Set TempData for use in the view
                    TempData["DrugID"] = viewModelList.FirstOrDefault()?.DrugID;
                    TempData["DbpatientID"] = viewModelList.FirstOrDefault()?.DbpatientID;

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

            //check drug is Given

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
                    DrugName = p.DrugName,
                    Morningunit = p.Morningunit,
                    Afternoonunit = p.Afternoonunit,
                    Eveningunit = p.Eveningunit,
                    Nightunit = p.Nightunit,
                    RouteAdmin = p.RouteAdmin,
                    Dosage = p.Dosage,
                    DbpatientID = p.DbpatientID,
                    DrugID = p.DrugID

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
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin,
                        Dosage = p.Dosage,
                        DrugID = p.DrugID,
                        DbpatientID = p.DbpatientID

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
                        DrugName = p.DrugName,
                        Morningunit = p.Morningunit,
                        Afternoonunit = p.Afternoonunit,
                        Eveningunit = p.Eveningunit,
                        Nightunit = p.Nightunit,
                        RouteAdmin = p.RouteAdmin,
                        Dosage = p.Dosage,
                        DbpatientID = p.DbpatientID,
                        DrugID = p.DrugID

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
                DrugName = p.DrugName,
                Morningunit = p.Morningunit,
                Afternoonunit = p.Afternoonunit,
                Eveningunit = p.Eveningunit,
                Nightunit = p.Nightunit,
                RouteAdmin = p.RouteAdmin,
                Dosage = p.Dosage,
                DrugID = p.DrugID,
                DbpatientID = p.DbpatientID

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

            if (string.IsNullOrEmpty(patientId) || string.IsNullOrEmpty(drugId))
            {
                ViewBag.ErrorMessage = "PatientID or DrugID is missing!";
                tabmod.Items = await GetDistinctCaseVisitID(patientId) ?? new List<PatientEPrescriptionModel>();
                tabmod.Viewprescription = new List<PrescriptionViewModel>();

                return View("PatientEPrescription",tabmod); // Handle the error gracefully
            }


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
            ViewData["patientid"] = prescription.GetPatientId(facilityId);
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
                    DrugName = p.DrugName,
                    Morningunit = p.Morningunit,
                    Afternoonunit = p.Afternoonunit,
                    Eveningunit = p.Eveningunit,
                    Nightunit = p.Nightunit,
                    RouteAdmin = p.RouteAdmin,
                    Dosage = p.Dosage,
                    DbpatientID = p.DbpatientID,
                    DrugID = p.DrugID

                }).ToList();
                prescriptionTableModel.Viewprescription = viewModelList;
            }

            // Populate Items in the model for dropdown selection
            prescriptionTableModel.Items = await GetDistinctCaseVisitID(prescriptionEdit.PatientID);

            // Set ViewBag and Model properties for the view
            ViewBag.SelectedPatientID = prescriptionEdit.PatientID;

            ViewBag.SelectedDrugID = prescriptionEdit.DrugID;

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
            ViewData["patientid"] = prescription.GetPatientId(facilityId);
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
                    DrugName = p.DrugName,
                    Morningunit = p.Morningunit,
                    Afternoonunit = p.Afternoonunit,
                    Eveningunit = p.Eveningunit,
                    Nightunit = p.Nightunit,
                    RouteAdmin = p.RouteAdmin,
                    Dosage = p.Dosage,
                    DrugID = p.DrugID,
                    DbpatientID = p.DbpatientID
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
                DrugName = p.DrugName,
                Morningunit = p.Morningunit,
                Afternoonunit = p.Afternoonunit,
                Eveningunit = p.Eveningunit,
                Nightunit = p.Nightunit,
                RouteAdmin = p.RouteAdmin,
                Dosage = p.Dosage,
                DrugID = p.DrugID,
                DbpatientID = p.DbpatientID

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
            ViewData["patientid"] = prescription.GetPatientId(facilityId);
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);

            var model = new PrescriptionTableModel(); 
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
            ViewData["patientid"] = prescription.GetPatientId(facilityId);
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);


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

            var modelview = new PrescriptionTableModel(); // Replace with your actual model type
            modelview.Items = new List<PatientEPrescriptionModel>();


            var viewModelList = new List<PrescriptionViewModel>();


            modelview.Viewprescription = viewModelList;

            return View("PatientEPrescription", modelview);

        }



        public async Task<IActionResult> AdddrugPop(DrugInventoryModel model)
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
            ViewData["patientid"] = prescription.GetPatientId(facilityId);
            ViewData["drugid"] = prescription.GetDrugid(facilityId);
            ViewData["docid"] = prescription.Getdocid(facilityId, docid);
            ViewData["visitid"] = prescription.Getvisit(facilityId);


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

            var existingPatient = await GetPrescription.SHstkDrugInventory.FirstOrDefaultAsync(x => x.DrugId == model.DrugId && x.FacilityID == daocfac && x.IsDelete == false);

            if (existingPatient != null)
            {
                existingPatient.DrugId = model.DrugId;
                existingPatient.ModelName = model.ModelName;
                existingPatient.SideEffects = model.SideEffects;
                existingPatient.Dosage = model.Dosage;
                existingPatient.FacilityID = daocfac;
               

                GetPrescription.Entry(existingPatient).State = EntityState.Modified;
            }
            else
            {

                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.FacilityID = daocfac;
                GetPrescription.SHstkDrugInventory.Add(model);


            }

            await GetPrescription.SaveChangesAsync();


            var modelview = new PrescriptionTableModel(); // Replace with your actual model type
            modelview.Items = new List<PatientEPrescriptionModel>();


            var viewModelList = new List<PrescriptionViewModel>();


            modelview.Viewprescription = viewModelList;

            return View("PatientEPrescription", modelview);

        }



        public async Task<IActionResult> GetCaseVisitIDs(string patientId)
             
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


            var caseVisitIds = GetPrescription.SHprsPrescription
                .Where(cv => cv.PatientID == patientId && cv.IsDelete == false && cv.FacilityID == facilityId && cv.DoctorID == doctorid)
                .Select(cv => cv.CaseVisitID).Distinct()
                .ToList();

            return Json(caseVisitIds);
        }

      

        public async Task<IActionResult> AddNewVisitID(string patientId)
        {
            string facilityId = string.Empty;
            if (TempData["FacilityID"] != null)
            {
                facilityId = TempData["FacilityID"].ToString();
                TempData.Keep("FacilityID");
            }

            try
            {
                // Fetch the last visit ID for the selected patient
                var lastVisitIdEntry = await GetPrescription.SHprsPrescription
                    .Where(cv => cv.PatientID == patientId && cv.FacilityID == facilityId && cv.IsDelete == false)
                    .OrderByDescending(cv => cv.CaseVisitID)
                    .FirstOrDefaultAsync();

                int nextVisitNumber = 1;

                // If a visit ID exists, increment the number
                if (lastVisitIdEntry != null)
                {
                    var lastVisitId = lastVisitIdEntry.CaseVisitID;

                    // Extract the numeric part from the visit ID (assuming the format is 'Visit-<number>_<date>')
                    var visitPrefix = "Visit-";
                    if (lastVisitId.StartsWith(visitPrefix))
                    {
                        var lastVisitNumberString = lastVisitId.Substring(visitPrefix.Length).Split('_')[0];

                        // Parse the numeric part safely
                        if (int.TryParse(lastVisitNumberString, out int lastVisitNumber))
                        {
                            nextVisitNumber = lastVisitNumber + 1;
                        }
                        else
                        {
                            return Json(new { success = false, message = "Invalid visit number format. Unable to generate the next visit number." });
                        }
                    }
                }

                // Create the new visit ID with the current date in DD-MM-YYYY format
                string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
                string newVisitId = $"Visit-{nextVisitNumber}_{currentDate}";

                // Insert the new visit ID in the database for that patient
                var newVisit = new PrescriptionTableModel
                {
                    PatientID = patientId,
                    CaseVisitID = newVisitId,
                    // Include other necessary fields as needed
                };

                // Add newVisit to the database (implement the logic to save it here)

                return Json(new { success = true, newVisitId = newVisitId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred while adding the new visit ID." });
            }
        }


    }
}
