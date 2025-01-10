using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class EmployeeAttendance
    {
        public EmployeeAttendance() { }

        private string staffID;
        private string leaveName;
        private string numberofdays;
        private string month;
        private string year;
        private String lastUpdatedUser;
        private String lastUpdatedDate;
        private String lastUpdatedMachine;
        private bool isDelete;
        private string facilityID;
        private string attendancetype;


        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }

        [MaxLength(100)]
        public string LeaveName { get => leaveName; set => leaveName = value; }

        [MaxLength(30)]
        public string? Numberofdays { get => numberofdays; set => numberofdays = value; }

        [MaxLength(50)]
        public string Month { get => month; set => month = value; }


        [MaxLength(50)]
        public string Year { get => year; set => year = value; }


        [MaxLength(50)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }


        [MaxLength(50)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }


        [MaxLength(50)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }

        [MaxLength(50)]
        public string? Attendancetype { get => attendancetype; set => attendancetype = value; }
    }
}
