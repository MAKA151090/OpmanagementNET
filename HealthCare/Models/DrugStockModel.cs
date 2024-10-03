using System.ComponentModel.DataAnnotations;

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


        [MaxLength(100)]
        public string IDNumber { get => strIDNumber; set => strIDNumber = value; }

        [MaxLength(100)]
        public string DrugID { get => strDrugID; set => strDrugID = value; }

        [MaxLength(30)]
        public string? ManufacturingDate { get => strManufacturingDate; set => strManufacturingDate = value; }

        [MaxLength(30)]
        public string? ExpiryDate { get => strExpiryDate; set => strExpiryDate = value; }

        [MaxLength(30)]
        public string? NumberOfStock { get => strNumberOfStock; set => strNumberOfStock = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? RackID { get => strRackID; set => strRackID = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
