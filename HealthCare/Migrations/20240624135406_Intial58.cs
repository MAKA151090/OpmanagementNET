using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial58 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShclnrollAccessmaster",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RollName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastupdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastupdateduser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShclnrollAccessmaster", x => new { x.StaffID, x.RollName });
                });

            migrationBuilder.CreateTable(
                name: "Shclnrolltypemaster",
                columns: table => new
                {
                    RollID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shclnrolltypemaster", x => x.RollID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShclnrollAccessmaster");

            migrationBuilder.DropTable(
                name: "Shclnrolltypemaster");
        }
    }
}
