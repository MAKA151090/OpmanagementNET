using System;
using System.ComponentModel.DataAnnotations;

public class PatientExaminationModel
{

    public PatientExaminationModel()
	{
	}

	private String strPatientID;
    private String strFacilityID;
    private String strExaminationID;
	private String strVisitID;
	private String strComplaint;
	private String strDiagnosis;
	private String strPrescription;
	private String strFollowUp;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;



    [MaxLength(100)]
    public string PatientID { get => strPatientID; set => strPatientID = value; }

    [MaxLength(100)]
    public string ExaminationID { get => strExaminationID; set => strExaminationID = value; }

    [MaxLength(100)]
    public string VisitID { get => strVisitID; set => strVisitID = value; }

    [MaxLength(30)]
    public string? Complaint { get => strComplaint; set => strComplaint = value; }

    [MaxLength(30)]
    public string? Diagnosis { get => strDiagnosis; set => strDiagnosis = value; }

    [MaxLength(30)]
    public string? Prescription { get => strPrescription; set => strPrescription = value; }

    [MaxLength(30)]
    public string? FollowUp { get => strFollowUp; set => strFollowUp = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(100)]
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}
