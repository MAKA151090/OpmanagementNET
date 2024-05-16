namespace HealthCare.Models
{
    public class RadiologyViewResultModel
    {
        public RadiologyViewResultModel()
        {

        }

        private String strPatentName;
        private String strRadioID;
        private String strClinicID;
        private String strRadioName;
        private String strScreeningDate;
        private String strResult;
        private String strReferralDoctorName;

        public string PatentName { get => strPatentName; set => strPatentName = value; }
        public string RadioID { get => strRadioID; set => strRadioID = value; }
        public string ClinicID { get => strClinicID; set => strClinicID = value; }
        public string RadioName { get => strRadioName; set => strRadioName = value; }
        public string ScreeningDate { get => strScreeningDate; set => strScreeningDate = value; }
        public string Result { get => strResult; set => strResult = value; }
        public string ReferralDoctorName { get => strReferralDoctorName; set => strReferralDoctorName = value; }
    }
}
