
using HealthCare.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public class DoctorScheduleModel
{

    public DoctorScheduleModel()
    {
    }

    private String strStaffID;
    private String strFacilityID;
    private string strDate;
    private string strDuration;
    private string strStartTime;
    private String strPatientID;
    private String strSlotsID;
    private bool strHoliday;
    private bool strBlocker;
    private bool strActive;
    private string viewslot;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;
    private string strlastUpdatedMachine;

  
    public string? PatientID { get => strPatientID; set => strPatientID = value; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? SlotsID { get => strSlotsID; set => strSlotsID = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }
  
    public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }
    public bool Holiday { get => strHoliday; set => strHoliday = value; }
    public bool Blocker { get => strBlocker; set => strBlocker = value; }
    public bool Active { get => strActive; set => strActive = value; }
    public string Date { get => strDate; set => strDate = value; }
    public string Duration { get => strDuration; set => strDuration = value; }
    public string StartTime { get => strStartTime; set => strStartTime = value; }
    public string? StaffID { get => strStaffID; set => strStaffID = value; }
    public string Viewslot { get => viewslot; set => viewslot = value; }

    [ForeignKey("StaffID,FacilityID,Viewslot")]
    public virtual ResourceScheduleModel Resource { get; set; }
}
