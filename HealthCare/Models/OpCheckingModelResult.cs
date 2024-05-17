using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OpCheckingModelResult
    {
        public OpCheckingModelResult()
        {

        }
        [Key]
        private String strPatientName;
        private String strDoctorName;
        private String strAppoinmentDate;
        private String strAppoinmentTime;

        public string PatientName { get => strPatientName; set => strPatientName = value; }
        public string DoctorName { get => strDoctorName; set => strDoctorName = value; }
        public string AppoinmentDate { get => strAppoinmentDate; set => strAppoinmentDate = value; }
        public string AppoinmentTime { get => strAppoinmentTime; set => strAppoinmentTime = value; }
    }

}
