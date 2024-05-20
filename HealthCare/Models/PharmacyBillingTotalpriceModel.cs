namespace HealthCare.Models
{
    public class PharmacyBillingTotalpriceModel
    {
        public PharmacyBillingTotalpriceModel()
        {

        }

        private String strPatientID;
        private String strVisitID;
        private String strOrderID;
        private String strVisitcaseID;
        private List<PharmacyBillingModel> strPharmacyBillingModelList;
        private String strTotalPrice;
        private String strTax;

        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string VisitID { get => strVisitID; set => strVisitID = value; }
        public string OrderID { get => strOrderID; set => strOrderID = value; }
        public List<PharmacyBillingModel> StrPharmacyBillingModelList { get => strPharmacyBillingModelList; set => strPharmacyBillingModelList = value; }
        public string TotalPrice { get => strTotalPrice; set => strTotalPrice = value; }
        public string StrTax { get => strTax; set => strTax = value; }
        public string StrVisitcaseID { get => strVisitcaseID; set => strVisitcaseID = value; }
    }
}
