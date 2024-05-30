
using DocumentFormat.OpenXml.Presentation;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class InPatientTransferUpdateModel
    {

        public InPatientTransferUpdateModel() { }

                                                                                                                                                                           
        private string strPatientId;
        private string strCaseId;
        private string strBedId;
        private string strRoomTypeFrom;
        private string strRoomTypeTo;
        private string strBedIdFrom;
        private string strBedIdTo;
        private string strTransferNotes;
        private string strDocId;
        private string strChangeDate;
        private string tranferID;
        private bool isCount;
        private string lastupdatedUser;
        private string lastupdatedDate;
        private string lastUpdatedMachine;

        public string PatientId { get => strPatientId; set => strPatientId = value; }
        public string CaseId { get => strCaseId; set => strCaseId = value; }
        public string BedId { get => strBedId; set => strBedId = value; }
        public string? RoomTypeFrom { get => strRoomTypeFrom; set => strRoomTypeFrom = value; }
        public string? RoomTypeTo { get => strRoomTypeTo; set => strRoomTypeTo = value; }
        public string? BedIdFrom { get => strBedIdFrom; set => strBedIdFrom = value; }
        public string? BedIdTo { get => strBedIdTo; set => strBedIdTo = value; }
        public string? TransferNotes { get => strTransferNotes; set => strTransferNotes = value; }
        public string? DocId { get => strDocId; set => strDocId = value; }
        public string? ChangeDate { get => strChangeDate; set => strChangeDate = value; }
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TranferID { get => tranferID; set => tranferID = value; }
        public bool IsCount { get => isCount; set => isCount = value; }
    }
}
