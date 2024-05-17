using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OpCheckingViewModel
    {
        public OpCheckingViewModel()
        {

        }
     
        private String patientId;
        private String currentDate;
        List<OpCheckingModelResult> results;
       

        public string PatientId { get => patientId; set => patientId = value; }
        public string CurrentDate { get => currentDate; set => currentDate = value; }
        public List<OpCheckingModelResult> Results { get => results; set => results = value; }
           }
}
