using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class ResourceTypeMasterModel
    {
        public ResourceTypeMasterModel()
        {

        }

        private String strResourceTypeID;
        private String strResourceTypeName;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private string strlastUpdatedMachine;
        private bool strIsDelete;
        private String facilityID;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [MaxLength(100)]
        public string ResourceTypeID { get => strResourceTypeID; set => strResourceTypeID = value; }

        [MaxLength(30)]
        public string? ResourceTypeName { get => strResourceTypeName; set => strResourceTypeName = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public bool StrIsDelete { get => strIsDelete; set => strIsDelete = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
