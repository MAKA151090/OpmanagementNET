using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string NurseStationID { get => strNurseStationID; set => strNurseStationID = value; }

        [MaxLength(30)]
        public string? StationName { get => strStationName; set => strStationName = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    }
}
