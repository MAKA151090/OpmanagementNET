using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class StaffLeaveModel
    {
        public StaffLeaveModel() { }


        private string staffID;
        private string leaveID;
        private string leaveType;
        private string startDate;
        private string noOfDays;
        private string approvalStatus;
        private string appliedDate;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUppdatedDate;



        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }
        
        [MaxLength(100)]
        public string LeaveID { get => leaveID; set => leaveID = value; }

        [MaxLength(100)]
        public string LeaveType { get => leaveType; set => leaveType = value; }

        [MaxLength(30)]
        public string? StartDate { get => startDate; set => startDate = value; }

        [MaxLength(30)]
        public string? ApprovalStatus { get => approvalStatus; set => approvalStatus = value; }

        [MaxLength(30)]
        public string? AppliedDate { get => appliedDate; set => appliedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? LastUppdatedDate { get => lastUppdatedDate; set => lastUppdatedDate = value; }

        [MaxLength(30)]
        public string? NoOfDays { get => noOfDays; set => noOfDays = value; }
    }
}
