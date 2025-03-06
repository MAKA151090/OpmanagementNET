using HealthCare.Context;
using System;
using System.ComponentModel.DataAnnotations;

public class ClinicAdminModel
{
    public ClinicAdminModel()
	{

	}

    private String facilityID;
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
    private bool strIsDelete;
    private String template;
    private string hospital;



    [MaxLength(30)]
    public string? ClinicName { get => strClinicName; set => strClinicName = value; }

    [MaxLength(100)]
    public string? ClinicAddress { get => strClinicAddress; set => strClinicAddress = value; }

    [MaxLength(30)]
    public string? City { get => strCity; set => strCity = value; }

    [MaxLength(30)]
    public string? State { get => strState; set => strState = value; }

    [MaxLength(30)]
    public string? PostalCode { get => strPostalCode; set => strPostalCode = value; }

    [MaxLength(30)]
    public string? ClinicPhoneNumber { get => strClinicPhoneNumber; set => strClinicPhoneNumber = value; }

    [MaxLength(30)]
    public string? ClinicEmailAddress { get => strClinicEmailAddress; set => strClinicEmailAddress = value; }

    [MaxLength(30)]
    public string? FromHour { get => strFromHour; set => strFromHour = value; }

    [MaxLength(30)]
    public string? ToHour { get => strToHour; set => strToHour = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(100)]
    public string FacilityID { get => facilityID; set => facilityID = value; }

    public bool StrIsDelete { get => strIsDelete; set => strIsDelete = value; }

    [MaxLength(30)]
    public string? Template { get => template; set => template = value; }

    [MaxLength(50)]
   public string Hospital { get => hospital; set => hospital = value; }
}
