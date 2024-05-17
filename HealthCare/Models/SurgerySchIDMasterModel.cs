namespace HealthCare.Models
{
    public class SurgerySchIDMasterModel
    {
        public SurgerySchIDMasterModel() { }

        private String otscheduleID;
        private String surgeryID;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string OtscheduleID { get => otscheduleID; set => otscheduleID = value; }
        public string SurgeryID { get => surgeryID; set => surgeryID = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
