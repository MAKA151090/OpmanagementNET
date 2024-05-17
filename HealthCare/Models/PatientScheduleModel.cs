using System;

public class PatientScheduleModel
{
	public PatientScheduleModel()
	{
	}

	private String strPatientID;
	private String strClinicID;
	private String strDoctorID;
	private String strDate;
	private String strDescription;
	private String strlastUpdatedDate;
	private String strlastUpdatedUser;
    private String strlastUpdatedMachine;




    public string PatientID { get => strPatientID; set => strPatientID = value; }
    public string? ClinicID { get => strClinicID; set => strClinicID = value; }
    public string? DoctorID { get => strDoctorID; set => strDoctorID = value; }
    public string? Date { get => strDate; set => strDate = value; }
	public string? Description { get => strDescription; set => strDescription = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public string StrlastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
}
