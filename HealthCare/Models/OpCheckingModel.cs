namespace HealthCare.Models
{
    public class OpCheckingModel
    {

        public OpCheckingModel() { }

        private String patientId;       
        private String visitId;
        private String visitStatus;      
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;

        public string PatientId { get => patientId; set => patientId = value; }
        public string? VisitId { get => visitId; set => visitId = value; }
        public string? VisitStatus { get => visitStatus; set => visitStatus = value; }
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
       
    }
}
