using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OtTableMasterModel
    {
        public OtTableMasterModel() { }

        private String strFacilityID;
        private String tableID;
        private String tableName;
        private String roomName;
        private String additionalFeature;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string TableID { get => tableID; set => tableID = value; }

        [MaxLength(30)]
        public string TableName { get => tableName; set => tableName = value; }

        [MaxLength(30)]
        public string RoomName { get => roomName; set => roomName = value; }

        [MaxLength(100)]
        public string AdditionalFeature { get => additionalFeature; set => additionalFeature = value; }

        [MaxLength(30)]
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    }
}
