namespace HealthCare.Models
{
    public class PrescriptionViewModel
    {
        public PrescriptionViewModel() { }

        private long epressID;
        private string patientID;
        private string caseVisitID;
        private string orderID;
        private string doctorID;
        private string drugID;
        private string prescriptionDate;
        private string unit;
        private string unitCategory;
        private string frequency;
        private string frequencyUnit;
        private string duration;
        private string quantity;
        private string endDate;
        private string routeAdmin;
        private string instructions;
        private string comments;
        private string fillDate;
        private string result;
        private string strlastupdatedDate;
        private string strlastUpdatedUser;
        private string strlastUpdatedMachine;
        private string drugName;
        private string dosage;
        private String morningunit;
        private String afternoonunit;
        private String eveningunit;
        private String nightunit;
        private string facilityID;

        private string dbpatientID;


        public long EpressID { get => epressID; set => epressID = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }
        public string OrderID { get => orderID; set => orderID = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public string DrugID { get => drugID; set => drugID = value; }
        public string PrescriptionDate { get => prescriptionDate; set => prescriptionDate = value; }
        public string Unit { get => unit; set => unit = value; }
        public string UnitCategory { get => unitCategory; set => unitCategory = value; }
        public string Frequency { get => frequency; set => frequency = value; }
        public string FrequencyUnit { get => frequencyUnit; set => frequencyUnit = value; }
        public string Duration { get => duration; set => duration = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public string RouteAdmin { get => routeAdmin; set => routeAdmin = value; }
        public string Instructions { get => instructions; set => instructions = value; }
        public string Comments { get => comments; set => comments = value; }
        public string FillDate { get => fillDate; set => fillDate = value; }
        public string Result { get => result; set => result = value; }
        public string StrlastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string StrlastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string StrlastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string DrugName { get => drugName; set => drugName = value; }
        public string Dosage { get => dosage; set => dosage = value; }
        public string Morningunit { get => morningunit; set => morningunit = value; }
        public string Afternoonunit { get => afternoonunit; set => afternoonunit = value; }
        public string Eveningunit { get => eveningunit; set => eveningunit = value; }
        public string Nightunit { get => nightunit; set => nightunit = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public string DbpatientID { get => dbpatientID; set => dbpatientID = value; }
    }
}
