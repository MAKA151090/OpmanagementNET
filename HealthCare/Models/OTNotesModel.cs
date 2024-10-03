using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OTNotesModel
    {
        public OTNotesModel() { }

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


        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }

        [MaxLength(100)]
        public string? PreOtNotes { get => preOtNotes; set => preOtNotes = value; }

        [MaxLength(100)]
        public string? IntraOtNotes { get => intraOtNotes; set => intraOtNotes = value; }

        [MaxLength(100)]
        public string? PostOtNotes { get => postOtNotes; set => postOtNotes = value; }

        [MaxLength(100)]
        public string? FinalOtNotes { get => finalOtNotes; set => finalOtNotes = value; }

        [MaxLength(100)]
        public string? PreOtAnesthesiaNotes { get => preOtAnesthesiaNotes; set => preOtAnesthesiaNotes = value; }

        [MaxLength(100)]
        public string? IntraOtAnesthesiaNotes { get => intraOtAnesthesiaNotes; set => intraOtAnesthesiaNotes = value; }

        [MaxLength(100)]
        public string? PostOtAnesthesiaNotes { get => postOtAnesthesiaNotes; set => postOtAnesthesiaNotes = value; }

        [MaxLength(100)]
        public string? ObservationNotes { get => observationNotes; set => observationNotes = value; }

        [MaxLength(100)]
        public string? OtherComments { get => otherComments; set => otherComments = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
