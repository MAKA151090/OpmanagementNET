using System;

public class PatientFHPHModel
{
	public PatientFHPHModel()
	{
	}
	private String strPatientID;
	private String strQuestionId;
    private String strFacilityID;
    private String strAnswer;
	private String strType;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;




    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string QuestionID { get => strQuestionId; set => strQuestionId = value; }
    public string? Answer { get => strAnswer; set => strAnswer = value; }
    public string Type { get => strType; set => strType = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; } 
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}
