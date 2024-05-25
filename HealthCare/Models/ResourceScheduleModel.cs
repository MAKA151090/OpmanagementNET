using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class ResourceScheduleModel
    {
        public ResourceScheduleModel() { }

       
        private String strStaffID;
        private String strFacilityID;
        private String strFromDate;
        private String strToDate;
        private String duration;
        private String strFromTime;
        private String strToTime;
        private String strSlots;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private string strlastUpdatedMachine;

        public string? StaffID { get => strStaffID; set => strStaffID = value; }
        public string? FacilityID { get => strFacilityID; set => strFacilityID = value; }
        public string? FromDate { get => strFromDate; set => strFromDate = value; }
        public string? ToDate { get => strToDate; set => strToDate = value; }
        public string Duration { get => duration; set => duration = value; }
        public string? FromTime { get => strFromTime; set => strFromTime = value; }
        public string? ToTime { get => strToTime; set => strToTime = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Viewslot { get => strSlots; set => strSlots = value; }
    }
}
