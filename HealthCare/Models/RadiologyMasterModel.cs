using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class RadiologyMasterModel
    {
        public RadiologyMasterModel() 
        { 
        }
        private String facilityID;
        private String strRadioID;
        private String strRadioName;
        private String strCost;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string RadioID { get => strRadioID; set => strRadioID = value; }

        [MaxLength(30)]
        public string? RadioName { get => strRadioName; set => strRadioName = value; }

        [MaxLength(30)]
        public string? Cost { get => strCost; set => strCost = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }

}
