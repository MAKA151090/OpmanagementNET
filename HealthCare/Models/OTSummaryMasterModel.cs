namespace HealthCare.Models
{
    public class OTSummaryMasterModel
    {
        public OTSummaryMasterModel() { }

        private String questionID;
        private String question;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string QuestionID { get => questionID; set => questionID = value; }
        public string Question { get => question; set => question = value; }
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
