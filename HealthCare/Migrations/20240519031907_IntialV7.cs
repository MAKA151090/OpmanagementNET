using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class IntialV7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Office",
                table: "SHStaffAttendance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Authorized",
                table: "SHClnScreenMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadWriteAccess",
                table: "SHClnScreenMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SHipmInPatientCaseSheet",
                columns: table => new
                {
                    StrPatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrCaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrBedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrPostMedHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrAllergicTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrDiagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrTreatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHipmInPatientCaseSheet", x => new { x.StrPatientId, x.StrCaseId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHipmInPatientCaseSheet");

            migrationBuilder.DropColumn(
                name: "Office",
                table: "SHStaffAttendance");

            migrationBuilder.DropColumn(
                name: "Authorized",
                table: "SHClnScreenMaster");

            migrationBuilder.DropColumn(
                name: "ReadWriteAccess",
                table: "SHClnScreenMaster");
        }
    }
}
