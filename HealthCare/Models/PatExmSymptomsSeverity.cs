using System;

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



    public string ExaminationID { get => strExaminationID; set => strExaminationID = value; }
    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string VisitID { get => strVisitID; set => strVisitID = value; }
    public string Symptoms { get => strSymptoms; set => strSymptoms = value; }
    public string Severity { get => strSeverity; set => strSeverity = value; }
    public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}

