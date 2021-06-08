using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EPolicy.LookupTables;
using Baldrich.DBRequest;
using EPolicy.XmlCooker;
using System.Xml;
/// <summary>
/// Summary description for Directorycs
/// </summary>
public class Directorycs
{
    public Directorycs()
    {

    }

    #region Variable

    private Directorycs oldDirectorycs = null;
    private DataTable _dtDirectory;
    private int _DirectoryID = 0;
    private string _FirstName = "";
    private string _LastName = "";
    private string _Salutation = "";
    private string _Title = "";
    private int _LocationID = 0;
    private string _Adds1 = "";
    private string _Adds2 = "";
    private string _City = "";
    private string _State = "";
    private string _Zip = "";
    private string _Adds1Postal = "";
    private string _Adds2Postal = "";
    private string _CityPostal = "";
    private string _StatePostal = "";
    private string _ZipPostal = "";
    private string _Phone1 = "";
    private string _ext1 = "";
    private string _Phone2 = "";
    private string _Email = "";
    private string _Comments = "";
    private int _Specialty = 0;

    private int _Mode = (int)DirectoryMode.CLEAR;

    #endregion

    #region Public Enumeration

    public enum DirectoryMode { ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4 };

    #endregion

    #region Properties

    public int DirectoryID
		{
			get
			{
				return this._DirectoryID;
			}
			set
			{
				this._DirectoryID = value;
			}
    }

    public string FirstName
	{
		get
		{
            return this._FirstName;
		}
		set
		{
            this._FirstName = value;
		}
    }

    public string LastName
	{
		get
		{
			return this._LastName;
		}
		set
		{
			this._LastName = value;
		}
    }

    public string Salutation
	{
		get
		{
			return this._Salutation;
		}
		set
		{
			this._Salutation = value;
		}
    }

    public string Title
	{
		get
		{
			return this._Title;
		}
		set
		{
			this._Title = value;
		}
    }

    public int LocationID
	{
		get
		{
			return this._LocationID;
		}
		set
		{
			this._LocationID = value;
		}
    }

    public string Adds1
	{
		get
		{
			return this._Adds1;
		}
		set
		{
			this._Adds1 = value;
		}
    }

    public string Adds2
	{
		get
		{
			return this._Adds2;
		}
		set
		{
			this._Adds2 = value;
		}
    }

    public string City
	{
		get
		{
			return this._City;
		}
		set
		{
			this._City = value;
		}
    }

    public string State
	{
		get
		{
			return this._State;
		}
		set
		{
			this._State = value;
		}
    }

    public string Zip
	{
		get
		{
			return this._Zip;
		}
		set
		{
			this._Zip = value;
		}
    }

    public string Adds1Postal
	{
		get
		{
			return this._Adds1Postal;
		}
		set
		{
			this._Adds1Postal = value;
		}
    }

    public string Adds2Postal
	{
		get
		{
			return this._Adds2Postal;
		}
		set
		{
			this._Adds2Postal = value;
		}
    }

    public string CityPostal
	{
		get
		{
			return this._CityPostal;
		}
		set
		{
			this._CityPostal = value;
		}
    }

    public string StatePostal
	{
		get
		{
			return this._StatePostal;
		}
		set
		{
			this._StatePostal = value;
		}
    }

    public string ZipPostal
	{
		get
		{
			return this._ZipPostal;
		}
		set
		{
			this._ZipPostal = value;
		}
    }

    public string Phone1
	{
		get
		{
			return this._Phone1;
		}
		set
		{
			this._Phone1 = value;
		}
    }

    public string Ext1
	{
		get
		{
			return this._ext1;
		}
		set
		{
			this._ext1 = value;
		}
    }

    public string Phone2
	{
		get
		{
			return this._Phone2;
		}
		set
		{
			this._Phone2 = value;
		}
    }

    public string Email
	{
		get
		{
			return this._Email;
		}
		set
		{
			this._Email = value;
		}
    }

    public string Comments
	{
		get
		{
			return this._Comments;
		}
		set
		{
			this._Comments = value;
		}
    }

    public int Specialty
	{
		get
		{
			return this._Specialty;
		}
		set
		{
			this._Specialty = value;
		}
    }

    public int Mode 
	{
		get
		{
			return this._Mode;
		}
		set
		{
			this._Mode = value;
		}
    }
#endregion

    #region Public Methods

    public static DataTable GetDirectoryByCriteria(string city, string location, string specialty, string firstName, string lastname)
    {
        DataTable dt = GetDirectoryByCriteriaDB(city, location, specialty, firstName, lastname);

        return dt;
    }


    public static Directorycs GetDirectoryByDirectoryID(int directoryID)
    {
        Directorycs directorycscs = null;

        DataTable dt = GetDirectoryByDirectoryIDDB(directoryID);
        directorycscs = new Directorycs();

        directorycscs._dtDirectory = dt;
        directorycscs = FillProperties(directorycscs);

        return directorycscs;
    }

