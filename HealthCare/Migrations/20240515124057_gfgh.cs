using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class gfgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastupdatedUser",
                table: "SHTestMaster",
                newName: "lastUpdatedUser");

            migrationBuilder.RenameColumn(
                name: "LastupdatedDate",
                table: "SHTestMaster",
                newName: "lastUpdatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedMachine",
                table: "SHTestMaster",
                newName: "lastUpdatedMachine");

            migrationBuilder.RenameColumn(
                name: "LastupdatedUser",
                table: "SHPatientTest",
                newName: "lastUpdatedUser");

            migrationBuilder.RenameColumn(
                name: "LastupdatedDate",
                table: "SHPatientTest",
                newName: "lastUpdatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedMachine",
                table: "SHPatientTest",
                newName: "lastUpdatedMachine");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedUser",
                table: "SHTestMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "SHTestMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedMachine",
                table: "SHTestMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SHPatientSchedule",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SHPatientSchedule");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedUser",
                table: "SHTestMaster",
                newName: "LastupdatedUser");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedMachine",
                table: "SHTestMaster",
                newName: "LastUpdatedMachine");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedDate",
                table: "SHTestMaster",
                newName: "LastupdatedDate");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedUser",
                table: "SHPatientTest",
                newName: "LastupdatedUser");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedMachine",
                table: "SHPatientTest",
                newName: "LastUpdatedMachine");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedDate",
                table: "SHPatientTest",
                newName: "LastupdatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "LastupdatedUser",
                table: "SHTestMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedMachine",
                table: "SHTestMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastupdatedDate",
                table: "SHTestMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
