using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial49 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHotInternalDepartmentMaster",
                table: "SHotInternalDepartmentMaster");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityID",
                table: "SHotInternalDepartmentMaster",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHotInternalDepartmentMaster",
                table: "SHotInternalDepartmentMaster",
                columns: new[] { "DepartmentID", "FacilityID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHotInternalDepartmentMaster",
                table: "SHotInternalDepartmentMaster");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityID",
                table: "SHotInternalDepartmentMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHotInternalDepartmentMaster",
                table: "SHotInternalDepartmentMaster",
                column: "DepartmentID");
        }
    }
}
