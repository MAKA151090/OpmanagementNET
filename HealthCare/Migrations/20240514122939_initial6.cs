using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial6 : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmPatientFHPH1",
                table: "SHExmPatientFHPH1");

            migrationBuilder.DropColumn(
                name: "BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.DropColumn(
                name: "BloodGroupModelIntBg_Id",
                table: "SHclnBloodGroup");

            migrationBuilder.RenameTable(
                name: "SHExmPatientFHPH1",
                newName: "PatientFHPHModel1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientFHPHModel1",
                table: "PatientFHPHModel1",
                columns: new[] { "PatientID", "Question", "Type" });

            migrationBuilder.CreateTable(
                name: "SHPatientSchedule",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientSchedule", x => x.PatientID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHPatientSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientFHPHModel1",
                table: "PatientFHPHModel1");

            migrationBuilder.RenameTable(
                name: "PatientFHPHModel1",
                newName: "SHExmPatientFHPH1");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmPatientFHPH1",
                table: "SHExmPatientFHPH1",
                columns: new[] { "PatientID", "Question", "Type" });

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
