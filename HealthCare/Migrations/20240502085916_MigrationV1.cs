using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StrlastUpdatedUser",
                table: "objPatientObjective",
                newName: "lastUpdatedUser");

            migrationBuilder.RenameColumn(
                name: "StrlastUpdatedDate",
                table: "objPatientObjective",
                newName: "lastUpdatedDate");

            migrationBuilder.RenameColumn(
                name: "StrWeight",
                table: "objPatientObjective",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "StrVisitDate",
                table: "objPatientObjective",
                newName: "VisitDate");

            migrationBuilder.RenameColumn(
                name: "StrTemperature",
                table: "objPatientObjective",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "StrResptryRate",
                table: "objPatientObjective",
                newName: "ResptryRate");

            migrationBuilder.RenameColumn(
                name: "StrPulseRate",
                table: "objPatientObjective",
                newName: "PulseRate");

            migrationBuilder.RenameColumn(
                name: "StrPatientID",
                table: "objPatientObjective",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "StrOxySat",
                table: "objPatientObjective",
                newName: "OxySat");

            migrationBuilder.RenameColumn(
                name: "StrHeight",
                table: "objPatientObjective",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "StrHeartRate",
                table: "objPatientObjective",
                newName: "HeartRate");

            migrationBuilder.RenameColumn(
                name: "StrClinicID",
                table: "objPatientObjective",
                newName: "ClinicID");

            migrationBuilder.RenameColumn(
                name: "StrCheifComplaint",
                table: "objPatientObjective",
                newName: "CheifComplaint");

            migrationBuilder.RenameColumn(
                name: "StrBloodPressure",
                table: "objPatientObjective",
                newName: "BloodPressure");

            migrationBuilder.RenameColumn(
                name: "StrBldGluLvl",
                table: "objPatientObjective",
                newName: "BldGluLvl");

            migrationBuilder.RenameColumn(
                name: "StrVisitID",
                table: "objPatientObjective",
                newName: "VisitID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastUpdatedUser",
                table: "objPatientObjective",
                newName: "StrlastUpdatedUser");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedDate",
                table: "objPatientObjective",
                newName: "StrlastUpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "objPatientObjective",
                newName: "StrWeight");

            migrationBuilder.RenameColumn(
                name: "VisitDate",
                table: "objPatientObjective",
                newName: "StrVisitDate");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "objPatientObjective",
                newName: "StrTemperature");

            migrationBuilder.RenameColumn(
                name: "ResptryRate",
                table: "objPatientObjective",
                newName: "StrResptryRate");

            migrationBuilder.RenameColumn(
                name: "PulseRate",
                table: "objPatientObjective",
                newName: "StrPulseRate");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "objPatientObjective",
                newName: "StrPatientID");

            migrationBuilder.RenameColumn(
                name: "OxySat",
                table: "objPatientObjective",
                newName: "StrOxySat");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "objPatientObjective",
                newName: "StrHeight");

            migrationBuilder.RenameColumn(
                name: "HeartRate",
                table: "objPatientObjective",
                newName: "StrHeartRate");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "objPatientObjective",
                newName: "StrClinicID");

            migrationBuilder.RenameColumn(
                name: "CheifComplaint",
                table: "objPatientObjective",
                newName: "StrCheifComplaint");

            migrationBuilder.RenameColumn(
                name: "BloodPressure",
                table: "objPatientObjective",
                newName: "StrBloodPressure");

            migrationBuilder.RenameColumn(
                name: "BldGluLvl",
                table: "objPatientObjective",
                newName: "StrBldGluLvl");

            migrationBuilder.RenameColumn(
                name: "VisitID",
                table: "objPatientObjective",
                newName: "StrVisitID");
        }
    }
}
