using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OtConfirmViewModel
    {
        public OtConfirmViewModel() { }
       
        private String otscheduleID;
        private String surgeryName;
        private String teamName;
        private String date;
        private String duration;
        private String tableName;
        private String roomName;

        public string OtscheduleID { get => otscheduleID; set => otscheduleID = value; }
        public string SurgeryName { get => surgeryName; set => surgeryName = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public string Date { get => date; set => date = value; }
        public string Duration { get => duration; set => duration = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public string RoomName { get => roomName; set => roomName = value; }
    }
}
