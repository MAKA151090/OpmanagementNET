namespace HealthCare.Models
{
    public class RollAccessModel
    {
        public RollAccessModel() 
        {
        }
        private String strRollID;
        private String strScreenID;
        private String strAccess;
        private String strAuthorized;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        public string RollID { get => strRollID; set => strRollID = value; }
        public string ScreenID { get => strScreenID; set => strScreenID = value; }
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string Access { get => strAccess; set => strAccess = value; }
        public string Authorized { get => strAuthorized; set => strAuthorized = value; }
    }
}
