using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHipmInPatientTransferUpdate",
                table: "SHipmInPatientTransferUpdate");

            migrationBuilder.AlterColumn<string>(
                name: "TranferID",
                table: "SHipmInPatientTransferUpdate",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHipmInPatientTransferUpdate",
                table: "SHipmInPatientTransferUpdate",
                columns: new[] { "PatientId", "CaseId", "BedId", "TranferID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHipmInPatientTransferUpdate",
                table: "SHipmInPatientTransferUpdate");

            migrationBuilder.AlterColumn<string>(
                name: "TranferID",
                table: "SHipmInPatientTransferUpdate",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHipmInPatientTransferUpdate",
                table: "SHipmInPatientTransferUpdate",
                columns: new[] { "PatientId", "CaseId", "BedId" });
        }
    }
}
