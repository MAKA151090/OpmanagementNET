namespace HealthCare.Models
{
    public class HospitalFacilityMappingModel
    {
       public HospitalFacilityMappingModel() 
        {
        }

        private String strHospitalID;
        private String strFacilityID;
        private String strFacilityStatus;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string HospitalID { get => strHospitalID; set => strHospitalID = value; }
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
        public string? FacilityStatus { get => strFacilityStatus; set => strFacilityStatus = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }

}
