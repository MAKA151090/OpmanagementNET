namespace HealthCare.Models
{
    public class ClinicSurgeryMasterModel
    {
        public ClinicSurgeryMasterModel() { }

        private String surgeryName;
        private String surgeryID;
        private String cost;
        private String duration;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string SurgeryName { get => surgeryName; set => surgeryName = value; }
        public string SurgeryID { get => surgeryID; set => surgeryID = value; }
        public string Cost { get => cost; set => cost = value; }
        public string Duration { get => duration; set => duration = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
