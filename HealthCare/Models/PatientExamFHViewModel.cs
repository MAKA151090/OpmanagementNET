namespace HealthCare.Models
{
    public class PatientExamFHViewModel
    {
        public PatientExamFHViewModel() { }

        private String strPatientID;
        private String strQuestionId;
        private String strAnswer;
        private String strType;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String question;
        private List<PatientFHPHModel> sHlistFHPH;




        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string QuestionID { get => strQuestionId; set => strQuestionId = value; }
        public string? Answer { get => strAnswer; set => strAnswer = value; }
        public string Type { get => strType; set => strType = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string Question { get => question; set => question = value; }
        public List<PatientFHPHModel> SHlistFHPH { get => sHlistFHPH; set => sHlistFHPH = value; }
    }
}
