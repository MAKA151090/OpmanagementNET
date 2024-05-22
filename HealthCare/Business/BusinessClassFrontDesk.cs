﻿using HealthCare.Context;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassFrontDesk
    {
        private readonly HealthcareContext _healthcareContext;
        private BusinessClassFrontDesk getSubmit;

        public BusinessClassFrontDesk(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }


        public BusinessClassFrontDesk(BusinessClassFrontDesk getSubmit)
        {
            this.getSubmit = getSubmit;
        }

        public List<OpCheckingModelResult> GetOpCheckingModel(string PatienId)
        {
            var OpCheckingData = (
                          from op in _healthcareContext.SHfdOpCheckingModel
                          join ds in _healthcareContext.SHcllDoctorScheduleModel on op.PatientId equals ds.PatientID
                          join dr in _healthcareContext.SHclnStaffAdminModel on ds.StaffID equals dr.StrStaffID
                          join pr in _healthcareContext.SHPatientRegistration on op.PatientId equals pr.PatientID
                          where op.PatientId == PatienId
                          select new OpCheckingModelResult
                          {
                              PatientName = pr.FullName,
                              DoctorName = dr.StrFullName,
                              AppoinmentDate = ds.Date,
                              AppoinmentTime = ds.StartTime
                          }).ToListAsync().Result;

            return OpCheckingData;

        }


    





    }

}