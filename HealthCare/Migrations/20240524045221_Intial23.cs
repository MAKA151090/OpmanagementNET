using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHclnResourseTypeMaster",
                columns: table => new
                {
                    ResourceTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResourceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnResourseTypeMaster", x => x.ResourceTypeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnResourseTypeMaster");
        }
    }
}
