using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigUpdTestDatePk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest");

            migrationBuilder.AlterColumn<string>(
                name: "TestDateTime",
                table: "SHPatientTest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest",
                columns: new[] { "PatientID", "ClinicID", "TestID", "TestDateTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest");

            migrationBuilder.AlterColumn<string>(
                name: "TestDateTime",
                table: "SHPatientTest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest",
                columns: new[] { "PatientID", "ClinicID", "TestID" });
        }
    }
}
