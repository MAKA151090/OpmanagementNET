namespace HealthCare.Models
{
    public class MedicationRackModel
    {
        public MedicationRackModel() { }

        private String rackID;
        private String rackName;
        private String uniqueIdentifier;
        private String comments;
        private String strLastUpdatedDate;
        private String strLastUpdatedUser;
        private string strLastUpdatedmachine;

        public string RackID { get => rackID; set => rackID = value; }
        public string RackName { get => rackName; set => rackName = value; }
        public string UniqueIdentifier { get => uniqueIdentifier; set => uniqueIdentifier = value; }
        public string Comments { get => comments; set => comments = value; }
        public string lastUpdatedDate { get => strLastUpdatedDate; set => strLastUpdatedDate = value; }
        public string lastUpdatedUser { get => strLastUpdatedUser; set => strLastUpdatedUser = value; }
        public string lastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }
    }
}
