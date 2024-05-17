namespace HealthCare.Models
{
    public class RoomTypeMasterModel
    {
        public RoomTypeMasterModel() { }

        private String strRoomTypeID;
        private String strRoomTypeName;
        private String strAdditionFeature;
        private String strAdditionalCost;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string RoomTypeID { get => strRoomTypeID; set => strRoomTypeID = value; }
        public string? RoomTypeName { get => strRoomTypeName; set => strRoomTypeName = value; }
        public string? AdditionFeature { get => strAdditionFeature; set => strAdditionFeature = value; }
        public string? AdditionalCost { get => strAdditionalCost; set => strAdditionalCost = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
