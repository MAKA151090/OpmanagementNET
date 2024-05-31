using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "SHclnResourceSchedule",
                newName: "StrInActive");

            migrationBuilder.AddColumn<bool>(
                name: "StrIsDelete",
                table: "SHclnViewResourceSchedule",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrIsDelete",
                table: "SHclnViewResourceSchedule");

            migrationBuilder.RenameColumn(
                name: "StrInActive",
                table: "SHclnResourceSchedule",
                newName: "Active");
        }
    }
}
