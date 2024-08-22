using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial63 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnStaffAdminModel",
                table: "SHclnStaffAdminModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHstkDrugInventory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityID",
                table: "SHPatientRegistration",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "shdbscreenname",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHclnStaffAdminModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroup",
                table: "SHclnBloodGroup",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory",
                columns: new[] { "DrugId", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration",
                columns: new[] { "PatientID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnStaffAdminModel",
                table: "SHclnStaffAdminModel",
                columns: new[] { "StrStaffID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup",
                column: "IntBg_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnStaffAdminModel",
                table: "SHclnStaffAdminModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHstkDrugInventory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "shdbscreenname");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHclnStaffAdminModel");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityID",
                table: "SHPatientRegistration",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BloodGroup",
                table: "SHclnBloodGroup",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory",
                column: "DrugId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration",
                column: "PatientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnStaffAdminModel",
                table: "SHclnStaffAdminModel",
                column: "StrStaffID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup",
                columns: new[] { "IntBg_Id", "BloodGroup" });
        }
    }
}
