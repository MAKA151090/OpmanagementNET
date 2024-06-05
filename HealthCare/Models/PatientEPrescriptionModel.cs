using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class PatientEPrescriptionModel
    {
        public PatientEPrescriptionModel() { }

        private long epressID;
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EpressID { get => epressID; set => epressID = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }
        public string OrderID { get => orderID; set => orderID = value; }
        public string? DoctorID { get => doctorID; set => doctorID = value; }
        public string DrugID { get => drugID; set => drugID = value; }
        public string? PrescriptionDate { get => prescriptionDate; set => prescriptionDate = value; }
        public string? Unit { get => unit; set => unit = value; }
        public string? UnitCategory { get => unitCategory; set => unitCategory = value; }
        public string? Frequency { get => frequency; set => frequency = value; }
        public string? FrequencyUnit { get => frequencyUnit; set => frequencyUnit = value; }
        public string? Duration { get => duration; set => duration = value; }
        public string? Quantity { get => quantity; set => quantity = value; }
        public string? EndDate { get => endDate; set => endDate = value; }
        public string? RouteAdmin { get => routeAdmin; set => routeAdmin = value; }
        public string? Instructions { get => instructions; set => instructions = value; }
        public string? Comments { get => comments; set => comments = value; }
        public string? FillDate { get => fillDate; set => fillDate = value; }
        public string? Result { get => result; set => result = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        
       
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
