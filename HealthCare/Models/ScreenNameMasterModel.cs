using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class ScreenNameMasterModel
    {
       public ScreenNameMasterModel() { }

        private string screenName;
        private string id;

        [MaxLength(30)]
        public string ScreenName { get => screenName; set => screenName = value; }

        [MaxLength(100)]
        public string Id { get => id; set => id = value; }
    }
}
