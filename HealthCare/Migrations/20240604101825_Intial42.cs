using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "SHStaffAttendance",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance",
                columns: new[] { "StaffID", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "SHStaffAttendance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance",
                column: "StaffID");
        }
    }
}
