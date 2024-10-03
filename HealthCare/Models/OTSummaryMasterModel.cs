using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string QuestionID { get => questionID; set => questionID = value; }

        [MaxLength(100)]
        public string Question { get => question; set => question = value; }

        [MaxLength(30)]
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
