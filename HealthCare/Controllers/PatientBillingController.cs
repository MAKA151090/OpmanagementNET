using HealthCare.Business;
using HealthCare.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Authorize]
    public class PatientBillingController : Controller
    {
        private HealthcareContext _healthcareContext;

        public PatientBillingController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public async Task<IActionResult> GetBill(string patientID, string visitID, string OrderID, string Medication, string Unit, String Price)
        {
            ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(_healthcareContext);

            
                var PharmacyData = await business.GetPharmacy(patientID , visitID , Medication, Unit , Price , OrderID);

                if (PharmacyData != null)
                {

                    return View("PharmacyBilling", PharmacyData);
                }
                else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs";
                    return View();
                }
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientBilling()
        {
            return View();
        }
        public IActionResult PharmacyBilling()
        {
            return View();
        }
        
    }
}
