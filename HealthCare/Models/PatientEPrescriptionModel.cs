using DocumentFormat.OpenXml.Presentation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Models
{
    public class PatientEPrescriptionModel
    {
        public PatientEPrescriptionModel() { }

        /*private long epressID;*/
        private String patientID;
        private String caseVisitID;
        private String orderID;
        private String doctorID;
        private String drugID;
        private String prescriptionDate;
        private String unit;
        private String unitCategory;
        private String frequency;
        private String frequencyUnit;
        private String duration;
        private String quantity;
        private String endDate;
        private String routeAdmin;
        private String instructions;
        private String comments;
        private String fillDate;
        private String result;
        private bool isDelete;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private String facilityID;
        private String morningunit;
        private String afternoonunit;
        private String eveningunit;
        private String nightunit;
       


       /* [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EpressID { get => epressID; set => epressID = value; }*/

        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }

        [MaxLength(30)]
        public string? OrderID { get => orderID; set => orderID = value; }

        [MaxLength(100)]
        public string? DoctorID { get => doctorID; set => doctorID = value; }

        [MaxLength(100)]
        public string DrugID { get => drugID; set => drugID = value; }

        [MaxLength(30)]
        public string? PrescriptionDate { get => prescriptionDate; set => prescriptionDate = value; }

        [MaxLength(30)]
        public string? Unit { get => unit; set => unit = value; }

        [MaxLength(30)]
        public string? UnitCategory { get => unitCategory; set => unitCategory = value; }

        [MaxLength(30)]
        public string? Frequency { get => frequency; set => frequency = value; }

        [MaxLength(30)]
        public string? FrequencyUnit { get => frequencyUnit; set => frequencyUnit = value; }

        [MaxLength(30)]
        public string? Duration { get => duration; set => duration = value; }

        [MaxLength(30)]
        public string? Quantity { get => quantity; set => quantity = value; }

        [MaxLength(30)]
        public string? EndDate { get => endDate; set => endDate = value; }

        [MaxLength(30)]
        public string? RouteAdmin { get => routeAdmin; set => routeAdmin = value; }

        [MaxLength(100)]
        public string? Instructions { get => instructions; set => instructions = value; }

        [MaxLength(100)]
        public string? Comments { get => comments; set => comments = value; }

        [MaxLength(30)]
        public string? FillDate { get => fillDate; set => fillDate = value; }

        [MaxLength(100)]
        public string? Result { get => result; set => result = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        
       
        public bool IsDelete { get => isDelete; set => isDelete = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }

        [MaxLength(30)]
        public string? Morningunit { get => morningunit; set => morningunit = value; }

        [MaxLength(30)]
        public string? Afternoonunit { get => afternoonunit; set => afternoonunit = value; }

        [MaxLength(30)]
        public string? Eveningunit { get => eveningunit; set => eveningunit = value; }

        [MaxLength(30)]
        public string? Nightunit { get => nightunit; set => nightunit = value; }
       
    }
}
