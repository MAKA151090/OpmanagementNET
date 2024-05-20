namespace HealthCare.Models
{
    public class OTSummaryViewModel
    {
        public OTSummaryViewModel() { }

        private String otscheduleID;
        private String question;
        private String answer;
        private List<OTSummaryModel> sHotsumm;
        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
       
        public string OtscheduleID { get => otscheduleID; set => otscheduleID = value; }
        public List<OTSummaryModel> SHotsumm { get => sHotsumm; set => sHotsumm = value; }
    }
}
