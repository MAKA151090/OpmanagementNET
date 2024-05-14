using HealthCare.Context;
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
    }
}
