using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial72 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory");

            migrationBuilder.AlterColumn<string>(
                name: "DrugId",
                table: "SHstkDrugInventory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "SHstkDrugInventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "101, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory",
                columns: new[] { "Id", "FacilityID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SHstkDrugInventory");

            migrationBuilder.AlterColumn<string>(
                name: "DrugId",
                table: "SHstkDrugInventory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugInventory",
                table: "SHstkDrugInventory",
                columns: new[] { "DrugId", "FacilityID" });
        }
    }
}
