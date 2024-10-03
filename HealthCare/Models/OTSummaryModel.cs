using DocumentFormat.OpenXml.Presentation;
using System.ComponentModel.DataAnnotations;

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



        [MaxLength(100)]
        public string OtscheduleID { get => otscheduleID; set => otscheduleID = value; }

        [MaxLength(30)]
        public string? QuestionID { get => questionID; set => questionID = value; }

        [MaxLength(30)]
        public string? Question { get => question; set => question = value; }

        [MaxLength(30)]
        public string? Answer { get => answer; set => answer = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
