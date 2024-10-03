using System.ComponentModel.DataAnnotations;

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



        [MaxLength(100)]
        public string PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(100)]
        public string CaseVisitID { get => strCaseVisitID; set => strCaseVisitID = value; }

        [MaxLength(30)]
        public string? BillID { get => strBillID; set => strBillID = value; }

        [MaxLength(30)]
        public string PaymentID { get => strPaymentID; set => strPaymentID = value; }
        
        [MaxLength(30)]
        public string? TotalPaymentAmount { get => strTotalPaymentAmount; set => strTotalPaymentAmount = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }

        [MaxLength(30)]
        public string? Date { get => strDate; set => strDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
