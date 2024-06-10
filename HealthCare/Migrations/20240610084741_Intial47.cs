using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "SHPatientBillDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SHPatientPayment",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CaseVisitID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BillID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPaymentAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientPayment", x => new { x.PaymentID, x.PatientID, x.CaseVisitID });
                });

            migrationBuilder.CreateTable(
                name: "SHPatientPaymentBillDetails",
                columns: table => new
                {
                    PaymentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentDetailID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateandTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountPaid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDelte = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHPatientPaymentBillDetails", x => new { x.PaymentID, x.PaymentDetailID });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHPatientPayment");

            migrationBuilder.DropTable(
                name: "SHPatientPaymentBillDetails");

            migrationBuilder.AlterColumn<string>(
                name: "IsDelete",
                table: "SHPatientBillDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
