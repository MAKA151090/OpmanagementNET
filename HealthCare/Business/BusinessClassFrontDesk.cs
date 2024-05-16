using HealthCare.Context;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassFrontDesk
    {
        private readonly HealthcareContext _healthcareContext;
        private BusinessClassFrontDesk getlabData;

        public BusinessClassFrontDesk(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public BusinessClassFrontDesk(BusinessClassFrontDesk getlabData)
        {
            this.getlabData = getlabData;
        }

        public async Task<List<OpCheckingModelResult>> GetOpCheckingModel(string PatienId)
        {
            var OpCheckingData = (
                          from op in _healthcareContext.SHfdOpCheckingModel
                            join ds in _healthcareContext.SHcllDoctorScheduleModel on op.PatientId equals ds.PatientID
                          join dr in _healthcareContext.SHclnDoctorAdmin on ds.DoctorID equals dr.DoctorID
                          join pr in _healthcareContext.SHPatientRegistration on op.PatientId equals pr.PatientID
                          where op.PatientId == PatienId
                          select new OpCheckingModelResult
                          {
                               PatientName = pr.FullName,
                              DoctorName = dr.FullName,
                              AppoinmentDate=ds.Date,
                              AppoinmentTime=ds.StartTime
                          }).ToListAsync().Result;

            return OpCheckingData;
        }
    }



 }
