
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
        private String VisitcaseID;
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


        public string PatientID { get => patientID; set => patientID = value; }
        public string TestID { get => testID; set => testID = value; }        

        public string VisitcaseID1 { get => VisitcaseID; set => VisitcaseID = value; }
        public string? TestDateTime { get => testDateTime; set => testDateTime = value; }
        public string? TestResult { get => testResult; set => testResult = value; }
        public string? TsampleClt { get => tsampleClt; set => tsampleClt = value; }
        public string? TsampleCltDateTime { get => tsampleCltDateTime; set => tsampleCltDateTime = value; }
        public string? ExptRsltDateTime { get => exptRsltDateTime; set => exptRsltDateTime = value; }
        public string? ResultPublish { get => resultPublish; set => resultPublish = value; }
        public string? ReferDocID { get => referDocID; set => referDocID = value; }
        public string? ReferDate { get => referDate; set => referDate = value; }
        public string? ResultDate { get => resultDate; set => resultDate = value; }
        public string? lastUpdatedUser { get => LastupdatedUser; set => LastupdatedUser = value; }
        public string? lastUpdatedDate { get => LastupdatedDate; set => LastupdatedDate = value; }
        public string? lastUpdatedMachine { get => LastUpdatedMachine; set => LastUpdatedMachine = value; }

        public string FacilityID { get => facilityID; set => facilityID = value; }
    }

}
