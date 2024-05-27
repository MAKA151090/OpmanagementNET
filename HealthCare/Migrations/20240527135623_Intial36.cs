using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationM~",
                table: "SHExmSeverity");

            migrationBuilder.DropIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationModelVisitID_PatientExami~",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelExaminationID",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelFacilityID",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelPatientID",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelVisitID",
                table: "SHExmSeverity");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedUser",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Symptoms",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedUser",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prescription",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FollowUp",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Diagnosis",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complaint",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedUser",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Symptoms",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientExaminationModelExaminationID",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientExaminationModelFacilityID",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientExaminationModelPatientID",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientExaminationModelVisitID",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedUser",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prescription",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FollowUp",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diagnosis",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complaint",
                table: "SHExmPatientExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationModelVisitID_PatientExami~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelFacilityID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelFacilityID_PatientExaminationM~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelFacilityID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" },
                principalTable: "SHExmPatientExamination",
                principalColumns: new[] { "PatientID", "FacilityID", "VisitID", "ExaminationID" });
        }
    }
}
