using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_objPatientObjective",
                table: "objPatientObjective");

            migrationBuilder.RenameTable(
                name: "objPatientObjective",
                newName: "SHExmPatientObjective");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "SHExmPatientObjective",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmPatientObjective",
                table: "SHExmPatientObjective",
                columns: new[] { "PatientID", "ClinicID", "VisitID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmPatientObjective",
                table: "SHExmPatientObjective");

            migrationBuilder.RenameTable(
                name: "SHExmPatientObjective",
                newName: "objPatientObjective");

            migrationBuilder.AlterColumn<string>(
                name: "lastUpdatedDate",
                table: "objPatientObjective",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_objPatientObjective",
                table: "objPatientObjective",
                columns: new[] { "PatientID", "ClinicID", "VisitID" });
        }
    }
}
