using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class TaxModel
    {
        public TaxModel() { }

        private string taxID;
        private string taxType;
        private string taxAmount;
        private string applicablePeriod;
        private string lastUpdatedUser;
        private string lastUpdatedDate;
        private string lastUpdatedMachine;



        [MaxLength(100)]
        public string TaxID { get => taxID; set => taxID = value; }

        [MaxLength(100)]
        public string TaxType { get => taxType; set => taxType = value; }

        [MaxLength(30)]
        public string? TaxAmount { get => taxAmount; set => taxAmount = value; }

        [MaxLength(30)]
        public string? ApplicablePeriod { get => applicablePeriod; set => applicablePeriod = value; }

        [MaxLength(30)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value; }

        [MaxLength(30)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
    }
}
