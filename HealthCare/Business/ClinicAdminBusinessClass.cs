
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

        public async Task<ClinicAdminModel> GetClinicRegister(string FacilityID, string clinicname)
        {
            var clinicregisterdata = await _healthcareContext.SHclnClinicAdmin.FirstOrDefaultAsync(x => x.FacilityID == FacilityID && x.ClinicName == clinicname);

            return clinicregisterdata;
        }

        public async Task<StaffAdminModel> GetDoctorRegister(string doctorid)
        {
            var staffregisterdata = await _healthcareContext.SHclnStaffAdminModel.FirstOrDefaultAsync(x => x.StrStaffID == doctorid);

            return staffregisterdata;
        }

        public async Task<List<RadiologyViewResultModel>> GetRadiologData(string radioID, string FacilityID, string patientID, string radioName, string screeingDate, string result, string referralDoctorName)
        {
            var RadiologyData = (
                            from pr in _healthcareContext.SHPatientRadiology
                            join rm in _healthcareContext.SHRadioMaster on pr.RadioID equals rm.RadioID
                            join p in _healthcareContext.SHPatientRegistration on pr.PatientID equals p.PatientID

                            select new RadiologyViewResultModel
                            {

                                PatentName = p.FullName,
                                RadioID = rm.RadioID,
                                FacilityID = pr.FacilityID,
                                RadioName = rm.RadioName,
                                ScreeningDate = pr.ScreeningDate,
                                Result = pr.Result,
                                ReferralDoctorName = pr.ReferralDoctorName

                            }).ToListAsync().Result;

            return RadiologyData;
        }

        
        ///dropdown for rollaccess 
        public  List<ScreenMasterModel> GetScreenid()

        {
            var screenid = (
                        from pr in _healthcareContext.SHClnScreenMaster                        
                        select new ScreenMasterModel
                        {
                            ScreenId = pr.ScreenId
                            , ScreenName = pr.ScreenName

                        }).ToList();
            return screenid;
        }

        ///dropdown for  OT table master
        public List<ClinicAdminModel> GetFacilityid()
        {
            var facilityid = (
                    from pr in _healthcareContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID , 
                        ClinicName = pr.ClinicName


                    }).ToList();

            return facilityid;         
        }

        ///Dropdown for Hospital bed master
        public List<NurseStationMasterModel> GetNurseid()
        {
            var nurseid = (
                from pr in _healthcareContext.SHclnNurseStationMaster
                select new NurseStationMasterModel
                {
                    NurseStationID = pr.NurseStationID
                }).ToList();
                
            return nurseid;
        }

        ///dropdown for nurse station
        public List<ClinicAdminModel> GetFacid()
        {
            var facid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID ,
                    ClinicName = pr.ClinicName
                }).ToList();

            return facid;       
        }

        ///dropdown for hospitalfacilitymapping
        public List<HospitalRegistrationModel> GetHospitalid()
        {
            var hospitalid = (
                from pr in _healthcareContext.SHHospitalRegistration
                select new HospitalRegistrationModel
                {
                    HospitalID = pr.HospitalID,
                    HospitalName = pr.HospitalName
                }).ToList();

            return hospitalid;
                
        }

        public List<ClinicAdminModel> GetFacId()
        {
            var facid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName

                }).ToList();

            return facid;    
        }


        ///dropdown for staffmapping

        public List<StaffAdminModel> GetStaffID()
        {
            var staffid = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID
                    }
                ).ToList();

            return staffid;
        }

        public List<ClinicAdminModel> GetFacidStaff()
        {
            var stafffacid = (
                    from pr in _healthcareContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID,
                        ClinicName = pr.ClinicName
                    }
                ).ToList();

            return stafffacid;
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
    }
}
