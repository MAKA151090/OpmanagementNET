using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class InpatientDischargeModel
    {
        public InpatientDischargeModel() { }

        private String strPatientID;
        private String strCaseID;
        private String strDischargeNotes;
        private String strDoctorID;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(100)]
        public string CaseID { get => strCaseID; set => strCaseID = value; }

        [MaxLength(100)]
        public string? DischargeNotes { get => strDischargeNotes; set => strDischargeNotes = value; }

        [MaxLength(100)]
        public string? DoctorID { get => strDoctorID; set => strDoctorID = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}