using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class DrugCategoryModel
    {
        public DrugCategoryModel() { }

        private String categoryID;
        private String categoryName;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private string strlastUpdatedmachine;
        private bool strIsDelete;
        private string facilityID;


        [MaxLength(100)]
        public string CategoryID { get => categoryID; set => categoryID = value; }

        [MaxLength(30)]
        public string? CategoryName { get => categoryName; set => categoryName = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedmachine { get => strlastUpdatedmachine; set => strlastUpdatedmachine = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
