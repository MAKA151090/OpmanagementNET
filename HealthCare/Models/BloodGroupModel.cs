using System;

public class BloodGroupModel
{
    public BloodGroupModel()
    {
    }

    private String intBg_Id;
    private String strBloodGroup;
    private String strlastUpdatedDate;
    private String strlastUpdatedUser;

    public string IntBg_Id { get => intBg_Id; set => intBg_Id = value; }
    public string BloodGroup { get => strBloodGroup; set => strBloodGroup = value; }
    public string? lastUpdatedDate { get => strlastUpdatedDate; set => strlastUpdatedDate = value; }
    public string? lastUpdatedUser { get => strlastUpdatedUser; set => strlastUpdatedUser = value; }
}

