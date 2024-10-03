using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

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
        private bool isDelete;


        [MaxLength(100)]
        public string PayrollID { get => payrollID; set => payrollID = value; }

        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }

        [MaxLength(30)]
        public string? StaffName { get => staffName; set => staffName = value; }

        [MaxLength(30)]
        public string? PayPeriod { get => payPeriod; set => payPeriod = value; }

        [MaxLength(30)]
        public string? BasicSalary { get => basicSalary; set => basicSalary = value; }

        [MaxLength(30)]
        public string? Bonus { get => bonus; set => bonus = value; }

        [MaxLength(30)]
        public string? ProvidentFund { get => providentFund; set => providentFund = value; }

        [MaxLength(30)]
        public string? TaxDeduction { get => taxDeduction; set => taxDeduction = value; }

        [MaxLength(30)]
        public string? Allowances { get => allowances; set => allowances = value; }

        [MaxLength(30)]
        public string? GrossSalary { get => grossSalary; set => grossSalary = value; }

        [MaxLength(30)]
        public string? NetSalary { get => netSalary; set => netSalary = value; }

        [MaxLength(30)]
        public string? PaymentDate { get => paymentDate; set => paymentDate = value; }

        [MaxLength(30)]
        public string? PaymentStatus { get => paymentStatus; set => paymentStatus = value; }


        [MaxLength(30)]
        public string? Remark { get => remark; set => remark = value; }

        [MaxLength(30)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }

        [MaxLength(30)]
        public string? HRA { get => hRA; set => hRA = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
