namespace HealthCare.Models
{
    public class PatientExamListModel
    {
        public PatientExamListModel() { }

        private String strPatientID;
        private String strQuestionId;
        private String strAnswer;
        private String strType;
        private String question;
       




        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string QuestionID { get => strQuestionId; set => strQuestionId = value; }
        public string? Answer { get => strAnswer; set => strAnswer = value; }
        public string Type { get => strType; set => strType = value; }
       
        public string Question { get => question; set => question = value; }
       
    }
}
