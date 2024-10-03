using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PatientVisitIntoDocumentModel
    {
        public PatientVisitIntoDocumentModel()
        {
        }
        private String strPatientID;
        private String facilityID;
        private String strVisitID;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;


        [MaxLength(100)]
        public string PatientID { get => strPatientID; set => strPatientID = value; }

        [MaxLength(100)]
        public string VisitID { get => strVisitID; set => strVisitID = value; }

        [MaxLength(30)]
        public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
