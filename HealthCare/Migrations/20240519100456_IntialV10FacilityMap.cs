using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class IntialV10FacilityMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VisitcaseID1",
                table: "SHPatientTest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrVisitcaseID",
                table: "SHPatientRadiology",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VisitcaseID",
                table: "SHPatientRadiology",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SHclnStaffFacilityMapping",
                columns: table => new
                {
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacilityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnStaffFacilityMapping", x => new { x.StaffId, x.FacilityID });
                });

            migrationBuilder.CreateTable(
                name: "SHInpatientDischarge",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DischargeNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHInpatientDischarge", x => new { x.PatientID, x.CaseID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnStaffFacilityMapping");

            migrationBuilder.DropTable(
                name: "SHInpatientDischarge");

            migrationBuilder.DropColumn(
                name: "VisitcaseID1",
                table: "SHPatientTest");

            migrationBuilder.DropColumn(
                name: "StrVisitcaseID",
                table: "SHPatientRadiology");

            migrationBuilder.DropColumn(
                name: "VisitcaseID",
                table: "SHPatientRadiology");
        }
    }
}
