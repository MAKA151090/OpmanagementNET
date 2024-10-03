using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class ProcedureCodeMasterModel
    {
        public ProcedureCodeMasterModel() 
        {
        
        }
        private String strProcedureID;
        private String strProcedureCode;
        private String strProcedureName;
        private String strCPTCode;
        private String strOtherCodeName;
        private String strOtherCode;
        private String strProcedureCodeDescription;
        private String strWHODescription;
        private String strProcedureCodeStatus;
        private String strCost;
        private String strTaxPercentage;
        private String strNetCost;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string ProcedureID { get => strProcedureID; set => strProcedureID = value; }

        [MaxLength(100)]
        public string? ProcedureCode { get => strProcedureCode; set => strProcedureCode = value; }

        [MaxLength(30)]
        public string? ProcedureName { get => strProcedureName; set => strProcedureName = value; }

        [MaxLength(30)]
        public string? CPTCode { get => strCPTCode; set => strCPTCode = value; }

        [MaxLength(30)]
        public string? OtherCodeName { get => strOtherCodeName; set => strOtherCodeName = value; }

        [MaxLength(30)]
        public string? OtherCode { get => strOtherCode; set => strOtherCode = value; }

        [MaxLength(100)]
        public string? ProcedureCodeDescription { get => strProcedureCodeDescription; set => strProcedureCodeDescription = value; }

        [MaxLength(100)]
        public string? WHODescription { get => strWHODescription; set => strWHODescription = value; }

        [MaxLength(30)]
        public string? ProcedureCodeStatus { get => strProcedureCodeStatus; set => strProcedureCodeStatus = value; }

        [MaxLength(30)]
        public string? Cost { get => strCost; set => strCost = value; }

        [MaxLength(30)]
        public string? TaxPercentage { get => strTaxPercentage; set => strTaxPercentage = value; }

        [MaxLength(30)]
        public string? NetCost { get => strNetCost; set => strNetCost = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
