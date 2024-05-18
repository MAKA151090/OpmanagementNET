using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class InitialV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHClnRollAccess",
                columns: table => new
                {
                    RollID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScreenID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHClnRollAccess", x => x.RollID);
                });

            migrationBuilder.CreateTable(
                name: "SHClnScreenMaster",
                columns: table => new
                {
                    ScreenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHClnScreenMaster", x => x.ScreenId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHClnRollAccess");

            migrationBuilder.DropTable(
                name: "SHClnScreenMaster");
        }
    }
}
