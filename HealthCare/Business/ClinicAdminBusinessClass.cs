using DocumentFormat.OpenXml.Drawing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task<StaffAdminModel> GetDoctorRegister(string doctorid)
        {
            var staffregisterdata = await _healthcareContext.SHclnStaffAdminModel.FirstOrDefaultAsync(x => x.StrStaffID == doctorid);

            return staffregisterdata;
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

        public async Task<PharmacyBillingTotalpriceModel> GetPharmacy(string patientID, string VisitcaseID,string OrderID, string Medication, string Unit, String Price)
        {
            PharmacyBillingTotalpriceModel billingTotalpriceModel = new PharmacyBillingTotalpriceModel();

            billingTotalpriceModel.StrPharmacyBillingModelList = (

                from pr in _healthcareContext.SHstkDrugInventory
                join rm in _healthcareContext.SHprsPrescription on pr.DrugId equals rm.DrugID

                where (rm.PatientID == patientID && rm.CaseVisitID == VisitcaseID) 

               /* where (r.PatientID == patientID || r.FullName == patientName) ||
                                                     (re.VisitID == visitID || re.VisitDate == visitDate || re.VisitID == null) ||
                                                     (re.ClinicID == clinicID || rec.ClinicName == clinicName || re.ClinicID == null)*/
                select new PharmacyBillingModel
                {
                    Medication = pr.ModelName,
                    Unit = rm.Unit,
                    Unitprice = pr.Price,

                }).ToListAsync().Result;


            billingTotalpriceModel.TotalPrice = billingTotalpriceModel.StrPharmacyBillingModelList.Sum(t => Convert.ToInt32(t.Totalprice)).ToString(); 

            return billingTotalpriceModel;
        }
    }
}
