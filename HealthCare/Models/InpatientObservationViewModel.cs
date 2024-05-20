using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class InpatientObservationViewModel
    {
        public InpatientObservationViewModel() {
           
        }


        private String bedNoID;
        private String patientID;
        private String observationID;
        private String dateTime;
        private String nurseID;
        private String answer;
        private String unit;
        private String frequency;
        private String observationName;
        private String range;


        private List<InpatientObservationModel> sHviewInpatientObs;

        public string BedNoID { get => bedNoID; set => bedNoID = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public string ObservationID { get => observationID; set => observationID = value; }
        public string? DateTime { get => dateTime; set => dateTime = value; }
        public string? NurseID { get => nurseID; set => nurseID = value; }
       
        public List<InpatientObservationModel> SHviewInpatientObs { get => sHviewInpatientObs; set => sHviewInpatientObs = value; }
        public string Answer { get => answer; set => answer = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Frequency { get => frequency; set => frequency = value; }
        public string ObservationName { get => observationName; set => observationName = value; }
        public string Range { get => range; set => range = value; }

     
    }
}
