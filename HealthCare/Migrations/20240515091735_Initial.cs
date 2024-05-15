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
                    TestDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SHPatientTest", x => new { x.PatientID, x.ClinicID, x.TestID });
                });

            migrationBuilder.CreateTable(
                name: "SHTestMaster",
                columns: table => new
                {
                    TestID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHTestMaster", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "SHUpdateRadiologyResults",
                columns: table => new
                {
                    RadioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHUpdateRadiologyResults", x => new { x.RadioID, x.ImageID });
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
                name: "PatExmFHPH");

            migrationBuilder.DropTable(
                name: "PatientVisitIntoDocumentModel");

            migrationBuilder.DropTable(
                name: "SHclnBloodGroup");

            migrationBuilder.DropTable(
                name: "SHclnClinicAdmin");

            migrationBuilder.DropTable(
                name: "SHclnDoctorAdmin");

            migrationBuilder.DropTable(
                name: "SHExmInfoDocument");

            migrationBuilder.DropTable(
                name: "SHExmPatientFHPH");

            migrationBuilder.DropTable(
                name: "SHExmPatientObjective");

            migrationBuilder.DropTable(
                name: "SHExmSeverity");

            migrationBuilder.DropTable(
                name: "SHLogs");

            migrationBuilder.DropTable(
                name: "SHPatientRegistration");

            migrationBuilder.DropTable(
                name: "SHPatientSchedule");

            migrationBuilder.DropTable(
                name: "SHPatientTest");

            migrationBuilder.DropTable(
                name: "SHTestMaster");

            migrationBuilder.DropTable(
                name: "SHUpdateRadiologyResults");

            migrationBuilder.DropTable(
                name: "SHWebErrors");

            migrationBuilder.DropTable(
                name: "SHExmPatientExamination");
        }
    }
}
