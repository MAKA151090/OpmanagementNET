namespace HealthCare.Models
{
    public class EmployeePayrollView
    {
        public EmployeePayrollView() { }

        private string payrollID;
      
        private string staffID;
        private string total;
        private string month;
        private string year;
        private List<EmployeePayrollModel> shpayrollview;

        public string PayrollID { get => payrollID; set => payrollID = value; }
      
        public string StaffID { get => staffID; set => staffID = value; }
        public List<EmployeePayrollModel> Shpayrollview { get => shpayrollview; set => shpayrollview = value; }
        public string Total { get => total; set => total = value; }
        public string Month { get => month; set => month = value; }
        public string Year { get => year; set => year = value; }
    }
}
