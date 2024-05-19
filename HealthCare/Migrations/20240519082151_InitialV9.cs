using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class InitialV9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SHclnDiagnosisMaster",
                columns: table => new
                {
                    DiagnosisID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiagnosisCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICDCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WHODescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnDiagnosisMaster", x => x.DiagnosisID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnProcedureCodeMaster",
                columns: table => new
                {
                    ProcedureID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPTCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureCodeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WHODescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureCodeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnProcedureCodeMaster", x => x.ProcedureID);
                });

            migrationBuilder.CreateTable(
                name: "SHHospitalFacilityMapping",
                columns: table => new
                {
                    HospitalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacilityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHHospitalFacilityMapping", x => new { x.HospitalID, x.FacilityID });
                });

            migrationBuilder.CreateTable(
                name: "SHHospitalRegistration",
                columns: table => new
                {
                    HospitalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHHospitalRegistration", x => x.HospitalID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnDiagnosisMaster");

            migrationBuilder.DropTable(
                name: "SHclnProcedureCodeMaster");

            migrationBuilder.DropTable(
                name: "SHHospitalFacilityMapping");

            migrationBuilder.DropTable(
                name: "SHHospitalRegistration");
        }
    }
}
