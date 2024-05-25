namespace HealthCare.Models
{
    public class UpdateRadiologyResultsModel
    {
        public UpdateRadiologyResultsModel() 
        {

        }
        private String strPatientID;
        private String strFacilityID;
        private String strRadioID;
        private String strImageID;
        private string srtImageData;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private byte[] resultImage;


        public string PatientID { get => strPatientID; set => strPatientID = value; }
        public string RadioID { get => strRadioID; set => strRadioID = value; }
        public string ImageID { get => strImageID; set => strImageID = value; }
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string ImageData { get => srtImageData; set => srtImageData = value; }
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
        public byte[] ResultImage { get => resultImage; set => resultImage = value; }
    }
}
