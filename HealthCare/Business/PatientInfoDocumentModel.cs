using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Business
{
    public class PatientInfoDocumentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private String patientID;
        private String visitID;
        private String facilityID;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;

        public string PatientID { get => patientID; set => patientID = value; }
        public string VisitID { get => visitID; set => visitID = value; }
        public string StrlastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
        public string StrlastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
        public string FacilityID { get => facilityID; set => facilityID = value; }
    }
}
