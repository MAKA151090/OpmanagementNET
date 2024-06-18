namespace HealthCare.Models
{
    public class StaffLeaveModel
    {
        public StaffLeaveModel() { }


        private string staffID;
        private string leaveID;
        private string leaveType;
        private string startDate;
        private string endDate;
        private string approvalStatus;
        private string appliedDate;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUppdatedDate;

        public string StaffID { get => staffID; set => staffID = value; }
        public string LeaveID { get => leaveID; set => leaveID = value; }
        public string LeaveType { get => leaveType; set => leaveType = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public string ApprovalStatus { get => approvalStatus; set => approvalStatus = value; }
        public string AppliedDate { get => appliedDate; set => appliedDate = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string? LastUppdatedDate { get => lastUppdatedDate; set => lastUppdatedDate = value; }
    }
}
