using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class ScreenNameMasterModel
    {
       public ScreenNameMasterModel() { }

        private string screenName;
        private string id;
        private string tableName;
        private bool isMaster;
        private string facilityID;


        [MaxLength(30)]
        public string ScreenName { get => screenName; set => screenName = value; }

        [MaxLength(100)]
        public string Id { get => id; set => id = value; }
        public bool IsMaster { get => isMaster; set => isMaster = value; }

        [MaxLength(30)]
        public string? TableName { get => tableName; set => tableName = value; }

        [MaxLength(100)]
        public string? FacilityID { get => facilityID; set => facilityID = value; }
    }
}
