namespace HealthCare.Models
{
    public class WebErrorsModel
    {
        private string errodDesc;
        private string screenName;
        private string username;
        private string DateTime;

        public string ErrodDesc { get => errodDesc; set => errodDesc = value; }
        public string ScreenName { get => screenName; set => screenName = value; }
        public string Username { get => username; set => username = value; }
        public string ErrDateTime { get => DateTime; set => DateTime = value; }
    }
}
