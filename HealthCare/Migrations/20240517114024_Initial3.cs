using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnHospitalBedMaster");

            migrationBuilder.DropTable(
                name: "SHclnIPTypeMaster");

            migrationBuilder.DropTable(
                name: "SHclnNurseStationMaster");

            migrationBuilder.DropTable(
                name: "SHclnRoomTypeMaster");

            migrationBuilder.DropTable(
                name: "SHInpatientAdmission");

            migrationBuilder.DropTable(
                name: "SHotSurgerymaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHotDepartmentMaster",
                table: "SHotDepartmentMaster");

            migrationBuilder.RenameTable(
                name: "SHotDepartmentMaster",
                newName: "SHotInternalDepartmentMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHotInternalDepartmentMaster",
                table: "SHotInternalDepartmentMaster",
                column: "DepartmentID");

            migrationBuilder.CreateTable(
                name: "SHotSurgerTypeymaster",
                columns: table => new
                {
                    SurgeryTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotSurgerTypeymaster", x => x.SurgeryTypeID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHotSurgerTypeymaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHotInternalDepartmentMaster",
                table: "SHotInternalDepartmentMaster");

            migrationBuilder.RenameTable(
                name: "SHotInternalDepartmentMaster",
                newName: "SHotDepartmentMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHotDepartmentMaster",
                table: "SHotDepartmentMaster",
                column: "DepartmentID");

            migrationBuilder.CreateTable(
                name: "SHclnHospitalBedMaster",
                columns: table => new
                {
                    BedID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostPerDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseStationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFloor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnHospitalBedMaster", x => x.BedID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnIPTypeMaster",
                columns: table => new
                {
                    IPTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnIPTypeMaster", x => x.IPTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnNurseStationMaster",
                columns: table => new
                {
                    NurseStationID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnNurseStationMaster", x => x.NurseStationID);
                });

            migrationBuilder.CreateTable(
                name: "SHclnRoomTypeMaster",
                columns: table => new
                {
                    RoomTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdditionFeature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnRoomTypeMaster", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHInpatientAdmission",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdditionConsultDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttenderContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultantDepartmentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DutyDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InpatientType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferredByDoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHInpatientAdmission", x => new { x.PatientID, x.CaseID });
                });

            migrationBuilder.CreateTable(
                name: "SHotSurgerymaster",
                columns: table => new
                {
                    SurgeryTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotSurgerymaster", x => x.SurgeryTypeID);
                });
        }
    }
}
