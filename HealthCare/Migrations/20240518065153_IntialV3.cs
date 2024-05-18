using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class IntialV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnDoctorAdmin");

            migrationBuilder.CreateTable(
                name: "SHclnStaffAdminModel",
                columns: table => new
                {
                    StrStaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrInitial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrDateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIdProofId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIdProofName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMedialLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastupdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnStaffAdminModel", x => x.StrStaffID);
                });

            migrationBuilder.CreateTable(
                name: "SHStaffAttendance",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckInTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckOuTtime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHStaffAttendance", x => x.StaffID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnStaffAdminModel");

            migrationBuilder.DropTable(
                name: "SHStaffAttendance");

            migrationBuilder.CreateTable(
                name: "SHclnDoctorAdmin",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedialLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnDoctorAdmin", x => x.DoctorID);
                });
        }
    }
}
