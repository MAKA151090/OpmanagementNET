using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigModelFHPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmPatientFHPH1",
                table: "SHExmPatientFHPH1");

            migrationBuilder.RenameTable(
                name: "SHExmPatientFHPH1",
                newName: "PatientFHPHModel1");

            migrationBuilder.AddColumn<string>(
                name: "ClinicID",
                table: "SHExmPatientFHPH",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientFHPHModel1",
                table: "PatientFHPHModel1",
                columns: new[] { "PatientID", "Question", "Type" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientFHPHModel1",
                table: "PatientFHPHModel1");

            migrationBuilder.DropColumn(
                name: "ClinicID",
                table: "SHExmPatientFHPH");

            migrationBuilder.RenameTable(
                name: "PatientFHPHModel1",
                newName: "SHExmPatientFHPH1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmPatientFHPH1",
                table: "SHExmPatientFHPH1",
                columns: new[] { "PatientID", "Question", "Type" });
        }
    }
}
