using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtSurgeryModel",
                columns: table => new
                {
                    OtScheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtSurgeryModel", x => new { x.OtScheduleID, x.SurgeryID });
                });

            migrationBuilder.CreateTable(
                name: "PatExmFHPH",
                columns: table => new
                {
                    QuestionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatExmFHPH", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "PatientVisitIntoDocumentModel",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVisitIntoDocumentModel", x => new { x.PatientID, x.ClinicID, x.VisitID });
                });

            migrationBuilder.CreateTable(
                name: "SHcllDoctorScheduleModel",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlotsID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Holiday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHcllDoctorScheduleModel", x => new { x.DoctorID, x.ClinicID, x.SlotsID });
                });

            migrationBuilder.CreateTable(
                name: "SHclnBloodGroup",
                columns: table => new
                {
                    IntBg_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnBloodGroup", x => new { x.IntBg_Id, x.BloodGroup });
                });

            migrationBuilder.CreateTable(
                name: "SHclnClinicAdmin",
                columns: table => new
                {
                    ClinicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnClinicAdmin", x => x.ClinicId);
                });

            migrationBuilder.CreateTable(
                name: "SHclnDoctorAdmin",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedialLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnDoctorAdmin", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:HealthCare/Migrations/20240517091834_Initial.cs
                name: "SHclnHospitalBedMaster",
                columns: table => new
                {
                    BedID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFloor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseStationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPerDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnHospitalBedMaster", x => x.BedID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnIPTypeMaster",
                columns: table => new
                {
                    IPTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnIPTypeMaster", x => x.IPTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnNurseStationMaster",
                columns: table => new
                {
                    NurseStationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnNurseStationMaster", x => x.NurseStationID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnRoomTypeMaster",
                columns: table => new
                {
                    RoomTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionFeature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnRoomTypeMaster", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
========
>>>>>>>> d68d94ae7e61ffe758fbb3f876876574f7b13217:HealthCare/Migrations/20240517045739_Initial.cs
                name: "SHclnSurgeryMaster",
                columns: table => new
                {
                    SurgeryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnSurgeryMaster", x => x.SurgeryID);
                });

            migrationBuilder.CreateTable(
                name: "SHExmInfoDocument",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrlastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrlastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmInfoDocument", x => new { x.PatientID, x.ClinicID, x.VisitID });
                });

            migrationBuilder.CreateTable(
                name: "SHExmPatientExamination",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExaminationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Complaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmPatientExamination", x => new { x.PatientID, x.ClinicID, x.VisitID, x.ExaminationID });
                });

            migrationBuilder.CreateTable(
                name: "SHExmPatientFHPH",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmPatientFHPH", x => new { x.PatientID, x.QuestionID, x.Type });
                });

            migrationBuilder.CreateTable(
                name: "SHExmPatientObjective",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeartRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResptryRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OxySat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PulseRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BldGluLvl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheifComplaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmPatientObjective", x => new { x.PatientID, x.ClinicID, x.VisitID });
                });

            migrationBuilder.CreateTable(
                name: "SHfdOpCheckingModel",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHfdOpCheckingModel", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:HealthCare/Migrations/20240517091834_Initial.cs
                name: "SHInpatientAdmission",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DutyDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferredByDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionConsultDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultantDepartmentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttenderContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InpatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHInpatientAdmission", x => new { x.PatientID, x.CaseID });
                });

            migrationBuilder.CreateTable(
========
>>>>>>>> d68d94ae7e61ffe758fbb3f876876574f7b13217:HealthCare/Migrations/20240517045739_Initial.cs
                name: "SHLogs",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogScreens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Att1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHLogs", x => x.LogID);
                });

            migrationBuilder.CreateTable(
                name: "SHotDepartmentMaster",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotDepartmentMaster", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "SHotNotes",
                columns: table => new
                {
                    OtScheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntraOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreOtAnesthesiaNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntraOtAnesthesiaNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOtAnesthesiaNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservationNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotNotes", x => x.OtScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "SHotScheduling",
                columns: table => new
                {
                    OtScheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InchrgDepID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotScheduling", x => x.OtScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "SHotSurgerymaster",
                columns: table => new
                {
                    SurgeryTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotSurgerymaster", x => x.SurgeryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHotTableMaster",
                columns: table => new
                {
                    TableID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalFeature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotTableMaster", x => x.TableID);
                });

            migrationBuilder.CreateTable(
                name: "SHPatientRadiology",
                columns: table => new
                {
                    RadioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScreeningDate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReferralDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferralDoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreeningCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreeningCompletedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientRadiology", x => new { x.RadioID, x.ClinicID, x.PatientID, x.ScreeningDate });
                });

            migrationBuilder.CreateTable(
                name: "SHPatientRegistration",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDPrfName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDPrfNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnctPrsnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rlnpatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmgcyCntNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientRegistration", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "SHPatientSchedule",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientSchedule", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "SHPatientTest",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestDateTime = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TsampleClt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TsampleCltDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExptRsltDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultPublish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferDocID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientTest", x => new { x.PatientID, x.ClinicID, x.TestID, x.TestDateTime });
                });

            migrationBuilder.CreateTable(
                name: "SHprsPrescription",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseVisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrugID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EpressID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FillDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHprsPrescription", x => new { x.PatientID, x.CaseVisitID, x.OrderID, x.DrugID });
                });

            migrationBuilder.CreateTable(
                name: "SHprsPrescriptionPrint",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseVisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicactionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHprsPrescriptionPrint", x => new { x.PatientID, x.CaseVisitID, x.OrderID });
                });

            migrationBuilder.CreateTable(
                name: "SHRadioMaster",
                columns: table => new
                {
                    RadioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RadioName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHRadioMaster", x => x.RadioID);
                });

            migrationBuilder.CreateTable(
                name: "SHSeverityModel",
                columns: table => new
                {
                    SeverityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeverityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHSeverityModel", x => x.SeverityID);
                });

            migrationBuilder.CreateTable(
                name: "SHstkDrugCategory",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHstkDrugCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SHstkDrugGroup",
                columns: table => new
                {
                    GroupTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupTypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHstkDrugGroup", x => new { x.GroupTypeName, x.GroupTypeID });
                });

            migrationBuilder.CreateTable(
                name: "SHstkDrugInventory",
                columns: table => new
                {
                    DrugId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RockId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Therapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHstkDrugInventory", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "SHstkDrugRack",
                columns: table => new
                {
                    RackID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RackName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniqueIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHstkDrugRack", x => new { x.RackID, x.RackName });
                });

            migrationBuilder.CreateTable(
                name: "SHstkDrugStock",
                columns: table => new
                {
                    IDNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrugID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufacturingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfStock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHstkDrugStock", x => new { x.IDNumber, x.DrugID });
                });

            migrationBuilder.CreateTable(
                name: "SHstkDrugType",
                columns: table => new
                {
                    TypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHstkDrugType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHTestMaster",
                columns: table => new
                {
                    TestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHTestMaster", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "SHUpdateRadiologyResult",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RadioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHUpdateRadiologyResult", x => new { x.PatientID, x.ClinicID, x.RadioID });
                });

            migrationBuilder.CreateTable(
                name: "SHWebErrors",
                columns: table => new
                {
                    ErrodDesc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ErrDateTime = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHWebErrors", x => new { x.ErrodDesc, x.ErrDateTime, x.ScreenName });
                });

            migrationBuilder.CreateTable(
                name: "SHExmSeverity",
                columns: table => new
                {
                    ExaminationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientExaminationModelClinicID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientExaminationModelExaminationID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientExaminationModelPatientID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientExaminationModelVisitID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmSeverity", x => new { x.PatientID, x.ClinicID, x.VisitID, x.ExaminationID, x.Severity });
                    table.ForeignKey(
                        name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationMod~",
                        columns: x => new { x.PatientExaminationModelPatientID, x.PatientExaminationModelClinicID, x.PatientExaminationModelVisitID, x.PatientExaminationModelExaminationID },
                        principalTable: "SHExmPatientExamination",
                        principalColumns: new[] { "PatientID", "ClinicID", "VisitID", "ExaminationID" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationModelVisitID_PatientExamina~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelClinicID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtSurgeryModel");

            migrationBuilder.DropTable(
                name: "PatExmFHPH");

            migrationBuilder.DropTable(
                name: "PatientVisitIntoDocumentModel");

            migrationBuilder.DropTable(
                name: "SHcllDoctorScheduleModel");

            migrationBuilder.DropTable(
                name: "SHclnBloodGroup");

            migrationBuilder.DropTable(
                name: "SHclnClinicAdmin");

            migrationBuilder.DropTable(
                name: "SHclnDoctorAdmin");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:HealthCare/Migrations/20240517091834_Initial.cs
                name: "SHclnHospitalBedMaster");

            migrationBuilder.DropTable(
                name: "SHclnIPTypeMaster");

            migrationBuilder.DropTable(
                name: "SHclnNurseStationMaster");

            migrationBuilder.DropTable(
                name: "SHclnRoomTypeMaster");

            migrationBuilder.DropTable(
========
>>>>>>>> d68d94ae7e61ffe758fbb3f876876574f7b13217:HealthCare/Migrations/20240517045739_Initial.cs
                name: "SHclnSurgeryMaster");

            migrationBuilder.DropTable(
                name: "SHExmInfoDocument");

            migrationBuilder.DropTable(
                name: "SHExmPatientFHPH");

            migrationBuilder.DropTable(
                name: "SHExmPatientObjective");

            migrationBuilder.DropTable(
                name: "SHExmSeverity");

            migrationBuilder.DropTable(
                name: "SHfdOpCheckingModel");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:HealthCare/Migrations/20240517091834_Initial.cs
                name: "SHInpatientAdmission");

            migrationBuilder.DropTable(
========
>>>>>>>> d68d94ae7e61ffe758fbb3f876876574f7b13217:HealthCare/Migrations/20240517045739_Initial.cs
                name: "SHLogs");

            migrationBuilder.DropTable(
                name: "SHotDepartmentMaster");

            migrationBuilder.DropTable(
                name: "SHotNotes");

            migrationBuilder.DropTable(
                name: "SHotScheduling");

            migrationBuilder.DropTable(
                name: "SHotSurgerymaster");

            migrationBuilder.DropTable(
                name: "SHotTableMaster");

            migrationBuilder.DropTable(
                name: "SHPatientRadiology");

            migrationBuilder.DropTable(
                name: "SHPatientRegistration");

            migrationBuilder.DropTable(
                name: "SHPatientSchedule");

            migrationBuilder.DropTable(
                name: "SHPatientTest");

            migrationBuilder.DropTable(
                name: "SHprsPrescription");

            migrationBuilder.DropTable(
                name: "SHprsPrescriptionPrint");

            migrationBuilder.DropTable(
                name: "SHRadioMaster");

            migrationBuilder.DropTable(
                name: "SHSeverityModel");

            migrationBuilder.DropTable(
                name: "SHstkDrugCategory");

            migrationBuilder.DropTable(
                name: "SHstkDrugGroup");

            migrationBuilder.DropTable(
                name: "SHstkDrugInventory");

            migrationBuilder.DropTable(
                name: "SHstkDrugRack");

            migrationBuilder.DropTable(
                name: "SHstkDrugStock");

            migrationBuilder.DropTable(
                name: "SHstkDrugType");

            migrationBuilder.DropTable(
                name: "SHTestMaster");

            migrationBuilder.DropTable(
                name: "SHUpdateRadiologyResult");

            migrationBuilder.DropTable(
                name: "SHWebErrors");

            migrationBuilder.DropTable(
                name: "SHExmPatientExamination");
        }
    }
}
