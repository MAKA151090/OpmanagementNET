﻿
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
    public class InPatientModulesController : Controller
    {

        private HealthcareContext _healthcareContext;

        public InPatientModulesController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public async Task<IActionResult> GetPatientDischarge(InpatientDischargeModel model)
        {
            var existingPatientDischarge = await _healthcareContext.SHInpatientDischarge.FindAsync(model.PatientID, model.CaseID);
            if (existingPatientDischarge != null)
            {
                existingPatientDischarge.PatientID = model.PatientID;
                existingPatientDischarge.CaseID = model.CaseID;
                existingPatientDischarge.DischargeNotes = model.DischargeNotes;
                existingPatientDischarge.DoctorID = model.DoctorID;
                existingPatientDischarge.lastUpdatedDate = DateTime.Now.ToString();
                existingPatientDischarge.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingPatientDischarge.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                _healthcareContext.Entry(existingPatientDischarge).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHInpatientDischarge.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            var updstatus = await _healthcareContext.SHInpatientAdmission.FirstOrDefaultAsync(x => x.PatientID == model.PatientID && x.CaseID == model.CaseID);
            {
                if(updstatus!= null)
                {
                    updstatus.Status = "Dischaged";
                    await _healthcareContext.SaveChangesAsync();
                }
            }

            ViewBag.Message = "Saved Successfully";
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["PatientID"] = inpatient.GetPatientID();
            ViewData["CaseID"] = inpatient.GetCaseID();
            ViewData["dutydocid"] = inpatient.Getdutydocid();
            return View("InPatientDischarge", model);

        }

        public async Task<IActionResult> GetPatientAdmission(InpatientAdmissionModel model)
        {
            var existingPatientAdmission = await _healthcareContext.SHInpatientAdmission.FindAsync(model.PatientID, model.CaseID);

            if (existingPatientAdmission != null)
            {
                existingPatientAdmission.FacilityID = model.FacilityID;
                existingPatientAdmission.PatientID = model.PatientID;
                existingPatientAdmission.CaseID = model.CaseID;
                existingPatientAdmission.ConsultDoctorID = model.ConsultDoctorID;
                existingPatientAdmission.DutyDoctorID = model.DutyDoctorID;
                existingPatientAdmission.ReferredByDoctorID = model.ReferredByDoctorID;
                existingPatientAdmission.BedID = model.BedID;
                existingPatientAdmission.Purpose = model.Purpose;
                existingPatientAdmission.AdditionConsultDoctorID = model.AdditionConsultDoctorID;
                existingPatientAdmission.ConsultantDepartmentID = model.ConsultantDepartmentID;
                existingPatientAdmission.AttenderName = model.AttenderName;
                existingPatientAdmission.AttenderContact = model.AttenderContact;
                existingPatientAdmission.AttenderEmail = model.AttenderEmail;
                existingPatientAdmission.DocInstruction = model.DocInstruction;
                existingPatientAdmission.InpatientType = model.InpatientType;
                existingPatientAdmission.AdmissionDate = model.AdmissionDate;
                existingPatientAdmission.lastupdatedDate = DateTime.Now.ToString();
                existingPatientAdmission.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingPatientAdmission.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                _healthcareContext.Entry(existingPatientAdmission).State = EntityState.Modified;
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHInpatientAdmission.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";

            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patid"] = inpatient.Getpatid();
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();
            ViewData["dutydocid"] = inpatient.Getdutydocid();
            ViewData["refocid"] = inpatient.GetRefDocId();
            ViewData["addcondocid"] = inpatient.GetAddcondocid();
            ViewData["bedid"] = inpatient.GetBedid();
            ViewData["condepid"] = inpatient.Getcondepid();
            ViewData["pattypeid"] = inpatient.Getinpattype();

            return View("InPatientAdmission", model);

        }

        [HttpPost]
        public async Task<IActionResult> GetInpatientViewResult(InpatientObservationViewModel Model, string buttonType,string bedNoID,string patientID)
        {

            BusinessClassInpatient ObjViewINP = new BusinessClassInpatient(_healthcareContext);

            /* if (buttonType == "get")
             {
                 var result = await ObjViewINP.GetInpatientObs(Model.BedNoID, Model.PatientID, Model.ObservationID, Model.ObservationID);
                 return View("InPatientObservation", result);

             }*/

            if (buttonType == "save")
            {

                foreach (var summary in Model.SHviewInpatientObs)
                {

                    var objadd = await _healthcareContext.SHipmInpatientobservation.FindAsync(Model.BedNoID, Model.PatientID, Model.ObservationID, Model.ObservationTypeID);
                    if (objadd != null)
                    {
                        objadd.Answer = summary.Answer;
                        objadd.ObservationID = Model.ObservationID;
                        objadd.NurseID = Model.NurseID;
                        objadd.DateTime = Model.DateTime;
                        objadd.lastupdatedDate = DateTime.Now.ToString();
                        objadd.lastupdatedDate = DateTime.Now.ToString();
                            objadd.lastUpdatedUser = User.Claims.First().Value.ToString();
                        objadd.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                        _healthcareContext.SHipmInpatientobservation.Update(objadd);
                    }
                    else
                    {
                        objadd = new InpatientObservationModel
                        {
                            BedNoID = Model.BedNoID,
                            PatientID = Model.PatientID,
                            ObservationID = Model.ObservationID,
                            ObservationTypeID = summary.ObservationTypeID,
                            ObservationName = summary.ObservationName,
                            Answer = summary.Answer,
                            Frequency = summary.Frequency,
                            Unit = summary.Unit,
                            Range = summary.Range,
                            NurseID = Model.NurseID,
                            DateTime = Model.DateTime,
                            lastupdatedDate = DateTime.Now.ToString(),
                            lastUpdatedUser = User.Claims.First().Value.ToString(),
                        lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                    };

                       //_healthcareContext.SHipmInpatientobservation.Add(objadd);
                        _healthcareContext.Entry(objadd).State = EntityState.Modified;
                    }
                }

                await _healthcareContext.SaveChangesAsync();

                ViewBag.Message = "Saved Successfully";
                //return View("InPatientObservation", Model);
            }
            var result = ObjViewINP.GetInpatientViewObs(Model.ObservationID, Model.BedNoID, Model.PatientID, Model.ObservationID, Model.ObservationTypeID);
            var viewModel = new InpatientObservationViewModel
            {
              
                Unit = Model.Unit,
                Answer = Model.Answer,
                Range = Model.Range,
                Frequency = Model.Frequency,
                ObservationName = Model.ObservationName,
                SHviewInpatientObs = result
            };
           // ViewBag.Message = "Saved Successfully";
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
             ViewData["patientID"] = inpatient.GetPatientid();
            ViewData["bedid"] = inpatient.Getbedid();
            return View("InPatientObservation", viewModel);

        }
        /*var objadd = await _healthcareContext.SHipmInpatientobservation.FindAsync(Model.BedNoID, Model.PatientID,Model.ObservationID);
         objadd.NurseID = Model.NurseID ?? objadd.NurseID; 
         objadd.DateTime = Model.DateTime ?? objadd.DateTime;
         objadd.lastupdatedDate=DateTime.Now.ToString();
         objadd.lastUpdatedUser = "Kumar";
         objadd.lastUpdatedMachine = "Lap";
         await _healthcareContext.SaveChangesAsync();
     }

     ViewBag.Message = "Saved Successfully";
     return View("InPatientObservation", Model);
*/

        [HttpPost]
        public async Task<IActionResult> InPatientCaseSheet(InPatientCaseSheetModel model)
        {

            var existingInPatientCaseSheet = await _healthcareContext.SHipmInPatientCaseSheet.FindAsync(model.StrPatientId, model.StrCaseId);
            if (existingInPatientCaseSheet != null)
            {
                existingInPatientCaseSheet.StrPatientId = model.StrPatientId;
                existingInPatientCaseSheet.StrCaseId = model.StrCaseId;
                existingInPatientCaseSheet.StrBedId = model.StrBedId;
                existingInPatientCaseSheet.StrPostMedHistory = model.StrPostMedHistory;
                existingInPatientCaseSheet.StrAllergicTo = model.StrAllergicTo;
                existingInPatientCaseSheet.StrHeight = model.StrHeight;
                existingInPatientCaseSheet.StrWeight = model.StrWeight;
                existingInPatientCaseSheet.StrDiagnosis = model.StrDiagnosis;
                existingInPatientCaseSheet.StrTreatment = model.StrTreatment;
                existingInPatientCaseSheet.LastupdatedDate = DateTime.Now.ToString();
                existingInPatientCaseSheet.LastupdatedUser = User.Claims.First().Value.ToString();
                existingInPatientCaseSheet.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                _healthcareContext.Entry(existingInPatientCaseSheet).State = EntityState.Modified;
            }
            else
            {
                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHipmInPatientCaseSheet.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";

            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patientID"] = inpatient.GetpateintID();
            ViewData["caseid"] = inpatient.GetCaseid();
            ViewData["bedid"] = inpatient.GetBedID();

            return View("InPatientCaseSheet", model);

        }


        [HttpPost]
        public async Task<IActionResult> InPatientDocVisit(InPatientDocVisitModel model)
        {
            var existingInPatientDocVisit = await _healthcareContext.SHipmInPatientDocVisit.FindAsync(model.PatientId, model.CaseId,model.VisitID);

            if (existingInPatientDocVisit != null)
            {
                existingInPatientDocVisit.PatientId = model.PatientId;
                existingInPatientDocVisit.CaseId = model.CaseId;
                existingInPatientDocVisit.BedId = model.BedId;
                existingInPatientDocVisit.VisitID = model.VisitID;
                existingInPatientDocVisit.NurseID = model.NurseID;
                existingInPatientDocVisit.NurseNote = model.NurseNote;
                existingInPatientDocVisit.DocId = model.DocId;
                existingInPatientDocVisit.DocNotes = model.DocNotes;
                existingInPatientDocVisit.LastupdatedDate = DateTime.Now.ToString();
                existingInPatientDocVisit.LastupdatedUser = User.Claims.First().Value.ToString();
                existingInPatientDocVisit.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                _healthcareContext.Entry(existingInPatientDocVisit).State = EntityState.Modified;
            }
            else
            {
                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHipmInPatientDocVisit.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";

            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patid"] = inpatient.Getpatid();
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();
            ViewData["dutydocid"] = inpatient.Getdutydocid();
            ViewData["refocid"] = inpatient.GetRefDocId();
            ViewData["addcondocid"] = inpatient.GetAddcondocid();
            ViewData["bedid"] = inpatient.GetBedid();
            ViewData["condepid"] = inpatient.Getcondepid();
            ViewData["pattypeid"] = inpatient.Getinpattype();
            ViewData["nurseDWid"] = inpatient.GetnurseDWID();

            return View("InPatientDocVisit", model);


        }



        [HttpPost]
        public async Task<IActionResult> InPatientTransfer(InPatientTransferUpdateModel Model, string buttonType,string patientId, string caseId,string BedId)
        {

            BusinessClassInpatient ObjView = new BusinessClassInpatient(_healthcareContext);

            ViewData["patientID"] = ObjView.GetPatID();
            ViewData["CaseID"] = ObjView.GetCaseId();
            ViewData["bedid"] = ObjView.GetBedId();
            if (buttonType == "Get")
            {
                var result = ObjView.InPatientTransfer(Model.PatientId, Model.CaseId, Model.BedId,Model.TranferID).Result;
                return View("InPatientTransfer", result);
            }
            else if (buttonType == "Save")
            {

                // Update on ADmission Table
                var admission = await _healthcareContext.SHInpatientAdmission.FindAsync(Model.PatientId, Model.CaseId,Model.TranferID,Model.BedId);
                if (admission != null)
                {

                    admission.BedID = Model.BedId;
                    admission.lastupdatedDate = DateTime.Now.ToString();
                    admission.lastUpdatedMachine = "test";
                    admission.lastUpdatedUser = "test";


                    _healthcareContext.Entry(admission).State = EntityState.Modified;
                }


                //Saving history
                var existingInPatientTransfer = await _healthcareContext.SHipmInPatientTransferUpdate.FindAsync(Model.PatientId, Model.CaseId, Model.BedId,Model.TranferID);

                if (existingInPatientTransfer != null)
                {
                    existingInPatientTransfer.PatientId = Model.PatientId;
                    existingInPatientTransfer.CaseId = Model.CaseId;
                    existingInPatientTransfer.BedId = Model.BedId;
                    existingInPatientTransfer.RoomTypeFrom = Model.RoomTypeFrom;
                    existingInPatientTransfer.RoomTypeTo = Model.RoomTypeTo;
                    existingInPatientTransfer.BedIdFrom = Model.BedIdFrom;
                    existingInPatientTransfer.BedIdTo = Model.BedIdTo;
                    existingInPatientTransfer.TransferNotes = Model.TransferNotes;
                    existingInPatientTransfer.DocId = Model.DocId;
                    existingInPatientTransfer.ChangeDate = Model.ChangeDate;
                    existingInPatientTransfer.IsCount = true;
                    existingInPatientTransfer.LastupdatedDate = DateTime.Now.ToString();
                    existingInPatientTransfer.LastupdatedUser = "Admin";
                    existingInPatientTransfer.LastUpdatedMachine = "Lap";

                    _healthcareContext.Entry(existingInPatientTransfer).State = EntityState.Modified;

                }
                else
                {
                    Model.LastupdatedDate = DateTime.Now.ToString();
                    Model.LastupdatedUser = "Admin";
                    Model.LastUpdatedMachine = "Lap";
                  
                    var objupdTr = (_healthcareContext.SHipmInPatientTransferUpdate.FirstOrDefault(x =>
                     x.PatientId == patientId && x.CaseId == caseId && x.BedId == BedId));
                    if(objupdTr!=null)
                    {
                        objupdTr.IsCount = false;
                        await _healthcareContext.SaveChangesAsync();
                    }
                   
                    Model.IsCount = true;
                    _healthcareContext.SHipmInPatientTransferUpdate.Add(Model);

                }

                await _healthcareContext.SaveChangesAsync();

                ViewBag.Message = "Saved Successfully";

                return View("InPatientTransfer", Model);


            }
            else
            {
                ViewBag.Message = "Saved Successfully";

                return View("InPatientTransfer", Model);

            }


        }


        public IActionResult InPatientTransfer()
        {
            BusinessClassInpatient ObjView = new BusinessClassInpatient(_healthcareContext);
            ViewData["patientID"] = ObjView.GetPatID();
            ViewData["CaseID"] = ObjView.GetCaseId();
            ViewData["bedid"] = ObjView.GetBedId();
            return View();
        }









        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InPatientAdmission()
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patid"] = inpatient.Getpatid();
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();
            ViewData["dutydocid"] = inpatient.Getdutydocid();
            ViewData["refocid"] = inpatient.GetRefDocId();
            ViewData["addcondocid"] = inpatient.GetAddcondocid();
            ViewData["bedid"] = inpatient.GetBedid();
            ViewData["condepid"] = inpatient.Getcondepid();
            ViewData["pattypeid"] = inpatient.Getinpattype();
            return View();
        }

        public IActionResult WardManagement()
        {
            return View();
        }

        public IActionResult InPatientCaseSheet()
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patientID"] = inpatient.GetpateintID();

            ViewData["caseid"] = inpatient.GetCaseid();

            ViewData["bedid"] = inpatient.GetBedID();

            return View();
        }

        public IActionResult InPatientDischarge()
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["PatientID"] = inpatient.GetPatientID();
            ViewData["CaseID"] = inpatient.GetCaseID();
            ViewData["dutydocid"] = inpatient.Getdutydocid();

            return View();
        }
        public IActionResult InPatientObservation()
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patientID"] = inpatient.GetPatientid();
            ViewData["bedid"] = inpatient.Getbedid();

            return View();
        }
        public IActionResult InPatientCaseSheetModel()
        {

            return View();
        }

        public IActionResult InPatientDocVisit()
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["patid"] = inpatient.Getpatid();
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();
            ViewData["dutydocid"] = inpatient.Getdutydocid();
            ViewData["refocid"] = inpatient.GetRefDocId();
            ViewData["addcondocid"] = inpatient.GetAddcondocid();
            ViewData["bedid"] = inpatient.GetBedid();
            ViewData["condepid"] = inpatient.Getcondepid();
            ViewData["pattypeid"] = inpatient.Getinpattype();
            ViewData["nurseDWid"] = inpatient.GetnurseDWID();
            return View();
        }

        public IActionResult InPatientDischargeSummary()
        {
            return View();
        }

    }
}






