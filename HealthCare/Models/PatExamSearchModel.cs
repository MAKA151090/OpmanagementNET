namespace HealthCare.Models
{
    public class PatExamSearchModel
    {
        public PatExamSearchModel() 
        { }
        private String strPatientID;
        private String strFullName;
        private String strFacilityID;
        private String strVisitID;
        private String strClinicName;
        private String strVisitDate;

        public string PatientID { get => strPatientID; set => strPatientID = value; }
       
        public string VisitID { get => strVisitID; set => strVisitID = value; }
        public string ClinicName { get => strClinicName; set => strClinicName = value; }
        public string FullName { get => strFullName; set => strFullName = value; }
        public string VisitDate { get => strVisitDate; set => strVisitDate = value; }
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    }
}
