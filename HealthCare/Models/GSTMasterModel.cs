using System;

public class GSTMasterModel
{
	public GSTMasterModel()
	{
	}

	private String strSGST;
	private String strCGST;
    private String strOtherTax;
    private String strLastUpdatedDate;
    private String strLastUpdatedUser;
    private String strLastUpdatedmachine;

    public string SGST { get => strSGST; set => strSGST = value; }
    public string CGST { get => strCGST; set => strCGST = value; }
    public string OtherTax { get => strOtherTax; set => strOtherTax = value; }
    public string LastUpdatedDate { get => strLastUpdatedDate; set => strLastUpdatedDate = value; }
    public string LastUpdatedUser { get => strLastUpdatedUser; set => strLastUpdatedUser = value; }
    public string LastUpdatedmachine { get => strLastUpdatedmachine; set => strLastUpdatedmachine = value; }
}
