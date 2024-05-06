namespace HealthCare.Models
{
    public class PatientVisitIntoDocumentModel
    {
        public PatientVisitIntoDocumentModel()
        {
        }
        private String strPatientID;
        private String strClinicID;
        private String strVisitID;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;

        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string ClinicID { get => strClinicID; set => strClinicID = value; }
        public string VisitID { get => strVisitID; set => strVisitID = value; }
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    }
}
