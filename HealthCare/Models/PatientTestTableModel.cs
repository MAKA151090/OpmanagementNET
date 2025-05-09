﻿namespace HealthCare.Models
{
    public class PatientTestTableModel
    {
        public PatientTestTableModel() { }

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
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;
        private String dbpatientID;
        private String testName;

        private List<PatientTestViewModel> viewTest;

        private String selectedItemId;
        private List<PatientTestModel> items;
        private String resourceTypeID;
        private String gender;

        private String barcodeID;


        public string PatientID { get => patientID; set => patientID = value; }
        public string TestID { get => testID; set => testID = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public string VisitcaseID { get => visitcaseID; set => visitcaseID = value; }
        public string TestDateTime { get => testDateTime; set => testDateTime = value; }
        public string TestResult { get => testResult; set => testResult = value; }
        public string TsampleClt { get => tsampleClt; set => tsampleClt = value; }
        public string TsampleCltDateTime { get => tsampleCltDateTime; set => tsampleCltDateTime = value; }
        public string ExptRsltDateTime { get => exptRsltDateTime; set => exptRsltDateTime = value; }
        public string ResultPublish { get => resultPublish; set => resultPublish = value; }
        public string ReferDocID { get => referDocID; set => referDocID = value; }
        public string ReferDate { get => referDate; set => referDate = value; }
        public string ResultDate { get => resultDate; set => resultDate = value; }
        public string LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
       
        public string SelectedItemId { get => selectedItemId; set => selectedItemId = value; }
        public List<PatientTestViewModel> ViewTest { get => viewTest; set => viewTest = value; }
      
        public string DbpatientID { get => dbpatientID; set => dbpatientID = value; }
        public string TestName { get => testName; set => testName = value; }
        public List<PatientTestModel> Items { get => items; set => items = value; }
        public string ResourceTypeID { get => resourceTypeID; set => resourceTypeID = value; }
        public string Gender { get => gender; set => gender = value; }
        public string BarcodeID { get => barcodeID; set => barcodeID = value; }
    }
}
