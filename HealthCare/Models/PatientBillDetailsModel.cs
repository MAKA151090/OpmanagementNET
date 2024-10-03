using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace HealthCare.Models
{
    public class PatientBillDetailsModel
    {
        public PatientBillDetailsModel() { }


        private string billID;
        private string detailID;
        private string patientID;
        private string particulars;
        private string dateandTime;
        private string rate;
        private string units;
        private string tax;
        private string totalAmount;
        private bool isDelete;
        private string strlastUpdatedDate;
        private string strlastUpdatedUser;
        private string strlastUpdatedMachine;



        [MaxLength(100)]
        public string BillID { get => billID; set => billID = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DetailID { get => detailID; set => detailID = value; }

        [MaxLength(100)]
        public string? PatientID { get => patientID; set => patientID = value; }

        [MaxLength(30)]
        public string? Particulars { get => particulars; set => particulars = value; }
        [MaxLength(30)]
        public string? DateandTime { get => dateandTime; set => dateandTime = value; }

        [MaxLength(30)]
        public string? Rate { get => rate; set => rate = value; }
        [MaxLength(30)]
        public string? Units { get => units; set => units = value; }
        [MaxLength(30)]
        public string? Tax { get => tax; set => tax = value; }
        [MaxLength(30)]
        public string? TotalAmount { get => totalAmount; set => totalAmount = value; }
        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
