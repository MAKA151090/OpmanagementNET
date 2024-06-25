
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



        ///dropdown for rollaccess 
        public List<ScreenMasterModel> GetScreenid()

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
                    join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor"
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName
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


        ///dropdown for clinicregister
        public List<ResourceTypeMasterModel> GetResourceid()
        {
            var resoruseid = (
                    from pr in _healthcareContext.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
               ).ToList();

            return resoruseid;
        }
        public List<RollTypeMaster> RollAccessType()
        {
            var rollid = (
                    from pr in _healthcareContext.Shclnrolltypemaster
                    select new RollTypeMaster
                    {
                        RollID = pr.RollID,
                        RollName = pr.RollName
                    }
                ).ToList();

            return rollid;
        }


    }
}
