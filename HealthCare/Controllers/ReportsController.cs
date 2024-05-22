using HealthCare.Business;
using HealthCare.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Dynamic;
using System.Globalization;

namespace HealthCare.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
               
        private HealthcareContext _healthcareContext;
        public ReportsController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;

        }
        public IActionResult Reports()
        {

            var query = BusinessClassCommon.DataTable(_healthcareContext, "Select * from SHTestMaster");


            return View("Reports", query);
        }
        [HttpPost]
        public IActionResult GetReports()
        {


            var query = BusinessClassCommon.DataTable(_healthcareContext, "Select * from SHTestMaster");
               

            return View("Reports",query);
        }


    }
}
