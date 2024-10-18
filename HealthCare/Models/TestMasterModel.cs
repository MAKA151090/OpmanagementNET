using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class TestMasterModel
    {
        public TestMasterModel() { }

        private String testID;
        private String testName;
        private String cost;
        private String range;
        private String LastupdatedUser;
        private String LastupdatedDate;
        private String LastUpdatedMachine;
        private String facilityID;
        private String unit;
        private long id;
        private bool isdelete;


        [MaxLength(100)]
        public string TestID { get => testID; set => testID = value; }

        [MaxLength(30)]
        public string? TestName { get => testName; set => testName = value; }

        [MaxLength(30)]
        public string? Cost { get => cost; set => cost = value; }

        [MaxLength(30)]
        public string? Range { get => range; set => range = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => LastupdatedUser; set => LastupdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => LastupdatedDate; set => LastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => LastUpdatedMachine; set => LastUpdatedMachine = value; }
        
        public string? FacilityID { get => facilityID; set => facilityID = value; }
        public string? Unit { get => unit; set => unit = value; }
        
        public long Id { get => id; set => id = value; }
        public bool Isdelete { get => isdelete; set => isdelete = value; }
    }
}
