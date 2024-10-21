using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class TestresultupdateModel
    {
        public TestresultupdateModel() { }

        private String patientID;
        private String testID;
        private String facilityID;
        private String visitcaseID;
        private String tsampleCltDateTime;
        private String result;
        private String verifiedby;
        private String verifieddate;
        private String resultby;
        private String resultdate;
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;
        private bool isdelete;


        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string TestID { get => testID; set => testID = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }

        [MaxLength(100)]
        public string VisitcaseID { get => visitcaseID; set => visitcaseID = value; }

        [MaxLength(100)]
        public string TsampleCltDateTime { get => tsampleCltDateTime; set => tsampleCltDateTime = value; }

        [MaxLength(100)]
        public string Result { get => result; set => result = value; }

        [MaxLength(30)]
        public string? Verifiedby { get => verifiedby; set => verifiedby = value; }

        [MaxLength(30)]
        public string? Verifieddate { get => verifieddate; set => verifieddate = value; }

        [MaxLength(30)]
        public string? Resultby { get => resultby; set => resultby = value; }

        [MaxLength(30)]
        public string? Resultdate { get => resultdate; set => resultdate = value; }

        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public bool Isdelete { get => isdelete; set => isdelete = value; }
    }
}
