using System;
using System.Data;
using System.Text;
using System.IO;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.Customer;
using System.Reflection;
using EPolicy.LookupTables;
using EPolicy.TaskControl;
using EPolicy.Audit;
using System.Collections;
using EPolicy.XmlCooker;

namespace EPolicy.TaskControl
{
	/// <summary>
	/// Summary description for Endorsement.
	/// </summary>
	public class Endorsement:TaskControl
	{
		public Endorsement()
		{
			this._EndorsementMode =(int) TaskControlMode.ADD;
		}

		#region Variable
		private DataTable _dtEndorsement ;
		private DataTable _dtEndorPolicyInfo ;
		private int _EndorsementMode = (int) TaskControlMode.CLEAR;
		private int	     _EndorsementID     = 0;
		private int      _EndNum		    = 0;
		private string   _PolicyType        = "";
		private string   _PolicyNo          = "";
		private string   _Certificate       = "";
		private string   _Sufijo            = "";
		private bool     _PrintFlag         = false;
		private string   _PrintDate         = "";
		private bool  	 _InvoiceFlag		= false;
		private string	 _InvoiceDate	    = "";
		private string	 _EndorsementDate	= "";
		private string   _EffectiveDate		= "";
		private string   _ExpirationDate	= "";
		private string   _BankNew			= "";
		private string   _EffectiveDateNew	= "";
		private string   _ExpirationDateNew	= "";	
		private int      _TCIDPolicy = 0;
		private bool     _Modify    		= true;
		#endregion

		#region Properties
		public int EndorsementMode
		{
			get
			{
				return this._EndorsementMode;
			}
			set 
			{
				this._EndorsementMode = value;
			}
		}

		public int EndorsementID
		{
			get
			{
				return this._EndorsementID;
			}
			set 
			{
				this._EndorsementID = value;
			}
		}

		public int EndNum
		{
			get
			{
				return this._EndNum;
			}
			set 
			{
				this._EndNum = value;
			}
		}

		public string PolicyType
		{
			get
			{
				return this._PolicyType;
			}
			set 
			{
				this._PolicyType = value;
			}
		}

		public string PolicyNo
		{
			get
			{
				return this._PolicyNo;
			}
			set 
			{
				this._PolicyNo = value;
			}
		}

		public string Certificate
		{
			get
			{
				return this._Certificate;
			}
			set 
			{
				this._Certificate = value;
			}
		}

		public string Sufijo
		{
			get
			{
				return this._Sufijo;
			}
			set 
			{
				this._Sufijo = value;
			}
		}

		public bool PrintFlag
		{
			get
			{
				return this._PrintFlag;
			}
			set 
			{
				this._PrintFlag = value;
			}
		}

		public string PrintDate
		{
			get
			{
				return this._PrintDate;
			}
			set 
			{
				this._PrintDate = value;
			}
		}

		public bool InvoiceFlag
		{
			get
			{
				return this._InvoiceFlag;
			}
			set 
			{
				this._InvoiceFlag = value;
			}
		}

		public string InvoiceDate
		{
			get
			{
				return this._InvoiceDate;
			}
			set 
			{
				this._InvoiceDate = value;
			}
		}

		public string EndorsementDate
		{
			get
			{
				return this._EndorsementDate;
			}
			set 
			{
				this._EndorsementDate = value;
			}
		}

		public string EffectiveDate
		{
			get
			{
				return this._EffectiveDate;
			}
			set 
			{
				this._EffectiveDate = value;
			}
		}

		public string ExpirationDate
		{
			get
			{
				return this._ExpirationDate;
			}
			set 
			{
				this._ExpirationDate = value;
			}
		}

		public string BankNew
		{
			get
			{
				return this._BankNew;
			}
			set 
			{
				this._BankNew = value;
			}
		}

		public string EffectiveDateNew
		{
			get
			{
				return this._EffectiveDateNew;
			}
			set 
			{
				this._EffectiveDateNew = value;
			}
		}

