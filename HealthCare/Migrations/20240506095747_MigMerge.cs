using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigMerge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmPatientDocument",
                table: "SHExmPatientDocument");

            migrationBuilder.RenameTable(
                name: "SHExmPatientDocument",
                newName: "PatientVisitIntoDocumentModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientVisitIntoDocumentModel",
                table: "PatientVisitIntoDocumentModel",
                columns: new[] { "PatientID", "ClinicID", "VisitID" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHExmInfoDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientVisitIntoDocumentModel",
                table: "PatientVisitIntoDocumentModel");

            migrationBuilder.RenameTable(
                name: "PatientVisitIntoDocumentModel",
                newName: "SHExmPatientDocument");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmPatientDocument",
                table: "SHExmPatientDocument",
                columns: new[] { "PatientID", "ClinicID", "VisitID" });
        }
    }
}
