using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHExmPatientFHPH1",
                table: "SHExmPatientFHPH1");

            migrationBuilder.RenameTable(
                name: "SHExmPatientFHPH1",
                newName: "PatientFHPHModel1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientFHPHModel1",
                table: "PatientFHPHModel1",
                columns: new[] { "PatientID", "Question", "Type" });

            migrationBuilder.CreateTable(
                name: "SHclnBloodGroup",
                columns: table => new
                {
                    IntBg_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroupModelBloodGroup = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BloodGroupModelIntBg_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnBloodGroup", x => new { x.IntBg_Id, x.BloodGroup });
                    table.ForeignKey(
                        name: "FK_SHclnBloodGroup_SHclnBloodGroup_BloodGroupModelIntBg_Id_BloodGroupModelBloodGroup",
                        columns: x => new { x.BloodGroupModelIntBg_Id, x.BloodGroupModelBloodGroup },
                        principalTable: "SHclnBloodGroup",
                        principalColumns: new[] { "IntBg_Id", "BloodGroup" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHclnBloodGroup_BloodGroupModelIntBg_Id_BloodGroupModelBloodGroup",
                table: "SHclnBloodGroup",
                columns: new[] { "BloodGroupModelIntBg_Id", "BloodGroupModelBloodGroup" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnBloodGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientFHPHModel1",
                table: "PatientFHPHModel1");

            migrationBuilder.RenameTable(
                name: "PatientFHPHModel1",
                newName: "SHExmPatientFHPH1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHExmPatientFHPH1",
                table: "SHExmPatientFHPH1",
                columns: new[] { "PatientID", "Question", "Type" });
        }
    }
}
