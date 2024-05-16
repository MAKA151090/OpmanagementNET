using HealthCare.Context;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class ClinicAdminBusinessClass
    {
        private readonly HealthcareContext _healthcareContext;

        public ClinicAdminBusinessClass(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public async Task<ClinicAdminModel> GetClinicRegister(string clinicid, string clinicname)
        {
            var clinicregisterdata = await _healthcareContext.SHclnClinicAdmin.FirstOrDefaultAsync(x => x.ClinicId == clinicid && x.ClinicName == clinicname);

             return clinicregisterdata;
        }

        public async Task<DoctorAdminModel> GetDoctorRegister(string doctorid)
        {
            var doctorregisterdata = await _healthcareContext.SHclnDoctorAdmin.FirstOrDefaultAsync(x => x.DoctorID == doctorid);
            
            return doctorregisterdata;
        }

        public async Task<List<RadiologyViewResultModel>> GetRadiologData(string radioID, string clinicID, string patientID, string radioName, string screeingDate, string result, string referralDoctorName)
        {
            var RadiologyData = (
                            from pr in _healthcareContext.SHPatientRadiology
                            join rm in _healthcareContext.SHRadioMaster on pr.RadioID equals rm.RadioID
                            join p in _healthcareContext.SHPatientRegistration on pr.PatientID equals p.PatientID

                            select new RadiologyViewResultModel
                            {
                                PatentName = p.FullName,
                                RadioID = rm.RadioID,
                                ClinicID = pr.ClinicID,
                                RadioName = rm.RadioName,
                                ScreeningDate = pr.ScreeningDate,
                                Result = pr.Result,
                                ReferralDoctorName = pr.ReferralDoctorName
                            
                            }).ToListAsync().Result;

            return RadiologyData;
        }
    }
}
