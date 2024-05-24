using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnViewResourceSchedule",
                table: "SHclnViewResourceSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "SlotsID",
                table: "SHclnViewResourceSchedule",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnViewResourceSchedule",
                table: "SHclnViewResourceSchedule",
                columns: new[] { "StaffID", "FacilityID", "SlotsID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnViewResourceSchedule",
                table: "SHclnViewResourceSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "SlotsID",
                table: "SHclnViewResourceSchedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnViewResourceSchedule",
                table: "SHclnViewResourceSchedule",
                columns: new[] { "StaffID", "FacilityID" });
        }
    }
}
