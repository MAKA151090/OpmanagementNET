using System.ComponentModel.DataAnnotations;

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



        [MaxLength(100)]
        public string PatientID { get => patientID; set => patientID = value; }

        [MaxLength(100)]
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }

        [MaxLength(100)]
        public string BillID { get => billID; set => billID = value; }

        [MaxLength(30)]
        public string? BillDate { get => billDate; set => billDate = value; }

        [MaxLength(30)]
        public string? TotalBillAmount { get => totalBillAmount; set => totalBillAmount = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
