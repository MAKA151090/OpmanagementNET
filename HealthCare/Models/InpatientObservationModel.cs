using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace HealthCare.Models
{
    public class InpatientObservationModel
    {
    

    
        public InpatientObservationModel() { }



        private String bedNoID;
        private String patientID;
        private String answer;
        private String observationID;
        private String dateTime;
        private String nurseID;
        private String observationName;
        private String unit;
        private String range;
        private String frequency;
        private String observationTypeID;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string BedNoID { get => bedNoID; set => bedNoID = value; }

        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string ObservationID { get => observationID; set => observationID = value; }

        [MaxLength(30)]
        public string? DateTime { get => dateTime; set => dateTime = value; }

        [MaxLength(30)]
        public string? NurseID { get => nurseID; set => nurseID = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? Answer { get => answer; set => answer = value; }

        [MaxLength(30)]
        public string? ObservationName { get => observationName; set => observationName = value; }

        [MaxLength(30)]
        public string? Unit { get => unit; set => unit = value; }

        [MaxLength(30)]
        public string? Range { get => range; set => range = value; }

        [MaxLength(30)]
        public string? Frequency { get => frequency; set => frequency = value; }

        [MaxLength(30)]
        public string ObservationTypeID { get => observationTypeID; set => observationTypeID = value; }
   
        
    
    }
}
