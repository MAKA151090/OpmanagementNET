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

        public string StaffID { get => staffID; set => staffID = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public string BankName { get => bankName; set => bankName = value; }
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string? IFSCCode { get => iFSCCode; set => iFSCCode = value; }
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        public string? Primary { get => primary; set => primary = value; }
    }
}
