using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigDocument1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHExmPatientExamination_SHExmSeverity_SeverityPatientID_SeverityClinicID_SeverityVisitID_SeverityExaminationID_Severity1",
                table: "SHExmPatientExamination");

            migrationBuilder.DropIndex(
                name: "IX_SHExmPatientExamination_SeverityPatientID_SeverityClinicID_SeverityVisitID_SeverityExaminationID_Severity1",
                table: "SHExmPatientExamination");

            migrationBuilder.DropColumn(
                name: "Severity1",
                table: "SHExmPatientExamination");

            migrationBuilder.DropColumn(
                name: "SeverityClinicID",
                table: "SHExmPatientExamination");

            migrationBuilder.DropColumn(
                name: "SeverityExaminationID",
                table: "SHExmPatientExamination");

            migrationBuilder.DropColumn(
                name: "SeverityPatientID",
                table: "SHExmPatientExamination");

            migrationBuilder.DropColumn(
                name: "SeverityVisitID",
                table: "SHExmPatientExamination");

            migrationBuilder.AddColumn<string>(
                name: "PatientExaminationModelClinicID",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientExaminationModelExaminationID",
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

            migrationBuilder.CreateTable(
                name: "SHExmPatientDocument",
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
                    table.PrimaryKey("PK_SHExmPatientDocument", x => new { x.PatientID, x.ClinicID, x.VisitID });
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationModelVisitID_PatientExamina~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelClinicID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationMod~",
                table: "SHExmSeverity",
                columns: new[] { "PatientExaminationModelPatientID", "PatientExaminationModelClinicID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID" },
                principalTable: "SHExmPatientExamination",
                principalColumns: new[] { "PatientID", "ClinicID", "VisitID", "ExaminationID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHExmSeverity_SHExmPatientExamination_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationMod~",
                table: "SHExmSeverity");

            migrationBuilder.DropTable(
                name: "SHExmPatientDocument");

            migrationBuilder.DropIndex(
                name: "IX_SHExmSeverity_PatientExaminationModelPatientID_PatientExaminationModelClinicID_PatientExaminationModelVisitID_PatientExamina~",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelClinicID",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelExaminationID",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelPatientID",
                table: "SHExmSeverity");

            migrationBuilder.DropColumn(
                name: "PatientExaminationModelVisitID",
                table: "SHExmSeverity");

            migrationBuilder.AddColumn<string>(
                name: "Severity1",
                table: "SHExmPatientExamination",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeverityClinicID",
                table: "SHExmPatientExamination",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeverityExaminationID",
                table: "SHExmPatientExamination",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeverityPatientID",
                table: "SHExmPatientExamination",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeverityVisitID",
                table: "SHExmPatientExamination",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SHExmPatientExamination_SeverityPatientID_SeverityClinicID_SeverityVisitID_SeverityExaminationID_Severity1",
                table: "SHExmPatientExamination",
                columns: new[] { "SeverityPatientID", "SeverityClinicID", "SeverityVisitID", "SeverityExaminationID", "Severity1" });

            migrationBuilder.AddForeignKey(
                name: "FK_SHExmPatientExamination_SHExmSeverity_SeverityPatientID_SeverityClinicID_SeverityVisitID_SeverityExaminationID_Severity1",
                table: "SHExmPatientExamination",
                columns: new[] { "SeverityPatientID", "SeverityClinicID", "SeverityVisitID", "SeverityExaminationID", "Severity1" },
                principalTable: "SHExmSeverity",
                principalColumns: new[] { "PatientID", "ClinicID", "VisitID", "ExaminationID", "Severity" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
