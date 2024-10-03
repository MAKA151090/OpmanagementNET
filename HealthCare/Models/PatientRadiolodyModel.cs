using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PatientRadiolodyModel
    {
        public PatientRadiolodyModel()
        {
        }

        private String strRadioID;
        private String strFacilityID;
        private String strPatientID;
        private String strVisitcaseID;
        private String strReferralDoctorID;
        private String strReferralDoctorName;
        private String strScreeningDate;
        private String strResult;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private String strScreeningCompleted;
        private String strScreeningCompletedDate;



        [MaxLength(100)]
        public string RadioID { get => strRadioID; set => strRadioID = value; }

        [MaxLength(100)]
        public string PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(100)]
        public string? VisitcaseID { get => strVisitcaseID; set => strVisitcaseID = value; }

        [MaxLength(100)]
        public string? ReferralDoctorID { get => strReferralDoctorID; set => strReferralDoctorID = value; }

        [MaxLength(30)]
        public string? ReferralDoctorName { get => strReferralDoctorName; set => strReferralDoctorName = value; }

        [MaxLength(30)]
        public string ScreeningDate { get => strScreeningDate; set => strScreeningDate = value; }

        [MaxLength(30)]
        public string? Result { get => strResult; set => strResult = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? ScreeningCompleted { get => strScreeningCompleted; set => strScreeningCompleted = value; }

        [MaxLength(30)]
        public string? ScreeningCompletedDate { get => strScreeningCompletedDate; set => strScreeningCompletedDate = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }

        [MaxLength(100)]
        public string StrVisitcaseID { get => strVisitcaseID; set => strVisitcaseID = value; }
    }
}
