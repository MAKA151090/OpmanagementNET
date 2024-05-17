namespace HealthCare.Models
{
    public class OTNotes
    {
        public OTNotes() { }

        private String patientID;
        private String otScheduleID;
        private String preOtNotes;
        private String intraOtNotes;
        private String postOtNotes;
        private String finalOtNotes;
        private String preOtAnesthesiaNotes;
        private String intraOtAnesthesiaNotes;
        private String postOtAnesthesiaNotes;
        private String observationNotes;
        private String otherComments;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string PatientID { get => patientID; set => patientID = value; }
        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }
        public string PreOtNotes { get => preOtNotes; set => preOtNotes = value; }
        public string IntraOtNotes { get => intraOtNotes; set => intraOtNotes = value; }
        public string PostOtNotes { get => postOtNotes; set => postOtNotes = value; }
        public string FinalOtNotes { get => finalOtNotes; set => finalOtNotes = value; }
        public string PreOtAnesthesiaNotes { get => preOtAnesthesiaNotes; set => preOtAnesthesiaNotes = value; }
        public string IntraOtAnesthesiaNotes { get => intraOtAnesthesiaNotes; set => intraOtAnesthesiaNotes = value; }
        public string PostOtAnesthesiaNotes { get => postOtAnesthesiaNotes; set => postOtAnesthesiaNotes = value; }
        public string ObservationNotes { get => observationNotes; set => observationNotes = value; }
        public string OtherComments { get => otherComments; set => otherComments = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
