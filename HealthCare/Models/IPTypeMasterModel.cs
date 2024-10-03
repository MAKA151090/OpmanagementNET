using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class IPTypeMasterModel
    {
        public IPTypeMasterModel() { }

        private String strIPTypeID;
        private String strIPTypeName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        [MaxLength(100)]
        public string IPTypeID { get => strIPTypeID; set => strIPTypeID = value; }

        [MaxLength(30)]
        public string? IPTypeName { get => strIPTypeName; set => strIPTypeName = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}

