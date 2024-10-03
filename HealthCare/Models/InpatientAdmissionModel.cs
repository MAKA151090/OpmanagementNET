using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class InpatientAdmissionModel
    {
        public InpatientAdmissionModel() { 
        }

        private String strFacilityID;
        private String strPatientID;
        private String strCaseID;
        private String strConsultDoctorID;
        private String strDutyDoctorID;
        private String strReferredByDoctorID;
        private String strBedID;
        private String strPurpose;
        private String strAdditionConsultDoctorID;
        private String strConsultantDepartmentID;
        private String strAttenderName;
        private String strAttenderContact;
        private String strAttenderEmail;
        private String strDocInstruction;
        private String strInpatientType;
        private String strAdmissionDate;
        private string strStatus;
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }

        [MaxLength(100)]
        public string PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(100)]
        public string? ConsultDoctorID { get => strConsultDoctorID; set => strConsultDoctorID = value; }

        [MaxLength(100)]
        public string? DutyDoctorID { get => strDutyDoctorID; set => strDutyDoctorID = value; }

        [MaxLength(100)]
        public string? ReferredByDoctorID { get => strReferredByDoctorID; set => strReferredByDoctorID = value; }

        [MaxLength(100)]
        public string? BedID { get => strBedID; set => strBedID = value; }

        [MaxLength(30)]
        public string? Purpose { get => strPurpose; set => strPurpose = value; }

        [MaxLength(100)]
        public string? AdditionConsultDoctorID { get => strAdditionConsultDoctorID; set => strAdditionConsultDoctorID = value; }

        [MaxLength(100)]
        public string? ConsultantDepartmentID { get => strConsultantDepartmentID; set => strConsultantDepartmentID = value; }

        [MaxLength(30)]
        public string? AttenderName { get => strAttenderName; set => strAttenderName = value; }

        [MaxLength(30)]
        public string? AttenderContact { get => strAttenderContact; set => strAttenderContact = value; }

        [MaxLength(30)]
        public string? AttenderEmail { get => strAttenderEmail; set => strAttenderEmail = value; }

        [MaxLength(100)]
        public string? DocInstruction { get => strDocInstruction; set => strDocInstruction = value; }

        [MaxLength(30)]
        public string? InpatientType { get => strInpatientType; set => strInpatientType = value; }

        [MaxLength(30)]
        public string? AdmissionDate { get => strAdmissionDate; set => strAdmissionDate = value; }

        [MaxLength(100)]
        public string CaseID { get => strCaseID; set => strCaseID = value; }

        [MaxLength(30)]
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? Status { get => strStatus; set => strStatus = value; }
    }
}
