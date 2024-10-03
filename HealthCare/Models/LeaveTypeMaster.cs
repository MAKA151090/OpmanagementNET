using System.ComponentModel.DataAnnotations;

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



        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }

        [MaxLength(100)]
        public string LeaveType { get => leaveType; set => leaveType = value; }

        [MaxLength(30)]
        public string? Total { get => total; set => total = value; }

        [MaxLength(30)]
        public string? Balance { get => balance; set => balance = value; }

        [MaxLength(30)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
    }
}
