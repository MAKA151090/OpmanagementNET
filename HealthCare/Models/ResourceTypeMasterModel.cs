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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string ResourceTypeID { get => strResourceTypeID; set => strResourceTypeID = value; }
        public string? ResourceTypeName { get => strResourceTypeName; set => strResourceTypeName = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public bool StrIsDelete { get => strIsDelete; set => strIsDelete = value; }
    }
}
