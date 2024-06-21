using NonFactors.Mvc.Grid;

namespace HealthCare.Models
{
    public class EmployeeTaxViewModel
    {
        public EmployeeTaxViewModel() { }

        private string payrollID;
        private string staffID;
        private List<PayrollTaxModel> viewPayrollTax;

        public string PayrollID { get => payrollID; set => payrollID = value; }
        public string StaffID { get => staffID; set => staffID = value; }
        public List<PayrollTaxModel> ViewPayrollTax { get => viewPayrollTax; set => viewPayrollTax = value; }
    }
}
