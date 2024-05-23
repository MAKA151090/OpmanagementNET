using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorScheduleModel",
                table: "DoctorScheduleModel");

            migrationBuilder.RenameTable(
                name: "DoctorScheduleModel",
                newName: "SHclnResourceSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "StaffID",
                table: "SHclnResourceSchedule",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "SHclnResourceSchedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnResourceSchedule",
                table: "SHclnResourceSchedule",
                columns: new[] { "StaffID", "FacilityID", "SlotsID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnResourceSchedule",
                table: "SHclnResourceSchedule");

            migrationBuilder.RenameTable(
                name: "SHclnResourceSchedule",
                newName: "DoctorScheduleModel");

            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "DoctorScheduleModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaffID",
                table: "DoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorScheduleModel",
                table: "DoctorScheduleModel",
                columns: new[] { "PatientID", "FacilityID", "SlotsID" });
        }
    }
}
