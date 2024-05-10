using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "objPatientObjective",
                columns: table => new
                {
                    StrVisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrPatientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrClinicID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrBloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrHeartRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrTemperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrResptryRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrOxySat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrPulseRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrVisitDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrBldGluLvl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrCheifComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrlastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrlastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objPatientObjective", x => x.StrVisitID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objPatientObjective");
        }
    }
}
