using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class ScreenMasterModel
    {
        public ScreenMasterModel() 
        {
        }
        private String strScreenId;
        private String strScreenName;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string ScreenId { get => strScreenId; set => strScreenId = value; }

        [MaxLength(30)]
        public string? ScreenName { get => strScreenName; set => strScreenName = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
       
       
    }

}
