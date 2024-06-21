using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHpayrollTax",
                table: "SHpayrollTax");

            migrationBuilder.AlterColumn<string>(
                name: "Taxtype",
                table: "SHpayrollTax",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "TaxSlotID",
                table: "SHpayrollTax",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHpayrollTax",
                table: "SHpayrollTax",
                columns: new[] { "PayrollID", "TaxSlotID", "StaffID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHpayrollTax",
                table: "SHpayrollTax");

            migrationBuilder.DropColumn(
                name: "TaxSlotID",
                table: "SHpayrollTax");

            migrationBuilder.AlterColumn<string>(
                name: "Taxtype",
                table: "SHpayrollTax",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHpayrollTax",
                table: "SHpayrollTax",
                columns: new[] { "PayrollID", "Taxtype", "StaffID" });
        }
    }
}
