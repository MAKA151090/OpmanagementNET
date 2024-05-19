namespace HealthCare.Models
{
    public class InpatientTransferModel
    {
        public InpatientTransferModel() { }


        private String strPatientId;
        private string strCaseId;
        private string strBedId;
        private string strRoomTypeFrom;
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;

        public string PatientId { get => strPatientId; set => strPatientId = value; }
        public string CaseId { get => strCaseId; set => strCaseId = value; }
        public string BedId { get => strBedId; set => strBedId = value; }
        public string? RoomTypeFrom { get => strRoomTypeFrom; set => strRoomTypeFrom = value; }
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
