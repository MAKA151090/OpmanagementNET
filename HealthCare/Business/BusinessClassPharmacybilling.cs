using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Business
{
    public class BusinessClassPharmacybilling : Controller
    {
        private readonly HealthcareContext _healthcareContext;

        public BusinessClassPharmacybilling(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

    }
}
