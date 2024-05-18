namespace HealthCare.Models
{
    public class LoginModel
    {
        public LoginModel() { }

        private String strEmail;
        private String strPassword;
        private String strLoggedIn;

        public string Email { get => strEmail; set => strEmail = value; }
        public string Password { get => strPassword; set => strPassword = value; }
        public string LoggedIn { get => strLoggedIn; set => strLoggedIn = value; }
    }
}
