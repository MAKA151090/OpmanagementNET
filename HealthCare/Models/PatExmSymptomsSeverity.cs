using System;
using System.ComponentModel.DataAnnotations;

public class PatExmSymptomsSeverity
{
    public PatExmSymptomsSeverity(object value)
	{
	}

    public PatExmSymptomsSeverity()
    {
    }

    private String strExaminationID;
	private String strPatientID;
	private String strVisitID;
    private String strFacilityID;
    private String strSymptoms;
	private String strSeverity;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;


    [MaxLength(100)]
    public string ExaminationID { get => strExaminationID; set => strExaminationID = value; }

    [MaxLength(100)]
    public string PatientID { get => strPatientID; set => strPatientID = value; }

    [MaxLength(100)]
    public string VisitID { get => strVisitID; set => strVisitID = value; }

    [MaxLength(30)]
    public string? Symptoms { get => strSymptoms; set => strSymptoms = value; }

    [MaxLength(30)]
    public string? Severity { get => strSeverity; set => strSeverity = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(100)]
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}

