using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string HospitalID { get => strHospitalID; set => strHospitalID = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }

        [MaxLength(30)]
        public string? FacilityStatus { get => strFacilityStatus; set => strFacilityStatus = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }

}