		public string ExpirationDateNew
		{
			get
			{
				return this._ExpirationDateNew;
			}
			set 
			{
				this._ExpirationDateNew = value;
			}
		}

		public DataTable DataTableEndorPolicyInfo
		{
			get
			{
				return this._dtEndorPolicyInfo;
			}
			set
			{
				this._dtEndorPolicyInfo = value;
			}
		}

		public int TCIDPolicy
		{
			get
			{
				return this._TCIDPolicy;
			}
			set
			{
				this._TCIDPolicy = value;
			}
		}
		
		#endregion

		#region Public Methods

		public virtual void SaveEndorsement(int UserID)
		{
			this.SaveEndor(UserID);			    // Save TaskApplicationAuto
		}

		public virtual void ValidateEndorsement()
		{
			string errorMessage = String.Empty;

//			if (this.ProspectID == 0 && this.CustomerNo == "")
//				errorMessage = "ProspectID or the Customer No. is missing or wrong.";

			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}
		}

		public static Endorsement GetEndorsement(int taskControlID)
		{
			Endorsement endorsement = null;

			DataTable dt = GetEndorsementByTaskControlIDDB(taskControlID);

			endorsement = new Endorsement();
			endorsement._dtEndorsement = dt;

			endorsement = FillProperties(endorsement);

			return endorsement;
		}

		public static Endorsement GetEndorsementByTaskControlID(int TaskControlID, Endorsement _endorsement)
		{
			Endorsement endorsement = _endorsement; 
			 
			DataTable dt= GetEndorsementByTaskControlIDDB(TaskControlID);

			endorsement._dtEndorsement = dt;
			endorsement = FillProperties(endorsement);

			return endorsement;
		}

		public void DeleteEndorsement(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("DeleteEndorsement",this.GetDeleteEndorsementXml());
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}
		#endregion

