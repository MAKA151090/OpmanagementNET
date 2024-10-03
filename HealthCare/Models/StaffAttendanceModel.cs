using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string StaffID { get => strStaffID; set => strStaffID = value; }

        [MaxLength(30)]
        public string? CheckInTime { get => strCheckInTime; set => strCheckInTime = value; }

        [MaxLength(30)]
        public string? CheckOuTtime { get => strCheckOuTtime; set => strCheckOuTtime = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? Office { get => strOffice; set => strOffice = value; }

        [MaxLength(30)]
        public string Date { get => strDate; set => strDate = value; }

        [MaxLength(30)]
        public string AttendanceID { get => strAttendanceID; set => strAttendanceID = value; }

        [MaxLength(30)]
        public string? Status { get => strStatus; set => strStatus = value; }
    }
}
