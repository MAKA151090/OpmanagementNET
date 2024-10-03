using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class RollAccessMaster
    {
        public RollAccessMaster() { }

        private string staffID;
        private string rollID;
        private string lastupdatedDate;
        private string lastupdatedMachine;
        private string lastupdateduser;
        private string facilityID;


        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastupdatedMachine { get => lastupdatedMachine; set => lastupdatedMachine = value; }

        [MaxLength(30)]
        public string? Lastupdateduser { get => lastupdateduser; set => lastupdateduser = value; }

        [MaxLength(100)]
        public string RollID { get => rollID; set => rollID = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
