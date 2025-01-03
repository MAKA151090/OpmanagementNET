namespace HealthCare.Models
{
    public class LeaveMasterModel
    {
        public LeaveMasterModel() { }

        private string leaveName;
        private string attendanceType;
        private string lastUpdatedDate;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string facilityID;
        private bool isDelete;

        public string LeaveName { get => leaveName; set => leaveName = value; }
        public string? AttendanceType { get => attendanceType; set => attendanceType = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
