using System;

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
    private List<PatExmSymptomsSeverity> severity;



    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string ExaminationID { get => strExaminationID; set => strExaminationID = value; }
    public string VisitID { get => strVisitID; set => strVisitID = value; }
    public string Complaint { get => strComplaint; set => strComplaint = value; }
    public string Diagnosis { get => strDiagnosis; set => strDiagnosis = value; }
    public string Prescription { get => strPrescription; set => strPrescription = value; }
    public string FollowUp { get => strFollowUp; set => strFollowUp = value; }
    public string lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public List<PatExmSymptomsSeverity> Severity { get => severity; set => severity = value; }
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
}
