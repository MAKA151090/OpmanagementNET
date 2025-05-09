﻿
using DocumentFormat.OpenXml.Drawing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
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

        ///Dropdown for Staffadmin

        public List<ClinicAdminModel> GetFacility()
        {
            var Getfac = (from f in _healthcareContext.SHclnClinicAdmin
                          where  f.StrIsDelete == false 
                          select new ClinicAdminModel
                          {
                              FacilityID = f.FacilityID,
                              Hospital = f.Hospital,
                              ClinicName = f.ClinicName
                          }
                ).ToList();

            return Getfac;
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

        public List<StaffAdminModel> GetStaffID(string facility)
        {
            var staffid = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor" && pr.IsDelete == false && p.StrIsDelete == false && pr.FacilityID == facility && p.FacilityID == facility
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName
                    }
                ).ToList();

            return staffid;
        }

        public List<StaffAdminModel> GetallStaffID(string facility)
        {
            var staffid = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    where  pr.IsDelete == false && pr.FacilityID == facility
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
        public List<ResourceTypeMasterModel> GetResourceid(string facilityID)
        {
            var resoruseid = (
                    from pr in _healthcareContext.SHclnResourseTypeMaster
                    where pr.StrIsDelete == false && pr.FacilityID == facilityID
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
               ).ToList();

            return resoruseid;
        }
        public List<RollTypeMaster> RollAccessType(string facility)
        {
            var rollid = (
                    from pr in _healthcareContext.Shclnrolltypemaster
                    where pr.FacilityID == facility
                    select new RollTypeMaster
                    {
                        RollID = pr.RollID,
                        RollName = pr.RollName
                    }
                ).ToList();

            return rollid;
        }

        public List<ScreenNameMasterModel> Screenname()
        {
            var screenname = (
                    from pr in _healthcareContext.shdbscreenname
                    select new ScreenNameMasterModel
                    {
                        Id=pr.Id,
                        ScreenName= pr.ScreenName,
                    }
                ).ToList();

            return screenname;
        }

        public List<HospitalRegistrationModel> Hospitalname()
        {
            var hospitalname = (
                    from pr in _healthcareContext.SHHospitalRegistration
                    select new HospitalRegistrationModel
                    {
                        HospitalID = pr.HospitalID,
                       HospitalName= pr.HospitalName,
                    }
                ).ToList();

            return hospitalname;
        }

        public List<StaffFacilityMappingModel> GetStaffFacilities(string staffId)
        {
            // Get facility assigned to the staff
            var staffFacility = _healthcareContext.SHclnStaffAdminModel
                .Where(s => s.StrStaffID == staffId)
                .Select(s => s.FacilityID)
                .FirstOrDefault();

            if (staffFacility == null)
            {
                return new List<StaffFacilityMappingModel>(); // Return empty list if no facility is found
            }

            // Get the hospital linked to the facility
            var hospitalName = _healthcareContext.SHclnClinicAdmin
                .Where(f => f.FacilityID == staffFacility)
                .Select(f => f.Hospital)
                .FirstOrDefault();

            if (hospitalName == null)
            {
                return new List<StaffFacilityMappingModel>(); // Return empty list if no hospital is found
            }

            // Fetch all facilities under the hospital & check if they exist in SHclnStaffFacilityMapping
            var availableFacilities = _healthcareContext.SHclnClinicAdmin
                .Where(f => f.Hospital == hospitalName)
                .Select(f => new StaffFacilityMappingModel
                {
                    FacilityID = f.FacilityID,
                    Hospital = f.ClinicName,
                    Active = _healthcareContext.SHclnStaffFacilityMapping
                        .Any(m => m.StaffId == staffId && m.FacilityID == f.FacilityID && m.Active == true) 
                })
                .ToList();

            return availableFacilities;
        }


        public List<ScreenNameMasterModel>AllScreenname(string facility)
        {

            var allscreen = (from pr in _healthcareContext.shdbscreenname
                             where pr.IsMaster == true && pr.TableName != null && pr.FacilityID == facility
                             select new ScreenNameMasterModel

                             {
                                 Id = pr.Id,
                                 ScreenName = pr.ScreenName,
                                 TableName = pr.TableName,
                                 IsMaster = pr.IsMaster
                             }


                ).ToList();

            return allscreen;
        }

       


    }
}
