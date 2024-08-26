using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial68 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Template",
                table: "SHprsPrescription");

            migrationBuilder.AddColumn<string>(
                name: "Template",
                table: "SHclnClinicAdmin",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Template",
                table: "SHclnClinicAdmin");

            migrationBuilder.AddColumn<string>(
                name: "Template",
                table: "SHprsPrescription",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
