using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PatientObjectiveModel
{
	public PatientObjectiveModel()
	{
	}
    private String strPatientID;
    private String strFacilityID;
    private String strVisitID;
	private String strHeight;
	private String strWeight;
	private String strBloodPressure;
	private String strHeartRate;
	private String strTemperature;
	private String strResptryRate;
	private String strOxySat;
	private String strPulseRate;
	private String strVisitDate;
	private String strBldGluLvl;
	private String strCheifComplaint;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;





    [MaxLength(100)]
    public string PatientID { get => strPatientID; set => strPatientID = value; }


    [MaxLength(100)]
    public string VisitID { get => strVisitID; set => strVisitID = value; }

    [MaxLength(30)]
    public string? Height { get => strHeight; set => strHeight = value; }

    [MaxLength(30)]
    public string? Weight { get => strWeight; set => strWeight = value; }

    [MaxLength(30)]
    public string?BloodPressure { get => strBloodPressure; set => strBloodPressure = value; }

    [MaxLength(30)]
    public string? HeartRate { get => strHeartRate; set => strHeartRate = value; }

    [MaxLength(30)]
    public string? Temperature { get => strTemperature; set => strTemperature = value; }

    [MaxLength(30)]
    public string? ResptryRate { get => strResptryRate; set => strResptryRate = value; }

    [MaxLength(30)]
    public string? OxySat { get => strOxySat; set => strOxySat = value; }

    [MaxLength(30)]
    public string? PulseRate { get => strPulseRate; set => strPulseRate = value; }

    [MaxLength(30)]
    public string? VisitDate { get => strVisitDate; set => strVisitDate = value; }

    [MaxLength(30)]
    public string? BldGluLvl { get => strBldGluLvl; set => strBldGluLvl = value; }

    [MaxLength(100)]
    public string? CheifComplaint { get => strCheifComplaint; set => strCheifComplaint = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(100)]
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}
