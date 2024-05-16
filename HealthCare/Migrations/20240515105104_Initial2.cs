using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology");

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

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "SHPatientRadiology",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClinicID",
                table: "SHPatientRadiology",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology",
                columns: new[] { "RadioID", "ClinicID", "PatientID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology");

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

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "SHPatientRadiology",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicID",
                table: "SHPatientRadiology",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology",
                column: "RadioID");
        }
    }
}
