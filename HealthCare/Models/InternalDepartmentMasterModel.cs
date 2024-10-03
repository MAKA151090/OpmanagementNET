using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class InternalDepartmentMasterModel
    {
        public InternalDepartmentMasterModel() { }

        private String facilityID;
        private String departmentID;
        private String departmentName;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        [MaxLength(100)]
        public string DepartmentID { get => departmentID; set => departmentID = value; }

        [MaxLength(30)]
        public string DepartmentName { get => departmentName; set => departmentName = value; }

        [MaxLength(30)]
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
