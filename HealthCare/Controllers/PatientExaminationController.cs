using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
   
    public class PatientExaminationController : Controller
    {
            private HealthcareContext getPatientObjective;

        public PatientExaminationController (HealthcareContext getPatientObjective)
        {
            this.getPatientObjective = getPatientObjective;
        }
    

        [HttpGet]

        [HttpGet]
        public async Task<IEnumerable<PatientObjectiveModel>> Get()
        {
            return await Task.FromResult(getPatientObjective.SHExmPatientObjective.ToList());
        }

        [HttpGet("PatientID")]
        public async Task<ActionResult<PatientObjectiveModel>> Get(string pPatientID)
        {
            var patientObjective = await getPatientObjective.SHExmPatientObjective.FirstOrDefaultAsync(x => x.PatientID == pPatientID);

            if (patientObjective == null)
            {
                return NotFound();
            }

            return patientObjective;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string objPatientID, PatientObjectiveModel pPatientIDCreate)
        {
            pPatientIDCreate.lastUpdatedDate = DateTime.Now.ToString();
            pPatientIDCreate.lastUpdatedUser = "Myself";
            getPatientObjective.SHExmPatientObjective.Add(pPatientIDCreate);
            await getPatientObjective.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { pPatientID = pPatientIDCreate.PatientID }, pPatientIDCreate);
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
        }

        //PatientExamination POST
        public async Task<IActionResult> Create(string objPatientID, PatientExaminationModel pPatientExmCreate)
        {
            pPatientExmCreate.lastUpdatedDate = DateTime.Now.ToString();
            pPatientExmCreate.lastUpdatedUser = "Myself";
            getPatientObjective.SHExmPatientExamination.Add(pPatientExmCreate);
            await getPatientObjective.SaveChangesAsync();

            // Assuming you want to redirect to the Index action after creation
            return RedirectToAction("Index");
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
            pPatientDocument.lastUpdatedUser = "Myself";
            //getPatientObjective.SHExmPatientDocument.Add(pPatientDocument);
            await getPatientObjective.SaveChangesAsync();
            //return RedirectToAction("Index");
            return CreatedAtAction(nameof(Get), new { pPatientID = pPatientDocument.PatientID }, pPatientDocument);
        }

        //PatientFHPH
        [HttpPost]
        public async Task<IActionResult> FHPH1 (string objPatientID, PatientFHPHModel pPatientFHPH)
        {
            pPatientFHPH.lastUpdatedDate = DateTime.Now.ToString();
            pPatientFHPH.lastUpdatedUser = "Myself";
            getPatientObjective.SHExmPatientFHPH.Add(pPatientFHPH);
            await getPatientObjective.SaveChangesAsync();
            //return RedirectToAction("Index");
            return CreatedAtAction(nameof(Get), new { pPatientID = pPatientFHPH.PatientID }, pPatientFHPH);
        }

        //PatientFHPH1
        [HttpPost]
        public async Task<IActionResult> FHPH2 (string objPatientID, PatientFHPHModel1 pPatientFHPH1)
        {
            pPatientFHPH1.lastUpdatedDate = DateTime.Now.ToString();
            pPatientFHPH1.lastUpdatedUser = "Myself";
            getPatientObjective.SHExmPatientFHPH1.Add(pPatientFHPH1);
            await getPatientObjective.SaveChangesAsync();
            // return RedirectToAction("Index");
            return CreatedAtAction(nameof(Get), new { pPatientID = pPatientFHPH1.PatientID }, pPatientFHPH1);
        }

        public IActionResult GeneratePatientExaminationDocument(string patientId, string visitId, string clinicId)
        {
            try
            {
                BusinessClass business = new BusinessClass(getPatientObjective);

                // Generate the document using the business class method-
                byte[] generatedDocument = business.GenerateDocument(patientId, visitId, clinicId);

                // Return the document as a downloadable file
                return File(generatedDocument, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "PatientExaminationDocument.docx");
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log the error or display an error message
                return BadRequest($"Error generating document: {ex.Message}");
            }
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientObjectiveData()
        {
            return View();
        }
        public IActionResult PatientHealthHistory()
        {
            return View();
        }
        public IActionResult PatientFamilyHistory()
        {
            return View();
        }

       
        public IActionResult PatientVisitIntoDocument()
        {
            return View();
        }
        public IActionResult PatientExamination()
        {
             var objsymp = new PatExmSymptomsSeverity()
             {
                 ClinicID = "1",
                 PatientID = "1",
                 VisitID = "1",
                 ExaminationID = "1",
                 Severity = "test"
             };
             var Obj = new PatientExaminationModel()
             {
                 ClinicID = "1",
                 PatientID = "1",
                 VisitID = "1",
                 ExaminationID = "1",
                 Severity = new List<PatExmSymptomsSeverity> { objsymp}
             };
            return View(Obj);



        }
        

    }
}
