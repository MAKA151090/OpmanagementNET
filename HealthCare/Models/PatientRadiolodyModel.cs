namespace HealthCare.Models
{
    public class PatientRadiolodyModel
    {
        public PatientRadiolodyModel()
        {
        }

        private String strRadioID;
        private String strClinicID;
        private String strPatientID;
        private String strReferralDoctorID;
        private String strReferralDoctorName;
        private String strScreeningDate;
        private String strResult;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private String strScreeningCompleted;
        private String strScreeningCompletedDate;



        public string RadioID { get => strRadioID; set => strRadioID = value; }
        public string ClinicID { get => strClinicID; set => strClinicID = value; }
        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string? ReferralDoctorID { get => strReferralDoctorID; set => strReferralDoctorID = value; }
        public string? ReferralDoctorName { get => strReferralDoctorName; set => strReferralDoctorName = value; }
        public string ScreeningDate { get => strScreeningDate; set => strScreeningDate = value; }
        public string? Result { get => strResult; set => strResult = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
        public string? ScreeningCompleted { get => strScreeningCompleted; set => strScreeningCompleted = value; }
        public string? ScreeningCompletedDate { get => strScreeningCompletedDate; set => strScreeningCompletedDate = value; }
    }
}
