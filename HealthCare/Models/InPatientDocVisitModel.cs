using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class InPatientDocVisitModel
    {

        public InPatientDocVisitModel() { }

        private String strPatientId;
        private string strCaseId;
        private string strBedId;
        private string strVisitID;
        private string strVisitDateTime;       
        private string strNurseID;
        private string strNurseNote;
        private string strDocId;
        private string strDocNotes;
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;

        [MaxLength(100)]
        public string PatientId { get => strPatientId; set => strPatientId = value; }

        [MaxLength(100)]
        public string CaseId { get => strCaseId; set => strCaseId = value; }

        [MaxLength(100)]
        public string? BedId { get => strBedId; set => strBedId = value; }

        [MaxLength(100)]
        public string? VisitID { get => strVisitID; set => strVisitID = value; }

        [MaxLength(30)]
        public string? VisitDateTime { get => strVisitDateTime; set => strVisitDateTime = value; }

        [MaxLength(30)]
        public string? NurseID { get => strNurseID; set => strNurseID = value; }

        [MaxLength(30)]
        public string? NurseNote { get => strNurseNote; set => strNurseNote = value; }

        [MaxLength(30)]
        public string? DocId { get => strDocId; set => strDocId = value; }

        [MaxLength(30)]
        public string? DocNotes { get => strDocNotes; set => strDocNotes = value; }

        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
