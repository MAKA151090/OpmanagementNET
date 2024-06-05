 using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
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
        [HttpPost]
        public IActionResult GetReports(String inputValue)
                                                                                                                                                                                                                                                                                                              {
            BusinessClassReports business = new BusinessClassReports(_healthcareContext);
            ViewData["reportid"] = business.GetReportId();
            ViewData["facilityid"] = business.GetFacilityId();


            var reportQuery = (from rep in _healthcareContext.SHRepGenericReports
                              where(rep.ReportName == inputValue)
                              select new GenericReportsModel
                              {
                                  ReportName = rep.ReportName,
                                  ReportQuery= rep.ReportQuery,
                                  ReportDescription = rep.ReportDescription
                              }).First();
                              
            

            var query = BusinessClassCommon.DataTable(_healthcareContext, reportQuery.ReportQuery);


            return View("Reports", query);
        }

        public IActionResult Reports()
        {
            BusinessClassReports business = new BusinessClassReports(_healthcareContext);
            ViewData["reportid"] = business.GetReportId();
            ViewData["facilityid"] = business.GetFacilityId();
            return View();
        }


    }
}
