using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassPatientPrescription : Controller
    {

        private HealthcareContext _healthcareContext;

        public BusinessClassPatientPrescription(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public async Task<List<PatientEPrescriptionPrintModel>> GetPrescriptionPrint(string patientID, string casevisitID, string orderID)
        {
            var prescription = await (
                    from pp in _healthcareContext.SHprsPrescription
                    join di in _healthcareContext.SHstkDrugInventory on pp.DrugID equals di.DrugId
                    join p in _healthcareContext.SHPatientRegistration on pp.PatientID equals p.PatientID
                    join d in _healthcareContext.SHclnStaffAdminModel on pp.DoctorID equals d.StrStaffID
                    where pp.PatientID == patientID && pp.CaseVisitID == casevisitID && pp.OrderID == orderID
                    select new PatientEPrescriptionPrintModel
                    {
                        PatientID = pp.PatientID,
                        CaseVisitID = pp.CaseVisitID,
                        OrderID = pp.OrderID,
                        PatientName = p.FullName,
                        MedicactionName = di.ModelName,
                        Unit = pp.Unit,
                        UnitCategory = pp.UnitCategory,
                        Frequency = pp.Frequency,
                        FrequencyUnit = pp.FrequencyUnit,
                        Duration = pp.Duration,
                        Quantity = pp.Quantity,
                        EndDate = pp.EndDate,
                        Instructions = pp.Instructions,
                        DoctorName = d.StrFullName

                    }).ToListAsync();
            return prescription;

        }

        ///patiwnt e prescription.
        public List<PatientRegistrationModel> GetPatientId()
        {
            var patientid = (
                    from pr in _healthcareContext.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName
                    }
                ).ToList();

            return patientid;
        }

        public List<DrugInventoryModel> GetDrugid()
        {
            var drugid = (
                    from pr in _healthcareContext.SHstkDrugInventory
                    select new DrugInventoryModel
                    {
                        DrugId = pr.DrugId,

                    }
                ).ToList();

            return drugid;
        }

        public List<ResourceTypeMasterModel> Getdocid()
        {
            var docid = (
                    from pr in _healthcareContext.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
                    ).ToList();

            return docid;
        }


    }
}
