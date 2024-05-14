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
    }
}
