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

        public string GroupTypeID { get => strGroupTypeID; set => strGroupTypeID = value; }
        public string GroupTypeName { get => strGroupTypeName; set => strGroupTypeName = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? LastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
    }
}
