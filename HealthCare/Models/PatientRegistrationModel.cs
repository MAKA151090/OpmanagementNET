using System;
using System.ComponentModel.DataAnnotations;

public class PatientRegistrationModel
{
	public PatientRegistrationModel()
	{
	}
	private String strPatientID;
    private String strFacilityID;
    private String strFirstName;
	private String strMidName;
	private String strLastName;
	private String strFullName;
	private String strInitial;
	private String strPrefix;
	private String strDob;
	private String strAge;
	private String strGender;
	private String strBloodGroup;
	private String strPhoneNumber;
	private String strMaritalStatus;
	private String strAddress1;
	private String strAddress2;
	private String strCountry;
	private String strCity;
	private String strState;
	private String strPin;
	private String strIDPrfName;
	private String strIDPrfNumber;
	private String strCnctPrsnName;
	private String strRlnpatient;
	private String strEmgcyCntNum;
	private String strlastUpdatedDate;
	private String strlastUpdatedUser;
    private bool strIsDelete;
    private long id;





    [MaxLength(100)]
    public string PatientID { get => strPatientID; set => strPatientID = value; }

    [MaxLength(30)]
    public string? FirstName { get => strFirstName; set => strFirstName = value; }

    [MaxLength(30)]
    public string? MidName { get => strMidName; set => strMidName = value; }

    [MaxLength(30)]
    public string? LastName { get => strLastName; set => strLastName = value; }

    [MaxLength(30)]
    public string? FullName { get => strFullName; set => strFullName = value; }

    [MaxLength(30)]
    public string? Initial { get => strInitial; set => strInitial = value; }

    [MaxLength(30)]
    public string? Prefix { get => strPrefix; set => strPrefix = value; }

    [MaxLength(30)]
    public string? Dob { get => strDob; set => strDob = value; }

    [MaxLength(30)]
    public string? Age { get => strAge; set => strAge = value; }

    [MaxLength(30)]
    public string? Gender { get => strGender; set => strGender = value; }

    [MaxLength(30)]
    public string? BloodGroup { get => strBloodGroup; set => strBloodGroup = value; }

    [MaxLength(30)]
    public string? PhoneNumber { get => strPhoneNumber; set => strPhoneNumber = value; }

    [MaxLength(30)]
    public string? MaritalStatus { get => strMaritalStatus; set => strMaritalStatus = value; }

    [MaxLength(100)]
    public string? Address1 { get => strAddress1; set => strAddress1 = value; }

    [MaxLength(100)]
    public string? Address2 { get => strAddress2; set => strAddress2 = value; }

    [MaxLength(30)]
    public string? Country { get => strCountry; set => strCountry = value; }

    [MaxLength(30)]
    public string? City { get => strCity; set => strCity = value; }

    [MaxLength(30)]
    public string? State { get => strState; set => strState = value; }

    [MaxLength(30)]
    public string? Pin { get => strPin; set => strPin = value; }

    [MaxLength(30)]
    public string? IDPrfName { get => strIDPrfName; set => strIDPrfName = value; }

    [MaxLength(30)]
    public string? IDPrfNumber { get => strIDPrfNumber; set => strIDPrfNumber = value; }

    [MaxLength(30)]
    public string? CnctPrsnName { get => strCnctPrsnName; set => strCnctPrsnName = value; }

    [MaxLength(30)]
    public string? Rlnpatient { get => strRlnpatient; set => strRlnpatient = value; }

    [MaxLength(30)]
    public string? EmgcyCntNum { get => strEmgcyCntNum; set => strEmgcyCntNum = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(100)]
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
    public long Id { get => id; set => id = value; }
}
