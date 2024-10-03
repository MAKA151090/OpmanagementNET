using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string PatientId { get => patientId; set => patientId = value; }

        [MaxLength(100)]
        public string? VisitId { get => visitId; set => visitId = value; }

        [MaxLength(30)]
        public string? VisitStatus { get => visitStatus; set => visitStatus = value; }

        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
       
    }
}
