using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class RollTypeMaster
    {
        public RollTypeMaster() { }

        private string rollID;
        private string rollName;
        private string lastupdatedUser;
        private string lastupdatedDate;
        private string lastupdatedMachine;
        private string facilityID;

        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastupdatedMachine { get => lastupdatedMachine; set => lastupdatedMachine = value; }

        [MaxLength(100)]
        public string RollID { get => rollID; set => rollID = value; }

        [MaxLength(30)]
        public string RollName { get => rollName; set => rollName = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
