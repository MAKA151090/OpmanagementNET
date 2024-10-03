using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class StaffFacilityMappingModel
    {
        public StaffFacilityMappingModel()
        {

        }

        private String strStaffId;
        private String strFacilityID;
        private String strFromHour;
        private String strToHour;
        private String strActive;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string StaffId { get => strStaffId; set => strStaffId = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }

        [MaxLength(30)]
        public string? FromHour { get => strFromHour; set => strFromHour = value; }

        [MaxLength(30)]
        public string? ToHour { get => strToHour; set => strToHour = value; }

        [MaxLength(30)]
        public string? Active { get => strActive; set => strActive = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
