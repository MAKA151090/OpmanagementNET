using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intialv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHclnOtSummaryMaster",
                columns: table => new
                {
                    QuestionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnOtSummaryMaster", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "SHOTsummary",
                columns: table => new
                {
                    OtscheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOTsummary", x => x.OtscheduleID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnOtSummaryMaster");

            migrationBuilder.DropTable(
                name: "SHOTsummary");
        }
    }
}
