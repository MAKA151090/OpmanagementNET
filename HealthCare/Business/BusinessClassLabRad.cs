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


        ///dropdown for print radiology result 

        public List<PatientRegistrationModel> Getpid(string facility)

        {
            var patid = (
                        from pr in _healthcareContext.SHPatientRegistration
                        where pr.FacilityID == facility
                        select new PatientRegistrationModel
                        {
                            PatientID = pr.PatientID,
                            FullName = pr.FullName


                        }).ToList();
            return patid;
        }


        public List<ClinicAdminModel> Getfacid(string facility)

        {
            var facid = (
                        from pr in _healthcareContext.SHclnClinicAdmin
                        where pr.FacilityID == facility
                        select new ClinicAdminModel
                        {
                            FacilityID = pr.FacilityID,
                            ClinicName = pr.ClinicName

                        }).ToList();
            return facid;

        }

        public List<PatientRadiolodyModel> Getvisitcaseid(string facility)

        {
            var visitcaseid = (
                        from pr in _healthcareContext.SHPatientRadiology
                        where pr.FacilityID == facility
                        select new PatientRadiolodyModel
                        {
                            VisitcaseID = pr.VisitcaseID

                        }).ToList();
            return visitcaseid;

        }


        ///test creation

        public List<TestMasterModel> GetTestid(string facility)
        {
            var testid = (
                from pr in _healthcareContext.SHTestMaster
                where pr.FacilityID == facility
                select new TestMasterModel
                {
                    TestID = pr.TestID,
                    TestName = pr.TestName,
                }
                ).ToList();
            return testid;
        }

        public List<PatientRegistrationModel> Getpatid(string facility)
        {
            var patid = (
                from pr in _healthcareContext.SHPatientRegistration
                where pr.FacilityID == facility
                select new PatientRegistrationModel
                {
                    PatientID = pr.PatientID,
                    FullName = pr.FullName

                }
                ).ToList();
            return patid;
        }

        public List<ClinicAdminModel> GetFacid(string facility)
        {
            var facid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                where pr.FacilityID == facility
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName


                }).ToList();
            return facid;
        }


        public List<StaffAdminModel> getrefdocid(string facility)
        {
            var refdocid = (

               from pr in _healthcareContext.SHclnStaffAdminModel
               join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
               where p.ResourceTypeName == "Doctor" && pr.IsDelete == false && p.StrIsDelete == false && pr.FacilityID == facility && p.FacilityID == facility
               select new StaffAdminModel
                {
                    StrStaffID = pr.StrStaffID,
                    StrFullName = pr.StrFullName,

                }).ToList();
            return refdocid;

        }
        

        //Lab Doctor
        public List<StaffAdminModel> getrefdocidlab(string facility)
        {
            var refdocidlab = (

               from pr in _healthcareContext.SHclnStaffAdminModel
               join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
               where p.ResourceTypeName == "Lab Doctor" && pr.IsDelete == false && p.StrIsDelete == false && pr.FacilityID == facility && p.FacilityID == facility
               select new StaffAdminModel
               {
                   StrStaffID = pr.StrStaffID,
                   StrFullName = pr.StrFullName,

               }).ToList();
            return refdocidlab;

        }


        //Lab Incharge
        public List<StaffAdminModel> getrefdocidlabInc(string facility)
        {
            var refdocidlabInc = (

               from pr in _healthcareContext.SHclnStaffAdminModel
               join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
               where p.ResourceTypeName == "Lab Incharge" && pr.IsDelete == false && p.StrIsDelete == false && pr.FacilityID == facility && p.FacilityID == facility
               select new StaffAdminModel
               {
                   StrStaffID = pr.StrStaffID,
                   StrFullName = pr.StrFullName,

               }).ToList();
            return refdocidlabInc;

        }

        ///Radilogy creation 
        ///

        public List<RadiologyMasterModel> GetRadioid(string facility)
        {
            var radioid = (
                from pr in _healthcareContext.SHRadioMaster
                where pr.FacilityID == facility
                select new RadiologyMasterModel
                {
                    RadioID = pr.RadioID,
                    RadioName = pr.RadioName,


                }).ToList();
            return radioid;

        }


        public List<ClinicAdminModel> Getfacilityid(string facility)
        {
            var facilityid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                where pr.FacilityID == facility
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName


                }).ToList();
            return facilityid;

        }

        public List<StaffAdminModel> Getrefdocid(string facility)
        {
            var refdocid = (
                from pr in _healthcareContext.SHclnStaffAdminModel
                where pr.FacilityID == facility
                select new StaffAdminModel
                {
                    StrStaffID = pr.StrStaffID,
                    StrFullName = pr.StrFullName,

                }).ToList();
            return refdocid;

        }

        public List<PatientRegistrationModel> Getpatiientid(string facility)
        {
            var patientid = (
                from pr in _healthcareContext.SHPatientRegistration
                where pr.FacilityID == facility
                select new PatientRegistrationModel
                {
                    PatientID = pr.PatientID,
                    FullName = pr.FullName


                }).ToList();
            return patientid;

        }


        ///print test result

        public List<PatientTestModel> GetVisitid(string facility)
        {
            var visitid = (
                from pr in _healthcareContext.SHPatientTest
                where pr.FacilityID == facility
                select new PatientTestModel
                {
                    VisitcaseID = pr.VisitcaseID,

                }).ToList();
            return visitid;

        }
        public List<PatientRegistrationModel> GetPatID(string facility)
        {
            var Patientid = (
                from pr in _healthcareContext.SHPatientRegistration
                where pr.FacilityID == facility
                select new PatientRegistrationModel
                {
                    PatientID = pr.PatientID,
                    FullName = pr.FullName


                }).ToList();
            return Patientid;

        }



        public List<ClinicAdminModel> GetFacilityid(string facility)
        {
            var Facilityid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                where pr.FacilityID == facility
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName


                }).ToList();
            return Facilityid;

        }


        public async Task<List<PatientViewResultModel>> GetTestResults(string patientId, string FacilityID, string Visitcaseid)
        {
            var testResults = await (
                from pt in _healthcareContext.SHPatientTest
                join tm in _healthcareContext.SHTestMaster on pt.TestID equals tm.TestID
                join ca in _healthcareContext.SHclnStaffAdminModel on pt.ReferDocID equals ca.StrStaffID
                join p in _healthcareContext.SHPatientRegistration on pt.PatientID equals p.PatientID
                join c in _healthcareContext.SHclnClinicAdmin on pt.FacilityID equals c.FacilityID
                where pt.PatientID == patientId && pt.FacilityID == FacilityID && pt.VisitcaseID == Visitcaseid
                select new PatientViewResultModel
                {
                    TestID = pt.TestID,
                    TestName = tm.TestName,
                    Range = tm.Range,
                    TestDate = pt.TestDateTime,
                    Result = pt.TestResult,
                    DoctorName = ca.StrFullName,
                    PatientName = p.FullName,
                    ClinicName = c.ClinicName

                }).ToListAsync();

            return testResults;

        }



        public async Task<List<RadiologyViewResultModel>> GetRadiologData(string visitcaseid, string patientid, string facilityid)
        {
            var RadiologyData = (
                            from pr in _healthcareContext.SHPatientRadiology
                            join rm in _healthcareContext.SHRadioMaster on pr.RadioID equals rm.RadioID
                            join p in _healthcareContext.SHPatientRegistration on pr.PatientID equals p.PatientID
                            where pr.VisitcaseID == visitcaseid && pr.PatientID == patientid && pr.FacilityID == facilityid
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


        ///update radiology result   
        ///

        public List<PatientRegistrationModel> Getupdpatid(string facility)
        {
            var updpatid = (
                from pr in _healthcareContext.SHPatientRegistration
                where pr.FacilityID == facility
                select new PatientRegistrationModel
                {
                    PatientID = pr.PatientID,
                    FullName = pr.FullName


                }).ToList();
            return updpatid;

        }


        public List<StaffAdminModel> Gettestfacility(string facilityId)
        {
            var docfac = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    where  pr.FacilityID == facilityId
                    select new StaffAdminModel
                    {
                        FacilityID = pr.FacilityID
                    }
                    ).ToList();

            return docfac;
        }

        public List<ClinicAdminModel> Getupdfacid(string facility)
        {
            var updfacid = (
                from pr in _healthcareContext.SHclnClinicAdmin
                where pr.FacilityID == facility
                select new ClinicAdminModel
                {
                    FacilityID = pr.FacilityID,
                    ClinicName = pr.ClinicName


                }).ToList();
            return updfacid;

        }

        public List<RadiologyMasterModel> Getupdradid(string facility)
        {
            var updradid = (
                from pr in _healthcareContext.SHRadioMaster
                where pr.FacilityID == facility
                select new RadiologyMasterModel
                {
                    RadioID = pr.RadioID,
                    RadioName = pr.RadioName,


                }).ToList();
            return updradid;

        }



        public List<PatientTestTableModel> Gettest(string patientID, string casevisitID, string testID, string facility,string tsample)
        {
            var result = (from p in _healthcareContext.SHPatientTest
                          join pat in _healthcareContext.SHPatientRegistration on p.PatientID equals pat.PatientID
                          join d in _healthcareContext.SHTestMaster on p.TestID equals d.TestID
                          where p.PatientID == patientID && p.VisitcaseID == casevisitID && p.Isdelete == false && p.FacilityID == facility && d.FacilityID == facility && pat.FacilityID == facility && p.TsampleCltDateTime == tsample
                          select new PatientTestTableModel
                          {
                              DbpatientID = p.PatientID,
                              PatientID = pat.FullName,
                              VisitcaseID = p.VisitcaseID,
                              TestID = p.TestID,
                              TestName = d.TestName,
                              TsampleCltDateTime = p.TsampleCltDateTime
                             


                          }).ToList();
            return result;
        }


        public List<TestresultTablemodel> Gettestresult(string patientID, string casevisitID, string facility, string tsample)
        {
            var result = (from p in _healthcareContext.SHPatientTest
                          join tm in _healthcareContext.SHTestMaster on p.TestID equals tm.TestID
                        
                          where p.PatientID == patientID && p.VisitcaseID == casevisitID && p.Isdelete == false && p.FacilityID == facility && tm.FacilityID == facility && tm.FacilityID == facility && p.TsampleCltDateTime == tsample
                          select new TestresultTablemodel
                          {
                           
                              TestName = tm.TestName,
                              
                              Range = tm.Range,
                              Unit = tm.Unit,
                          
                          }).ToList();
            return result;
        }

    }
}
