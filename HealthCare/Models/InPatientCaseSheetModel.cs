namespace HealthCare.Models
{
    public class InPatientCaseSheetModel
    {

        public InPatientCaseSheetModel() { }

        private String strPatientId;
        private string strCaseId;
        private string strBedId;
        private string strPostMedHistory;
        private string strAllergicTo;
        private string strHeight;
        private string strWeight;
        private string strDiagnosis;
        private string strTreatment;
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;

        public string StrPatientId { get => strPatientId; set => strPatientId = value; }
        public string StrCaseId { get => strCaseId; set => strCaseId = value; }
        public string? StrBedId { get => strBedId; set => strBedId = value; }
        public string? StrPostMedHistory { get => strPostMedHistory; set => strPostMedHistory = value; }
        public string? StrAllergicTo { get => strAllergicTo; set => strAllergicTo = value; }
        public string? StrHeight { get => strHeight; set => strHeight = value; }
        public string? StrWeight { get => strWeight; set => strWeight = value; }
        public string? StrDiagnosis { get => strDiagnosis; set => strDiagnosis = value; }
        public string? StrTreatment { get => strTreatment; set => strTreatment = value; }
        public string LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
