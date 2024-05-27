using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        /* public async Task<ActionResult> CreateGet(PatientObjectiveModel patient)
         {
             return View();
         }*/

        /* [HttpGet("PatientID")]
         public async Task<ActionResult<PatientObjectiveModel>> CreateGet(string pPatientID)
         {
             var patientObjective = await getPatientObjective.SHExmPatientObjective.FirstOrDefaultAsync(x => x.PatientID == pPatientID);

             if (patientObjective == null)
             {
                 return NotFound();
             }

             return patientObjective;
         }*/


        public async Task<ActionResult<PatientObjectiveModel>> CreateGet()
        {

            BusinessClassExamination DPDW = new BusinessClassExamination(getPatientObjective);
            ViewData["patid"] = DPDW.Getpatid();
            ViewData["faid"] = DPDW.Getfaid();
            return View();
             
           
        }

       
        /*public async Task<ActionResult> View(string patientID, string visitID, string clinicID)
        {
            // Retrieve relevant patient objective details from the database based on the IDs
            var patientObjective = await getPatientObjective.SHExmPatientObjective.FirstOrDefaultAsync(x =>
                x.PatientID == patientID && x.VisitID == visitID && x.ClinicID == clinicID);

            if (patientObjective == null)
            {
                return NotFound(); 
            }

            return Json(new
            {
                patientID = patientObjective.PatientID,
                visitID = patientObjective.VisitID,
                clinicID = patientObjective.ClinicID,
                PatientObjectiveData = patientObjective
            });

            //return Json(new { patientID = patientObjective.PatientID, visitID = patientObjective.VisitID, clinicID = patientObjective.ClinicID,patientObjective});

            //return RedirectToAction("PatientObjectiveData");
            //return Json ("PatientObjectiveData",patientObjective);
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

        [HttpPut("{pPatientID}")]
        public async Task<IActionResult> Put(string pPatientID, [FromBody] PatientObjectiveModel pPatientIDData)
        {
            var patientObjective = await getPatientObjective.SHExmPatientObjective.FirstOrDefaultAsync(x => x.PatientID == pPatientID);

            if (patientObjective == null)
            {
                return NotFound();
            }

            getPatientObjective.Entry(patientObjective).CurrentValues.SetValues(pPatientIDData);
            await getPatientObjective.SaveChangesAsync();
            
            return NoContent();
        }*/

      
        public async Task<IActionResult> CreateExm(string objPatientID, PatientExaminationModel pPatientExmCreate,PatExmSymptomsSeverity severity,PatientExaminationModel patientExamination)
        {
            BusinessClassExamination objBusinessclass = new BusinessClassExamination(getPatientObjective);
            pPatientExmCreate.lastUpdatedDate = DateTime.Now.ToString();
            pPatientExmCreate.lastUpdatedUser = User.Claims.First().Value.ToString();

            await objBusinessclass.SavePatientExaminationAndSeverity(patientExamination,severity);
            

            //getPatientObjective.SHExmPatientExamination.Add(pPatientExmCreate);
            //await getPatientObjective.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateGet), new { pPatientID = pPatientExmCreate.PatientID }, pPatientExmCreate);

           // return RedirectToAction("Index");
        }
        //PatientVisitDocument
        /*public async Task<IActionResult> GetDocument(string objPatientID, PatientVisitIntoDocumentModel pPatientDocument)
        {
            pPatientDocument.lastUpdatedDate = DateTime.Now.ToString();
            pPatientDocument.lastUpdatedUser = "Myself";
            //getPatientObjective.SHExmPatientDocument.Add(pPatientDocument);
            await getPatientObjective.SaveChangesAsync();
            //return RedirectToAction("Index");
            return CreatedAtAction(nameof(Get), new { pPatientID = pPatientDocument.PatientID }, pPatientDocument);
        }*/

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


        [HttpPost]
        public async Task<ActionResult> PatientExamination(string objPatientID, PatientExaminationModel pPatientExmCreate,PatExmSymptomsSeverity severity,PatientExaminationModel patientExamination, string buttonType)
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


        }

        public async Task<IActionResult> PatientviewDiagnosis(PatientDiagnosisModel pPatientDig)
        {
            var existingDig = await getPatientObjective.SHEXMdiagnosis.FindAsync(pPatientDig.PatientID, pPatientDig.VisitID, pPatientDig.ExamID, pPatientDig.DiagnosisID);
            if (existingDig != null)
            {

                existingDig.PatientID = pPatientDig.PatientID;
                existingDig.VisitID = pPatientDig.VisitID;
                existingDig.ExamID = pPatientDig.ExamID;
                existingDig.DiagnosisID = pPatientDig.DiagnosisID;
                existingDig.Notes = pPatientDig.Notes;
                existingDig.Comments = pPatientDig.Comments;
                existingDig.DoctorID = pPatientDig.DoctorID;
                existingDig.lastUpdatedDate = pPatientDig.lastUpdatedDate;
                existingDig.lastUpdatedUser = pPatientDig.lastUpdatedUser;
                existingDig.lasrUpdatedMachine = pPatientDig.lasrUpdatedMachine;
            }
            else
            {
                pPatientDig.lastUpdatedDate = DateTime.Now.ToString();
                pPatientDig.lastUpdatedUser = "Myself";
                pPatientDig.lasrUpdatedMachine = "Lap";
                getPatientObjective.SHEXMdiagnosis.Add(pPatientDig);

            }
            await getPatientObjective.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("PatientDiagnosis", pPatientDig);
        }

        public async Task<IActionResult> PatientviewProcedure(PatientProcedureModel pPatientDig)
        {
            var existingDig = await getPatientObjective.SHEXMprocedure.FindAsync(pPatientDig.PatientID, pPatientDig.VisitID, pPatientDig.ExamID, pPatientDig.ProcedureID);
            if (existingDig != null)
            {

                existingDig.PatientID = pPatientDig.PatientID;
                existingDig.VisitID = pPatientDig.VisitID;
                existingDig.ExamID = pPatientDig.ExamID;
                existingDig.ProcedureID = pPatientDig.ProcedureID;
                existingDig.Notes = pPatientDig.Notes;
                existingDig.Comments = pPatientDig.Comments;
                existingDig.DoctorID = pPatientDig.DoctorID;
                existingDig.lastUpdatedDate = pPatientDig.lastUpdatedDate;
                existingDig.lastUpdatedUser = pPatientDig.lastUpdatedUser;
                existingDig.lasrUpdatedMachine = pPatientDig.lasrUpdatedMachine;
            }
            else
            {
                pPatientDig.lastUpdatedDate = DateTime.Now.ToString();
                pPatientDig.lastUpdatedUser = "Myself";
                pPatientDig.lasrUpdatedMachine = "Lap";
                getPatientObjective.SHEXMprocedure.Add(pPatientDig);

            }
            await getPatientObjective.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("PatientProcedure", pPatientDig);
        }

    /*// Check which button was clicked
    switch (buttonType)
    {
        case "select":
            // Handle Select button click
            return await HandleSelectButton(patientID, visitID, clinicID);

        case "create":
            // Handle Create button click
            return HandleCreateButton();

        case "submit":
            // Handle Submit button click
            return HandleSubmitButton();

        default:
            return View();
    }*/


    /* private async Task<ActionResult> HandleSelectButton(string patientID, string visitID, string clinicID)
     {
         // Retrieve relevant patient objective details from the database based on the IDs
         var patientObjective = await getPatientObjective.SHExmPatientObjective.FirstOrDefaultAsync(x =>
             x.PatientID == patientID && x.VisitID == visitID && x.ClinicID == clinicID);

         if (patientObjective == null)
         {
             ViewBag.Message = "No data found for the provided IDs.";
             ViewBag.PatientObjectiveData = null;
             return View();
         }

         ViewBag.PatientObjectiveData = patientObjective;
         // Enable the Submit button
         ViewBag.SubmitButtonDisabled = false;
         return View("PatientObjectiveData",patientObjective);
     }

     private ActionResult HandleCreateButton()
     {
         // Handle Create button click logic here
         return RedirectToAction("PatientObjectivePage");
     }

     private ActionResult HandleSubmitButton()
     {
         // Handle Submit button click logic here
         return RedirectToAction("PatientObjectivePage");
     }*/


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
        public IActionResult PatientProcedure()
        {
            return View();
        }

        public IActionResult PatientDiagnosis()
        {
            return View();
        }

       
    }
}
