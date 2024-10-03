using System;
using System.ComponentModel.DataAnnotations;

public class PatientScheduleModel
{
	public PatientScheduleModel()
	{
	}

	private String strPatientID;
    private String strFacilityID;
    private String strDoctorID;
	private String strDate;
	private String strDescription;
	private String strlastUpdatedDate;
	private String strlastUpdatedUser;
    private String strlastUpdatedMachine;



    [MaxLength(100)]
    public string PatientID { get => strPatientID; set => strPatientID = value; }

    [MaxLength(100)]
    public string? DoctorID { get => strDoctorID; set => strDoctorID = value; }

    [MaxLength(30)]
    public string? Date { get => strDate; set => strDate = value; }

    [MaxLength(30)]
    public string? Description { get => strDescription; set => strDescription = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(30)]
    public string StrlastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

    [MaxLength(100)]
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}
