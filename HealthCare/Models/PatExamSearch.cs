namespace HealthCare.Models
{
    public class PatExamSearch
    {
        public PatExamSearch() 
        { }
        private String strPatientID;
        private String strFullName;
        private String strClinicID;
        private String strVisitID;
        private String strClinicName;
        private String strVisitDate;

        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string ClinicID { get => strClinicID; set => strClinicID = value; }
        public string VisitID { get => strVisitID; set => strVisitID = value; }
        public string ClinicName { get => strClinicName; set => strClinicName = value; }
        public string FullName { get => strFullName; set => strFullName = value; }
        public string VisitDate { get => strVisitDate; set => strVisitDate = value; }
    }
}
