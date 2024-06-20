using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial53 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxID",
                table: "SHpayrollTax",
                newName: "Taxtype");

            migrationBuilder.AddColumn<string>(
                name: "Primary",
                table: "SHBankdetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Primary",
                table: "SHBankdetails");

            migrationBuilder.RenameColumn(
                name: "Taxtype",
                table: "SHpayrollTax",
                newName: "TaxID");
        }
    }
}
