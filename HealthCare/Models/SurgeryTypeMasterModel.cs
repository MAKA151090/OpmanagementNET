using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class SurgeryTypeMasterModel
    {
        public SurgeryTypeMasterModel() { }

        private String surgeryTypeID;
        private String surgeryTypeName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string SurgeryTypeID { get => surgeryTypeID; set => surgeryTypeID = value; }

        [MaxLength(30)]
        public string SurgeryTypeName { get => surgeryTypeName; set => surgeryTypeName = value; }

        [MaxLength(30)]
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
