using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PatientEPrescriptionPrintModel
    {
        public PatientEPrescriptionPrintModel() { }

        private String patientID;
        private String caseVisitID;
        private String orderID;
        private String patientName;
        private String medicactionName;
        private String unit;
        private String unitCategory;
        private String frequency;
        private String frequencyUnit;
        private String duration;
        private String quantity;
        private String endDate;
        private String instructions;
        private String doctorName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }

        [MaxLength(100)]
        public string OrderID { get => orderID; set => orderID = value; }

        [MaxLength(30)]
        public string? PatientName { get => patientName; set => patientName = value; }

        [MaxLength(30)]
        public string? MedicactionName { get => medicactionName; set => medicactionName = value; }

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
        public string? Quantity { get => quantity; set => quantity = value;}

        [MaxLength(30)]
        public string? EndDate { get => endDate; set => endDate = value; }

        [MaxLength(100)]
        public string? Instructions { get => instructions; set => instructions = value; }

        [MaxLength(30)]
        public string? DoctorName { get => doctorName; set => doctorName = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
