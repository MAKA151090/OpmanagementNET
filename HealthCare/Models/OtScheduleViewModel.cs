namespace HealthCare.Models
{
    public class OtScheduleViewModel
    {

        public OtScheduleViewModel() { }

        private String facilityID;
        private String date;
        private String otSchedulingId;
        private String patientName;
        private String scheduleDateTime;
        private String startTime;
        private String duration;
        private String operationType;
        private String IncharegeDeparment;
        private String isConformed;
        private String teamName;

        public string? Date { get => date; set => date = value; }
        public string? OtSchedulingId { get => otSchedulingId; set => otSchedulingId = value; }
        public string? PatientName { get => patientName; set => patientName = value; }
        public string? ScheduleDateTime { get => scheduleDateTime; set => scheduleDateTime = value; }
        public string? StartTime { get => startTime; set => startTime = value; }
        public string? Duration { get => duration; set => duration = value; }
        public string? OperationType { get => operationType; set => operationType = value; }
        public string? IncharegeDeparment1 { get => IncharegeDeparment; set => IncharegeDeparment = value; }
        public string? IsConformed { get => isConformed; set => isConformed = value; }
        public string? TeamName { get => teamName; set => teamName = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
