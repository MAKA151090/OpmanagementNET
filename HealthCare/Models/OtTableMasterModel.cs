namespace HealthCare.Models
{
    public class OtTableMasterModel
    {
        public OtTableMasterModel() { }

        private String tableID;
        private String tableName;
        private String roomName;
        private String additionalFeature;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string TableID { get => tableID; set => tableID = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public string AdditionalFeature { get => additionalFeature; set => additionalFeature = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
