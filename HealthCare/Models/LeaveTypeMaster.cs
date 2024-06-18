namespace HealthCare.Models
{
    public class LeaveTypeMaster
    {
        public LeaveTypeMaster() { }

        private string staffID;
        private string leaveType;
        private string total;
        private string balance;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUpdatedDate;

        public string StaffID { get => staffID; set => staffID = value; }
        public string LeaveType { get => leaveType; set => leaveType = value; }
        public string Total { get => total; set => total = value; }
        public string Balance { get => balance; set => balance = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
    }
}
