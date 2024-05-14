using System;

public class ClinicAdminModel
{
	public ClinicAdminModel()
	{

	}
	
	private String strClinicID ;
	private String strClinicName ;
	private String strClinicAddress;
	private String strCity;
	private String strState;
	private String strPostalCode;
	private String strClinicPhoneNumber;
	private String strClinicEmailAddress;
	private String strFromHour;
	private String strToHour;
	private String strlastUpdatedDate;
	private String strlastUpdatedUser;





    public String ClinicId { get => strClinicID; set => strClinicID = value; }
    public String ClinicName { get => strClinicName; set => strClinicName = value; }
    public String ClinicAddress { get => strClinicAddress; set => strClinicAddress = value; }
    public String City { get => strCity; set => strCity = value; }
    public String State { get => strState; set => strState = value; }
    public String PostalCode { get => strPostalCode; set => strPostalCode = value; }
    public String ClinicPhoneNumber { get => strClinicPhoneNumber; set => strClinicPhoneNumber = value; }
    public String ClinicEmailAddress { get => strClinicEmailAddress; set => strClinicEmailAddress = value; }
    public String FromHour { get => strFromHour; set => strFromHour = value; }
    public String ToHour { get => strToHour; set => strToHour = value; }
    public String lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public String lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
}
