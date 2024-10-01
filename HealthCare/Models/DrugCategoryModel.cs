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

        public string CategoryID { get => categoryID; set => categoryID = value; }
        public string? CategoryName { get => categoryName; set => categoryName = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedmachine { get => strlastUpdatedmachine; set => strlastUpdatedmachine = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
