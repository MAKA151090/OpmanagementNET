using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class StaffFacilityMappingModel
    {
        public StaffFacilityMappingModel()
        {

        }

        private String strStaffId;
        private string facilityID;
        private bool active;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private string hospital;


        [MaxLength(100)]
        public string StaffId { get => strStaffId; set => strStaffId = value; }

       

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(50)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public bool Active { get => active; set => active = value; }

        [MaxLength(50)]
        public string? Hospital { get => hospital; set => hospital = value; }
    }
}
