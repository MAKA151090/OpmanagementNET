using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HealthCare.Models
{
    public class PayrollModel
    {
        public PayrollModel() { }

        private string payrollID;
        private string staffID;
        private string staffName;
        private string payPeriod;
        private string basicSalary;
        private string bonus;
        private string providentFund;
        private string taxDeduction;
        private string allowances;
        private string grossSalary;
        private string netSalary;
        private string paymentDate;
        private string paymentStatus;
        private string remark;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUpdatedDate;
        private string hRA;
        private string isDelete;

        public string PayrollID { get => payrollID; set => payrollID = value; }
        public string StaffID { get => staffID; set => staffID = value; }
        public string? StaffName { get => staffName; set => staffName = value; }
        public string? PayPeriod { get => payPeriod; set => payPeriod = value; }
        public string? BasicSalary { get => basicSalary; set => basicSalary = value; }
        public string? Bonus { get => bonus; set => bonus = value; }
        public string? ProvidentFund { get => providentFund; set => providentFund = value; }
        public string? TaxDeduction { get => taxDeduction; set => taxDeduction = value; }
        public string? Allowances { get => allowances; set => allowances = value; }
        public string? GrossSalary { get => grossSalary; set => grossSalary = value; }
        public string? NetSalary { get => netSalary; set => netSalary = value; }
        public string? PaymentDate { get => paymentDate; set => paymentDate = value; }
        public string? PaymentStatus { get => paymentStatus; set => paymentStatus = value; }
        public string? Remark { get => remark; set => remark = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public string? HRA { get => hRA; set => hRA = value; }
        public string IsDelete { get => isDelete; set => isDelete = value; }
    }
}
