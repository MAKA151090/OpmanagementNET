namespace HealthCare.Models
{
    public class InpatientAdmissionModel
    {
        public InpatientAdmissionModel() { 
        }

        private String strLocation;
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
        private String strlastupdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;


        public string? Location { get => strLocation; set => strLocation = value; }
        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string? ConsultDoctorID { get => strConsultDoctorID; set => strConsultDoctorID = value; }
        public string? DutyDoctorID { get => strDutyDoctorID; set => strDutyDoctorID = value; }
        public string? ReferredByDoctorID { get => strReferredByDoctorID; set => strReferredByDoctorID = value; }
        public string? BedID { get => strBedID; set => strBedID = value; }
        public string? Purpose { get => strPurpose; set => strPurpose = value; }
        public string? AdditionConsultDoctorID { get => strAdditionConsultDoctorID; set => strAdditionConsultDoctorID = value; }
        public string? ConsultantDepartmentID { get => strConsultantDepartmentID; set => strConsultantDepartmentID = value; }
        public string? AttenderName { get => strAttenderName; set => strAttenderName = value; }
        public string? AttenderContact { get => strAttenderContact; set => strAttenderContact = value; }
        public string? AttenderEmail { get => strAttenderEmail; set => strAttenderEmail = value; }
        public string? DocInstruction { get => strDocInstruction; set => strDocInstruction = value; }
        public string? InpatientType { get => strInpatientType; set => strInpatientType = value; }
        public string? AdmissionDate { get => strAdmissionDate; set => strAdmissionDate = value; }
        public string CaseID { get => strCaseID; set => strCaseID = value; }
        public string? lastupdatedDate { get => strlastupdatedDate; set => strlastupdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    }
}
