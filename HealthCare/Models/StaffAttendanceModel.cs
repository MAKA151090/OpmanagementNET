namespace HealthCare.Models
{
    public class StaffAttendanceModel
    {
        public StaffAttendanceModel() 
        {
        }

        private String strStaffID;

        private String strDate;
        private String strOffice;
        private String strCheckInTime;
        private String strCheckOuTtime;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private string strAttendanceID;
        private string strStatus;

        public string StaffID { get => strStaffID; set => strStaffID = value; }
      
        public string? CheckInTime { get => strCheckInTime; set => strCheckInTime = value; }
        public string? CheckOuTtime { get => strCheckOuTtime; set => strCheckOuTtime = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string? Office { get => strOffice; set => strOffice = value; }
        public string Date { get => strDate; set => strDate = value; }
        public string AttendanceID { get => strAttendanceID; set => strAttendanceID = value; }
        public string? Status { get => strStatus; set => strStatus = value; }
    }
}
