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

        public string PatientID { get => patientID; set => patientID = value; }
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }
        public string OrderID { get => orderID; set => orderID = value; }
        public string PatientName { get => patientName; set => patientName = value; }
        public string MedicactionName { get => medicactionName; set => medicactionName = value; }
        public string Unit { get => unit; set => unit = value; }
        public string UnitCategory { get => unitCategory; set => unitCategory = value; }
        public string Frequency { get => frequency; set => frequency = value; }
        public string FrequencyUnit { get => frequencyUnit; set => frequencyUnit = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public string Instructions { get => instructions; set => instructions = value; }
        public string DoctorName { get => doctorName; set => doctorName = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
