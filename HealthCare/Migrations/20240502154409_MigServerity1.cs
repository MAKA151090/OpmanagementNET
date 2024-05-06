using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigServerity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmSeverity", x => new { x.PatientID, x.ClinicID, x.VisitID, x.ExaminationID, x.Severity });
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
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeverityPatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeverityClinicID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeverityVisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeverityExaminationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Severity1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHExmPatientExamination", x => new { x.PatientID, x.ClinicID, x.VisitID, x.ExaminationID });
                    table.ForeignKey(
                        name: "FK_SHExmPatientExamination_SHExmSeverity_SeverityPatientID_SeverityClinicID_SeverityVisitID_SeverityExaminationID_Severity1",
                        columns: x => new { x.SeverityPatientID, x.SeverityClinicID, x.SeverityVisitID, x.SeverityExaminationID, x.Severity1 },
                        principalTable: "SHExmSeverity",
                        principalColumns: new[] { "PatientID", "ClinicID", "VisitID", "ExaminationID", "Severity" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHExmPatientExamination_SeverityPatientID_SeverityClinicID_SeverityVisitID_SeverityExaminationID_Severity1",
                table: "SHExmPatientExamination",
                columns: new[] { "SeverityPatientID", "SeverityClinicID", "SeverityVisitID", "SeverityExaminationID", "Severity1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHExmPatientExamination");

            migrationBuilder.DropTable(
                name: "SHExmSeverity");
        }
    }
}
