using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class EWSMasterModel
    {
        public EWSMasterModel() { }

        private String observationTypeID;
        private String observationName;
        private String unit;
        private String range;
        private String frequency;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        [MaxLength(100)]
        public string ObservationTypeID { get => observationTypeID; set => observationTypeID = value; }

        [MaxLength(30)]
        public string ObservationName { get => observationName; set => observationName = value; }

        [MaxLength(30)]
        public string Unit { get => unit; set => unit = value; }

        [MaxLength(30)]
        public string Range { get => range; set => range = value; }

        [MaxLength(30)]
        public string Frequency { get => frequency; set => frequency = value; }

        [MaxLength(30)]
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
