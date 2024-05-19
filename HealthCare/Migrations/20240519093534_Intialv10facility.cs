using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intialv10facility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationMod~",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "ClinicID",
                table: "SHPatientSchedule");

            migrationBuilder.DropColumn(
                name: "ClinicID",
                table: "SHPatientRegistration");

            migrationBuilder.DropColumn(
                name: "ClinicID",
                table: "SHExmPatientFHPH");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHUpdateRadiologyResult",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHPatientTest",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHPatientRadiology",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "PatientExaminationModelClinicID",
                table: "SHExmSeverity",
                newName: "PatientExaminationModelFacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHExmSeverity",
                newName: "FacilityID");

            migrationBuilder.RenameIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationModelVisitID_PatientExamina~",
                table: "SHExmSeverity",
                newName: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationModelVisitID_PatientExami~");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHExmPatientObjective",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHExmPatientExamination",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHExmInfoDocument",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "SHclnClinicAdmin",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "SHcllDoctorScheduleModel",
                newName: "FacilityID");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "PatientVisitIntoDocumentModel",
                newName: "FacilityID");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHstkDrugRack",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHRadioMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHPatientSchedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHPatientRegistration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHotTableMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHotScheduling",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHotInternalDepartmentMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHExmPatientFHPH",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHclnRoomTypeMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHclnNurseStationMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHclnHospitalBedMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SHEXMdiagnosis",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiagnosisID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lasrUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHEXMdiagnosis", x => new { x.PatientID, x.VisitID, x.ExamID, x.DiagnosisID });
                });

            migrationBuilder.CreateTable(
                name: "SHEXMprocedure",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcedureID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lasrUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHEXMprocedure", x => new { x.PatientID, x.VisitID, x.ExamID, x.ProcedureID });
                });

            migrationBuilder.CreateTable(
                name: "SHipmInPatientTransferUpdate",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomTypeFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomTypeTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedIdFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedIdTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHipmInPatientTransferUpdate", x => new { x.PatientId, x.CaseId, x.BedId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationM~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelFacilityID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" },
                principalTable: "SHExmPatientExamination",
                principalColumns: new[] { "PatientID", "FacilityID", "VisitID", "ExaminationID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationM~",
                table: "SHExmSeverity");

            migrationBuilder.DropTable(
                name: "SHEXMdiagnosis");

            migrationBuilder.DropTable(
                name: "SHEXMprocedure");

            migrationBuilder.DropTable(
                name: "SHipmInPatientTransferUpdate");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHstkDrugRack");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHRadioMaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHPatientSchedule");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHPatientRegistration");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHotTableMaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHotScheduling");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHotInternalDepartmentMaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHExmPatientFHPH");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHclnRoomTypeMaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHclnNurseStationMaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHclnHospitalBedMaster");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHUpdateRadiologyResult",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHPatientTest",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHPatientRadiology",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "PatientExaminationModelFacilityID",
                table: "SHExmSeverity",
                newName: "PatientExaminationModelClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHExmSeverity",
                newName: "ClinicID");

            migrationBuilder.RenameIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationModelVisitID_PatientExami~",
                table: "SHExmSeverity",
                newName: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationModelVisitID_PatientExamina~");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHExmPatientObjective",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHExmPatientExamination",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHExmInfoDocument",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHclnClinicAdmin",
                newName: "ClinicId");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHcllDoctorScheduleModel",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "PatientVisitIntoDocumentModel",
                newName: "ClinicID");

            migrationBuilder.AddColumn<string>(
                name: "ClinicID",
                table: "SHPatientSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicID",
                table: "SHPatientRegistration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicID",
                table: "SHExmPatientFHPH",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationMod~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelClinicID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" },
                principalTable: "SHExmPatientExamination",
                principalColumns: new[] { "PatientID", "ClinicID", "VisitID", "ExaminationID" });
        }
    }
}
