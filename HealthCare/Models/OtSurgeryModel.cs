using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OtSurgeryModel
    {
        private String otScheduleID;
        private String surgeryID;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        [MaxLength(100)]
        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }

        [MaxLength(100)]
        public string SurgeryID { get => surgeryID; set => surgeryID = value; }

        [MaxLength(30)]
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
