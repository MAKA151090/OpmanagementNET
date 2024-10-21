namespace HealthCare.Models
{
    public class TestresultviewModel
    {
        public TestresultviewModel() { }

        private String testName;
        private String resukt;
        private String unit;
        private String range;
        private String verifiedby;
        private String verifieddate;
        private String resultby;
        private String resultdate;

        public string TestName { get => testName; set => testName = value; }
        public string Resukt { get => resukt; set => resukt = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Range { get => range; set => range = value; }
        public string Verifiedby { get => verifiedby; set => verifiedby = value; }
        public string Verifieddate { get => verifieddate; set => verifieddate = value; }
        public string Resultby { get => resultby; set => resultby = value; }
        public string Resultdate { get => resultdate; set => resultdate = value; }
    }
}
