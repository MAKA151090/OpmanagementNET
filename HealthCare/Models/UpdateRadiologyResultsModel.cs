using System.ComponentModel.DataAnnotations;

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

        [MaxLength(100)]
        public string PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(100)]
        public string RadioID { get => strRadioID; set => strRadioID = value; }

        [MaxLength(100)]
        public string ImageID { get => strImageID; set => strImageID = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(100)]
        public string ImageData { get => srtImageData; set => srtImageData = value; }

        [MaxLength(100)]
        public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
        public byte[] ResultImage { get => resultImage; set => resultImage = value; }
    }
}
