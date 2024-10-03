using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PatientFHPHMasterModel
    {
        public  PatientFHPHMasterModel()
        {
        }

        private String questionID;
        private String question;
        private String type;
        private String lastUpdatedDate;
        private String lastUpdatedUser;


        [MaxLength(100)]
        public string Question { get => question; set => question = value; }

        [MaxLength(30)]
        public string Type { get => type; set => type = value; }

        [MaxLength(30)]
        public string LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }

        [MaxLength(30)]
        public string LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string QuestionID { get => questionID; set => questionID = value; }
    }
}
