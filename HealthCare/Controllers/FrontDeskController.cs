<<<<<<< HEAD
﻿using HealthCare.Business;
using HealthCare.Context;
=======
﻿using HealthCare.Context;
>>>>>>> purusoth: merged
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class FrontDeskController : Controller
    {

<<<<<<< HEAD
        private HealthcareContext GetFrontDeskData;

        public FrontDeskController(HealthcareContext healthCare) {
        GetFrontDeskData = healthCare;
        }

=======
>>>>>>> purusoth: merged
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpChecking()
        {
            return View();
        }
        public IActionResult IpRegistration()
        {
            return View();
        }
        public IActionResult OpDischarge()
        {
            return View();
        }



     


        public async Task<IActionResult> ViewResult(OpCheckingModel Model)
        {
            BusinessClassFrontDesk ObjTestResult = new BusinessClassFrontDesk(GetFrontDeskData);

            if (ObjTestResult != null)
            {
                var testResults = await ObjTestResult.GetOpCheckingModel(Model.PatientId);
                return View("OpChecking", testResults);
            }
            return View(Model);


        }


    }
}
