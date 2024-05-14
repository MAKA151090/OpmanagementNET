namespace HealthCare.Models
{
    public class TestMasterModel
    {
        public TestMasterModel() { }

        private String testID;
        private String testName;
        private String cost;
        private String range;
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;

        public string TestID { get => testID; set => testID = value; }
        public string? TestName { get => testName; set => testName = value; }
        public string? Cost { get => cost; set => cost = value; }
        public string? Range { get => range; set => range = value; }
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
