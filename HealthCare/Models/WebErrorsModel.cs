using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class WebErrorsModel
    {
        private string errodDesc;
        private string screenName;
        private string username;
        private string DateTime;
        private string machineName;

        [MaxLength(100)]
        public string ErrodDesc { get => errodDesc; set => errodDesc = value; }

        [MaxLength(100)]
        public string ScreenName { get => screenName; set => screenName = value; }

        [MaxLength(30)]
        public string Username { get => username; set => username = value; }

        [MaxLength(30)]
        public string ErrDateTime { get => DateTime; set => DateTime = value; }

        [MaxLength(30)]
        public string MachineName { get => machineName; set => machineName = value; }
    }
}
