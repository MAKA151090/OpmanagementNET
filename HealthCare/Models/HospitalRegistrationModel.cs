using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class HospitalRegistrationModel
    {

        public HospitalRegistrationModel() 
        {
        }
        private String strHospitalID;
        private String strHospitalName;
        private String strAddress;
        private String strCity;
        private String strState;
        private String strPhone1;
        private String strPhone2;
        private String strPhone3;
        private String strEmail;
        private String strlastUpdatedDate;
        private String strlastUpdatedUser;
        private String strlastUpdatedMachine;
        private long id;
        private bool isDelete;


        [MaxLength(100)]
        public string HospitalID { get => strHospitalID; set => strHospitalID = value; }

        [MaxLength(30)]
        public string HospitalName { get => strHospitalName; set => strHospitalName = value; }

        [MaxLength(100)]
        public string? Address { get => strAddress; set => strAddress = value; }

        [MaxLength(30)]
        public string? City { get => strCity; set => strCity = value; }

        [MaxLength(30)]
        public string? State { get => strState; set => strState = value; }

        [MaxLength(30)]
        public string? Phone1 { get => strPhone1; set => strPhone1 = value; }

        [MaxLength(30)]
        public string? Phone2 { get => strPhone2; set => strPhone2 = value; }

        [MaxLength(30)]
        public string? Phone3 { get => strPhone3; set => strPhone3 = value; }

        [MaxLength(30)]
        public string? Email { get => strEmail; set => strEmail = value; }

        [MaxLength(30)]
        public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

        [MaxLength(30)]
        public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

        [MaxLength(30)]
        public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

        public long Id { get => id; set => id = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }

}
