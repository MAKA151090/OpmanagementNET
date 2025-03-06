using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromHour",
                table: "SHclnStaffFacilityMapping");

            migrationBuilder.DropColumn(
                name: "ToHour",
                table: "SHclnStaffFacilityMapping");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "SHclnStaffFacilityMapping",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityID",
                table: "SHclnStaffFacilityMapping",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Hospital",
                table: "SHclnStaffFacilityMapping",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hospital",
                table: "SHclnStaffFacilityMapping");

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "SHclnStaffFacilityMapping",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityID",
                table: "SHclnStaffFacilityMapping",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FromHour",
                table: "SHclnStaffFacilityMapping",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ToHour",
                table: "SHclnStaffFacilityMapping",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
