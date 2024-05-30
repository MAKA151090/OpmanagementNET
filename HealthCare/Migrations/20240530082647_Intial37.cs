using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmSeverity",
                table: "SHExmSeverity");

            migrationBuilder.AlterColumn<string>(
                name: "Symptoms",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Severity",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmSeverity",
                table: "SHExmSeverity",
                columns: new[] { "PatientID", "FacilityID", "VisitID", "ExaminationID", "Symptoms" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmSeverity",
                table: "SHExmSeverity");

            migrationBuilder.AlterColumn<string>(
                name: "Severity",
                table: "SHExmSeverity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Symptoms",
                table: "SHExmSeverity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmSeverity",
                table: "SHExmSeverity",
                columns: new[] { "PatientID", "FacilityID", "VisitID", "ExaminationID", "Severity" });
        }
    }
}
