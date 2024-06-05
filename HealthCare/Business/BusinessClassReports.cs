using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Business
{
    public class BusinessClassReports : Controller
    {
        private readonly HealthcareContext _healthcareContext;

        public BusinessClassReports(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }


        public List<GenericReportsModel> GetReportId()
        {
            var reportid = (
                    from pr in _healthcareContext.SHRepGenericReports
                    select new GenericReportsModel
                    {
                        ReportName = pr.ReportName,
                    }
                ).ToList();

            return reportid;
        }


        public List<ClinicAdminModel> GetFacilityId()
        {
            var facilityid = (
                    from pr in _healthcareContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                       FacilityID = pr.FacilityID,
                       ClinicName = pr.ClinicName,
                    }
                ).ToList();

            return facilityid;
        }



    }
}
