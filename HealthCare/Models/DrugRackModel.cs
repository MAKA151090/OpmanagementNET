using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class DrugRackModel
    {
        public DrugRackModel() { }

        private String facilityID;
        private String rackID;
        private String rackName;
        private String uniqueIdentifier;
        private String comments;
        private String strLastUpdatedDate;
        private String strLastUpdatedUser;
        private string strLastUpdatedmachine;

        [MaxLength(100)]
        public string RackID { get => rackID; set => rackID = value; }

        [MaxLength(30)]
        public string RackName { get => rackName; set => rackName = value; }

        [MaxLength(30)]
        public string? UniqueIdentifier { get => uniqueIdentifier; set => uniqueIdentifier = value; }

        [MaxLength(30)]
        public string? Comments { get => comments; set => comments = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strLastUpdatedDate; set => strLastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strLastUpdatedUser; set => strLastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
