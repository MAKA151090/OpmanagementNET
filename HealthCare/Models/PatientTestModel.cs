
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PatientTestModel
    {
        public PatientTestModel()
        {
        }

        private String patientID;
        private String testID;
        private String facilityID;
        private String visitcaseID;
        private String testDateTime;
        private String testResult;
        private String tsampleClt;
        private String tsampleCltDateTime;
        private String exptRsltDateTime;
        private String resultPublish;
        private String referDocID;
        private String referDate;
        private String resultDate;
        private String LastupdatedUser;
        private String LastupdatedDate;
        private String LastUpdatedMachine;
        private bool isdelete;
        private String barcodeID;
        private String test;


        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string TestID { get => testID; set => testID = value; }

       

        [MaxLength(30)]
        public string? TestDateTime { get => testDateTime; set => testDateTime = value; }

        [MaxLength(30)]
        public string? TestResult { get => testResult; set => testResult = value; }

        [MaxLength(30)]
        public string? TsampleClt { get => tsampleClt; set => tsampleClt = value; }

        [MaxLength(30)]
        public string? TsampleCltDateTime { get => tsampleCltDateTime; set => tsampleCltDateTime = value; }

        [MaxLength(30)]
        public string? ExptRsltDateTime { get => exptRsltDateTime; set => exptRsltDateTime = value; }

        [MaxLength(30)]
        public string? ResultPublish { get => resultPublish; set => resultPublish = value; }

        [MaxLength(30)]
        public string? ReferDocID { get => referDocID; set => referDocID = value; }

        [MaxLength(30)]
        public string? ReferDate { get => referDate; set => referDate = value; }

        [MaxLength(30)]
        public string? ResultDate { get => resultDate; set => resultDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => LastupdatedUser; set => LastupdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => LastupdatedDate; set => LastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => LastUpdatedMachine; set => LastUpdatedMachine = value; }


        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }

        [MaxLength(100)]
        public string VisitcaseID { get => visitcaseID; set => visitcaseID = value; }
        public bool Isdelete { get => isdelete; set => isdelete = value; }

        [MaxLength(50)]
        public string? BarcodeID { get => barcodeID; set => barcodeID = value; }

        [MaxLength(50)]
        public string? Test { get => test; set => test = value; }
    }

}
