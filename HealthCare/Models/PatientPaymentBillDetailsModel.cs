using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class PatientPaymentBillDetailsModel
    {
        public PatientPaymentBillDetailsModel() { }


        private string strPaymentID;
        private string strPaymentDetailID;
        private string strPatientID;
        private string strPaymentDescription;
        private string strDateandTime;
        private string strAmountPaid;
        private string strPaymentMode;
        private string strTransactionDetails;
        private string strOtherComments;
        private bool strIsDelte;
        private string strPaymentDate;
        private string strlastUpdatedDate;
        private string strlastUpdatedUser;
        private string strlastUpdatedMachine;

        public string PaymentID { get => strPaymentID; set => strPaymentID = value; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PaymentDetailID { get => strPaymentDetailID; set => strPaymentDetailID = value; }
        public string? PatientID { get => strPatientID; set => strPatientID = value; }
        public string? PaymentDescription { get => strPaymentDescription; set => strPaymentDescription = value; }
        public string? DateandTime { get => strDateandTime; set => strDateandTime = value; }
        public string? AmountPaid { get => strAmountPaid; set => strAmountPaid = value; }
        public string? PaymentMode { get => strPaymentMode; set => strPaymentMode = value; }
        public string? TransactionDetails { get => strTransactionDetails; set => strTransactionDetails = value; }
        public string? OtherComments { get => strOtherComments; set => strOtherComments = value; }
        public bool IdDelte { get => strIsDelte; set => strIsDelte = value; }
        public string? PaymentDate { get => strPaymentDate; set => strPaymentDate = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
