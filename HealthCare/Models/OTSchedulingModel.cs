namespace HealthCare.Models
{
    public class OTSchedulingModel
    {
        public class OTScheduling { }

        private String otScheduleID;
        private String tableID;
        private String operationType;
        private String priority;
        private String inchrgDepID;
        private String additionalNotes;
        private String comments;
        private String startDate;
        private String startTime;
        private String patientID;
        private String bookedBy;
        private String status;
        private String duration;
        private String teamID;
        private bool isDeleted;
        private String confirm;
        private String confirmDate;
        private String confirmBy;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }
        public string TableID { get => tableID; set => tableID = value; }
        public string OperationType { get => operationType; set => operationType = value; }
        public string Priority { get => priority; set => priority = value; }
        public string InchrgDepID { get => inchrgDepID; set => inchrgDepID = value; }
        public string AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }
        public string Comments { get => comments; set => comments = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public string BookedBy { get => bookedBy; set => bookedBy = value; }
        public string Status { get => status; set => status = value; }
        public string Duration { get => duration; set => duration = value; }
        public string TeamID { get => teamID; set => teamID = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string Confirm { get => confirm; set => confirm = value; }
        public string ConfirmDate { get => confirmDate; set => confirmDate = value; }
        public string ConfirmBy { get => confirmBy; set => confirmBy = value; }
    }
}
