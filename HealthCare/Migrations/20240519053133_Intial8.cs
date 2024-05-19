using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHipmInPatientDocVisit",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BedId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHipmInPatientDocVisit", x => new { x.PatientId, x.CaseId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHipmInPatientDocVisit");
        }
    }
}
