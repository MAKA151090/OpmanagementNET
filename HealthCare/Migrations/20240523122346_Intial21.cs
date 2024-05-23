using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slots",
                table: "SHclnViewResourceSchedule",
                newName: "SlotsID");

            migrationBuilder.AddColumn<string>(
                name: "RackID",
                table: "SHstkDrugStock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedMachine",
                table: "SHclnResourceSchedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RackID",
                table: "SHstkDrugStock");

            migrationBuilder.RenameColumn(
                name: "SlotsID",
                table: "SHclnViewResourceSchedule",
                newName: "Slots");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedMachine",
                table: "SHclnResourceSchedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
