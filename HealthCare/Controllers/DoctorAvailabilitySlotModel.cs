using System;

public class clsDocAvailabilitySlots
{

    public clsDocAvailabilitySlots()
	{
	}

	private String strDoctorID;
	private String strClinicID;
	private String strDate;
	private String strDuration;
	private String strStartTime;
	private String strPatientID;
	private String strSlotsID;
	private String strHoliday;
	private String strBlocker;
	private String strActive;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;

    public string StrDoctorID { get => strDoctorID; set => strDoctorID = value; }
    public string StrClinicID { get => strClinicID; set => strClinicID = value; }
    public string StrDate { get => strDate; set => strDate = value; }
    public string StrDuration { get => strDuration; set => strDuration = value; }
    public string StrStartTime { get => strStartTime; set => strStartTime = value; }
    public string StrPatientID { get => strPatientID; set => strPatientID = value; }
    public string StrSlotsID { get => strSlotsID; set => strSlotsID = value; }
    public string StrHoliday { get => strHoliday; set => strHoliday = value; }
    public string StrBlocker { get => strBlocker; set => strBlocker = value; }
    public string StrActive { get => strActive; set => strActive = value; }
    public string StrlastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string StrlastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
}
