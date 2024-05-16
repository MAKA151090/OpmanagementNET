namespace HealthCare.Models
{
    public class RadiologyMasterModel
    {
        public RadiologyMasterModel() 
        { 
        }

        private String strRadioID;
        private String strRadioName;
        private String strCost;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string RadioID { get => strRadioID; set => strRadioID = value; }
        public string? RadioName { get => strRadioName; set => strRadioName = value; }
        public string? Cost { get => strCost; set => strCost = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }

}
