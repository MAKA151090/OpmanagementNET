namespace HealthCare.Models
{
    public class NurseStationMasterModel
    {
        public NurseStationMasterModel() { }

        private String strFacilityID;
        private String strNurseStationID;
        private String strStationName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string NurseStationID { get => strNurseStationID; set => strNurseStationID = value; }
        public string? StationName { get => strStationName; set => strStationName = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    }
}
