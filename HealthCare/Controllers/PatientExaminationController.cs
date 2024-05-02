using HealthCare.Context;
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
            return View();
        }
        

    }
}
