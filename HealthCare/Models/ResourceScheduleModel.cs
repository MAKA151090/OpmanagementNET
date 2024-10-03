using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
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
        private bool strIsDelete;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private string strlastUpdatedMachine;



        [MaxLength(100)]
        public string? StaffID { get => strStaffID; set => strStaffID = value; }

        [MaxLength(100)]
        public string? FacilityID { get => strFacilityID; set => strFacilityID = value; }

        [MaxLength(30)]
        public string? FromDate { get => strFromDate; set => strFromDate = value; }

        [MaxLength(30)]
        public string? ToDate { get => strToDate; set => strToDate = value; }

        [MaxLength(30)]
        public string Duration { get => duration; set => duration = value; }

        [MaxLength(30)]
        public string? FromTime { get => strFromTime; set => strFromTime = value; }

        [MaxLength(30)]
        public string? ToTime { get => strToTime; set => strToTime = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Viewslot { get => strSlots; set => strSlots = value; }
        public bool StrIsDelete { get => strIsDelete; set => strIsDelete = value; }
    }
}
