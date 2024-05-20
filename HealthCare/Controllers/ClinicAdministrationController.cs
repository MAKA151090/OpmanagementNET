using Azure;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Security.Claims;

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
                existingClinic.lastUpdatedUser = "Myself";

                _healthcareContext.Entry(existingClinic).State = EntityState.Modified;
            }
            else
            {

                //BusinessClass businessClass = new BusinessClass(_healthcareContext);
                //try
                //{

                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
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
                existingBloodGroup.lastUpdatedUser = "Admin";
                existingBloodGroup.lastUpdatedDate = DateTime.Now.ToString();
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
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
                existingStaffAdmin.LastupdatedUser = "Admin";
                existingStaffAdmin.LastUpdatedMachine = "Lap";
            }
            else
            {

                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = "Admin";
                model.LastUpdatedMachine = "lap";
                _healthcareContext.SHclnStaffAdminModel.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("StaffAdminModel", model);

        }

        [HttpPost]

        public async Task<IActionResult> GetDoctor()
        {
            return View();
        }

        /*public async Task<ActionResult> Doctoradmin(string doctorid, string buttonType)
        {
            ClinicAdminBusinessClass businessClass = new ClinicAdminBusinessClass(_healthcareContext);
            if (buttonType == "submit")
            {
                var doctor = await businessClass.GetDoctorRegister(doctorid);
                if (doctor != null)
                {
                    doctorid = doctor.DoctorID;

                    return View("DoctorRegistration", doctor);
                }
                else
                {
                    ViewBag.ErrorMessage = "No data found for the entered IDs.";
                    return View(GetDoctor);
                }
            }

            return View();
        }*/

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
                existingRoomType.lastUpdatedUser = "Admin";
                existingRoomType.lastUpdatedMachine = "Lap";
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                model.lastUpdatedMachine = "Lap";
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
                existingNurseStation.NurseStationID = model.NurseStationID;
                existingNurseStation.StationName = model.StationName;
                existingNurseStation.lastupdatedDate = DateTime.Now.ToString();
                existingNurseStation.lastUpdatedUser = "Admin";
                existingNurseStation.lastUpdatedMachine = "Lap";
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                model.lastUpdatedMachine = "Lap";
                _healthcareContext.SHclnNurseStationMaster.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";
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
                existingIpType.lastUpdatedUser = "Admin";
                existingIpType.lastUpdatedMachine = "Machine";
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                model.lastUpdatedMachine = "Machine";
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
                model.lastUpdatedUser = User.Identity.Name.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                _healthcareContext.SHclnHospitalBedMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
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
                existingEWS.lastUpdatedUser = "admin";
                existingEWS.lastUpdatedMachine = "Lap";
            }
            else
            {
                pEWS.lastupdatedDate = DateTime.Now.ToString();
                pEWS.lastUpdatedUser = "Myself";
                pEWS.lastUpdatedMachine = "lap";
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
            return View();
        }
        public IActionResult NurseStationMaster()
        {
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
                existingTest.lastUpdatedUser = "Myself";
                existingTest.lastUpdatedDate = DateTime.Now.ToString(); ;
                existingTest.lastUpdatedMachine = "Myself";
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {


                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
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
                existingFHPH.LastUpdatedUser = "Myself";
            }
            else
            {

                model.LastUpdatedDate = DateTime.Now.ToString();
                model.LastUpdatedUser = "Myself";
                _healthcareContext.PatExmFHPH.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("PatientFHPHMaster", model);



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

                existingTest.LastupdatedUser = "Myself";
                existingTest.LastupdatedDate = DateTime.Now.ToString(); ;
                existingTest.LastUpdatedMachine = "Myself";
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {


                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = "Myself";
                model.LastUpdatedMachine = "Myself";
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "myself";
            }

            else
            {

                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHclnSurgeryMaster.Add(model);

            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("ClinicSurgeryMaster", model);
        }


        public async Task<IActionResult> GetOTTableMaster(OtTableMasterModel model)
        {
            var existingTest = await _healthcareContext.SHotTableMaster.FindAsync(model.TableID);
            if (existingTest != null)
            {
                existingTest.TableID = model.TableID;
                existingTest.TableName = model.TableName;
                existingTest.RoomName = model.RoomName;
                existingTest.AdditionalFeature = model.AdditionalFeature;
                existingTest.lastupdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "myself";
            }

            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHotTableMaster.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "myself";
            }

            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "myself";
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHotInternalDepartmentMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("InternalDepartmentMaster", model);
        }



        public async Task<IActionResult> GetRollAccess(RollAccessModel model)
        {
            var existingTest = await _healthcareContext.SHClnRollAccess.FindAsync(model.RollID);
            if (existingTest != null)
            {
                existingTest.RollID = model.RollID;
                existingTest.ScreenID = model.ScreenID;
                existingTest.Access = model.Access;           
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "lap";

            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHClnRollAccess.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("RollAccess", model);

        }



        public async Task<IActionResult> GetScreenMaster (ScreenMasterModel model)
        {

            var existingTest = await _healthcareContext.SHClnScreenMaster.FindAsync(model.ScreenId);
            if (existingTest != null)
            {
                existingTest.ScreenId = model.ScreenId;
                existingTest.ScreenName = model.ScreenName;
                existingTest.ReadWriteAccess = model.ReadWriteAccess;
                existingTest.Authorized = model.Authorized;
                existingTest.lastUpdatedDate = DateTime.Now.ToString();
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "lap";
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHClnScreenMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("ScreenMaster", model);
        }

        public async Task<IActionResult>GetHospitalRegistration(HospitalRegistrationModel model)
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "lap";
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "lap";
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHHospitalFacilityMapping.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("HospitalFacilityMapping", model);
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "lap";
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
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
                existingTest.lastUpdatedUser = "myself";
                existingTest.lastUpdatedMachine = "lap";
                _healthcareContext.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "lap";
                _healthcareContext.SHclnProcedureCodeMaster.Add(model);
            }
            await _healthcareContext.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";
            return View("ProcedureCodeMaster", model);
        }





        public IActionResult DoctorSchedule()
        {
            return View();
        }

        public IActionResult HospitalRegistration()
        {
            return View();
        }
        
        public IActionResult HospitalFacilityMapping()
        {
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

        public IActionResult StaffFacilityMapping()
        {
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
                existingStafff.lastUpdatedUser = "Admin";
                existingStafff.lastUpdatedMachine = "Lap";

                _healthcareContext.Entry(existingStafff).State = EntityState.Modified;
            }
            else
            {
                model.lastupdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Admin";
                model.lastUpdatedMachine = "Lap";
                _healthcareContext.SHclnStaffFacilityMapping.Add(model);
            }

            await _healthcareContext.SaveChangesAsync();


            ViewBag.Message = "Saved Successfully";
            return View("StaffFacilityMapping", model);


        }





    }
}


