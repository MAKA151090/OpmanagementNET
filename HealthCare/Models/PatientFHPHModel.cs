using HealthCare.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class PatientFHPHModel
{
	public PatientFHPHModel()
	{
	}
	private String strPatientID;
	private String strQuestionId;
    private String strAnswer;
	private String strType;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;
    private String strlastUpdatedMachine;




    [MaxLength(100)]
    public string PatientID { get => strPatientID; set => strPatientID = value; }

    [MaxLength(100)]
    public string QuestionID { get => strQuestionId; set => strQuestionId = value; }

    [MaxLength(100)]
    public string? Answer { get => strAnswer; set => strAnswer = value; }

    [MaxLength(30)]
    public string Type { get => strType; set => strType = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(30)]
    public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
  
}
