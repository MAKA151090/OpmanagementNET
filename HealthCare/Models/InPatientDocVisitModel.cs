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

        public string PatientId { get => strPatientId; set => strPatientId = value; }
        public string CaseId { get => strCaseId; set => strCaseId = value; }
        public string? BedId { get => strBedId; set => strBedId = value; }
        public string? VisitID { get => strVisitID; set => strVisitID = value; }
        public string? VisitDateTime { get => strVisitDateTime; set => strVisitDateTime = value; }
         public string? NurseID { get => strNurseID; set => strNurseID = value; }
        public string? NurseNote { get => strNurseNote; set => strNurseNote = value; }
        public string? DocId { get => strDocId; set => strDocId = value; }
        public string? DocNotes { get => strDocNotes; set => strDocNotes = value; }
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
