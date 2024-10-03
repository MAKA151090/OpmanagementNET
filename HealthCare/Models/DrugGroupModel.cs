using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class DrugGroupModel
    {
        public DrugGroupModel() 
        {

        }
        private string strGroupTypeID;
        private string strGroupTypeName;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private string strLastUpdatedmachine;
        private bool strIsDelete;
        private string facilityID;


        [MaxLength(100)]
        public string GroupTypeID { get => strGroupTypeID; set => strGroupTypeID = value; }

        [MaxLength(30)]
        public string GroupTypeName { get => strGroupTypeName; set => strGroupTypeName = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }


        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }

        [MaxLength(30)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
