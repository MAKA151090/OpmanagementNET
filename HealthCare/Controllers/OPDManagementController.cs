using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
    public class OPDManagementController : Controller
    {
            private HealthcareContext getPatientObjective;

        public OPDManagementController (HealthcareContext getPatientObjective)
        {
            this.getPatientObjective = getPatientObjective;
        }

        [HttpPost]
        public async Task<IActionResult> PatientObjectiveData(PatientObjectiveModel pPatientIDCreate)
        {
            var existingPatientobjective= await getPatientObjective.SHExmPatientObjective.FindAsync(pPatientIDCreate.PatientID,pPatientIDCreate.FacilityID,pPatientIDCreate.VisitID);
            if (existingPatientobjective != null)
            {

                existingPatientobjective.PatientID = pPatientIDCreate.PatientID;
                existingPatientobjective.FacilityID = pPatientIDCreate.FacilityID;
                existingPatientobjective.VisitID = pPatientIDCreate.VisitID;
                existingPatientobjective.Height = pPatientIDCreate.Height;
                existingPatientobjective.Weight = pPatientIDCreate.Weight;
                existingPatientobjective.BloodPressure = pPatientIDCreate.BloodPressure;
                existingPatientobjective.BldGluLvl = pPatientIDCreate.BldGluLvl;
                existingPatientobjective.HeartRate = pPatientIDCreate.HeartRate;
                existingPatientobjective.Temperature = pPatientIDCreate.Temperature;
                existingPatientobjective.ResptryRate = pPatientIDCreate.ResptryRate;
                existingPatientobjective.OxySat = pPatientIDCreate.OxySat;
                existingPatientobjective.PulseRate = pPatientIDCreate.PulseRate;
                existingPatientobjective.VisitDate = pPatientIDCreate.VisitDate;
                existingPatientobjective.CheifComplaint = pPatientIDCreate.CheifComplaint;
                existingPatientobjective.lastUpdatedDate = pPatientIDCreate.lastUpdatedDate;
                existingPatientobjective.lastUpdatedUser = pPatientIDCreate.lastUpdatedUser;

            }
            else
            {
                pPatientIDCreate.lastUpdatedDate = DateTime.Now.ToString();
                pPatientIDCreate.lastUpdatedUser = User.Claims.First().Value.ToString();
                getPatientObjective.SHExmPatientObjective.Add(pPatientIDCreate);
           
            }
            await getPatientObjective.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            return View("PatientObjectiveData",pPatientIDCreate);
        }

       
        public async Task<ActionResult<PatientObjectiveModel>> CreateGet()
        {

            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            return View();
             
           
        } 

            [HttpPost]
        public async Task<IActionResult> Create(string objPatientID, PatientObjectiveModel pPatientIDCreate)
        {
            pPatientIDCreate.lastUpdatedDate = DateTime.Now.ToString();
            pPatientIDCreate.lastUpdatedUser = "Myself";
            getPatientObjective.SHExmPatientObjective.Add(pPatientIDCreate);
            await getPatientObjective.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateGet), new { pPatientID = pPatientIDCreate.PatientID }, pPatientIDCreate);
        }

        [HttpPost]
        public async Task<IActionResult> PatientExamination(PatientExaminationModel pexmmodel, string buttonType)
        {
            if (buttonType == "patientDiagnosis")
            {
                TempData["PatientID"] = pexmmodel.PatientID;
                TempData["ExaminationID"] = pexmmodel.ExaminationID;
                TempData["VisitID"] = pexmmodel.VisitID;
                TempData["FacilityID"] = pexmmodel.FacilityID;

                TempData.Keep("PatientID");
                TempData.Keep("ExaminationID");
                TempData.Keep("VisitID");
                TempData.Keep("FacilityID");


                return RedirectToAction("PatientDiagnosis");
            }
            else if (buttonType == "patientProcedure")
            {
                TempData["PatientID"] = pexmmodel.PatientID;
                TempData["ExaminationID"] = pexmmodel.ExaminationID;
                TempData["VisitID"] = pexmmodel.VisitID;
                TempData["FacilityID"] = pexmmodel.FacilityID;

                TempData.Keep("PatientID");
                TempData.Keep("ExaminationID");
                TempData.Keep("VisitID");
                TempData.Keep("FacilityID");

                return RedirectToAction("PatientProcedure");

            }
            else if(buttonType== "Symptoms Severity")
            {

                TempData["PatientID"] = pexmmodel.PatientID;
                TempData["ExaminationID"] = pexmmodel.ExaminationID;
                TempData["VisitID"] = pexmmodel.VisitID;
                TempData["FacilityID"] = pexmmodel.FacilityID;
              
                TempData.Keep("PatientID");
                TempData.Keep("ExaminationID");
                TempData.Keep("VisitID");
                TempData.Keep("FacilityID");

                return RedirectToAction("SymptomsSeverity");

              
            }

            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            ViewData["VisitDW"] = DPDW.GetvisitDW();

            var existingExm = await getPatientObjective.SHExmPatientExamination.FindAsync(pexmmodel.PatientID, pexmmodel.FacilityID, pexmmodel.VisitID,pexmmodel.ExaminationID);
            if (existingExm != null)
            {
                existingExm.PatientID=pexmmodel.PatientID;
                existingExm.FacilityID=pexmmodel.FacilityID;
                existingExm.ExaminationID = pexmmodel.ExaminationID;
                existingExm.VisitID= pexmmodel.VisitID;
                existingExm.Complaint=pexmmodel.Complaint;
                existingExm.Diagnosis= pexmmodel.Diagnosis;
                existingExm.Prescription= pexmmodel.Prescription;
                existingExm.FollowUp= pexmmodel.FollowUp;
            }
            else
            {
                pexmmodel.lastUpdatedDate = DateTime.Now.ToString();
                pexmmodel.lastUpdatedUser = User.Claims.First().Value.ToString();
                getPatientObjective.SHExmPatientExamination.Add(pexmmodel);

            }
            await getPatientObjective.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("PatientExamination", pexmmodel);


            /*
            BusinessClassExamination objBusinessclass = new BusinessClassExamination(getPatientObjective);
            pPatientExmCreate.lastUpdatedDate = DateTime.Now.ToString();
            pPatientExmCreate.lastUpdatedUser = User.Claims.First().Value.ToString();

            await objBusinessclass.SavePatientExaminationAndSeverity(patientExamination,severity);
            

            //getPatientObjective.SHExmPatientExamination.Add(pPatientExmCreate);
            //await getPatientObjective.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateGet), new { pPatientID = pPatientExmCreate.PatientID }, pPatientExmCreate);

           // return RedirectToAction("Index");*/
        }
       

        public async Task<IActionResult> GetDocument(string objPatientID, PatientVisitIntoDocumentModel pPatientDocument)
        {
            pPatientDocument.lastUpdatedDate = DateTime.Now.ToString();
            pPatientDocument.lastUpdatedUser = User.Claims.First().Value.ToString();
            //getPatientObjective.SHExmPatientDocument.Add(pPatientDocument);
            await getPatientObjective.SaveChangesAsync();
            //return RedirectToAction("Index");
            return CreatedAtAction(nameof(CreateGet), new { pPatientID = pPatientDocument.PatientID }, pPatientDocument);
        }

        //PatientFHPH
        [HttpPost]
        public async Task<IActionResult> FHPH1 (string objPatientID, PatientFHPHModel pPatientFHPH)
        {
            pPatientFHPH.lastUpdatedDate = DateTime.Now.ToString();
            pPatientFHPH.lastUpdatedUser = User.Claims.First().Value.ToString();
            getPatientObjective.SHExmPatientFHPH.Add(pPatientFHPH);
            await getPatientObjective.SaveChangesAsync();
            //return RedirectToAction("Index");
            return CreatedAtAction(nameof(CreateGet), new { pPatientID = pPatientFHPH.PatientID }, pPatientFHPH);
        }

     

        public IActionResult GeneratePatientExaminationDocument(string patientId, string visitId, string FacilityID)
        {
            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            ViewData["VisitDW"] = DPDW.GetvisitDW();

            try
            {
                BusinessClassExamination business = new BusinessClassExamination(getPatientObjective);

                // Generate the document using the business class method-
                byte[] generatedDocument = business.GenerateDocument(patientId, visitId, FacilityID);

                // Return the document as a downloadable file
                return File(generatedDocument, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "PatientExaminationDocument.docx");
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log the error or display an error message
                return BadRequest($"Error generating document: {ex.Message}");
            }
        }
      
        public async Task<ActionResult> HandleForm(string patientID, string visitID, string FacilityID, string visitDate,string patientName,string clinicName, string buttonType)
        {
            BusinessClassExamination business = new BusinessClassExamination(getPatientObjective);

            if (buttonType == "select")
            {
                var patientObjective = await business.GetPatientObjectiveData(patientID, visitID, FacilityID, visitDate,patientName,clinicName);

                if (patientObjective != null)
                {
                       
                    ViewBag.PatientObjectiveData = patientObjective;
                    BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
                    ViewData["patid"] = DPDW.Getpatid();
                    ViewData["faid"] = DPDW.Getfaid();
                    
                    return View("CreateGet");
                }
                else
                {
                   
                    ViewBag.ErrorMessage = "No data found for the entered IDs.";
                    return View("CreateGet");
                }
            }
            else if (buttonType == "submit")
            {
                var patientObjective = await business.GetPatientObjectiveSubmit(patientID, visitID, FacilityID); 

                if (patientObjective != null)
                {
                    patientID = patientObjective.PatientID;
                    visitID = patientObjective.VisitID;
                    FacilityID = patientObjective.FacilityID;
                    BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
                    ViewData["patid"] = DPDW.Getpatid();
                    ViewData["faid"] = DPDW.Getfaid();
                    return View("PatientObjectiveData", patientObjective);
                }
                else
                {
                    BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
                    ViewData["patid"] = DPDW.Getpatid();
                    ViewData["faid"] = DPDW.Getfaid();
                    ViewBag.ErrorMessage = "No data found for the entered IDs.";
                    return View("PatientObjectiveData");
                }
            }
            else if (buttonType == "create")
            {                
                return RedirectToAction("PatientObjectiveData");
            }

           
            return View();
        }



        /* public async Task<ActionResult> PatientExamination(string objPatientID, PatientExaminationModel pPatientExmCreate,PatExmSymptomsSeverity severity,PatientExaminationModel patientExamination, string buttonType)
         {
             BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
             ViewData["patid"] = DPDW.Getpatid();
             ViewData["faid"] = DPDW.Getfaid();
             ViewData["VisitDW"] = DPDW.GetvisitDW();


             if (buttonType == "patientDiagnosis")
             {
                 return View("PatientDiagnosis");
             }
             else if (buttonType == "patientProcedure")
             {

                 return View("PatientProcedure");

             }

             BusinessClassExamination objBusinessclass = new BusinessClassExamination(getPatientObjective);
             pPatientExmCreate.lastUpdatedDate = DateTime.Now.ToString();
             pPatientExmCreate.lastUpdatedUser = User.Claims.First().Value.ToString();

             await objBusinessclass.SavePatientExaminationAndSeverity(patientExamination, severity);


             //getPatientObjective.SHExmPatientExamination.Add(pPatientExmCreate);
             //await getPatientObjective.SaveChangesAsync();
             return CreatedAtAction(nameof(CreateGet), new { pPatientID = pPatientExmCreate.PatientID }, pPatientExmCreate);


         }*/

        [HttpPost]
        public async Task<IActionResult> PatientviewDiagnosis(List<PatientDiagnosisModel> pPatientDig, string action)
        {
            if (action == "Save")
            {
                foreach (var pDiagnosis in pPatientDig)
                {
                    var existingEntry = await getPatientObjective.SHEXMdiagnosis.FindAsync(
                       pDiagnosis.PatientID,
                        pDiagnosis.VisitID,
                        pDiagnosis.ExamID,
                        pDiagnosis.DiagnosisID);


                    if (existingEntry == null)
                    {
                        pDiagnosis.lastUpdatedDate = DateTime.Now.ToString();
                        pDiagnosis.lastUpdatedUser = User.Claims.First().Value.ToString();
                        pDiagnosis.lasrUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                        getPatientObjective.SHEXMdiagnosis.Add(pDiagnosis);
                    }
                    else
                    {
                        existingEntry.lastUpdatedDate = DateTime.Now.ToString();
                        existingEntry.lastUpdatedUser = User.Claims.First().Value.ToString();
                        existingEntry.lasrUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                        existingEntry.Notes = pDiagnosis.Notes;
                        existingEntry.Comments = pDiagnosis.Comments;
                        getPatientObjective.SHEXMdiagnosis.Update(existingEntry);
                    }
                }

                await getPatientObjective.SaveChangesAsync();
                ViewBag.Message = "Saved Successfully.";

            }
            else if (action == "Add Row")
            {
                if (pPatientDig.Count > 0)
                {
                    // Copy the values from the last entry to a new entry
                    var lastEntry = pPatientDig.Last();
                    var newEntry = new PatientDiagnosisModel
                    {
                        PatientID = lastEntry.PatientID,
                        ExamID = lastEntry.ExamID,
                        VisitID = lastEntry.VisitID,

                    };

                    pPatientDig.Add(newEntry); ;
                }
                else
                {
                    var newEntry = new PatientDiagnosisModel
                    {
                        PatientID = TempData["PatientID"] as string,
                        ExamID = TempData["ExaminationID"] as string,
                        VisitID = TempData["VisitID"] as string,

                    };

                    pPatientDig.Add(newEntry);
                }

            }

            return View("PatientDiagnosis", pPatientDig);
        }

        [HttpPost]
        public async Task<IActionResult> PatientviewProcedure(List<PatientProcedureModel> pPatientPro, string action)
        {
            if (action == "Save")
            {
                foreach (var pProcedure in pPatientPro)
                {
                    var existingEntry = await getPatientObjective.SHEXMprocedure.FindAsync(
                        pProcedure.PatientID,
                        pProcedure.VisitID,
                        pProcedure.ExamID,
                        pProcedure.ProcedureID);


                    if (existingEntry == null)
                    {
                        pProcedure.lastUpdatedDate = DateTime.Now.ToString();
                        pProcedure.lastUpdatedUser = User.Claims.First().Value.ToString();
                        pProcedure.lasrUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                        getPatientObjective.SHEXMprocedure.Add(pProcedure);
                    }
                    else
                    {
                        existingEntry.lastUpdatedDate = DateTime.Now.ToString();
                        existingEntry.lastUpdatedUser = User.Claims.First().Value.ToString();
                        existingEntry.lasrUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                        existingEntry.Notes = pProcedure.Notes;
                        existingEntry.Comments = pProcedure.Comments;
                        getPatientObjective.SHEXMprocedure.Update(existingEntry);
                    }
                }

                await getPatientObjective.SaveChangesAsync();
                ViewBag.Message = "Saved Successfully.";

            }
            else if (action == "Add Row")
            {
                if (pPatientPro.Count > 0)
                {
                    // Copy the values from the last entry to a new entry
                    var lastEntry = pPatientPro.Last();
                    var newEntry = new PatientProcedureModel
                    {
                        PatientID = lastEntry.PatientID,
                        ExamID = lastEntry.ExamID,
                        VisitID = lastEntry.VisitID,
                       
                    };

                    pPatientPro.Add(newEntry); ;
                }
                else
                {
                    var newEntry = new PatientProcedureModel
                    {
                        PatientID = TempData["PatientID"] as string,
                        ExamID = TempData["ExaminationID"] as string,
                        VisitID = TempData["VisitID"] as string,
                      
                    };

                    pPatientPro.Add(newEntry);
                }

            }

            return View("PatientProcedure", pPatientPro);

        }
        [HttpPost]
        public async Task<IActionResult> PatientviewSeverity(List<PatExmSymptomsSeverity> pseverityList, string action)
        {
            if (action == "Save")
            {
                foreach (var pseverity in pseverityList)
                {
                    var existingEntry = await getPatientObjective.SHExmSeverity.FindAsync(
                        pseverity.PatientID,
                        pseverity.FacilityID,
                        pseverity.VisitID,
                        pseverity.ExaminationID,
                        pseverity.Severity);


                    if (existingEntry == null)
                    {   
                       pseverity.lastUpdatedDate= DateTime.Now.ToString();
                        pseverity.lastUpdatedUser = User.Claims.First().Value.ToString();

                        getPatientObjective.SHExmSeverity.Add(pseverity);
                    }
                    else
                    {
                        existingEntry.lastUpdatedDate = DateTime.Now.ToString();
                        existingEntry.lastUpdatedUser = User.Claims.First().Value.ToString();
                        existingEntry.Symptoms = pseverity.Symptoms;
                        getPatientObjective.SHExmSeverity.Update(existingEntry);
                    }
                }
                
                await getPatientObjective.SaveChangesAsync();
                ViewBag.Message = "Saved Successfully.";

            }
            else if (action == "Add Row")
            {
                if (pseverityList.Count > 0)
                {
                    // Copy the values from the last entry to a new entry
                    var lastEntry = pseverityList.Last();
                    var newEntry = new PatExmSymptomsSeverity
                    {
                        PatientID = lastEntry.PatientID,
                        ExaminationID = lastEntry.ExaminationID,
                        VisitID = lastEntry.VisitID,
                        FacilityID = lastEntry.FacilityID
                    };

                    pseverityList.Add(newEntry); ;
                }
                else
                {
                    var newEntry = new PatExmSymptomsSeverity
                    {
                        PatientID = TempData["PatientID"] as string,
                        ExaminationID = TempData["ExaminationID"] as string,
                        VisitID = TempData["VisitID"] as string,
                        FacilityID = TempData["FacilityID"] as string
                    };

                    pseverityList.Add(newEntry);
                }

            }
           
            return View("SymptomsSeverity", pseverityList);
        }

         public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientObjectiveData()
        {
            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();

            return View();
        }
        public IActionResult PatientHealthHistory()
        {
            return View();
        }
        public IActionResult PatientFamilyHistory()
        {
            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveFHPH(PatientFHPHViewModel Model, string buttonType)
        {

            BusinessClassExamination ViewFHPH = new BusinessClassExamination(getPatientObjective);

            if (buttonType == "Save")
            {
               

                foreach (var summary in Model.SHFHPHviewlist)
                {
                    var SelectFHPH = await getPatientObjective.SHExmPatientFHPH.FindAsync(Model.PatientID, summary.QuestionID, Model.Type);

                    if (SelectFHPH != null)
                    {
                        SelectFHPH.Answer = summary.Answer;
                        SelectFHPH.lastUpdatedDate = DateTime.Now.ToString();
                        SelectFHPH.lastUpdatedUser = User.Claims.First().Value.ToString();
                        SelectFHPH.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                        getPatientObjective.SHExmPatientFHPH.Update(SelectFHPH);
                        getPatientObjective.Entry(SelectFHPH).State = EntityState.Modified; 
                        

                        BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
                        ViewData["patid"] = DPDW.Getpatid();
                       
                    }
                    else
                    {
                        BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
                        ViewData["patid"] = DPDW.Getpatid();
                        
                        SelectFHPH = new PatientFHPHModel
                        {

                            PatientID = Model.PatientID,
                            Answer = summary.Answer,
                            QuestionID=summary.QuestionID,
                            Type = Model.Type,
                            lastUpdatedDate = DateTime.Now.ToString(),
                            lastUpdatedUser = User.Claims.First().Value.ToString(),
                            lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString()

                        };
                       // getPatientObjective.SHExmPatientFHPH.Update(SelectFHPH);
                       
                    }
                   
                }
               
                await getPatientObjective.SaveChangesAsync();
                ViewBag.Message = "Saved Successfully.";
            }

            if (buttonType == "Get")
            {
                var FHPHresult = ViewFHPH.GetHistoryQuestions(Model.Type, Model.PatientID, Model.QuestionID);
                BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
                ViewData["patid"] = DPDW.Getpatid();
                var FHPHviewModel = new PatientFHPHViewModel
                {
                    Answer = Model.Answer,
                    SHFHPHviewlist = FHPHresult

                };

                
                return View("PatientFamilyHistory", FHPHviewModel);
            }
            ViewBag.Message = "Saved Successfully";
            // return View("PatientFamilyHistory", FHPHviewModel);
            return View("PatientFamilyHistory");

            
        }
        
       
        public IActionResult PatientVisitIntoDocument()
        {
            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            ViewData["VisitDW"] = DPDW.GetvisitDW();


            return View();
        }
        public IActionResult PatientExamination()
        {
            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            ViewData["VisitDW"] = DPDW.GetvisitDW();


            return View();

        }
        public async Task <IActionResult> PatientProcedure()
        {
            var model = new List<PatientProcedureModel>();

            if (TempData["PatientID"] != null)
            {
                var ProcedureModel = new PatientProcedureModel
                {
                    PatientID = TempData["PatientID"] as string,
                    ExamID = TempData["ExaminationID"] as string,
                    VisitID = TempData["VisitID"] as string,
                  
                };
                var existingEntries = await getPatientObjective.SHEXMprocedure
          .Where(s => s.PatientID == ProcedureModel.PatientID && s.ExamID == ProcedureModel.ExamID
                   && s.VisitID == ProcedureModel.VisitID )
          .ToListAsync();

                if (existingEntries != null && existingEntries.Any())
                {

                    return View(existingEntries);
                }

                model.Add(ProcedureModel);
            }

            return View(model);

          
        }

        public async Task <IActionResult> PatientDiagnosis()
        {
            var model = new List<PatientDiagnosisModel>();



            if (TempData["PatientID"] != null)
            {
                var DiagnosisModel = new PatientDiagnosisModel
                {
                    PatientID = TempData["PatientID"] as string,
                    ExamID = TempData["ExaminationID"] as string,
                    VisitID = TempData["VisitID"] as string,
                   
                };


                var existingEntries = await getPatientObjective.SHEXMdiagnosis
           .Where(s => s.PatientID == DiagnosisModel.PatientID && s.ExamID == DiagnosisModel.ExamID
                    && s.VisitID == DiagnosisModel.VisitID)
           .ToListAsync();

                if (existingEntries != null && existingEntries.Any())
                {

                    return View(existingEntries);
                }

                model.Add(DiagnosisModel);
            }

            return View(model);
        }

        public async Task <IActionResult> SymptomsSeverity()
         {

            var model = new List<PatExmSymptomsSeverity>();

            

            if (TempData["PatientID"] != null)
            {
                var severityModel = new PatExmSymptomsSeverity
                {
                    PatientID = TempData["PatientID"] as string,
                    ExaminationID = TempData["ExaminationID"] as string,
                    VisitID = TempData["VisitID"] as string,
                    FacilityID = TempData["FacilityID"] as string
                };

             
                var existingEntries = await getPatientObjective.SHExmSeverity
           .Where(s => s.PatientID == severityModel.PatientID && s.ExaminationID == severityModel.ExaminationID
                    && s.VisitID ==severityModel.VisitID && s.FacilityID ==severityModel.FacilityID )
           .ToListAsync();

                if (existingEntries != null && existingEntries.Any())
                {
                    
                    return View(existingEntries);
                }

                model.Add(severityModel);
            }

            return View(model);
    

        }
     }
}
