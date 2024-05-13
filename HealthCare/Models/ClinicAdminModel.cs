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





    public string ClinicId { get => strClinicID; set => strClinicID = value; }
    public string? ClinicName { get => strClinicName; set => strClinicName = value; }
    public string? ClinicAddress { get => strClinicAddress; set => strClinicAddress = value; }
    public string? City { get => strCity; set => strCity = value; }
    public string? State { get => strState; set => strState = value; }
    public string? PostalCode { get => strPostalCode; set => strPostalCode = value; }
    public string? ClinicPhoneNumber { get => strClinicPhoneNumber; set => strClinicPhoneNumber = value; }
    public string? ClinicEmailAddress { get => strClinicEmailAddress; set => strClinicEmailAddress = value; }
    public string? FromHour { get => strFromHour; set => strFromHour = value; }
    public string? ToHour { get => strToHour; set => strToHour = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
}
