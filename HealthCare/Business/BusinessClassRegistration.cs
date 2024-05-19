using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;

namespace HealthCare.Business
{
    public class BusinessClassRegistration
    {

        private readonly HealthcareContext objDbContext;

        public BusinessClassRegistration(HealthcareContext serviceContext)
        {
            objDbContext = serviceContext;
        }
        public async Task<PatientRegistrationModel> GetPatientObjectiveSubmit(string patientID,  string FacilityID)
        {
            var patitentRegDataSubmit = await objDbContext.SHPatientRegistration.FirstOrDefaultAsync(x =>
                    x.PatientID == patientID && x.FacilityID == FacilityID);

            return patitentRegDataSubmit;
        }

    }
}
