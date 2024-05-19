namespace HealthCare.Models
{
    public class HospitalRegistrationModel
    {

        public HospitalRegistrationModel() 
        {
        }
        private String strHospitalID;
        private String strHospitalName;
        private String strAddress;
        private String strCity;
        private String strState;
        private String strPhone1;
        private String strPhone2;
        private String strPhone3;
        private String strEmail;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string HospitalID { get => strHospitalID; set => strHospitalID = value; }
        public string? HospitalName { get => strHospitalName; set => strHospitalName = value; }
        public string? Address { get => strAddress; set => strAddress = value; }
        public string? City { get => strCity; set => strCity = value; }
        public string? State { get => strState; set => strState = value; }
        public string? Phone1 { get => strPhone1; set => strPhone1 = value; }
        public string? Phone2 { get => strPhone2; set => strPhone2 = value; }
        public string? Phone3 { get => strPhone3; set => strPhone3 = value; }
        public string? Email { get => strEmail; set => strEmail = value; }
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }

}
