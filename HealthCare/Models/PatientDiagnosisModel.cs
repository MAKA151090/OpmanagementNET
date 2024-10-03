using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string VisitID { get => visitID; set => visitID = value; }

        [MaxLength(100)]
        public string ExamID { get => examID; set => examID = value; }

        [MaxLength(30)]
        public string? DoctorID { get => doctorID; set => doctorID = value; }

        [MaxLength(30)]
        public string DiagnosisID { get => diagnosisID; set => diagnosisID = value; }

        [MaxLength(100)]
        public string? Notes { get => notes; set => notes = value; }

        [MaxLength(100)]
        public string? Comments { get => comments; set => comments = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lasrUpdatedMachine { get => strlasrUpdatedMachine; set => strlasrUpdatedMachine = value; }
    }
}
