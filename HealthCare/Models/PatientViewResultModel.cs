namespace HealthCare.Models
{
    public class PatientViewResultModel
    {
        public PatientViewResultModel() { }

        private String patientName;
        private String clinicName;
        private String patientID;
        private String clinicID;
        private String testID;
        private String testDate;
        private String testName;
        private String result;
        private String range;
        private String doctorName;
        private String visitcaseID;

        public string PatientID { get => patientID; set => patientID = value; }
        public string ClinicID { get => clinicID; set => clinicID = value; }
        public string TestID { get => testID; set => testID = value; }
        public string TestDate { get => testDate; set => testDate = value; }
        public string TestName { get => testName; set => testName = value; }
        public string Result { get => result; set => result = value; }
        public string Range { get => range; set => range = value; }
        public string DoctorName { get => doctorName; set => doctorName = value; }
        public string PatientName { get => patientName; set => patientName = value; }
        public string ClinicName { get => clinicName; set => clinicName = value; }
        public string VisitcaseID { get => visitcaseID; set => visitcaseID = value; }
    }
}
