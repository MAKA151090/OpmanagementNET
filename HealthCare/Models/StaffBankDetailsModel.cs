using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class StaffBankDetailsModel
    {
        public StaffBankDetailsModel() { }

        private string staffID;
        private string staffName;
        private string bankName;
        private string accountNumber;
        private string iFSCCode;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUpdatedDate;
        private bool isDelete;
        private string primary;



        [MaxLength(100)]
        public string StaffID { get => staffID; set => staffID = value; }

        [MaxLength(30)]
        public string StaffName { get => staffName; set => staffName = value; }

        [MaxLength(30)]
        public string BankName { get => bankName; set => bankName = value; }

        [MaxLength(30)]
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }

        [MaxLength(30)]
        public string? IFSCCode { get => iFSCCode; set => iFSCCode = value; }

        [MaxLength(30)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }

        [MaxLength(30)]
        public string? Primary { get => primary; set => primary = value; }
    }
}
