using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHprsPrescription",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Afternoonunit",
                table: "SHprsPrescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eveningunit",
                table: "SHprsPrescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Morningunit",
                table: "SHprsPrescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nightunit",
                table: "SHprsPrescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription",
                columns: new[] { "PatientID", "CaseVisitID", "OrderID", "DrugID", "FacilityID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHprsPrescription");

            migrationBuilder.DropColumn(
                name: "Afternoonunit",
                table: "SHprsPrescription");

            migrationBuilder.DropColumn(
                name: "Eveningunit",
                table: "SHprsPrescription");

            migrationBuilder.DropColumn(
                name: "Morningunit",
                table: "SHprsPrescription");

            migrationBuilder.DropColumn(
                name: "Nightunit",
                table: "SHprsPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription",
                columns: new[] { "PatientID", "CaseVisitID", "OrderID", "DrugID" });
        }
    }
}
