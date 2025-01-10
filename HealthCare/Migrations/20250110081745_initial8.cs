using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHemployeeattendance",
                table: "SHemployeeattendance");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHemployeeattendance",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHemployeeattendance",
                table: "SHemployeeattendance",
                columns: new[] { "StaffID", "LeaveName", "Month", "Year", "FacilityID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHemployeeattendance",
                table: "SHemployeeattendance");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHemployeeattendance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHemployeeattendance",
                table: "SHemployeeattendance",
                columns: new[] { "StaffID", "LeaveName", "Month", "Year" });
        }
    }
}
