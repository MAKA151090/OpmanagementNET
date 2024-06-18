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

        public string EmpStaffID { get => empStaffID; set => empStaffID = value; }
        public string MgrStaffID { get => mgrStaffID; set => mgrStaffID = value; }
        public string ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
