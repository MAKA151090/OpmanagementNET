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

        public string ObservationTypeID { get => observationTypeID; set => observationTypeID = value; }
        public string ObservationName { get => observationName; set => observationName = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Range { get => range; set => range = value; }
        public string Frequency { get => frequency; set => frequency = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
