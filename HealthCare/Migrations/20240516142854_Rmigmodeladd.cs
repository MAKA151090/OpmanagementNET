using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Rmigmodeladd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtSurgeryModel",
                columns: table => new
                {
                    OtScheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtSurgeryModel", x => new { x.OtScheduleID, x.SurgeryID });
                });

            migrationBuilder.CreateTable(
                name: "SHclnSurgeryMaster",
                columns: table => new
                {
                    SurgeryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurgeryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnSurgeryMaster", x => x.SurgeryID);
                });

            migrationBuilder.CreateTable(
                name: "SHotDepartmentMaster",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotDepartmentMaster", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "SHotNotes",
                columns: table => new
                {
                    OtScheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntraOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalOtNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreOtAnesthesiaNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntraOtAnesthesiaNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOtAnesthesiaNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservationNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotNotes", x => x.OtScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "SHotScheduling",
                columns: table => new
                {
                    OtScheduleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InchrgDepID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotScheduling", x => x.OtScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "SHotSurgerymaster",
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
                    table.PrimaryKey("PK_SHotSurgerymaster", x => x.SurgeryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SHotTableMaster",
                columns: table => new
                {
                    TableID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalFeature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHotTableMaster", x => x.TableID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtSurgeryModel");

            migrationBuilder.DropTable(
                name: "SHclnSurgeryMaster");

            migrationBuilder.DropTable(
                name: "SHotDepartmentMaster");

            migrationBuilder.DropTable(
                name: "SHotNotes");

            migrationBuilder.DropTable(
                name: "SHotScheduling");

            migrationBuilder.DropTable(
                name: "SHotSurgerymaster");

            migrationBuilder.DropTable(
                name: "SHotTableMaster");
        }
    }
}
