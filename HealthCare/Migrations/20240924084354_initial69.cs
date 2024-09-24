using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial69 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription");

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "SHprsPrescription",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription",
                columns: new[] { "PatientID", "CaseVisitID", "DrugID", "FacilityID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription");

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "SHprsPrescription",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHprsPrescription",
                table: "SHprsPrescription",
                columns: new[] { "PatientID", "CaseVisitID", "OrderID", "DrugID", "FacilityID" });
        }
    }
}
