﻿namespace HealthCare.Models
{
    public class OtDepartmentModel
    {
        public OtDepartmentModel() { }

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
    }
}
