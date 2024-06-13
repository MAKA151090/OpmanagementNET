namespace HealthCare.Models
{
    public class PatientPaymentViewModel
    {
        public PatientPaymentViewModel() { }


        private string patientid;
        private string casevisitid;
        private string billid;
        private string paymentid;
        private List<PatientPaymentBillDetailsModel> billdetails;

        public string Patientid { get => patientid; set => patientid = value; }
        public string Casevisitid { get => casevisitid; set => casevisitid = value; }
        public string Billid { get => billid; set => billid = value; }
        public string Paymentid { get => paymentid; set => paymentid = value; }
        public List<PatientPaymentBillDetailsModel> Billdetails { get => billdetails; set => billdetails = value; }
    }

}
