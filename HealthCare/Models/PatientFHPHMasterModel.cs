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

        
        public string Question { get => question; set => question = value; }
        public string Type { get => type; set => type = value; }
        public string LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public string LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string QuestionID { get => questionID; set => questionID = value; }
    }
}
