using System;

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






    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string? FirstName { get => strFirstName; set => strFirstName = value; }
    public string? MidName { get => strMidName; set => strMidName = value; }
    public string? LastName { get => strLastName; set => strLastName = value; }
    public string? FullName { get => strFullName; set => strFullName = value; }
    public string? Initial { get => strInitial; set => strInitial = value; }
    public string? Prefix { get => strPrefix; set => strPrefix = value; }
    public string? Dob { get => strDob; set => strDob = value; }
    public string? Age { get => strAge; set => strAge = value; }
    public string? Gender { get => strGender; set => strGender = value; }
    public string? BloodGroup { get => strBloodGroup; set => strBloodGroup = value; }
    public string? PhoneNumber { get => strPhoneNumber; set => strPhoneNumber = value; }
    public string? MaritalStatus { get => strMaritalStatus; set => strMaritalStatus = value; }
    public string? Address1 { get => strAddress1; set => strAddress1 = value; }
    public string? Address2 { get => strAddress2; set => strAddress2 = value; }
    public string? Country { get => strCountry; set => strCountry = value; }
    public string? City { get => strCity; set => strCity = value; }
    public string? State { get => strState; set => strState = value; }
    public string? Pin { get => strPin; set => strPin = value; }
    public string? IDPrfName { get => strIDPrfName; set => strIDPrfName = value; }
    public string? IDPrfNumber { get => strIDPrfNumber; set => strIDPrfNumber = value; }
    public string? CnctPrsnName { get => strCnctPrsnName; set => strCnctPrsnName = value; }
    public string? Rlnpatient { get => strRlnpatient; set => strRlnpatient = value; }
    public string? EmgcyCntNum { get => strEmgcyCntNum; set => strEmgcyCntNum = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
    public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
    public long Id { get => id; set => id = value; }
}
