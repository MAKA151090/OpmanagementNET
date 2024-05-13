using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PatientObjectiveModel
{
	public PatientObjectiveModel()
	{
	}
    private String strPatientID;
	private String strClinicID;
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






    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string ClinicID { get => strClinicID; set => strClinicID = value; }
    public string VisitID { get => strVisitID; set => strVisitID = value; }
    public string? Height { get => strHeight; set => strHeight = value; }
    public string? Weight { get => strWeight; set => strWeight = value; }
    public string?BloodPressure { get => strBloodPressure; set => strBloodPressure = value; }
    public string? HeartRate { get => strHeartRate; set => strHeartRate = value; }
    public string? Temperature { get => strTemperature; set => strTemperature = value; }
    public string? ResptryRate { get => strResptryRate; set => strResptryRate = value; }
    public string? OxySat { get => strOxySat; set => strOxySat = value; }
    public string? PulseRate { get => strPulseRate; set => strPulseRate = value; }
    public string? VisitDate { get => strVisitDate; set => strVisitDate = value; }
    public string? BldGluLvl { get => strBldGluLvl; set => strBldGluLvl = value; }
    public string? CheifComplaint { get => strCheifComplaint; set => strCheifComplaint = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
}
