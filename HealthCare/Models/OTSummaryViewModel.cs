namespace HealthCare.Models
{
    public class OTSummaryViewModel
    {
        public OTSummaryViewModel() { }

       
        private String question;
        private String answer;

        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
    }
}
