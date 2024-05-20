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

        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string CaseID { get => strCaseID; set => strCaseID = value; }
        public string? DischargeNotes { get => strDischargeNotes; set => strDischargeNotes = value; }
        public string? DoctorID { get => strDoctorID; set => strDoctorID = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}