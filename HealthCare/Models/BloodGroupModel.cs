using System;
using System.ComponentModel.DataAnnotations;

public class BloodGroupModel
{
    public BloodGroupModel()
    {
    }

    private String intBg_Id;
    private String strBloodGroup;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;
    private bool strIsDelete;
    private String facilityID;


    [MaxLength(100)]
    public string IntBg_Id { get => intBg_Id; set => intBg_Id = value; }

    [MaxLength(30)]
    public string BloodGroup { get => strBloodGroup; set => strBloodGroup = value; }

    [MaxLength(30)]
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }

    [MaxLength(30)]
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
    public bool StrIsDelete { get => strIsDelete; set => strIsDelete = value; }

    [MaxLength(100)]
    public string FacilityID { get => facilityID; set => facilityID = value; }
}

