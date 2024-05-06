using System;

public class PatientFHPHModel
{
	public PatientFHPHModel()
	{
	}
	private String strPatientID;
	private String strQuestion;
	private String strAnswer;
	private String strType;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;




    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string Question { get => strQuestion; set => strQuestion = value; }
    public string Answer { get => strAnswer; set => strAnswer = value; }
    public string Type { get => strType; set => strType = value; }
    public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
}
