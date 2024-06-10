namespace HealthCare.Models
{
    public class PatientPaymentModel
    {
        public PatientPaymentModel()
        {}


        private String strPatientID;
        private String strCaseVisitID;
        private String strBillID;
        private String strPaymentID;
        private String strTotalPaymentAmount;
        private bool strIsDelete;
        private String strDate;

        private string strlastUpdatedUser;
        private string strlastUpdatedDate;
        private string strlastUpdatedMachine;

        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string CaseVisitID { get => strCaseVisitID; set => strCaseVisitID = value; }
        public string? BillID { get => strBillID; set => strBillID = value; }
        public string PaymentID { get => strPaymentID; set => strPaymentID = value; }
        public string? TotalPaymentAmount { get => strTotalPaymentAmount; set => strTotalPaymentAmount = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
        public string? Date { get => strDate; set => strDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
