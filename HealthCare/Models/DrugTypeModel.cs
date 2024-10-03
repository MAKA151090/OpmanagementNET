using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using System.ComponentModel.DataAnnotations;

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

        [MaxLength(100)]
        public string TypeID { get => typeID; set => typeID = value; }

        [MaxLength(30)]
        public string? TypeName { get => typeName; set => typeName = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strLastUpdatedDate; set => strLastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strLastUpdatedUser; set => strLastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }

        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
