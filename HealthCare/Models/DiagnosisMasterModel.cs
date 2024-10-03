using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string DiagnosisID { get => strDiagnosisID; set => strDiagnosisID = value; }

        [MaxLength(30)]
        public string DiagnosisCode { get => strDiagnosisCode; set => strDiagnosisCode = value; }

        [MaxLength(30)]
        public string DiagnosisName { get => strDiagnosisName; set => strDiagnosisName = value; }

        [MaxLength(30)]
        public string ICDCode { get => strICDCode; set => strICDCode = value; }

        [MaxLength(30)]
        public string OtherCodeName { get => strOtherCodeName; set => strOtherCodeName = value; }

        [MaxLength(30)]
        public string OtherCode { get => strOtherCode; set => strOtherCode = value; }

        [MaxLength(100)]
        public string DiagnosisDescription { get => strDiagnosisDescription; set => strDiagnosisDescription = value; }

        [MaxLength(100)]
        public string WHODescription { get => strWHODescription; set => strWHODescription = value; }

        [MaxLength(30)]
        public string DiagnosisStatus { get => strDiagnosisStatus; set => strDiagnosisStatus = value; }

        [MaxLength(30)]
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
