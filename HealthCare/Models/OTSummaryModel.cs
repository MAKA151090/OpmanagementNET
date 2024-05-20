using DocumentFormat.OpenXml.Presentation;

namespace HealthCare.Models
{
    public class OTSummaryModel
    {
        public OTSummaryModel() { }

        private String otscheduleID;
        private String questionID;
        private String question;
        private String answer;
        private String strlastUpdatedUser;
        private String strlastUpdatedDate;
        private String strlastUpdatedMachine;
        

        public string OtscheduleID { get => otscheduleID; set => otscheduleID = value; }
        public string? QuestionID { get => questionID; set => questionID = value; }
        public string? Question { get => question; set => question = value; }
        public string? Answer { get => answer; set => answer = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
