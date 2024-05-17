namespace HealthCare.Models
{
    public class HospitalBedMasterModel
    {
        public HospitalBedMasterModel() { }

        private String strBedID;
        private String strBedName;
        private String strBedType;
        private String strRoomType;
        private String strRoomFloor;
        private String strNurseStationID;
        private String strCostPerDay;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string BedID { get => strBedID; set => strBedID = value; }
        public string? BedName { get => strBedName; set => strBedName = value; }
        public string? BedType { get => strBedType; set => strBedType = value; }
        public string? RoomType { get => strRoomType; set => strRoomType = value; }
        public string? RoomFloor { get => strRoomFloor; set => strRoomFloor = value; }
        public string? NurseStationID { get => strNurseStationID; set => strNurseStationID = value; }
        public string? CostPerDay { get => strCostPerDay; set => strCostPerDay = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
