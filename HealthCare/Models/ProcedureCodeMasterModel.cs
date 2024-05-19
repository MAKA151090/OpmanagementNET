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

        public string ProcedureID { get => strProcedureID; set => strProcedureID = value; }
        public string? ProcedureCode { get => strProcedureCode; set => strProcedureCode = value; }
        public string? ProcedureName { get => strProcedureName; set => strProcedureName = value; }
        public string? CPTCode { get => strCPTCode; set => strCPTCode = value; }
        public string? OtherCodeName { get => strOtherCodeName; set => strOtherCodeName = value; }
        public string? OtherCode { get => strOtherCode; set => strOtherCode = value; }
        public string? ProcedureCodeDescription { get => strProcedureCodeDescription; set => strProcedureCodeDescription = value; }
        public string? WHODescription { get => strWHODescription; set => strWHODescription = value; }
        public string? ProcedureCodeStatus { get => strProcedureCodeStatus; set => strProcedureCodeStatus = value; }
        public string? Cost { get => strCost; set => strCost = value; }
        public string? TaxPercentage { get => strTaxPercentage; set => strTaxPercentage = value; }
        public string? NetCost { get => strNetCost; set => strNetCost = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
