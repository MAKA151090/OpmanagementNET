using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class ClinicSurgeryMasterModel
    {
        public ClinicSurgeryMasterModel() { }

        private String surgeryName;
        private String surgeryID;
        private String cost;
        private String duration;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(30)]
        public string SurgeryName { get => surgeryName; set => surgeryName = value; }

        [MaxLength(100)]
        public string SurgeryID { get => surgeryID; set => surgeryID = value; }

        [MaxLength(30)]
        public string Cost { get => cost; set => cost = value; }

        [MaxLength(30)]
        public string Duration { get => duration; set => duration = value; }

        [MaxLength(30)]
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
