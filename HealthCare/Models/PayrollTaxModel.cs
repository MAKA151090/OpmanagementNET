using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class PayrollTaxModel
    {
        public PayrollTaxModel() { }

        private string payrollID;
        private string taxtype;
        private string amount;
        private string staffID;
        private bool isDelete;
        private string lastUpdatedUser;
        private string lastUpdatedMachine;
        private string lastUpdatedDate;
        private string taxSlotID;

        public string PayrollID { get => payrollID; set => payrollID = value; }
        public string StaffID { get => staffID; set => staffID = value; }
       
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }
        public string? Amount { get => amount; set => amount = value; }
        public string? Taxtype { get => taxtype; set => taxtype = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? TaxSlotID { get => taxSlotID; set => taxSlotID = value; }
    }
}
