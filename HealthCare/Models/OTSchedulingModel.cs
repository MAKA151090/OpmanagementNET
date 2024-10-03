using DocumentFormat.OpenXml.Presentation;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class OTSchedulingModel
    {
        public class OTScheduling { }

        private String strFacilityID;
        private String otScheduleID;
        private String tableID;
        private String operationType;
        private String priority;
        private String inchrgDepID;
        private String additionalNotes;
        private String comments;
        private String startDate;
        private String startTime;
        private String patientID;
        private String bookedBy;
        private String status;
        private String duration;
        private String teamID;
        private String teamName;
        private bool isDeleted;
        private String confirm;

        private String confirmDate;
        private String confirmBy;
        private String caseVisitID;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        [MaxLength(100)]
        public string OtScheduleID { get => otScheduleID; set => otScheduleID = value; }

        [MaxLength(100)]
        public string? TableID { get => tableID; set => tableID = value; }

        [MaxLength(30)]
        public string? OperationType { get => operationType; set => operationType = value; }

        [MaxLength(30)]
        public string? Priority { get => priority; set => priority = value; }

        [MaxLength(30)]
        public string? InchrgDepID { get => inchrgDepID; set => inchrgDepID = value; }

        [MaxLength(100)]
        public string? AdditionalNotes { get => additionalNotes; set => additionalNotes = value; }

        [MaxLength(100)]
        public string? Comments { get => comments; set => comments = value; }

        [MaxLength(30)]
        public string? StartDate { get => startDate; set => startDate = value; }

        [MaxLength(30)]
        public string? StartTime { get => startTime; set => startTime = value; }

        [MaxLength(100)]
        public string? PatientID { get => patientID; set => patientID = value; }

        [MaxLength(30)]
        public string? BookedBy { get => bookedBy; set => bookedBy = value; }

        [MaxLength(30)]
        public string? Status { get => status; set => status = value; }

        [MaxLength(30)]
        public string? Duration { get => duration; set => duration = value; }

        [MaxLength(100)]
        public string? TeamID { get => teamID; set => teamID = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? Confirm { get => confirm; set => confirm = value; }

        [MaxLength(30)]
        public string? ConfirmDate { get => confirmDate; set => confirmDate = value; }

        [MaxLength(30)]
        public string? ConfirmBy { get => confirmBy; set => confirmBy = value; }

        [MaxLength(30)]
        public string? TeamName { get => teamName; set => teamName = value; }

        [MaxLength(100)]
        public string CaseVisitID { get => caseVisitID; set => caseVisitID = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    }
}
