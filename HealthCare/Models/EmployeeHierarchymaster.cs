using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class EmployeeHierarchymaster
    {
        public EmployeeHierarchymaster() { }

        private string empStaffID;
        private string mgrStaffID;
        private string expiryDate;
        private string lastUpdatedUser;
        private string lastUpdatedDate;
        private string lastUpdatedMachine;



        [MaxLength(100)]
        public string EmpStaffID { get => empStaffID; set => empStaffID = value; }
        [MaxLength(100)]
        public string MgrStaffID { get => mgrStaffID; set => mgrStaffID = value; }

        [MaxLength(30)]
        public string? ExpiryDate { get => expiryDate; set => expiryDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
