namespace HealthCare.Models
{
    public class StaffAttendanceViewModel
    {

        public StaffAttendanceViewModel() 
        {
       
        
        }
        private String staffID;
        private String date;
        private String office;
        private String checkInTime;
        private String checkOuTtime;

        private List<StaffAttendanceModel> stfAttedance;

        public string StaffID { get => staffID; set => staffID = value; }
        public string Date { get => date; set => date = value; }
        public string Office { get => office; set => office = value; }
      
        public List<StaffAttendanceModel> StfAttedance { get => stfAttedance; set => stfAttedance = value; }
        public string CheckInTime { get => checkInTime; set => checkInTime = value; }
        public string CheckOuTtime { get => checkOuTtime; set => checkOuTtime = value; }
    }
}
