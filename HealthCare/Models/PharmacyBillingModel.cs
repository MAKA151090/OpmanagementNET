namespace HealthCare.Models
{
    public class PharmacyBillingModel
    {
       public PharmacyBillingModel() 
        {
        }

        private String strPatientID;
        private String strVisitID;
        private String strOrderID;
        private String strVisitcaseID;
        private String strMedication;
        private String strUnit;
        private String strUnitprice;
        private String strTotalprice;
        private String strTax;
        private String strNetPrice;

        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string VisitID { get => strVisitID; set => strVisitID = value; }
        public string Medication { get => strMedication; set => strMedication = value; }
        public string Unit { get => strUnit; set => strUnit = value; }
        public string Unitprice { get => strUnitprice; set => strUnitprice = value; }
        public string Totalprice { get => strTotalprice; set => strTotalprice = value; }
        public string Tax { get => strTax; set => strTax = value; }
        public string OrderID { get => strOrderID; set => strOrderID = value; }
        public string NetPrice { get => strNetPrice; set => strNetPrice = value; }
        public string VisitcaseID { get => strVisitcaseID; set => strVisitcaseID = value; }
    }
}
