namespace HealthCare.Models
{
    public class PatientDiagnosisModel
    {
        public PatientDiagnosisModel() { }

        private String patientID;
        private String visitID;
        private String examID;
        private String doctorID;
        private String diagnosisID;
        private String notes;
        private String comments;
        private String strlastUpdatedUser;
        private String strlastUpdatedDate;
        private String strlasrUpdatedMachine;

        public string PatientID { get => patientID; set => patientID = value; }
        public string VisitID { get => visitID; set => visitID = value; }
        public string ExamID { get => examID; set => examID = value; }
        public string? DoctorID { get => doctorID; set => doctorID = value; }
        public string DiagnosisID { get => diagnosisID; set => diagnosisID = value; }
        public string? Notes { get => notes; set => notes = value; }
        public string? Comments { get => comments; set => comments = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lasrUpdatedMachine { get => strlasrUpdatedMachine; set => strlasrUpdatedMachine = value; }
    }
}
