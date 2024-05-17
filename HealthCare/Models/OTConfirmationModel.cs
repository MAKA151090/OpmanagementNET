namespace HealthCare.Models
{
    public class OTConfirmationModel
    {
        public OTConfirmationModel() { }

        private String otScheduleID;
        private string teamName;
        private String date;
        private String duration;
        private String tableName;
        private String roomName;
        private String confirmDate;
        private String confirmBy;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private List<OtConfirmViewModel> otviewModel;


        public string? TeamName { get => teamName; set => teamName = value; }
        public string? Date { get => date; set => date = value; }
        public string? Duration { get => duration; set => duration = value; }
       
        public string? ConfirmDate { get => confirmDate; set => confirmDate = value; }
        public string? ConfirmBy { get => confirmBy; set => confirmBy = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string? TableName { get => tableName; set => tableName = value; }
        public string? RoomName { get => roomName; set => roomName = value; }
        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }
        public List<OtConfirmViewModel> OtviewModel { get => otviewModel; set => otviewModel = value; }
    }
}
