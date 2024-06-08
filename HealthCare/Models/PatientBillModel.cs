namespace HealthCare.Models
{
    public class PatientBillModel
    {
        public PatientBillModel() { }


        private string patientID;

        private string caseVisitID;

        private string billID;

        private string billDate;

        private string totalBillAmount;

        private bool isDelete;

        private string strlastUpdatedUser;
        private string strlastUpdatedDate;
        private string strlastUpdatedMachine;

        public string PatientID { get => patientID; set => patientID = value; }
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }
        public string BillID { get => billID; set => billID = value; }
        public string? BillDate { get => billDate; set => billDate = value; }
        public string? TotalBillAmount { get => totalBillAmount; set => totalBillAmount = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
