using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class EmployeePayrollModel
    {
        public EmployeePayrollModel() { }

        private string payrollID;
        private string month;
        private string year;
        private string staffID;
        private string payheadType;
        private string amount;
        private string total;
        private String lastUpdatedUser;
        private String lastUpdatedDate;
        private String lastUpdatedMachine;
        private string facilityID;
        private long id;
        private bool isDelete;

        [MaxLength(100)]
        public string PayrollID { get => payrollID; set => payrollID = value; }

      

        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }

        [MaxLength(100)]
        public string PayheadType { get => payheadType; set => payheadType = value; }

        [MaxLength(50)]
        public string? Amount { get => amount; set => amount = value; }

        [MaxLength(50)]
        public string? Total { get => total; set => total = value; }

        [MaxLength(50)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(50)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }

        [MaxLength(50)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }

        [MaxLength(50)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public long Id { get => id; set => id = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        public string Month { get => month; set => month = value; }
        public string Year { get => year; set => year = value; }
    }
}
