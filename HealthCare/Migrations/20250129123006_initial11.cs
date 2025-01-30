using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMaster",
                table: "shdbscreenname",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "shdbscreenname",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMaster",
                table: "shdbscreenname");

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "shdbscreenname");
        }
    }
}
