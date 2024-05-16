using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology");

            migrationBuilder.AlterColumn<string>(
                name: "ScreeningDate",
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
                columns: new[] { "RadioID", "ClinicID", "PatientID", "ScreeningDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology");

            migrationBuilder.AlterColumn<string>(
                name: "ScreeningDate",
                table: "SHPatientRadiology",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRadiology",
                table: "SHPatientRadiology",
                columns: new[] { "RadioID", "ClinicID", "PatientID" });
        }
    }
}
