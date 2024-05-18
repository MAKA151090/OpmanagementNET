using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class IntialV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHclnEWSMaster",
                columns: table => new
                {
                    ObservationTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ObservationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnEWSMaster", x => x.ObservationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHipmInpatientobservation",
                columns: table => new
                {
                    BedNoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ObservationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NurseID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHipmInpatientobservation", x => new { x.PatientID, x.ObservationID, x.BedNoID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnEWSMaster");

            migrationBuilder.DropTable(
                name: "SHipmInpatientobservation");
        }
    }
}
