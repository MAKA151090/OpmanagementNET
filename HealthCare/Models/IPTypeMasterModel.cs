namespace HealthCare.Models
{
    public class IPTypeMasterModel
    {
        public IPTypeMasterModel() { }

        private String strIPTypeID;
        private String strIPTypeName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string IPTypeID { get => strIPTypeID; set => strIPTypeID = value; }
        public string? IPTypeName { get => strIPTypeName; set => strIPTypeName = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}

