using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class SeverityModel
    {

        public SeverityModel() { }

        private String severityID;
        private String severityName;
        private String active;      
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;


        [MaxLength(100)]
        public string SeverityID { get => severityID; set => severityID = value; }

        [MaxLength(30)]
        public string? SeverityName { get => severityName; set => severityName = value; }

        [MaxLength(30)]
        public string? Active { get => active; set => active = value; }

        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
