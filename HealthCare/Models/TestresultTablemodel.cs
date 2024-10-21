namespace HealthCare.Models
{
    public class TestresultTablemodel
    {
        public TestresultTablemodel() { }

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
        private bool idelete;

        private String testName;
        private String resukt;
        private String unit;
        private String range;


        private List<TestresultviewModel> viewtestresult;
        private String selectedItemId;
        private List<TestresultupdateModel> items;

        public string PatientID { get => patientID; set => patientID = value; }
        public string TestID { get => testID; set => testID = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public string VisitcaseID { get => visitcaseID; set => visitcaseID = value; }
        public string TsampleCltDateTime { get => tsampleCltDateTime; set => tsampleCltDateTime = value; }
        public string Result { get => result; set => result = value; }
        public string Verifiedby { get => verifiedby; set => verifiedby = value; }
        public string Verifieddate { get => verifieddate; set => verifieddate = value; }
        public string Resultby { get => resultby; set => resultby = value; }
        public string Resultdate { get => resultdate; set => resultdate = value; }
        public bool Idelete { get => idelete; set => idelete = value; }
        public List<TestresultviewModel> Viewtestresult { get => viewtestresult; set => viewtestresult = value; }
        public string SelectedItemId { get => selectedItemId; set => selectedItemId = value; }
        public List<TestresultupdateModel> Items { get => items; set => items = value; }
        public string TestName { get => testName; set => testName = value; }
        public string Resukt { get => resukt; set => resukt = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Range { get => range; set => range = value; }
    }
}
