using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHUpdateRadiologyResult",
                table: "SHUpdateRadiologyResult");

            migrationBuilder.AlterColumn<string>(
                name: "ImageID",
                table: "SHUpdateRadiologyResult",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHUpdateRadiologyResult",
                table: "SHUpdateRadiologyResult",
                columns: new[] { "PatientID", "FacilityID", "RadioID", "ImageID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHUpdateRadiologyResult",
                table: "SHUpdateRadiologyResult");

            migrationBuilder.AlterColumn<string>(
                name: "ImageID",
                table: "SHUpdateRadiologyResult",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHUpdateRadiologyResult",
                table: "SHUpdateRadiologyResult",
                columns: new[] { "PatientID", "FacilityID", "RadioID" });
        }
    }
}
