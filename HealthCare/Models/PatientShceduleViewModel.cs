namespace HealthCare.Models
{
    public class PatientShceduleViewModel
    {
        public PatientShceduleViewModel() { }

        private String staffID;
        private String staffName;
        private String facilityID;
        private String facilityName;
        private String startTime;
        private String duration;
        private String patientID;
        private String date;
        private String scheduleID;

        public string? StaffID { get => staffID; set => staffID = value; }
        public string? StaffName { get => staffName; set => staffName = value; }
        public string? FacilityID { get => facilityID; set => facilityID = value; }
        public string? FacilityName { get => facilityName; set => facilityName = value; }
        public string? StartTime { get => startTime; set => startTime = value; }
        public string? Duration { get => duration; set => duration = value; }
        public string? PatientID { get => patientID; set => patientID = value; }
        public string? Date { get => date; set => date = value; }
        public string? ScheduleID { get => scheduleID; set => scheduleID = value; }
    }
}
