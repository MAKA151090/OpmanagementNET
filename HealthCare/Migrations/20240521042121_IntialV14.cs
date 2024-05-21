using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class IntialV14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacilityID",
                table: "SHExmPatientFHPH",
                newName: "Question");

            migrationBuilder.AddColumn<string>(
                name: "lastUpdatedMachine",
                table: "SHExmPatientFHPH",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastUpdatedMachine",
                table: "SHExmPatientFHPH");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "SHExmPatientFHPH",
                newName: "FacilityID");
        }
    }
}
