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

        public string StaffId { get => strStaffId; set => strStaffId = value; }
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
        public string? FromHour { get => strFromHour; set => strFromHour = value; }
        public string? ToHour { get => strToHour; set => strToHour = value; }
        public string? Active { get => strActive; set => strActive = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
