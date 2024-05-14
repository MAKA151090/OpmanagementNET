using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHclnBloodGroup_SHclnBloodGroup_BloodGroupModelIntBg_Id_BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.DropIndex(
                name: "IX_SHclnBloodGroup_BloodGroupModelIntBg_Id_BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.DropColumn(
                name: "BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.DropColumn(
                name: "BloodGroupModelIntBg_Id",
                table: "SHclnBloodGroup");

            migrationBuilder.CreateTable(
                name: "SHclnDoctorAdmin",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedialLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnDoctorAdmin", x => x.DoctorID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnDoctorAdmin");

            migrationBuilder.AddColumn<string>(
                name: "BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroupModelIntBg_Id",
                table: "SHclnBloodGroup",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SHclnBloodGroup_BloodGroupModelIntBg_Id_BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup",
                columns: new[] { "BloodGroupModelIntBg_Id", "BloodGroupModelBloodGroup" });

            migrationBuilder.AddForeignKey(
                name: "FK_SHclnBloodGroup_SHclnBloodGroup_BloodGroupModelIntBg_Id_BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup",
                columns: new[] { "BloodGroupModelIntBg_Id", "BloodGroupModelBloodGroup" },
                principalTable: "SHclnBloodGroup",
                principalColumns: new[] { "IntBg_Id", "BloodGroup" });
        }
    }
}