		#region Private Methods
		private static DataTable GetEndorsementByTaskControlIDDB(int taskControlID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, taskControlID.ToString(),
				ref cookItems);

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			XmlDocument xmlDoc;
			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
			DataTable dt = null;
			try
			{
				dt = exec.GetQuery("GetEndorsementByTaskControlID", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
			
		}

		private void SaveEndor(int UserID)
		{
			this._Modify = true;
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				switch (this._EndorsementMode)
				{
					case 1:  //ADD
						this.EndorsementID = Executor.Insert("AddEndorsement",this.GetInsertEndorsementXml());
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						Executor.Update("UpdateEndorsement",this.GetUpdateEndorsementXml());
						break;
				}
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}

		private XmlDocument GetDeleteEndorsementXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument GetUpdateEndorsementXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[19];

			DbRequestXmlCooker.AttachCookItem("EndorsementID",
				SqlDbType.Int, 0, this.EndorsementID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EndNum",
				SqlDbType.Int, 0, this.EndNum.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyType",
				SqlDbType.Char, 3, this.PolicyType.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyNo",
				SqlDbType.Char, 11, this.PolicyNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Certificate",
				SqlDbType.Char, 10, this.Certificate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Sufijo",
				SqlDbType.Char, 2, this.Sufijo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PrintFlag",
				SqlDbType.Bit, 0, this.PrintFlag.ToString(),
				ref cookItems);


			if(this.PrintDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("PrintDate",
					SqlDbType.DateTime, 0, this.PrintDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.PrintDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("PrintDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}
			
			DbRequestXmlCooker.AttachCookItem("InvoiceFlag",
				SqlDbType.Bit, 0, this.InvoiceFlag.ToString(),
				ref cookItems);

			if(this.InvoiceDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("InvoiceDate",
					SqlDbType.DateTime, 0, this.InvoiceDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.InvoiceDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("InvoiceDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.EndorsementDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("EndorsementDate",
					SqlDbType.DateTime, 0, this.EndorsementDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.EndorsementDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("EndorsementDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.EffectiveDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("EffectiveDate",
					SqlDbType.DateTime, 0, this.EffectiveDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.EffectiveDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("EffectiveDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.ExpirationDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("ExpirationDate",
					SqlDbType.DateTime, 0, this.ExpirationDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.ExpirationDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("ExpirationDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			DbRequestXmlCooker.AttachCookItem("BankNew",
				SqlDbType.Char, 3, this.BankNew.ToString(),
				ref cookItems);

			if(this.EffectiveDateNew =="")
			{
				DbRequestXmlCooker.AttachCookItem("EffectiveDateNew",
					SqlDbType.DateTime, 0, this.EffectiveDateNew.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.EffectiveDateNew+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("EffectiveDateNew",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.ExpirationDateNew =="")
			{
				DbRequestXmlCooker.AttachCookItem("ExpirationDateNew",
					SqlDbType.DateTime, 0, this.ExpirationDateNew.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.ExpirationDateNew+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("ExpirationDateNew",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			DbRequestXmlCooker.AttachCookItem("TCIDPolicy",
				SqlDbType.Int, 0, this.TCIDPolicy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Modify",
				SqlDbType.Bit, 0, _Modify.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private XmlDocument GetInsertEndorsementXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[18];

			DbRequestXmlCooker.AttachCookItem("EndNum",
				SqlDbType.Int, 0, this.EndNum.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyType",
				SqlDbType.Char, 3, this.PolicyType.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyNo",
				SqlDbType.Char, 11, this.PolicyNo.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Certificate",
				SqlDbType.Char, 10, this.Certificate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Sufijo",
				SqlDbType.Char, 2, this.Sufijo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PrintFlag",
				SqlDbType.Bit, 0, this.PrintFlag.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Modify",
				SqlDbType.Bit, 0, _Modify.ToString(),
				ref cookItems);

			if(this.PrintDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("PrintDate",
					SqlDbType.DateTime, 0, this.PrintDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.PrintDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("PrintDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}
			
			DbRequestXmlCooker.AttachCookItem("InvoiceFlag",
				SqlDbType.Bit, 0, this.InvoiceFlag.ToString(),
				ref cookItems);

			if(this.InvoiceDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("InvoiceDate",
					SqlDbType.DateTime, 0, this.InvoiceDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.InvoiceDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("InvoiceDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.EndorsementDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("EndorsementDate",
					SqlDbType.DateTime, 0, this.EndorsementDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.EndorsementDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("EndorsementDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.EffectiveDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("EffectiveDate",
					SqlDbType.DateTime, 0, this.EffectiveDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.EffectiveDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("EffectiveDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.ExpirationDate =="")
			{
				DbRequestXmlCooker.AttachCookItem("ExpirationDate",
					SqlDbType.DateTime, 0, this.ExpirationDate.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.ExpirationDate+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("ExpirationDate",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			DbRequestXmlCooker.AttachCookItem("BankNew",
				SqlDbType.Char, 3, this.BankNew.ToString(),
				ref cookItems);

			if(this.EffectiveDateNew =="")
			{
				DbRequestXmlCooker.AttachCookItem("EffectiveDateNew",
					SqlDbType.DateTime, 0, this.EffectiveDateNew.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.EffectiveDateNew+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("EffectiveDateNew",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			if(this.ExpirationDateNew =="")
			{
				DbRequestXmlCooker.AttachCookItem("ExpirationDateNew",
					SqlDbType.DateTime, 0, this.ExpirationDateNew.ToString(),
					ref cookItems);
			}
			else
			{
				DateTime date = DateTime.Parse(this.ExpirationDateNew+" 12:01:00 AM");

				DbRequestXmlCooker.AttachCookItem("ExpirationDateNew",
					SqlDbType.DateTime, 0, date.ToString(),
					ref cookItems);
			}

			DbRequestXmlCooker.AttachCookItem("TCIDPolicy",
				SqlDbType.Int, 0, this.TCIDPolicy.ToString(),
				ref cookItems);

			try
			{
				return DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}
		}

		private static Endorsement FillProperties(Endorsement endorsement)
		{
			endorsement.EndorsementID  = (int) endorsement._dtEndorsement.Rows[0]["EndorsementID"];
			endorsement.EndNum	       = (endorsement._dtEndorsement.Rows[0]["EndNum"]!=System.DBNull.Value) ? (int) endorsement._dtEndorsement.Rows[0]["EndNum"]: 0;
			endorsement.PolicyType	   = (endorsement._dtEndorsement.Rows[0]["PolicyType"]!=System.DBNull.Value) ?  endorsement._dtEndorsement.Rows[0]["PolicyType"].ToString(): "";
			endorsement.PolicyNo	   = (endorsement._dtEndorsement.Rows[0]["PolicyNo"]!=System.DBNull.Value) ?  endorsement._dtEndorsement.Rows[0]["PolicyNo"].ToString(): "";
			endorsement.Certificate	   = (endorsement._dtEndorsement.Rows[0]["Certificate"]!=System.DBNull.Value) ?  endorsement._dtEndorsement.Rows[0]["Certificate"].ToString(): "";
			endorsement.Sufijo		   = (endorsement._dtEndorsement.Rows[0]["Sufijo"]!=System.DBNull.Value) ?  endorsement._dtEndorsement.Rows[0]["Sufijo"].ToString(): "";
			endorsement.PrintFlag	   = (endorsement._dtEndorsement.Rows[0]["PrintFlag"]!=System.DBNull.Value) ? (bool) endorsement._dtEndorsement.Rows[0]["PrintFlag"]: false;
			endorsement.PrintDate	   = (endorsement._dtEndorsement.Rows[0]["PrintDate"]!= System.DBNull.Value)? ((DateTime) endorsement._dtEndorsement.Rows[0]["PrintDate"]).ToShortDateString():"";
			endorsement.InvoiceFlag	   = (endorsement._dtEndorsement.Rows[0]["InvoiceFlag"]!=System.DBNull.Value) ? (bool) endorsement._dtEndorsement.Rows[0]["InvoiceFlag"]: false;
			endorsement.InvoiceDate	   = (endorsement._dtEndorsement.Rows[0]["InvoiceDate"]!=System.DBNull.Value) ? ((DateTime) endorsement._dtEndorsement.Rows[0]["InvoiceDate"]).ToShortDateString():"";
			endorsement.EndorsementDate= (endorsement._dtEndorsement.Rows[0]["EndorsementDate"]!=System.DBNull.Value) ? ((DateTime) endorsement._dtEndorsement.Rows[0]["EndorsementDate"]).ToShortDateString():"";
			endorsement.EffectiveDate  = (endorsement._dtEndorsement.Rows[0]["EffectiveDate"]!=System.DBNull.Value) ? ((DateTime) endorsement._dtEndorsement.Rows[0]["EffectiveDate"]).ToShortDateString():"";
			endorsement.ExpirationDate = (endorsement._dtEndorsement.Rows[0]["ExpirationDate"]!=System.DBNull.Value) ? ((DateTime) endorsement._dtEndorsement.Rows[0]["ExpirationDate"]).ToShortDateString():"";
			endorsement.BankNew		   = (endorsement._dtEndorsement.Rows[0]["BankNew"]!=System.DBNull.Value) ? endorsement._dtEndorsement.Rows[0]["BankNew"].ToString(): "000";
			endorsement.EffectiveDateNew = (endorsement._dtEndorsement.Rows[0]["EffectiveDateNew"]!=System.DBNull.Value) ? ((DateTime) endorsement._dtEndorsement.Rows[0]["EffectiveDateNew"]).ToShortDateString():"";
			endorsement.ExpirationDateNew =(endorsement._dtEndorsement.Rows[0]["ExpirationDateNew"]!=System.DBNull.Value) ? ((DateTime) endorsement._dtEndorsement.Rows[0]["ExpirationDateNew"]).ToShortDateString():"";
			endorsement.TCIDPolicy		= (int) endorsement._dtEndorsement.Rows[0]["TCIDPolicy"];

			return endorsement;
		}

		#endregion
	}
}
