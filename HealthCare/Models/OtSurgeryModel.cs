namespace HealthCare.Models
{
    public class OtSurgeryModel
    {
        private String otScheduleID;
        private String surgeryID;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }
        public string SurgeryID { get => surgeryID; set => surgeryID = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
