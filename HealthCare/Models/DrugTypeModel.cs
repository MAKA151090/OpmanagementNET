using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;

namespace HealthCare.Models
{
    public class DrugTypeModel
    {
        public DrugTypeModel() { }

        private String typeID;
        private String typeName;
        private String strLastUpdatedDate;
        private String strLastUpdatedUser;
        private string strLastUpdatedmachine;
        private bool strIsDelete;
        private String facilityID;

        public string TypeID { get => typeID; set => typeID = value; }
        public string? TypeName { get => typeName; set => typeName = value; }
        public string? lastUpdatedDate { get => strLastUpdatedDate; set => strLastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strLastUpdatedUser; set => strLastUpdatedUser = value; }
        public string? lastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
