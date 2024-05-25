using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassLabRad : Controller
    {
        private readonly HealthcareContext _healthcareContext;

        public BusinessClassLabRad(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
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

        ///dropdown for print radiology result 

        public List<PatientRegistrationModel> Getpid()

        {
            var patid = (
                        from pr in _healthcareContext.SHPatientRegistration
                        select new PatientRegistrationModel
                        {
                            PatientID = pr.PatientID,
                            FullName = pr.FullName


                        }).ToList();
            return patid;
        }


        public List<ClinicAdminModel> Getfacid()

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

        public List<PatientRadiolodyModel> Getvisitcaseid()

        {
            var visitcaseid = (
                        from pr in _healthcareContext.SHPatientRadiology
                        select new PatientRadiolodyModel
                        {
                           VisitcaseID = pr.VisitcaseID 

                        }).ToList();
            return visitcaseid;

        }


        ///test creation
        
        public List<TestMasterModel> GetTestid()
        {
            var testid = (
                from pr in _healthcareContext.SHTestMaster
                select new TestMasterModel
                {
                    TestID = pr.TestID,
                    TestName = pr.TestName,
                }
                ).ToList();
            return testid;
        }

        public List<PatientRegistrationModel> Getpatid()
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

        public List<ClinicAdminModel> GetFacid()
        {
            var facid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName


                } ).ToList();
            return facid;
        }

        ///Radilogy creation 
        ///

        public List<RadiologyMasterModel> GetRadioid()
        {
            var radioid = (
                from pr in _healthcareContext.SHRadioMaster
                select new RadiologyMasterModel
                {
                    RadioID = pr.RadioID,
                    RadioName = pr.RadioName,


                }).ToList();
            return radioid;

        }


        public List<ClinicAdminModel> Getfacilityid()
        {
            var facilityid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                select new ClinicAdminModel
                {
                    FacilityID= pr.FacilityID,
                    ClinicName = pr.ClinicName


                }).ToList();
            return facilityid;

        }

        public List<ResourceTypeMasterModel> Getrefdocid()
        {
            var refdocid = (
                from pr in _healthcareContext.SHclnResourseTypeMaster
                select new ResourceTypeMasterModel
                {
                    ResourceTypeID = pr.ResourceTypeID,
                    ResourceTypeName = pr.ResourceTypeName,

                }).ToList();
            return refdocid;

        }

        public List<PatientRegistrationModel> Getpatiientid()
        {
            var patientid = (
                from pr in _healthcareContext.SHPatientRegistration
                select new PatientRegistrationModel
                {
                    PatientID = pr.PatientID,
                    FullName = pr.FullName


                }).ToList();
            return patientid;

        }


        ///print test result

        public List<PatientTestModel> GetVisitid()
        {
            var visitid = (
                from pr in _healthcareContext.SHPatientTest
                select new PatientTestModel
                {
                   VisitcaseID1 = pr.VisitcaseID1,

                }).ToList();
            return visitid;

        }
        public List<PatientRegistrationModel> GetPatID()
        {
            var Patientid = (
                from pr in _healthcareContext.SHPatientRegistration
                select new PatientRegistrationModel
                {
                    PatientID = pr.PatientID,
                    FullName = pr.FullName


                }).ToList();
            return Patientid;

        }



        public List<ClinicAdminModel> GetFacilityid()
        {
            var Facilityid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName


                }).ToList();
            return Facilityid;

        }

    }
}
