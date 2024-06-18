namespace HealthCare.Models
{
    public class StaffClaimModel
    {
        public StaffClaimModel() { }

        private string claimID;
        private string claimType;
        private string claimAmount;
        private string claimStatus;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUpdatedDate;

        public string ClaimID { get => claimID; set => claimID = value; }
        public string ClaimType { get => claimType; set => claimType = value; }
        public string ClaimAmount { get => claimAmount; set => claimAmount = value; }
        public string ClaimStatus { get => claimStatus; set => claimStatus = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
    }
}
