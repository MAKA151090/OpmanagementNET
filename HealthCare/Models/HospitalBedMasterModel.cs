using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class HospitalBedMasterModel
    {
        public HospitalBedMasterModel() { }

        private String strFacilityID;
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


        [MaxLength(100)]
        public string BedID { get => strBedID; set => strBedID = value; }

        [MaxLength(30)]
        public string? BedName { get => strBedName; set => strBedName = value; }

        [MaxLength(30)]
        public string? BedType { get => strBedType; set => strBedType = value; }

        [MaxLength(30)]
        public string? RoomType { get => strRoomType; set => strRoomType = value; }

        [MaxLength(30)]
        public string? RoomFloor { get => strRoomFloor; set => strRoomFloor = value; }

        [MaxLength(30)]
        public string? NurseStationID { get => strNurseStationID; set => strNurseStationID = value; }

        [MaxLength(30)]
        public string? CostPerDay { get => strCostPerDay; set => strCostPerDay = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    }
}
