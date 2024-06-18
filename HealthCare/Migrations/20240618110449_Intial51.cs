using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance");

            migrationBuilder.AddColumn<string>(
                name: "AttendanceID",
                table: "SHStaffAttendance",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SHStaffAttendance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance",
                columns: new[] { "StaffID", "Date", "AttendanceID" });

            migrationBuilder.CreateTable(
                name: "SHBankdetails",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHBankdetails", x => new { x.StaffID, x.AccountNumber });
                });

            migrationBuilder.CreateTable(
                name: "SHCategoryMaster",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHCategoryMaster", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SHCustomerBilling",
                columns: table => new
                {
                    BillID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Items = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryBasedDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHCustomerBilling", x => new { x.BillID, x.CustomerNumber });
                });

            migrationBuilder.CreateTable(
                name: "SHCustomerMaster",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsReedem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHCustomerMaster", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "SHDiscountCategory",
                columns: table => new
                {
                    DiscountPrice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHDiscountCategory", x => x.DiscountPrice);
                });

            migrationBuilder.CreateTable(
                name: "SHEmpHierarchy",
                columns: table => new
                {
                    EmpStaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MgrStaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHEmpHierarchy", x => new { x.EmpStaffID, x.MgrStaffID });
                });

            migrationBuilder.CreateTable(
                name: "SHGSTMaster",
                columns: table => new
                {
                    SGST = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CGST = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OtherTax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHGSTMaster", x => new { x.SGST, x.CGST });
                });

            migrationBuilder.CreateTable(
                name: "SHLeaveTypeMaster",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHLeaveTypeMaster", x => new { x.StaffID, x.LeaveType });
                });

            migrationBuilder.CreateTable(
                name: "SHpayroll",
                columns: table => new
                {
                    PayrollID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvidentFund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxDeduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allowances = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HRA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHpayroll", x => new { x.StaffID, x.PayrollID });
                });

            migrationBuilder.CreateTable(
                name: "SHpayrollTax",
                columns: table => new
                {
                    PayrollID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDelete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHpayrollTax", x => new { x.PayrollID, x.TaxID, x.StaffID });
                });

            migrationBuilder.CreateTable(
                name: "SHProductMaster",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brandname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHProductMaster", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "SHStaffLeave",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeaveID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUppdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHStaffLeave", x => new { x.LeaveID, x.StaffID, x.LeaveType });
                });

            migrationBuilder.CreateTable(
                name: "SHTaxModel",
                columns: table => new
                {
                    TaxID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicablePeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHTaxModel", x => new { x.TaxID, x.TaxType });
                });

            migrationBuilder.CreateTable(
                name: "SHVoucherDetails",
                columns: table => new
                {
                    VoucherID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedmachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHVoucherDetails", x => x.VoucherID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHBankdetails");

            migrationBuilder.DropTable(
                name: "SHCategoryMaster");

            migrationBuilder.DropTable(
                name: "SHCustomerBilling");

            migrationBuilder.DropTable(
                name: "SHCustomerMaster");

            migrationBuilder.DropTable(
                name: "SHDiscountCategory");

            migrationBuilder.DropTable(
                name: "SHEmpHierarchy");

            migrationBuilder.DropTable(
                name: "SHGSTMaster");

            migrationBuilder.DropTable(
                name: "SHLeaveTypeMaster");

            migrationBuilder.DropTable(
                name: "SHpayroll");

            migrationBuilder.DropTable(
                name: "SHpayrollTax");

            migrationBuilder.DropTable(
                name: "SHProductMaster");

            migrationBuilder.DropTable(
                name: "SHStaffLeave");

            migrationBuilder.DropTable(
                name: "SHTaxModel");

            migrationBuilder.DropTable(
                name: "SHVoucherDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance");

            migrationBuilder.DropColumn(
                name: "AttendanceID",
                table: "SHStaffAttendance");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SHStaffAttendance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHStaffAttendance",
                table: "SHStaffAttendance",
                columns: new[] { "StaffID", "Date" });
        }
    }
}
