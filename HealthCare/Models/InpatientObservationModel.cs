namespace HealthCare.Models
{
    public class InpatientObservationModel
    {
        public InpatientObservationModel() { }

        private String bedNoID;
        private String patientID;
        private String observationID;
        private String dateTime;
        private String nurseID;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        public  List<InpatientObservationViewModel>SHviewInpatientObs;

        public string BedNoID { get => bedNoID; set => bedNoID = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public string ObservationID { get => observationID; set => observationID = value; }
       
        public string DateTime { get => dateTime; set => dateTime = value; }
        public string NurseID { get => nurseID; set => nurseID = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
