using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial71 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration");

            // Drop and recreate the 'Id' column with the new IDENTITY property
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SHPatientRegistration");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "SHPatientRegistration",
                type: "bigint",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "101, 1");

            // Alter 'PatientID' column to be nullable or non-nullable as needed
            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "SHPatientRegistration",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Re-add the primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration",
                columns: new[] { "Id", "FacilityID" });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration");

            // Drop the 'Id' column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SHPatientRegistration");

            // Recreate the 'Id' column without the IDENTITY property
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "SHPatientRegistration",
                type: "bigint",
                nullable: false,
                defaultValue: 0);

            // Restore 'PatientID' column to its original state
            migrationBuilder.AlterColumn<string>(
                name: "PatientID",
                table: "SHPatientRegistration",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Re-add the original primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_SHPatientRegistration",
                table: "SHPatientRegistration",
                columns: new[] { "PatientID", "FacilityID" });
        }

    }
}
