using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassPharmacybilling : Controller
    {
        private readonly HealthcareContext _healthcareContext;

        public BusinessClassPharmacybilling(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }


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

        public List<PatientEPrescriptionModel> Getorderid()
        {
            var orderid = (
                    from pr in _healthcareContext.SHprsPrescription
                    select new PatientEPrescriptionModel
                    {
                       OrderID = pr.OrderID

                    }
                ).ToList();

            return orderid;
        }

        public List<PatientEPrescriptionModel> Getvisitcaseid()
        {
            var visitcaseid = (
                    from pr in _healthcareContext.SHprsPrescription
                    select new PatientEPrescriptionModel
                    {
                       CaseVisitID = pr.CaseVisitID

                    }
                ).ToList();

            return visitcaseid;
        }


        public async Task<PharmacyBillingTotalpriceModel> GetPharmacy(string patientID, string VisitcaseID, string OrderID, string Medication, string Unit, String Price)
        {
            PharmacyBillingTotalpriceModel billingTotalpriceModel = new PharmacyBillingTotalpriceModel();

            billingTotalpriceModel.StrPharmacyBillingModelList = (

                from pr in _healthcareContext.SHstkDrugInventory
                join rm in _healthcareContext.SHprsPrescription on pr.DrugId equals rm.DrugID
                where (rm.PatientID == patientID && rm.CaseVisitID == VisitcaseID)

                /* where (r.PatientID == patientID || r.FullName == patientName) ||
                                                      (re.VisitID == visitID || re.VisitDate == visitDate || re.VisitID == null) ||
                                                      (re.FacilityID == FacilityID || rec.ClinicName == clinicName || re.FacilityID == null)*/
                select new PharmacyBillingModel
                {
                    Medication = pr.ModelName,
                    Unit = rm.Unit,
                    Unitprice = pr.Price,

                }).ToListAsync().Result;


            billingTotalpriceModel.TotalPrice = billingTotalpriceModel.StrPharmacyBillingModelList.Sum(t => Convert.ToInt32(t.Totalprice)).ToString();

            return billingTotalpriceModel;
        }


        ///patient payments
        ///
        public List<PatientRegistrationModel> GetPatid()
        {
            var patid = (
                    from pr in _healthcareContext.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName
                    }
                ).ToList();

            return patid;
        }

    }
}
