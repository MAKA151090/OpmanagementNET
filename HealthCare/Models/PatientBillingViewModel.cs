namespace HealthCare.Models
{
    public class PatientBillingViewModel
    {
        public PatientBillingViewModel() { }

        private string patientID;
        private string caseVisitID;
        private string billID;
        private string billDate;
        private string detailID;
        private List<PatientBillDetailsModel> viewbilldetails;

        public string PatientID { get => patientID; set => patientID = value; }
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }
        public string BillID { get => billID; set => billID = value; }
        public string BillDate { get => billDate; set => billDate = value; }
        public List<PatientBillDetailsModel> Viewbilldetails { get => viewbilldetails; set => viewbilldetails = value; }
        public string DetailID { get => detailID; set => detailID = value; }
    }
}
