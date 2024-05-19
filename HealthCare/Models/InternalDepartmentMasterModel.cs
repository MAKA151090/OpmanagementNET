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

        public string DepartmentID { get => departmentID; set => departmentID = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public string lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
