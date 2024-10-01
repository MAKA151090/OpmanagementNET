namespace HealthCare.Models
{
    public class DrugStockModel
    {
        public DrugStockModel() { 
        }

        private String strIDNumber;
        private String strDrugID;
        private String strRackID;
        private String strManufacturingDate;
        private String strExpiryDate;
        private String strNumberOfStock;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private String facilityID;

        public string IDNumber { get => strIDNumber; set => strIDNumber = value; }
        public string DrugID { get => strDrugID; set => strDrugID = value; }
        public string? ManufacturingDate { get => strManufacturingDate; set => strManufacturingDate = value; }
        public string? ExpiryDate { get => strExpiryDate; set => strExpiryDate = value; }
        public string? NumberOfStock { get => strNumberOfStock; set => strNumberOfStock = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string? RackID { get => strRackID; set => strRackID = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
