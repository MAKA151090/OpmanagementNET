namespace HealthCare.Models
{
    public class PatientFHPHViewModel
    {
        private String patientID;
        private String type;
        private String question;
        private String answer;
        private String questionID;
       

        private List<PatientExamListModel> sHFHPHviewlist;

        public string PatientID { get => patientID; set => patientID = value; }
        public string Type { get => type; set => type = value; }
        public List<PatientExamListModel> SHFHPHviewlist { get => sHFHPHviewlist; set => sHFHPHviewlist = value; }
        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
        public string QuestionID { get => questionID; set => questionID = value; }
     
    }
}
