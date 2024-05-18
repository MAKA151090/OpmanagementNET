using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class InpatientObservationViewModel
    {
        public InpatientObservationViewModel() { }
        
        private String bedNoID;
        private String patientID;
        private String observationID;
        private String dateTime;
        private String nurseID;
        private List<InpatientObservationModel> sHviewInpatientObs;

        public string BedNoID { get => bedNoID; set => bedNoID = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public string ObservationID { get => observationID; set => observationID = value; }
        public string? DateTime { get => dateTime; set => dateTime = value; }
        public string? NurseID { get => nurseID; set => nurseID = value; }
        public List<InpatientObservationModel> SHviewInpatientObs { get => sHviewInpatientObs; set => sHviewInpatientObs = value; }
    }
}
