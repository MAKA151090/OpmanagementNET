using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class RoomTypeMasterModel
    {
        public RoomTypeMasterModel() { }

        private String strFacilityID;
        private String strRoomTypeID;
        private String strRoomTypeName;
        private String strAdditionFeature;
        private String strAdditionalCost;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string RoomTypeID { get => strRoomTypeID; set => strRoomTypeID = value; }

        [MaxLength(30)]
        public string? RoomTypeName { get => strRoomTypeName; set => strRoomTypeName = value; }

        [MaxLength(100)]
        public string? AdditionFeature { get => strAdditionFeature; set => strAdditionFeature = value; }

        [MaxLength(30)]
        public string? AdditionalCost { get => strAdditionalCost; set => strAdditionalCost = value; }

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
