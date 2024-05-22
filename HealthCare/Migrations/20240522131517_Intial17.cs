using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHcllDoctorScheduleModel",
                table: "SHcllDoctorScheduleModel");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "SHExmPatientFHPH");

            migrationBuilder.RenameTable(
                name: "SHcllDoctorScheduleModel",
                newName: "DoctorScheduleModel");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "DoctorScheduleModel",
                newName: "lastUpdatedMachine");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "DoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Holiday",
                table: "DoctorScheduleModel",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "DoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "DoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Blocker",
                table: "DoctorScheduleModel",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "DoctorScheduleModel",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "DoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorScheduleModel",
                table: "DoctorScheduleModel",
                columns: new[] { "PatientID", "FacilityID", "SlotsID" });

            migrationBuilder.CreateTable(
                name: "SHclnViewResourceSchedule",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacilityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slots = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnViewResourceSchedule", x => new { x.StaffID, x.FacilityID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnViewResourceSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorScheduleModel",
                table: "DoctorScheduleModel");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "DoctorScheduleModel");

            migrationBuilder.RenameTable(
                name: "DoctorScheduleModel",
                newName: "SHcllDoctorScheduleModel");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedMachine",
                table: "SHcllDoctorScheduleModel",
                newName: "DoctorID");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "SHExmPatientFHPH",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "SHcllDoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Holiday",
                table: "SHcllDoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "SHcllDoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "SHcllDoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Blocker",
                table: "SHcllDoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "SHcllDoctorScheduleModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHcllDoctorScheduleModel",
                table: "SHcllDoctorScheduleModel",
                columns: new[] { "PatientID", "FacilityID", "SlotsID" });
        }
    }
}
