namespace HealthCare.Models
{
    public class InpatientObservationViewModel
    {
        public InpatientObservationViewModel() { }

        private String observationName;
        private String answer;
        private String unit;
        private String range;
        private String frequency;

       
        public string Answer { get => answer; set => answer = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Range { get => range; set => range = value; }
        public string Frequency { get => frequency; set => frequency = value; }
        public string ObservationName { get => observationName; set => observationName = value; }
    }
}
