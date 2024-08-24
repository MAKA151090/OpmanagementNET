using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial65 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StrIsDelete",
                table: "SHclnResourseTypeMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StrIsDelete",
                table: "SHclnClinicAdmin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StrIsDelete",
                table: "SHclnBloodGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrIsDelete",
                table: "SHclnResourseTypeMaster");

            migrationBuilder.DropColumn(
                name: "StrIsDelete",
                table: "SHclnClinicAdmin");

            migrationBuilder.DropColumn(
                name: "StrIsDelete",
                table: "SHclnBloodGroup");
        }
    }
}
