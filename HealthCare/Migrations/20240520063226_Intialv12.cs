using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intialv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHipmInpatientobservation",
                table: "SHipmInpatientobservation");

            migrationBuilder.AlterColumn<string>(
                name: "ObservationTypeID",
                table: "SHipmInpatientobservation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHipmInpatientobservation",
                table: "SHipmInpatientobservation",
                columns: new[] { "PatientID", "ObservationID", "BedNoID", "ObservationTypeID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHipmInpatientobservation",
                table: "SHipmInpatientobservation");

            migrationBuilder.AlterColumn<string>(
                name: "ObservationTypeID",
                table: "SHipmInpatientobservation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHipmInpatientobservation",
                table: "SHipmInpatientobservation",
                columns: new[] { "PatientID", "ObservationID", "BedNoID" });
        }
    }
}
