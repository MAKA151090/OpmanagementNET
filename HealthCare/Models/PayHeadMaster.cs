using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PayHeadMaster
    {
        public PayHeadMaster() { }

        private String payheadID;
        private String payheadName;
        private String payheadType;
        private String payheadCalculationType;
        private String lastUpdatedUser;
        private String lastUpdatedDate;
        private String lastUpdatedMachine;
        private string facilityID;
        private bool isDelete;
        private long id;



        [MaxLength(100)]
        public string PayheadID { get => payheadID; set => payheadID = value; }

        [MaxLength(50)]
        public string? PayheadName { get => payheadName; set => payheadName = value; }


        [MaxLength(50)]
        public string? PayheadType { get => payheadType; set => payheadType = value; }

        [MaxLength(50)]
        public string? PayheadCalculationType { get => payheadCalculationType; set => payheadCalculationType = value; }

        [MaxLength(50)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(50)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }

        [MaxLength(50)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        public long Id { get => id; set => id = value; }
    }
}
