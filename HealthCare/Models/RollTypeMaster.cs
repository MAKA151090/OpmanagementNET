﻿namespace HealthCare.Models
{
    public class RollTypeMaster
    {
        public RollTypeMaster() { }

        private string rollID;
        private string rollName;
        private string lastupdatedUser;
        private string lastupdatedDate;
        private string lastupdatedMachine;
        private string facilityID;


        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string? LastupdatedMachine { get => lastupdatedMachine; set => lastupdatedMachine = value; }
        public string RollID { get => rollID; set => rollID = value; }
        public string RollName { get => rollName; set => rollName = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