    public void SaveDirectory(int UserID)
    {
        this.Save(UserID);
    }

    public static void DeleteDirectoryByDirectoryID(int directoryID)
    {
        DBRequest Executor = new DBRequest();
        Executor.Update("DeleteDirectory", DeleteDirectoryByDirectoryIDXml(directoryID));
    }

    #endregion

    #region Private Methods

    private static XmlDocument DeleteDirectoryByDirectoryIDXml(int directoryID)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

        DbRequestXmlCooker.AttachCookItem("DirectoryID",
            SqlDbType.Int, 0, directoryID.ToString(),
            ref cookItems);

        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }

        return xmlDoc;
    }

    private void Save(int UserID)
    {
        if (this.Mode == 2)
            oldDirectorycs = (Directorycs)Directorycs.GetDirectoryByDirectoryID(this.DirectoryID);

        DBRequest Executor = new DBRequest();
        try
        {
            Executor.BeginTrans();
            switch (this.Mode)
            {
                case 1:  //ADD
                    this.DirectoryID = Executor.Insert("AddDirectory", this.GetInsertDirectoryXml());
                    break;

                default: //UPDATE
                    Executor.Update("UpdateDirectory", this.GetUpdateDirectoryXml());
                    break;
            }
            Executor.CommitTrans();
        }

        catch (Exception xcp)
        {
            Executor.RollBackTrans();
            throw new Exception("Error while trying to save the Information. " + xcp.Message, xcp);
        }

        this.Mode = 4;
    }

    private XmlDocument GetUpdateDirectoryXml()
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[22];

        DbRequestXmlCooker.AttachCookItem("DirectoryID",
            SqlDbType.Int, 0, this.DirectoryID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FirstName",
            SqlDbType.VarChar, 50, this.FirstName.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("LastName",
            SqlDbType.VarChar, 50, this.LastName.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Salutation",
            SqlDbType.VarChar, 5, this.Salutation.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Title",
            SqlDbType.VarChar, 20, this.Title.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("LocationID",
            SqlDbType.Int, 0, this.LocationID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds1",
            SqlDbType.VarChar, 50, this.Adds1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds2",
            SqlDbType.VarChar, 50, this.Adds2.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("City",
            SqlDbType.VarChar, 15, this.City.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("State",
            SqlDbType.VarChar, 2, this.State.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Zip",
            SqlDbType.VarChar, 10, this.Zip.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds1Postal",
            SqlDbType.VarChar, 50, this.Adds1Postal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds2Postal",
            SqlDbType.VarChar, 50, this.Adds2Postal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("CityPostal",
            SqlDbType.VarChar, 15, this.CityPostal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("StatePostal",
            SqlDbType.VarChar, 2, this.StatePostal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("ZipPostal",
            SqlDbType.VarChar, 10, this.ZipPostal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Phone1",
            SqlDbType.VarChar, 14, this.Phone1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Ext1",
            SqlDbType.VarChar, 10, this.Ext1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Phone2",
            SqlDbType.VarChar, 14, this.Phone2.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Email",
            SqlDbType.VarChar, 50, this.Email.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Comments",
            SqlDbType.VarChar, 500, this.Comments.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Specialty",
            SqlDbType.Int, 0, this.Specialty.ToString(),
            ref cookItems);

        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }

        return xmlDoc;
    }

    private XmlDocument GetInsertDirectoryXml()
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[21];

        DbRequestXmlCooker.AttachCookItem("FirstName",
            SqlDbType.VarChar, 50, this.FirstName.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("LastName",
            SqlDbType.VarChar, 50, this.LastName.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Salutation",
            SqlDbType.VarChar, 5, this.Salutation.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Title",
            SqlDbType.VarChar, 20, this.Title.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("LocationID",
            SqlDbType.Int, 0, this.LocationID.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds1",
            SqlDbType.VarChar, 50, this.Adds1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds2",
            SqlDbType.VarChar, 50, this.Adds2.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("City",
            SqlDbType.VarChar, 15, this.City.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("State",
            SqlDbType.VarChar, 2, this.State.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Zip",
            SqlDbType.VarChar, 10, this.Zip.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds1Postal",
            SqlDbType.VarChar, 50, this.Adds1Postal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Adds2Postal",
            SqlDbType.VarChar, 50, this.Adds2Postal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("CityPostal",
            SqlDbType.VarChar, 15, this.CityPostal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("StatePostal",
            SqlDbType.VarChar, 2, this.StatePostal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("ZipPostal",
            SqlDbType.VarChar, 10, this.ZipPostal.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Phone1",
            SqlDbType.VarChar, 14, this.Phone1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Ext1",
            SqlDbType.VarChar, 10, this.Ext1.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Phone2",
            SqlDbType.VarChar, 14, this.Phone2.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Email",
            SqlDbType.VarChar, 50, this.Email.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Comments",
            SqlDbType.VarChar, 500, this.Comments.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Specialty",
            SqlDbType.Int, 0, this.Specialty.ToString(),
            ref cookItems);

        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }

        return xmlDoc;
    }

    private static DataTable GetDirectoryByCriteriaDB(string city, string location, string specialty, string firstName, string lastname)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[5];

        DbRequestXmlCooker.AttachCookItem("City",
            SqlDbType.VarChar, 15, city.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("LocationID",
            SqlDbType.VarChar, 100, location.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Specialty",
            SqlDbType.VarChar, 100, specialty.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("FirstName",
            SqlDbType.VarChar, 50, firstName.ToString(),
            ref cookItems);

        DbRequestXmlCooker.AttachCookItem("Lastname",
            SqlDbType.VarChar, 50, lastname.ToString(),
            ref cookItems);

        DBRequest exec = new DBRequest();
        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }
        DataTable dt = null;
        try
        {
            dt = exec.GetQuery("GetDirectoryByCriteria", xmlDoc);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve the information by criteria.", ex);
        }
    }

    public static DataTable GetDirectoryByDirectoryIDDB(int directoryID)
    {
        DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

        DbRequestXmlCooker.AttachCookItem("DirectoryID",
            SqlDbType.Int, 0, directoryID.ToString(),
            ref cookItems);

        DBRequest exec = new DBRequest();
        XmlDocument xmlDoc;

        try
        {
            xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not cook items.", ex);
        }
        DataTable dt = null;
        try
        {
            dt = exec.GetQuery("GetDirectoryByDirectoryID", xmlDoc);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not retrieve the information by criteria.", ex);
        }
    }

    private static Directorycs FillProperties(Directorycs directorycs)
    {
        directorycs.DirectoryID = (directorycs._dtDirectory.Rows[0]["DirectorioID"] != System.DBNull.Value) ? (int)directorycs._dtDirectory.Rows[0]["DirectorioID"] : 0;
        directorycs.FirstName = directorycs._dtDirectory.Rows[0]["FirstName"].ToString();
        directorycs.LastName = directorycs._dtDirectory.Rows[0]["LastName"].ToString().Trim();
        directorycs.Salutation = directorycs._dtDirectory.Rows[0]["Salutation"].ToString().Trim();
        directorycs.Title = directorycs._dtDirectory.Rows[0]["Title"].ToString().Trim();
        directorycs.LocationID = (directorycs._dtDirectory.Rows[0]["LocationID"] != System.DBNull.Value) ? (int)directorycs._dtDirectory.Rows[0]["LocationID"] : 0;
        directorycs.Adds1 = directorycs._dtDirectory.Rows[0]["Adds1"].ToString().Trim();
        directorycs.Adds2 = directorycs._dtDirectory.Rows[0]["Adds2"].ToString().Trim();
        directorycs.City = directorycs._dtDirectory.Rows[0]["City"].ToString().Trim();
        directorycs.State = directorycs._dtDirectory.Rows[0]["State"].ToString().Trim();
        directorycs.Zip = directorycs._dtDirectory.Rows[0]["Zip"].ToString().Trim();
        directorycs.Adds1Postal = directorycs._dtDirectory.Rows[0]["Adds1Postal"].ToString().Trim();
        directorycs.Adds2Postal = directorycs._dtDirectory.Rows[0]["Adds2Postal"].ToString().Trim();
        directorycs.CityPostal = directorycs._dtDirectory.Rows[0]["CityPostal"].ToString().Trim();
        directorycs.StatePostal = directorycs._dtDirectory.Rows[0]["StatePostal"].ToString().Trim();
        directorycs.ZipPostal = directorycs._dtDirectory.Rows[0]["ZipPostal"].ToString().Trim();
        directorycs.Phone1 = directorycs._dtDirectory.Rows[0]["Phone1"].ToString().Trim();
        directorycs.Ext1 = directorycs._dtDirectory.Rows[0]["Ext1"].ToString().Trim();
        directorycs.Phone2 = directorycs._dtDirectory.Rows[0]["Phone2"].ToString().Trim();
        directorycs.Email = directorycs._dtDirectory.Rows[0]["Email"].ToString().Trim();
        directorycs.Comments = directorycs._dtDirectory.Rows[0]["Comments"].ToString().Trim();
        directorycs.Specialty = (directorycs._dtDirectory.Rows[0]["Specialty"] != System.DBNull.Value) ? (int)directorycs._dtDirectory.Rows[0]["Specialty"] : 0;

        return directorycs;
    }

    #endregion
}
