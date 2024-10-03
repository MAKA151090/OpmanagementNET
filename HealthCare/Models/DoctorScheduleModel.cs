
using HealthCare.Models;
using System;
using System.ComponentModel.DataAnnotations;
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
    private bool strInActive;
    private string viewslot;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;
    private string strlastUpdatedMachine;


    [MaxLength(100)]
    public string? PatientID { get => strPatientID; set => strPatientID = value; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? SlotsID { get => strSlotsID; set => strSlotsID = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }

    [MaxLength(100)]
    public string FacilityID { get => strFacilityID; set => strFacilityID = value; }

    [MaxLength(30)]
    public string? lastUpdatedMachine { get => strlastUpdatedMachine; set => strlastUpdatedMachine = value; }

    [MaxLength(30)]
    public bool Holiday { get => strHoliday; set => strHoliday = value; }

    [MaxLength(30)]
    public bool Blocker { get => strBlocker; set => strBlocker = value; }

    [MaxLength(30)]
    public string Date { get => strDate; set => strDate = value; }

    [MaxLength(30)]
    public string Duration { get => strDuration; set => strDuration = value; }

    [MaxLength(30)]
    public string StartTime { get => strStartTime; set => strStartTime = value; }

    [MaxLength(30)]
    public string? StaffID { get => strStaffID; set => strStaffID = value; }


    public string Viewslot { get => viewslot; set => viewslot = value; }

    [ForeignKey("StaffID,FacilityID,Viewslot")]
    public virtual ResourceScheduleModel Resource { get; set; }
    
    public bool StrInActive { get => strInActive; set => strInActive = value; }
}
