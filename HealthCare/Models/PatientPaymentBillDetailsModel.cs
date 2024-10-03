using System.ComponentModel.DataAnnotations;
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


        [MaxLength(100)]
        public string PaymentID { get => strPaymentID; set => strPaymentID = value; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PaymentDetailID { get => strPaymentDetailID; set => strPaymentDetailID = value; }

        [MaxLength(30)]
        public string? PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(30)]
        public string? PaymentDescription { get => strPaymentDescription; set => strPaymentDescription = value; }

        [MaxLength(30)]
        public string? DateandTime { get => strDateandTime; set => strDateandTime = value; }

        [MaxLength(30)]
        public string? AmountPaid { get => strAmountPaid; set => strAmountPaid = value; }

        [MaxLength(30)]
        public string? PaymentMode { get => strPaymentMode; set => strPaymentMode = value; }

        [MaxLength(30)]
        public string? TransactionDetails { get => strTransactionDetails; set => strTransactionDetails = value; }

        [MaxLength(30)]
        public string? OtherComments { get => strOtherComments; set => strOtherComments = value; }

        public bool IdDelte { get => strIsDelte; set => strIsDelte = value; }

        [MaxLength(30)]
        public string? PaymentDate { get => strPaymentDate; set => strPaymentDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
