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
            migrationBuilder.CreateTable(
                name: "SHclnClinicAdmin",
                columns: table => new
                {
                    ClinicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHclnClinicAdmin", x => x.ClinicId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHclnClinicAdmin");
        }
    }
}
