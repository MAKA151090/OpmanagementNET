using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial66 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SHstkDrugType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SHstkDrugInventory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SHstkDrugGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SHstkDrugCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SHPatientRegistration",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SHclnStaffAdminModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SHstkDrugType");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SHstkDrugInventory");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SHstkDrugGroup");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SHstkDrugCategory");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SHPatientRegistration");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SHclnStaffAdminModel");
        }
    }
}
