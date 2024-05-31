using Azure;
using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Timers;

namespace HealthCare.Controllers
{
    [Authorize]
    public class ClinicAdministrationController : Controller
    {


        private HealthcareContext _healthcareContext;

        public ClinicAdministrationController(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }



        [HttpPost]
        public async Task<IActionResult> AddClinic(ClinicAdminModel model)
        {
            var existingClinic = await _healthcareContext.SHclnClinicAdmin.FindAsync(model.FacilityID);

            if (existingClinic != null)
            {
                existingClinic.FacilityID = model.FacilityID;
                existingClinic.ClinicName = model.ClinicName;
                existingClinic.ClinicAddress = model.ClinicAddress;
                existingClinic.City = model.City;
                existingClinic.State = model.State;
                existingClinic.PostalCode = model.PostalCode;
                existingClinic.ClinicPhoneNumber = model.ClinicPhoneNumber;
                existingClinic.ClinicEmailAddress = model.ClinicEmailAddress;
                existingClinic.FromHour = model.FromHour;
                existingClinic.ToHour = model.ToHour;
                existingClinic.lastUpdatedDate = DateTime.Now.ToString();
                existingClinic.lastUpdatedUser = User.Claims.First().Value.ToString();

                _healthcareContext.Entry(existingClinic).State = EntityState.Modified;
            }
            else
            {

                //BusinessClass businessClass = new BusinessClass(_healthcareContext);
                //try
                //{

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.SHclnClinicAdmin.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("ClinicRegistration", model);
        }

        [HttpPost]
        public async Task<IActionResult> GetClinic()
        {

            return View();
        }

        public async Task<ActionResult> ClinicAdmin(string FacilityID, string clinicname, string buttonType)
        {

            {
                ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(_healthcareContext);
                if (buttonType == "submit")
                {
                    var Clinic = await business.GetClinicRegister(FacilityID, clinicname);

                    if (Clinic != null)
                    {
                        FacilityID = Clinic.FacilityID;
                        clinicname = Clinic.ClinicName;

                        return View("ClinicRegistration", Clinic);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "No data found for the entered IDs.";
                        return View("GetClinic");
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> BloodGroupList(BloodGroupModel model)

        {
            var existingBloodGroup = await _healthcareContext.SHclnBloodGroup.FindAsync(model.IntBg_Id, model.BloodGroup);

            if (existingBloodGroup != null)
            {
                existingBloodGroup.IntBg_Id = model.IntBg_Id;
                existingBloodGroup.BloodGroup = model.BloodGroup;
                existingBloodGroup.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingBloodGroup.lastUpdatedDate = DateTime.Now.ToString();
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                // Retrieve the list of blood groups from the database

                _healthcareContext.SHclnBloodGroup.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";
            return View("BloodGroupAdministration", model);
            // Pass the list to the view
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffAdminModel model)
        {


            var existingStaffAdmin = await _healthcareContext.SHclnStaffAdminModel.FindAsync(model.StrStaffID);

            if (existingStaffAdmin != null)
            {
                existingStaffAdmin.StrStaffID = model.StrStaffID;
                existingStaffAdmin.ResourceTypeID = model.ResourceTypeID;
                existingStaffAdmin.StrFirstName = model.StrFirstName;
                existingStaffAdmin.StrLastName = model.StrLastName;
                existingStaffAdmin.StrInitial = model.StrInitial;
                existingStaffAdmin.StrPrefix = model.StrPrefix;
                existingStaffAdmin.StrAge = model.StrAge;
                existingStaffAdmin.StrDateofBirth = model.StrDateofBirth;
                existingStaffAdmin.StrEmailId = model.StrEmailId;
                existingStaffAdmin.StrAddress1 = model.StrAddress1;
                existingStaffAdmin.StrAddress2 = model.StrAddress2;
                existingStaffAdmin.StrCity = model.StrCity;
                existingStaffAdmin.StrState = model.StrState;
                existingStaffAdmin.StrPin = model.StrPin;
                existingStaffAdmin.StrPhoneNumber = model.StrPhoneNumber;
                existingStaffAdmin.StrEmailId = model.StrEmailId;
                existingStaffAdmin.StrNationality = model.StrNationality;
                existingStaffAdmin.StrUserName = model.StrUserName;
                existingStaffAdmin.StrPassword = model.StrPassword;
                existingStaffAdmin.StrIdProofId = model.StrIdProofId;
                existingStaffAdmin.StrIdProofName = model.StrIdProofName;
                existingStaffAdmin.StrMedialLicenseNumber = model.StrMedialLicenseNumber;
                existingStaffAdmin.LastupdatedDate = DateTime.Now.ToString();
                existingStaffAdmin.LastupdatedUser = User.Claims.First().Value.ToString();
                existingStaffAdmin.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {

                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnStaffAdminModel.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["resoruseid"] = clinicAdmin.GetResourceid();

            return View("StaffAdminModel", model);


        }

        //[HttpPost]

        //public async Task<IActionResult> GetDoctor()
        //{
        //    return View();
        //}

        public async Task<ActionResult> Doctoradmin(string doctorid)
        {
            ClinicAdminBusinessClass businessClass = new ClinicAdminBusinessClass(_healthcareContext);

            var doctor = await businessClass.GetDoctorRegister(doctorid);
            if (doctor != null)
            {
                doctorid = doctor.StrStaffID;

                return View("StaffAdminModel", doctor);
            }
            else
            {
                ViewBag.ErrorMessage = "No data found for the entered IDs.";
                return View("GetDoctor");
            }

        }

        public async Task<IActionResult> GetRoomType(RoomTypeMasterModel model)
        {
            var existingRoomType = await _healthcareContext.SHclnRoomTypeMaster.FindAsync(model.RoomTypeID);
            if (existingRoomType != null)
            {
                existingRoomType.RoomTypeID = model.RoomTypeID;
                existingRoomType.RoomTypeName = model.RoomTypeName;
                existingRoomType.AdditionFeature = model.AdditionFeature;
                existingRoomType.AdditionalCost = model.AdditionalCost;
                existingRoomType.lastupdatedDate = DateTime.Now.ToString();
                existingRoomType.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingRoomType.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnRoomTypeMaster.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("RoomTypeMaster", model);
        }
        public async Task<IActionResult> GetNurseStation(NurseStationMasterModel model)
        {
            var existingNurseStation = await _healthcareContext.SHclnNurseStationMaster.FindAsync(model.NurseStationID);
            if (existingNurseStation != null)
            {
                existingNurseStation.FacilityID = model.FacilityID;
                existingNurseStation.NurseStationID = model.NurseStationID;
                existingNurseStation.StationName = model.StationName;
                existingNurseStation.lastupdatedDate = DateTime.Now.ToString();
                existingNurseStation.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingNurseStation.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnNurseStationMaster.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["facid"] = clinicAdmin.GetFacid();

            return View("NurseStationMaster", model);
        }
        public async Task<IActionResult> GetIpType(IPTypeMasterModel model)
        {
            var existingIpType = await _healthcareContext.SHclnIPTypeMaster.FindAsync(model.IPTypeID);
            if (existingIpType != null)
            {
                existingIpType.IPTypeID = model.IPTypeID;
                existingIpType.IPTypeName = model.IPTypeName;
                existingIpType.lastupdatedDate = DateTime.Now.ToString();
                existingIpType.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingIpType.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnIPTypeMaster.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("IPTypeMaster", model);

        }


        public async Task<IActionResult> GetHospitalBedMaster(HospitalBedMasterModel model)
        {
            var existingHospitalBed = await _healthcareContext.SHclnHospitalBedMaster.FindAsync(model.BedID);
            if (existingHospitalBed != null)
            {
                existingHospitalBed.BedID = model.BedID;
                existingHospitalBed.BedName = model.BedName;
                existingHospitalBed.BedType = model.BedType;
                existingHospitalBed.RoomType = model.RoomType;
                existingHospitalBed.RoomFloor = model.RoomFloor;
                existingHospitalBed.NurseStationID = model.NurseStationID;
                existingHospitalBed.CostPerDay = model.CostPerDay;
                existingHospitalBed.lastupdatedDate = DateTime.Now.ToString();
                existingHospitalBed.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingHospitalBed.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnHospitalBedMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["nurseid"] = clinicAdmin.GetNurseid();

            return View("HospitalBedMaster", model);
        }

        public async Task<IActionResult> GetEWSMaster(EWSMasterModel pEWS)
        {
            var existingEWS = await _healthcareContext.SHclnEWSMaster.FindAsync(pEWS.ObservationTypeID);
            if (existingEWS != null)
            {
                existingEWS.ObservationTypeID = pEWS.ObservationTypeID;
                existingEWS.ObservationName = pEWS.ObservationName;
                existingEWS.Unit = pEWS.Unit;
                existingEWS.Range = pEWS.Range;
                existingEWS.Frequency = pEWS.Frequency;
                existingEWS.lastupdatedDate = DateTime.Now.ToString();
                existingEWS.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingEWS.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                pEWS.lastupdatedDate = DateTime.Now.ToString();
                pEWS.lastUpdatedUser = User.Claims.First().Value.ToString();
                pEWS.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnEWSMaster.Add(pEWS);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("EWSMaster", pEWS);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClinicRegistration()
        {
            return View();

        }

        public IActionResult BloodGroupAdministration()
        {

            return View();
        }
        public IActionResult RollAccess()
        {

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["screenid"] = clinicAdmin.GetScreenid();
            return View();
        }
        public IActionResult ScreenMaster()
        {
            return View();
        }
        public IActionResult DoctorRegistration()
        {
            return View();
        }

        public IActionResult TestMaster()
        {
            return View();
        }
        public IActionResult OTTableMaster()
        {
            ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["facilityid"] = business.GetFacilityid();

            return View();
        }
        public IActionResult ClinicSurgeryMaster()
        {
            return View();
        }
        public IActionResult InternalDepartmentMaster()
        {
            return View();
        }
        public IActionResult SurgeryTypeMaster()
        {
            return View();
        }
        public IActionResult HospitalBedMaster()
        {
            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["nurseid"] = clinicAdmin.GetNurseid();
            return View();
        }
        public IActionResult NurseStationMaster()
        {
            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["facid"] = clinicAdmin.GetFacid();
            return View();
        }
        public IActionResult IPTypeMaster()
        {
            return View();
        }
        public IActionResult RoomTypeMaster()
        {
            return View();
        }
        public IActionResult EWSMaster()
        {
            return View();
        }

        public IActionResult StaffAdminModel()
        {
            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["resoruseid"] = clinicAdmin.GetResourceid();
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> TestMaster(TestMasterModel model)
        {
            var existingTest = await _healthcareContext.SHTestMaster.FindAsync(model.TestID);

            if (existingTest != null)
            {
                existingTest.TestID = model.TestID;
                existingTest.TestName = model.TestName;
                existingTest.Cost = model.Cost;
                existingTest.Range = model.Range;
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedDate = DateTime.Now.ToString(); ;
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {


                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.SHTestMaster.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("TestMaster", model);
        }
        public IActionResult PatientFHPHMaster()
        {
            return View();
        }

        public async Task<IActionResult> FHPHMaster(PatientFHPHMasterModel model)
        {
            var existingFHPH = await _healthcareContext.PatExmFHPH.FindAsync(model.QuestionID);
            if (existingFHPH != null)
            {
                existingFHPH.QuestionID = model.QuestionID;
                existingFHPH.Question = model.Question;
                existingFHPH.Type = model.Type;
                existingFHPH.LastUpdatedDate = DateTime.Now.ToString();
                existingFHPH.LastUpdatedUser = User.Claims.First().Value.ToString();
            }
            else
            {

                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = User.Claims.First().Value.ToString();
                _healthcareContext.PatExmFHPH.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("PatientFHPHMaster", model);



        }

        public async Task<IActionResult> SummaryMaster(OTSummaryMasterModel model)
        {
            var summary = await _healthcareContext.SHclnOtSummaryMaster.FindAsync(model.QuestionID);
            if (summary != null)
            {
                summary.QuestionID = model.QuestionID;
                summary.Question = model.Question;
                summary.lastUpdatedDate = DateTime.Now.ToString();
                summary.lastUpdatedUser = "Myself";
                summary.lastUpdatedMachine = "Lap";
            }
            else
            {

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "Lap";
                _healthcareContext.SHclnOtSummaryMaster.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("OTSummaryMaster", model);



        }

        public IActionResult SeverityModel()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SeverityModel(SeverityModel model)
        {
            var existingTest = await _healthcareContext.SHSeverityModel.FindAsync(model.SeverityID);

            if (existingTest != null)
            {
                existingTest.SeverityID = model.SeverityID;
                existingTest.SeverityName = model.SeverityName;
                existingTest.Active = model.Active;

                existingTest.LastupdatedUser = User.Claims.First().Value.ToString();
                existingTest.LastupdatedDate = DateTime.Now.ToString(); ;
                existingTest.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {


                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHSeverityModel.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("SeverityModel", model);
        }


        public async Task<IActionResult> GetClinicSurgeryMaster(ClinicSurgeryMasterModel model)
        {
            var existingTest = await _healthcareContext.SHclnSurgeryMaster.FindAsync(model.SurgeryID);
            if (existingTest != null)
            {
                existingTest.SurgeryID = model.SurgeryID;
                existingTest.SurgeryName = model.SurgeryName;
                existingTest.Duration = model.Duration;
                existingTest.Cost = model.Cost;
                existingTest.lastupdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            else
            {

                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnSurgeryMaster.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("ClinicSurgeryMaster", model);
        }


        public async Task<IActionResult> GetOTTableMaster(OtTableMasterModel model)
        {
            ClinicAdminBusinessClass businessClass = new ClinicAdminBusinessClass(_healthcareContext);
            var existingTest = await _healthcareContext.SHotTableMaster.FindAsync(model.TableID);
            if (existingTest != null)
            {
                existingTest.TableID = model.TableID;
                existingTest.TableName = model.TableName;
                existingTest.RoomName = model.RoomName;
                existingTest.AdditionalFeature = model.AdditionalFeature;
                existingTest.FacilityID = model.FacilityID;
                existingTest.lastupdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHotTableMaster.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass business = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["facilityid"] = business.GetFacilityid();


            return View("OTTableMaster", model);
        }




        public async Task<IActionResult> GetSurgeryTypeMaster(SurgeryTypeMasterModel model)
        {
            var existingTest = await _healthcareContext.SHotSurgerTypeymaster.FindAsync(model.SurgeryTypeID);
            if (existingTest != null)
            {
                existingTest.SurgeryTypeID = model.SurgeryTypeID;
                existingTest.SurgeryTypeName = model.SurgeryTypeName;
                existingTest.lastupdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHotSurgerTypeymaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("SurgeryTypeMaster", model);
        }



        public async Task<IActionResult> GetInternalDepartmentMaster(InternalDepartmentMasterModel model)
        {
            var existingTest = await _healthcareContext.SHotInternalDepartmentMaster.FindAsync(model.DepartmentID);
            if (existingTest != null)
            {
                existingTest.DepartmentID = model.DepartmentID;
                existingTest.DepartmentName = model.DepartmentName;
                existingTest.lastupdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHotInternalDepartmentMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("InternalDepartmentMaster", model);
        }



        public async Task<IActionResult> GetRollAccess(RollAccessModel model)
        {
            ClinicAdminBusinessClass businessClass = new ClinicAdminBusinessClass(_healthcareContext);

            //  var bus = await businessClass.GetScreenid(model.ScreenID);

            var existingTest = await _healthcareContext.SHClnRollAccess.FindAsync(model.RollID);
            if (existingTest != null)
            {
                existingTest.RollID = model.RollID;
                existingTest.ScreenID = model.ScreenID;
                existingTest.Access = model.Access;
                existingTest.Authorized = model.Authorized;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHClnRollAccess.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["screenid"] = clinicAdmin.GetScreenid();


            return View("RollAccess", model);

        }



        public async Task<IActionResult> GetScreenMaster(ScreenMasterModel model)
        {

            var existingTest = await _healthcareContext.SHClnScreenMaster.FindAsync(model.ScreenId);
            if (existingTest != null)
            {
                existingTest.ScreenId = model.ScreenId;
                existingTest.ScreenName = model.ScreenName;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHClnScreenMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";
            return View("ScreenMaster", model);
        }

        public async Task<IActionResult> GetHospitalRegistration(HospitalRegistrationModel model)
        {
            var existingTest = await _healthcareContext.SHHospitalRegistration.FindAsync(model.HospitalID);
            if (existingTest != null)
            {
                existingTest.HospitalID = model.HospitalID;
                existingTest.HospitalName = model.HospitalName;
                existingTest.Address = model.Address;
                existingTest.City = model.City;
                existingTest.State = model.State;
                existingTest.Phone1 = model.Phone1;
                existingTest.Phone2 = model.Phone2;
                existingTest.Phone3 = model.Phone3;
                existingTest.Email = model.Email;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHHospitalRegistration.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("HospitalRegistration", model);
        }

        public async Task<IActionResult> GetHospitalFacilityMapping(HospitalFacilityMappingModel model)
        {
            var existingTest = await _healthcareContext.SHHospitalFacilityMapping.FindAsync(model.HospitalID, model.FacilityID);
            if (existingTest != null)
            {
                existingTest.HospitalID = model.HospitalID;
                existingTest.FacilityID = model.FacilityID;
                existingTest.FacilityStatus = model.FacilityStatus;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHHospitalFacilityMapping.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["hospitalid"] = clinicAdmin.GetHospitalid();
            ViewData["facid"] = clinicAdmin.GetFacId();



            return View("HospitalFacilityMapping", model);
        }

        public async Task<IActionResult> SaveResourceTypeID(ResourceTypeMasterModel model)
        {
            var existingTypeID = await _healthcareContext.SHclnResourseTypeMaster.FindAsync(model.ResourceTypeID);
                if(existingTypeID != null)
            {
                existingTypeID.ResourceTypeID = model.ResourceTypeID;
                existingTypeID.ResourceTypeName = model.ResourceTypeName;
                existingTypeID.lastUpdatedDate = DateTime.Now.ToString();
                existingTypeID.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTypeID.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTypeID).State = EntityState.Modified;
            }
                else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnResourseTypeMaster.Add(model);
            }
                await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            return View("ResourceTypeMaster" ,model);
        }

        public async Task<IActionResult> GetDiagnosisMaster(DiagnosisMasterModel model)
        {
            var existingTest = await _healthcareContext.SHclnDiagnosisMaster.FindAsync(model.DiagnosisID);
            if (existingTest != null)
            {
                existingTest.DiagnosisID = model.DiagnosisID;
                existingTest.DiagnosisCode = model.DiagnosisCode;
                existingTest.DiagnosisName = model.DiagnosisName;
                existingTest.ICDCode = model.ICDCode;
                existingTest.OtherCodeName = model.OtherCodeName;
                existingTest.OtherCode = model.OtherCode;
                existingTest.DiagnosisDescription = model.DiagnosisDescription;
                existingTest.WHODescription = model.WHODescription;
                existingTest.DiagnosisStatus = model.DiagnosisStatus;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnDiagnosisMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("DiagnosisMaster", model);

        }
        public async Task<IActionResult> GetProcedureCodeMaster(ProcedureCodeMasterModel model)
        {
            var existingTest = await _healthcareContext.SHclnProcedureCodeMaster.FindAsync(model.ProcedureID);
            if (existingTest != null)
            {
                existingTest.ProcedureID = model.ProcedureID;
                existingTest.ProcedureName = model.ProcedureName;
                existingTest.ProcedureCode = model.ProcedureCode;
                existingTest.CPTCode = model.CPTCode;
                existingTest.OtherCodeName = model.OtherCodeName;
                existingTest.OtherCode = model.OtherCode;
                existingTest.ProcedureCodeDescription = model.ProcedureCodeDescription;
                existingTest.WHODescription = model.WHODescription;
                existingTest.ProcedureCodeStatus = model.ProcedureCodeStatus;
                existingTest.Cost = model.Cost;
                existingTest.TaxPercentage = model.TaxPercentage;
                existingTest.NetCost = model.NetCost;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingTest.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnProcedureCodeMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("ProcedureCodeMaster", model);
        }





        public IActionResult DoctorSchedule()
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();
            return View();
        }
        
       
        

        public IActionResult HospitalRegistration()
        {
            return View();
        }

        public IActionResult HospitalFacilityMapping()
        {
            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["hospitalid"] = clinicAdmin.GetHospitalid();
            ViewData["facid"] = clinicAdmin.GetFacId();
            return View();
        }

        public IActionResult DiagnosisMaster()
        {
            return View();
        }

        public IActionResult ProcedureCodeMaster()
        {
            return View();
        }
        public IActionResult ResourceTypeMaster()
        {
            return View();
        }

        public IActionResult OTSummaryMaster()
        {
            return View();
        }
        public IActionResult StaffFacilityMapping()
        {
            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["staffid"] = clinicAdmin.GetStaffID();
            ViewData["stafffacid"] = clinicAdmin.GetFacidStaff();
            return View();
        }

        public async Task<IActionResult> GetStaffFacilityMap(StaffFacilityMappingModel model)
        {
            var existingStafff = await _healthcareContext.SHclnStaffFacilityMapping.FindAsync(model.StaffId, model.FacilityID);
            if (existingStafff != null)
            {
                existingStafff.StaffId = model.StaffId;
                existingStafff.FacilityID = model.FacilityID;
                existingStafff.FromHour = model.FromHour;
                existingStafff.ToHour = model.ToHour;
                existingStafff.lastupdatedDate = DateTime.Now.ToString();
                existingStafff.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingStafff.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                _healthcareContext.Entry(existingStafff).State = EntityState.Modified;
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnStaffFacilityMapping.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";

            ClinicAdminBusinessClass clinicAdmin = new ClinicAdminBusinessClass(_healthcareContext);
            ViewData["staffid"] = clinicAdmin.GetStaffID();
            ViewData["stafffacid"] = clinicAdmin.GetFacidStaff();

            return View("StaffFacilityMapping", model);


        }



        [HttpPost]
        public ActionResult AddSlot()
        {
            return View(new ResourceScheduleModel());
        }

       
        public async Task<IActionResult> SaveSlots(string action,string selectedSlots, string FromTime, string ToTime)
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();

            var StaffID = Request.Form["StaffID"].ToString();
            var FacilityID = Request.Form["FacilityID"].ToString();
            var FromDate = Request.Form["FromDate"].ToString();
            var ToDate = Request.Form["ToDate"].ToString();
            var duration = Request.Form["Duration"].ToString();
           
            var SlotsIDs = selectedSlots;



            DateTime fromDate;
            DateTime toDate;
            TimeSpan fromTime;
            TimeSpan toTime;

            // Attempt to parse the date strings to DateTime objects
            bool isFromDateValid = DateTime.TryParse(FromDate, out fromDate);
            bool isToDateValid = DateTime.TryParse(ToDate, out toDate);
            bool isFromTimeValid = TimeSpan.TryParse(Request.Form[$"FromTime_{SlotsIDs}"], out fromTime);
            bool isToTimeValid = TimeSpan.TryParse(Request.Form[$"ToTime_{SlotsIDs}"], out toTime);


            if (action == "Get Slots")
            {
                return await GetSlots(StaffID, FacilityID,duration,FromDate,ToDate);
            }
            else if (action == "Delete Selected")
            {
                await DeleteSelectedSlots(StaffID, FacilityID, SlotsIDs);
            }


            if ( action == "Save")
            {

                    var slot = await _healthcareContext.SHclnViewResourceSchedule.FindAsync(StaffID,FacilityID,SlotsIDs);
                    if (slot != null)
                    { 

                            slot.FromTime = fromTime.ToString(@"hh\:mm");
                            slot.ToTime = toTime.ToString(@"hh\:mm");
                        
                    }
               

                await _healthcareContext.SaveChangesAsync();

                var exslots = await _healthcareContext.SHclnViewResourceSchedule
                                                      .Where(slot => slot.StaffID == StaffID)
                                                      .ToListAsync();

                ViewBag.Slots = exslots;
                ViewBag.StaffID = StaffID;
                ViewBag.FacilityID = FacilityID;
                ViewBag.Duration = duration;
                ViewBag.FromDate = FromDate;
                ViewBag.ToDate = ToDate;
                ViewBag.FromTime = fromTime.ToString(@"hh\:mm");
                ViewBag.ToTime = toTime.ToString(@"hh\:mm");
                _healthcareContext.SaveChanges();

                var slots = GenerateDoctorSlots(StaffID, FacilityID, FromDate, ToDate, duration, fromTime.ToString(@"hh\:mm"), toTime.ToString(@"hh\:mm"));
                foreach (var s in slots)
                {
                    s.lastUpdatedDate = DateTime.Now.ToString();
                    s.lastUpdatedUser = User.Claims.First().Value.ToString();
                    s.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    s.Viewslot = DetermineViewslotValue(StaffID,FacilityID);
                   
                    _healthcareContext.SHclnResourceSchedule.Add(s);
                }

                await _healthcareContext.SaveChangesAsync();

                return View("DoctorSchedule");


            }
            if(action== "Add Slot")
            {
                    var slotUpd = _healthcareContext.SHclnViewResourceSchedule.Find(SlotsIDs,StaffID,FacilityID);

                    if (slotUpd == null)
                    {
                        var model = new ResourceScheduleModel
                        {
                            StaffID = StaffID,
                            FacilityID = FacilityID,
                            FromDate = FromDate,
                            ToDate = ToDate,
                            Duration = duration,
                           
                        };

                        _healthcareContext.SHclnViewResourceSchedule.Add(model);
                        _healthcareContext.SaveChanges();
                    }
                

            }

            var allSlots = await _healthcareContext.SHclnViewResourceSchedule
                                         .Where(slot => slot.StaffID == StaffID)
                                         .ToListAsync();

            ViewBag.Slots = allSlots;
            ViewBag.StaffID = StaffID;
            ViewBag.FacilityID = FacilityID;
            ViewBag.Duration = duration;
            ViewBag.FromDate = FromDate;
            ViewBag.ToDate = ToDate;
            ViewBag.FromTime = fromTime.ToString();
            ViewBag.ToTime = toTime.ToString();



            return View("DoctorSchedule");



        }


        private string DetermineViewslotValue(string staffId,string facilityId)
        {
           
            var relatedEntity = _healthcareContext.SHclnViewResourceSchedule.FirstOrDefault(entity => entity.StaffID == staffId && entity.FacilityID == facilityId);
            if (relatedEntity != null)
            {
                return relatedEntity.Viewslot;
            }
            else
            {
                
                return "DefaultViewslotValue";
            }
        }

        //get slot
        public async Task<IActionResult> GetSlots(string StaffID, string FacilityID,string Duration,string FromDate, string ToDate)
        {
            var exslots = await _healthcareContext.SHclnViewResourceSchedule
                                                .Where(slot => slot.StaffID == StaffID && slot.FacilityID == FacilityID)
                                                .ToListAsync();

            ViewBag.Slots = exslots;
            ViewBag.StaffID = StaffID;
            ViewBag.FacilityID = FacilityID;
            ViewBag.Duration = Duration; 
            ViewBag.FromDate = FromDate; 
            ViewBag.ToDate = ToDate;


            return View("DoctorSchedule");
        }
   //delete slot
        private async Task DeleteSelectedSlots(string staffID, string facilityID, string slotID)
        {

                 
            var doctors = await _healthcareContext.SHclnResourceSchedule.Where(e => e.StaffID == staffID && e.FacilityID == facilityID && e.Viewslot == slotID)
                 .Select(e => new DoctorScheduleModel
                 {
     
                      StaffID = e.StaffID,
                       FacilityID = e.FacilityID,
                       SlotsID = e.SlotsID,
                      //Active = true
                      })
                         .ToListAsync();

           

            await _healthcareContext.SaveChangesAsync();


            var slot = await _healthcareContext.SHclnViewResourceSchedule.FindAsync(staffID, facilityID, slotID);
            if (slot != null)
            {
               

                await _healthcareContext.SaveChangesAsync();
            }

        } 
        private List<DoctorScheduleModel> GenerateDoctorSlots(string staffID, string facilityID, string fromDate, string toDate, string duration, string fromTime, string toTime)
        {
            var slots = new List<DoctorScheduleModel>();
            DateTime startDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            TimeSpan slotDuration = TimeSpan.FromMinutes(int.Parse(duration));
            TimeSpan startTime = TimeSpan.Parse(fromTime);
            TimeSpan endTime = TimeSpan.Parse(toTime);
            /* TimeSpan startTime = TimeSpan.Parse(string.Format(fromTime,"HH:mm"));
             TimeSpan endTime = TimeSpan.Parse(toTime);*/

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                DateTime currentTime = date + startTime;

                // Handle the case where endTime is smaller than startTime
                if (endTime < startTime)
                {
                    endTime = endTime.Add(new TimeSpan(1, 0, 0, 0)); // Add one day
                }
                while (currentTime.Add(slotDuration) <= date + endTime)
                {
                    var slot = new DoctorScheduleModel
                    {
                        StaffID = staffID,
                        FacilityID = facilityID,
                        Date = date.ToString("yyyy-MM-dd"),
                        Duration = duration,
                        StartTime = currentTime.ToString(@"hh\:mm")
                    };
                    slots.Add(slot);
                    currentTime = currentTime.Add(slotDuration);
                }
            }

            return slots;
        }


        public IActionResult ScheduleHoliday(string staffID, string facilityID, string fromDate, string toDate)
        {

            var slotsToDelete = _healthcareContext.SHclnViewResourceSchedule
         .Where(ds => ds.StaffID == staffID &&
                      ds.FacilityID == facilityID &&
                      ds.FromDate == fromDate &&
                      ds.ToDate == toDate)
         .ToList();

            foreach (var slot in slotsToDelete)
            {
                _healthcareContext.SHclnViewResourceSchedule.Remove(slot);
            }


            DateTime startDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // checl update here
            // Define parameters for the stored procedure if needed
            var parameter1 = new SqlParameter("@pStrStaffId", staffID);
            var parameter2 = new SqlParameter("@pStrFacility", facilityID);
            var parameter3 = new SqlParameter("@pStrFromDate", fromDate);
            var parameter4 = new SqlParameter("@pStrToDate", toDate);


            // Execute the stored procedure
            var result = _healthcareContext.Database.ExecuteSqlRaw("SP_UpdateHoliday @pStrStaffId, @pStrFacility, @pStrFromDate, @pStrToDate", parameter1, parameter2,parameter3,parameter4);

            _healthcareContext.SaveChanges();

            return View("ScheduleHoliday");



        }

        [HttpPost] 
        private IActionResult ScheduleHoliday(DoctorScheduleModel model)
        {
          

            return View("ScheduleHoliday");
          
        }

        [HttpPost]
        private void MarkBlockers(DoctorScheduleModel model)
         {
            
         }

        public IActionResult ScheduleBlocker(string staffID, string facilityID, string date)
        {
          
            DateTime endDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);


            var parameter1 = new SqlParameter("@pStrStaffId", staffID);
            var parameter2 = new SqlParameter("@pStrFacility", facilityID);
            var parameter3 = new SqlParameter("@pStrFromDate", date);
            var parameter4 = new SqlParameter("@pStrToDate", date);


                var result = _healthcareContext.Database.ExecuteSqlRaw("SP_UpdateHoliday @pStrStaffId, @pStrFacility, @pStrFromDate, @pStrToDate", parameter1, parameter2, parameter3, parameter4);

            _healthcareContext.SaveChanges();

            return View("ScheduleBlocker");
        }

        [HttpPost]
        public IActionResult DoctorSchedule(DoctorScheduleModel model, string buttonType)
        {
            BusinessClassInpatient inpatient = new BusinessClassInpatient(_healthcareContext);
            ViewData["faid"] = inpatient.Getfaid();
            ViewData["condocid"] = inpatient.GetConDocId();

            if (buttonType == "Holiday")
            {
                return View("ScheduleHoliday");
            }
            else if (buttonType == "Blocker")
            {

                return View("ScheduleBlocker");

            }
            return View();
        }

    }
}




