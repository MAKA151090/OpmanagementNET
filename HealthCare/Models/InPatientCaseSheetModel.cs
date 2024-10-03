using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string StrPatientId { get => strPatientId; set => strPatientId = value; }

        [MaxLength(100)]
        public string StrCaseId { get => strCaseId; set => strCaseId = value; }

        [MaxLength(100)]
        public string? StrBedId { get => strBedId; set => strBedId = value; }

        [MaxLength(100)]
        public string? StrPostMedHistory { get => strPostMedHistory; set => strPostMedHistory = value; }

        [MaxLength(30)]
        public string? StrAllergicTo { get => strAllergicTo; set => strAllergicTo = value; }

        [MaxLength(30)]
        public string? StrHeight { get => strHeight; set => strHeight = value; }

        [MaxLength(30)]
        public string? StrWeight { get => strWeight; set => strWeight = value; }

        [MaxLength(100)]
        public string? StrDiagnosis { get => strDiagnosis; set => strDiagnosis = value; }

        [MaxLength(100)]
        public string? StrTreatment { get => strTreatment; set => strTreatment = value; }

        [MaxLength(30)]
        public string LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
