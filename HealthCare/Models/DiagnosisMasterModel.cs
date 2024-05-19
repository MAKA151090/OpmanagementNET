namespace HealthCare.Models
{
    public class DiagnosisMasterModel
    {
        public DiagnosisMasterModel() 
        {
        }
        private String strDiagnosisID;
        private String strDiagnosisCode;
        private String strDiagnosisName;
        private String strICDCode;
        private String strOtherCodeName;
        private String strOtherCode;
        private String strDiagnosisDescription;
        private String strWHODescription;
        private String strDiagnosisStatus;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string DiagnosisID { get => strDiagnosisID; set => strDiagnosisID = value; }
        public string DiagnosisCode { get => strDiagnosisCode; set => strDiagnosisCode = value; }
        public string DiagnosisName { get => strDiagnosisName; set => strDiagnosisName = value; }
        public string ICDCode { get => strICDCode; set => strICDCode = value; }
        public string OtherCodeName { get => strOtherCodeName; set => strOtherCodeName = value; }
        public string OtherCode { get => strOtherCode; set => strOtherCode = value; }
        public string DiagnosisDescription { get => strDiagnosisDescription; set => strDiagnosisDescription = value; }
        public string WHODescription { get => strWHODescription; set => strWHODescription = value; }
        public string DiagnosisStatus { get => strDiagnosisStatus; set => strDiagnosisStatus = value; }
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
