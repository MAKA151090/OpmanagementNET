﻿namespace HealthCare.Models
{
    public class RollAccessMaster
    {
        public RollAccessMaster() { }

        private string staffID;
        private string rollName;
        private string lastupdatedDate;
        private string lastupdatedMachine;
        private string lastupdateduser;

        public string StaffID { get => staffID; set => staffID = value; }
        public string RollName { get => rollName; set => rollName = value; }
        public string LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        public string LastupdatedMachine { get => lastupdatedMachine; set => lastupdatedMachine = value; }
        public string Lastupdateduser { get => lastupdateduser; set => lastupdateduser = value; }
    }
}
