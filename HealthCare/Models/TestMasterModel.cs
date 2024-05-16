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

        public string TestID { get => testID; set => testID = value; }
        public string? TestName { get => testName; set => testName = value; }
        public string? Cost { get => cost; set => cost = value; }
        public string? Range { get => range; set => range = value; }
        public string? lastUpdatedUser { get => LastupdatedUser; set => LastupdatedUser = value; }
        public string? lastUpdatedDate { get => LastupdatedDate; set => LastupdatedDate = value; }
        public string? lastUpdatedMachine { get => LastUpdatedMachine; set => LastUpdatedMachine = value; }
    }
}
