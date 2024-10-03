using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class RollAccessModel
    {
        public RollAccessModel() 
        {
        }
        private String strRollID;
        private String strScreenID;
        private String strAccess;
        private String strAuthorized;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private string facilityID;


        [MaxLength(100)]
        public string RollID { get => strRollID; set => strRollID = value; }

        [MaxLength(100)]
        public string ScreenID { get => strScreenID; set => strScreenID = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string Access { get => strAccess; set => strAccess = value; }

        [MaxLength(30)]
        public string Authorized { get => strAuthorized; set => strAuthorized = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
