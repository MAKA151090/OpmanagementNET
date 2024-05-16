namespace HealthCare.Models
{
    public class OtSurgeryMasterModel
    {
        public OtSurgeryMasterModel() { }

        private String surgeryTypeID;
        private String surgeryTypeName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string SurgeryTypeID { get => surgeryTypeID; set => surgeryTypeID = value; }
        public string SurgeryTypeName { get => surgeryTypeName; set => surgeryTypeName = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
