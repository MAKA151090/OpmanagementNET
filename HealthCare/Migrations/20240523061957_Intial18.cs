using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authorized",
                table: "SHClnScreenMaster");

            migrationBuilder.DropColumn(
                name: "ReadWriteAccess",
                table: "SHClnScreenMaster");

            migrationBuilder.AddColumn<string>(
                name: "Authorized",
                table: "SHClnRollAccess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authorized",
                table: "SHClnRollAccess");

            migrationBuilder.AddColumn<string>(
                name: "Authorized",
                table: "SHClnScreenMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadWriteAccess",
                table: "SHClnScreenMaster",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
