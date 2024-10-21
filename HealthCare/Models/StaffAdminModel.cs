using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class StaffAdminModel
    {
        public StaffAdminModel() { }

        private String strStaffID;
        private String strResourceTypeID;
        private String strFirstName;
        private String strLastName;
        private String strFullName;
        private String strInitial;
        private String strPrefix;
        private String strGender;
        private String strDateofBirth;
        private String strAge;
        private String strAddress1;
        private String strAddress2;
        private String strCity;
        private String strState;
        private String strPin;
        private String strPhoneNumber;
        private String strEmailId;
        private String strNationality;
        private String strUserName;
        private String strPassword;
        private String strIdProofId;
        private String strIdProofName;
        private String strMedialLicenseNumber;
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;
        private String facilityID;
        private bool strIsDelete;
        private long id;


        [MaxLength(100)]
        public string StrStaffID { get => strStaffID; set => strStaffID = value; }

        [MaxLength(100)]
        public string? ResourceTypeID { get => strResourceTypeID; set => strResourceTypeID = value; }

        [MaxLength(30)]
        public string? StrFirstName { get => strFirstName; set => strFirstName = value; }

        [MaxLength(30)]
        public string? StrLastName { get => strLastName; set => strLastName = value; }

        [MaxLength(30)]
        public string? StrFullName { get => strFullName; set => strFullName = value; }

        [MaxLength(30)]
        public string? StrInitial { get => strInitial; set => strInitial = value; }

        [MaxLength(30)]
        public string? StrPrefix { get => strPrefix; set => strPrefix = value; }

        [MaxLength(30)]
        public string? StrGender { get => strGender; set => strGender = value; }

        [MaxLength(30)]
        public string? StrDateofBirth { get => strDateofBirth; set => strDateofBirth = value; }

        [MaxLength(30)]
        public string? StrAge { get => strAge; set => strAge = value; }

        [MaxLength(100)]
        public string? StrAddress1 { get => strAddress1; set => strAddress1 = value; }

        [MaxLength(100)]
        public string? StrAddress2 { get => strAddress2; set => strAddress2 = value; }

        [MaxLength(30)]
        public string? StrCity { get => strCity; set => strCity = value; }
        [MaxLength(30)]
        public string? StrState { get => strState; set => strState = value; }
        [MaxLength(30)]
        public string? StrPin { get => strPin; set => strPin = value; }
        [MaxLength(30)]
        public string? StrPhoneNumber { get => strPhoneNumber; set => strPhoneNumber = value; }
        [MaxLength(30)]
        public string? StrEmailId { get => strEmailId; set => strEmailId = value; }
        [MaxLength(30)]
        public string? StrNationality { get => strNationality; set => strNationality = value; }
        [MaxLength(30)]
        public string? StrUserName { get => strUserName; set => strUserName = value; }
        [MaxLength(30)]
        public string? StrPassword { get => strPassword; set => strPassword = value; }
        [MaxLength(30)]
        public string? StrIdProofId { get => strIdProofId; set => strIdProofId = value; }
        [MaxLength(30)]
        public string? StrIdProofName { get => strIdProofName; set => strIdProofName = value; }
        [MaxLength(30)]
        public string? StrMedialLicenseNumber { get => strMedialLicenseNumber; set => strMedialLicenseNumber = value; }
        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }
        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }
        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }
        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
        public long Id { get => id; set => id = value; }
    }
}
