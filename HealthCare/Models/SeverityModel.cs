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

        public string SeverityID { get => severityID; set => severityID = value; }
        public string? SeverityName { get => severityName; set => severityName = value; }
        public string? Active { get => active; set => active = value; }
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
