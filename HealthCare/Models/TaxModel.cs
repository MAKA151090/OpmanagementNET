namespace HealthCare.Models
{
    public class TaxModel
    {
        public TaxModel() { }

        private string taxID;
        private string taxType;
        private string taxAmount;
        private string applicablePeriod;
        private string lastUpdatedUser;
        private string lastUpdatedDate;
        private string lastUpdatedMachine;

        public string TaxID { get => taxID; set => taxID = value; }
        public string TaxType { get => taxType; set => taxType = value; }
        public string? TaxAmount { get => taxAmount; set => taxAmount = value; }
        public string? ApplicablePeriod { get => applicablePeriod; set => applicablePeriod = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
