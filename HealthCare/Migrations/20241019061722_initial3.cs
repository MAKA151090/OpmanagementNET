using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest");

            migrationBuilder.RenameColumn(
                name: "VisitcaseID1",
                table: "SHPatientTest",
                newName: "VisitcaseID");

            migrationBuilder.UpdateData(
                table: "SHPatientTest",
                keyColumn: "TsampleCltDateTime",
                keyValue: null,
                column: "TsampleCltDateTime",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TsampleCltDateTime",
                table: "SHPatientTest",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TestDateTime",
                table: "SHPatientTest",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest",
                columns: new[] { "PatientID", "FacilityID", "TestID", "TsampleCltDateTime", "VisitcaseID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest");

            migrationBuilder.RenameColumn(
                name: "VisitcaseID",
                table: "SHPatientTest",
                newName: "VisitcaseID1");

            migrationBuilder.UpdateData(
                table: "SHPatientTest",
                keyColumn: "TestDateTime",
                keyValue: null,
                column: "TestDateTime",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TestDateTime",
                table: "SHPatientTest",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TsampleCltDateTime",
                table: "SHPatientTest",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientTest",
                table: "SHPatientTest",
                columns: new[] { "PatientID", "FacilityID", "TestID", "TestDateTime" });
        }
    }
}
