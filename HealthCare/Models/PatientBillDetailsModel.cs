using Humanizer;
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
        private string isDelete;
        private string strlastUpdatedDate;
        private string strlastUpdatedUser;
        private string strlastUpdatedMachine;

        public string BillID { get => billID; set => billID = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DetailID { get => detailID; set => detailID = value; }
        public string? PatientID { get => patientID; set => patientID = value; }
        public string? Particulars { get => particulars; set => particulars = value; }
        public string? DateandTime { get => dateandTime; set => dateandTime = value; }
        public string? Rate { get => rate; set => rate = value; }
        public string? Units { get => units; set => units = value; }
        public string? Tax { get => tax; set => tax = value; }
        public string? TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string IsDelete { get => isDelete; set => isDelete = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
