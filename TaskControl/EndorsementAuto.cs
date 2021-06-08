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
	/// Summary description for EndorsementAuto.
	/// </summary>
	public class EndorsementAuto:Endorsement
	{
		public EndorsementAuto()
		{
			this.PolicyClassID	   = 3;
			this.PolicyID          = 0;
			this.InsuranceCompany  = "000";
			this.Agency            = "000";
			this.Agent             = "000";
			this.Bank			   = "000";
			this.Dealer			   = "000";
			this.CompanyDealer	   = "000";
			this.TaskStatusID      = 1; //Open //int.Parse(LookupTables.LookupTables.GetID("TaskStatus","Open"));
			this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType","Endorsement Auto"));
			this._mode =(int) TaskControlMode.ADD;
		}

		#region Variable
		private DataTable _dtEndorsementAuto ;
		private int _mode = (int) TaskControlMode.CLEAR;
		private int _EndorsementAutoID = 0;
		private int _QuotesAutoIDVIN   = 0;
		private int _QuotesAutoIDLoss  = 0;
		private int _QuotesAutoIDMake  = 0;
		private int _QuotesAutoIDModel = 0;
		private int _QuotesAutoIDYear  = 0;
		private int _VehicleYear = 0;
		private int    _VehicleMake = 0;
		private int    _VehicleModel = 0;
		private string _VIN = "";
		private string _FirstName = "";
		private string _Initial = "";
		private string _Lastna1 = "";
		private string _Lastna2 = "";
		private string _Adds1 = "";
		private string _Adds2 = "";
		private string _City = "";
		private string _State = "";
		private string _Zip = "";
		private string _Adds1_F = "";
		private string _Adds2_F = "";
		private string _City_F = "";
		private string _Zip_F = "";
		private double _TotalPremium = 0.00;
		private bool   _Opt1 = false;
		private bool   _Opt2 = false;
		private bool   _Opt3 = false;
		private bool   _Opt4 = false;
		private bool   _Opt5 = false;
		private bool   _Opt6 = false;
		private bool   _Opt7 = false;
		private bool   _Opt8 = false;
		private bool   _Opt9 = false;
		private bool   _Opt10 = false;
		private bool   _Opt11 = false;
		private bool   _Opt12 = false;
		private bool   _Opt13 = false;
		private int    _VehicleYearNew = 0;
		private int    _VehicleMakeNew = 0;
		private int    _VehicleModelNew= 0;
		private string _VINNew = "";
		private string _FirstNameNew = "";
		private string _InitialNew = "";
		private string _Lastna1New = "";
		private string _Lastna2New = "";
		private string _Adds1New = "";
		private string _Adds2New = "";
		private string _CityNew = "";
		private string _StateNew = "";
		private string _ZipNew = "";
		private string _Adds1_FNew = "";
		private string _Adds2_FNew = "";
		private string _City_FNew = "";
		private string _Zip_FNew = "";
		private double _TotalPremiumNew = 0.00;
		private string _Text1 = "";
		private string _Text2 = "";
		private string _Text3 = "";
		private string _Text4 = "";
		private string _Text5 = "";
		private string _Text6 = "";
		private string _Text7 = "";
		private string _Text8 = "";
		private string _Text9 = "";
		private string _Text10 = "";
		private string _Text11 = "";
		private string _Text12= "";
		private string _Text13 = "";
		private int _EndNumPolicy = 0;

		#endregion

		#region Properties
		public int QuotesAutoIDVIN 
		{
			get
			{
				return this._QuotesAutoIDVIN;
			}
			set 
			{
				this._QuotesAutoIDVIN = value;
			}
		}

		public int QuotesAutoIDLoss 
		{
			get
			{
				return this._QuotesAutoIDLoss;
			}
			set 
			{
				this._QuotesAutoIDLoss = value;
			}
		}

		public int QuotesAutoIDMake
		{
			get
			{
				return this._QuotesAutoIDMake;
			}
			set 
			{
				this._QuotesAutoIDMake = value;
			}
		}

		public int QuotesAutoIDModel 
		{
			get
			{
				return this._QuotesAutoIDModel;
			}
			set 
			{
				this._QuotesAutoIDModel = value;
			}
		}

		public int QuotesAutoIDYear 
		{
			get
			{
				return this._QuotesAutoIDYear;
			}
			set 
			{
				this._QuotesAutoIDYear = value;
			}
		}

		public int EndorsementAutoID
		{
			get
			{
				return this._EndorsementAutoID;
			}
			set 
			{
				this._EndorsementAutoID = value;
			}
		}

		public int VehicleYear 
		{
			get
			{
				return this._VehicleYear;
			}
			set 
			{
				this._VehicleYear = value;
			}
		}

		public int VehicleMake
		{
			get
			{
				return this._VehicleMake;
			}
			set 
			{
				this._VehicleMake = value;
			}
		}

		public int VehicleModel
		{
			get
			{
				return this._VehicleModel;
			}
			set 
			{
				this._VehicleModel = value;
			}
		}

		public string VIN 
		{
			get
			{
				return this._VIN;
			}
			set 
			{
				this._VIN = value;
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

		public string Initial 
		{
			get
			{
				return this._Initial;
			}
			set 
			{
				this._Initial = value;
			}
		}

		public string Lastna1 
		{
			get
			{
				return this._Lastna1;
			}
			set 
			{
				this._Lastna1 = value;
			}
		}

		public string Lastna2 	
		{
			get
			{
				return this._Lastna2;
			}
			set 
			{
				this._Lastna2 = value;
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

		public string Adds1_F 	
		{
			get
			{
				return this._Adds1_F;
			}
			set 
			{
				this._Adds1_F = value;
			}
		}

		public string Adds2_F 	
		{
			get
			{
				return this._Adds2_F;
			}
			set 
			{
				this._Adds2_F = value;
			}
		}

		public string City_F 	
		{
			get
			{
				return this._City_F;
			}
			set 
			{
				this._City_F = value;
			}
		}

		public string Zip_F 	
		{
			get
			{
				return this._Zip_F;
			}
			set 
			{
				this._Zip_F = value;
			}
		}

		public double TotalPremium	
		{
			get
			{
				return this._TotalPremium;
			}
			set 
			{
				this._TotalPremium = value;
			}
		}

		public bool Opt1
		{
			get
			{
				return this._Opt1;
			}
			set 
			{
				this._Opt1 = value;
			}
		}

		public bool Opt2
		{
			get
			{
				return this._Opt2;
			}
			set 
			{
				this._Opt2 = value;
			}
		}

		public bool Opt3	
		{
			get
			{
				return this._Opt3;
			}
			set 
			{
				this._Opt3 = value;
			}
		}

		public bool Opt4	
		{
			get
			{
				return this._Opt4;
			}
			set 
			{
				this._Opt4 = value;
			}
		}

		public bool Opt5	
		{
			get
			{
				return this._Opt5;
			}
			set 
			{
				this._Opt5 = value;
			}
		}

		public bool Opt6	
		{
			get
			{
				return this._Opt6;
			}
			set 
			{
				this._Opt6 = value;
			}
		}

		public bool Opt7	
		{
			get
			{
				return this._Opt7;
			}
			set 
			{
				this._Opt7 = value;
			}
		}

		public bool Opt8	
		{
			get
			{
				return this._Opt8;
			}
			set 
			{
				this._Opt8 = value;
			}
		}

		public bool Opt9	
		{
			get
			{
				return this._Opt9;
			}
			set 
			{
				this._Opt9 = value;
			}
		}

		public bool Opt10	
		{
			get
			{
				return this._Opt10;
			}
			set 
			{
				this._Opt10 = value;
			}
		}

		public bool Opt11	
		{
			get
			{
				return this._Opt11;
			}
			set 
			{
				this._Opt11 = value;
			}
		}

		public bool Opt12	
		{
			get
			{
				return this._Opt12;
			}
			set 
			{
				this._Opt12 = value;
			}
		}

		public bool Opt13	
		{
			get
			{
				return this._Opt13;
			}
			set 
			{
				this._Opt13 = value;
			}
		}

		public int VehicleYearNew 	
		{
			get
			{
				return this._VehicleYearNew;
			}
			set 
			{
				this._VehicleYearNew = value;
			}
		}

		public int VehicleMakeNew	
		{
			get
			{
				return this._VehicleMakeNew;
			}
			set 
			{
				this._VehicleMakeNew = value;
			}
		}

		public int VehicleModelNew	
		{
			get
			{
				return this._VehicleModelNew;
			}
			set 
			{
				this._VehicleModelNew = value;
			}
		}

		public string VINNew 	
		{
			get
			{
				return this._VINNew;
			}
			set 
			{
				this._VINNew = value;
			}
		}

		public string FirstNameNew 	
		{
			get
			{
				return this._FirstNameNew;
			}
			set 
			{
				this._FirstNameNew = value;
			}
		}

		public string InitialNew 	
		{
			get
			{
				return this._InitialNew;
			}
			set 
			{
				this._InitialNew = value;
			}
		}

		public string Lastna1New 	
		{
			get
			{
				return this._Lastna1New;
			}
			set 
			{
				this._Lastna1New = value;
			}
		}

		public string Lastna2New 	
		{
			get
			{
				return this._Lastna2New;
			}
			set 
			{
				this._Lastna2New = value;
			}
		}

		public string Adds1New 	
		{
			get
			{
				return this._Adds1New;
			}
			set 
			{
				this._Adds1New = value;
			}
		}

		public string Adds2New 	
		{
			get
			{
				return this._Adds2New;
			}
			set 
			{
				this._Adds2New = value;
			}
		}

		public string CityNew 	
		{
			get
			{
				return this._CityNew;
			}
			set 
			{
				this._CityNew = value;
			}
		}

		public string StateNew 	
		{
			get
			{
				return this._StateNew;
			}
			set 
			{
				this._StateNew = value;
			}
		}

		public string ZipNew 
		{
			get
			{
				return this._ZipNew;
			}
			set 
			{
				this._ZipNew = value;
			}
		}

		public string Adds1_FNew 
		{
			get
			{
				return this._Adds1_FNew;
			}
			set 
			{
				this._Adds1_FNew = value;
			}
		}

		public string Adds2_FNew 	
		{
			get
			{
				return this._Adds2_FNew;
			}
			set 
			{
				this._Adds2_FNew = value;
			}
		}

		public string City_FNew 	
		{
			get
			{
				return this._City_FNew;
			}
			set 
			{
				this._City_FNew = value;
			}
		}

		public string Zip_FNew 	
		{
			get
			{
				return this._Zip_FNew;
			}
			set 
			{
				this._Zip_FNew = value;
			}
		}

		public double TotalPremiumNew	
		{
			get
			{
				return this._TotalPremiumNew;
			}
			set 
			{
				this._TotalPremiumNew = value;
			}
		}

		public string Text1 	
		{
			get
			{
				return this._Text1;
			}
			set 
			{
				this._Text1 = value;
			}
		}

		public string Text2 	
		{
			get
			{
				return this._Text2;
			}
			set 
			{
				this._Text2 = value;
			}
		}

		public string Text3 	
		{
			get
			{
				return this._Text3;
			}
			set 
			{
				this._Text3 = value;
			}
		}

		public string Text4 	
		{
			get
			{
				return this._Text4;
			}
			set 
			{
				this._Text4 = value;
			}
		}

		public string Text5 	
		{
			get
			{
				return this._Text5;
			}
			set 
			{
				this._Text5 = value;
			}
		}

		public string Text6 	
		{
			get
			{
				return this._Text6;
			}
			set 
			{
				this._Text6 = value;
			}
		}

		public string Text7 	
		{
			get
			{
				return this._Text7;
			}
			set 
			{
				this._Text7 = value;
			}
		}

		public string Text8 	
		{
			get
			{
				return this._Text8;
			}
			set 
			{
				this._Text8 = value;
			}
		}

		public string Text9 	
		{
			get
			{
				return this._Text9;
			}
			set 
			{
				this._Text9 = value;
			}
		}

		public string Text10 	
		{
			get
			{
				return this._Text10;
			}
			set 
			{
				this._Text10 = value;
			}
		}

		public string Text11 	
		{
			get
			{
				return this._Text11;
			}
			set 
			{
				this._Text11 = value;
			}
		}

		public string Text12	
		{
			get
			{
				return this._Text12;
			}
			set 
			{
				this._Text12 = value;
			}
		}

		public string Text13	
		{
			get
			{
				return this._Text13;
			}
			set 
			{
				this._Text13 = value;
			}
		}

		public int EndNumPolicy	
		{
			get
			{
				return this._EndNumPolicy;
			}
			set 
			{
				this._EndNumPolicy = value;
			}
		}
		
		#endregion

		#region Public Methods

		public override void SaveEndorsement(int UserID)
		{
			this._mode		= (int) this.Mode;  // Se le asigna el mode de taskControl.
			this.EndorsementMode = (int) this.Mode;  // Se le asigna el mode de taskControl.

			base.ValidateEndorsement();
			this.Validate();

			base.Save(UserID);			// Validate and Save TaskControl
			base.SaveEndorsement(UserID);
			this.SaveEndorsementAuto(UserID);								

			//Update Table Relation From Endorsement
			this.UpdateTableRelationFromEndorsement();

			this._mode = (int) TaskControlMode.UPDATE;
			this.Mode = (int) TaskControlMode.CLEAR;
		}

		public void DeleteEndorsementAuto(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("DeleteEndorsementAuto",this.GetDeleteEndorsementAutotXml());
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to delete the Endorsement Auto. "+xcp.Message,xcp);
			}
		}

		public override void Validate()
		{

		}

		public static EndorsementAuto GetEndorsementAuto(int TaskControlID)
		{
			EndorsementAuto endorsementAuto = null;
			
			DataTable dt = GetEndorsementAutoByTaskControlID(TaskControlID);

			endorsementAuto = new EndorsementAuto();
			endorsementAuto = (EndorsementAuto) Endorsement.GetEndorsementByTaskControlID(TaskControlID,endorsementAuto);
			endorsementAuto._dtEndorsementAuto = dt;

			endorsementAuto = FillProperties(endorsementAuto);

			return endorsementAuto;
		}

		#endregion

		#region Private Methods
		private void SaveEndorsementAuto(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				switch (this._mode)
				{
					case 1:  //ADD
						_EndorsementAutoID = Executor.Insert("AddEndorsementAuto",this.GetInsertEndorsementAutohXml());
						this.History(this._mode,UserID);
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						Executor.Update("UpdateEndorsementAuto",this.GetUpdateEndorsementAutoXml());
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

		private XmlDocument GetDeleteEndorsementAutotXml()
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

		private void UpdateTableRelationFromEndorsement()
		{
			if(this.EndNumPolicy < this.EndNum)
				UpdatePolicyEndNum();

			if(this.Opt1 || this.Opt2) //Insured Name & Postal Adrrs.
				UpdateCustomerFromEndorsement();

			if(this.Opt3) //Res. Addrs.
				UpdateCustom_FFromEndorsement();

			if(this.Opt5) //Policy Period
                UpdatePolicyFromEndorsement();

			if(this.Opt4 || this.Opt6 ||this.Opt7 || this.Opt8 || this.Opt9) //VIN,LossPay,Make,Model,Year
				UpdateAutoPolicyFromEndorsement();
		}

		private void UpdateCustomerFromEndorsement()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[12];

			DbRequestXmlCooker.AttachCookItem("OPT1",
				SqlDbType.Bit, 0, this.Opt1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("OPT2",
				SqlDbType.Bit, 0, this.Opt2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, this.CustomerNo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Firstna",
				SqlDbType.VarChar, 150, this.FirstNameNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Initial",
				SqlDbType.Char, 1, this.InitialNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna1",
				SqlDbType.VarChar, 15, this.Lastna1New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna2",
				SqlDbType.VarChar, 15, this.Lastna2New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.VarChar, 30, this.Adds1New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.VarChar, 30, this.Adds2New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.VarChar, 14, this.CityNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 10, this.StateNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, this.ZipNew.ToString(),
				ref cookItems);
			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateCustomerFromEndorsementAuto",xmlDoc);
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}

		private void UpdateCustom_FFromEndorsement()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[6];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, this.CustomerNo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.VarChar, 30, this.Adds1_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.VarChar, 30, this.Adds2_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.VarChar, 14, this.City_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, "PR",
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, this.Zip_FNew.ToString(),
				ref cookItems);
			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateCustom_FFromEndorsementAuto",xmlDoc);
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}

		private void UpdatePolicyFromEndorsement()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[3];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TCIDPolicy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("EffectiveDate",
				SqlDbType.DateTime, 0, this.EffectiveDateNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ExpirationDate",
				SqlDbType.DateTime, 0, this.ExpirationDateNew.ToString(),
				ref cookItems);

			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdatePolicyFromEndorsementAuto",xmlDoc);
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}

		private void UpdateAutoPolicyFromEndorsement()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[16];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TCIDPolicy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt6",
				SqlDbType.Bit, 0, this.Opt6.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("Opt7",
				SqlDbType.Bit, 0, this.Opt7.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("Opt8",
				SqlDbType.Bit, 0, this.Opt8.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("Opt4",
				SqlDbType.Bit, 0, this.Opt4.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("Opt9",
				SqlDbType.Bit, 0, this.Opt9.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDLoss",
				SqlDbType.Int, 0, this.QuotesAutoIDLoss.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDMake",
				SqlDbType.Int, 0, this.QuotesAutoIDMake.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDModel",
				SqlDbType.Int, 0, this.QuotesAutoIDModel.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDVIN",
				SqlDbType.Int, 0, this.QuotesAutoIDVIN.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDYear",
				SqlDbType.Int, 0, this.QuotesAutoIDYear.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Bank",
				SqlDbType.Char, 3, this.BankNew.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
				SqlDbType.Int, 0, this.VehicleMakeNew.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("VehicleModelID",
				SqlDbType.Int, 0, this.VehicleModelNew.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("VIN",
				SqlDbType.Char, 18, this.VINNew.ToString(),
				ref cookItems);
			DbRequestXmlCooker.AttachCookItem("VehicleYearID",
				SqlDbType.Int, 0, this.VehicleYearNew.ToString(),
				ref cookItems);

			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdateAutoPolicyFromEndorsementAuto",xmlDoc);
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}

		private void UpdatePolicyEndNum()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TCIDPolicy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Endoso",
				SqlDbType.Int, 0, this.EndNum.ToString(),
				ref cookItems);

			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				Executor.Update("UpdatePolicyEndNum",xmlDoc);
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Endorsement. "+xcp.Message,xcp);
			}
		}

		private static DataTable GetEndorsementAutoByTaskControlID(int TaskControlID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, TaskControlID.ToString(),
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
			
			DataTable dt = exec.GetQuery("GetEndorsementAutoByTaskControlID",xmlDoc);
			return dt;
		}

		private XmlDocument GetInsertEndorsementAutohXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[68];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleYear",
				SqlDbType.Int, 0, this.VehicleYear.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleMake",
				SqlDbType.Int, 0, this.VehicleMake.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleModel",
				SqlDbType.Int, 0, this.VehicleModel.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VIN",
				SqlDbType.Char, 17, this.VIN.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FirstName",
				SqlDbType.VarChar, 15, this.FirstName.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Initial",
				SqlDbType.Char, 1, this.Initial.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna1",
				SqlDbType.VarChar, 15, this.Lastna1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna2",
				SqlDbType.VarChar, 15, this.Lastna2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.VarChar, 30, this.Adds1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.VarChar, 30, this.Adds2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.VarChar, 14, this.City.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, this.State.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, this.Zip.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1_F",
				SqlDbType.VarChar, 30, this.Adds1_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2_F",
				SqlDbType.VarChar, 30, this.Adds2_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City_F",
				SqlDbType.VarChar, 14, this.City_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip_F",
				SqlDbType.Char, 10, this.Zip_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TotalPremium",
				SqlDbType.Float, 0, this.TotalPremium.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt1",
				SqlDbType.Bit, 0, this.Opt1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt2",
				SqlDbType.Bit, 0, this.Opt2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt3",
				SqlDbType.Bit, 0, this.Opt3.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt4",
				SqlDbType.Bit, 0, this.Opt4.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt5",
				SqlDbType.Bit, 0, this.Opt5.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt6",
				SqlDbType.Bit, 0, this.Opt6.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt7",
				SqlDbType.Bit, 0, this.Opt7.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt8",
				SqlDbType.Bit, 0, this.Opt8.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt9",
				SqlDbType.Bit, 0, this.Opt9.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt10",
				SqlDbType.Bit, 0, this.Opt10.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt11",
				SqlDbType.Bit, 0, this.Opt11.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt12",
				SqlDbType.Bit, 0, this.Opt12.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt13",
				SqlDbType.Bit, 0, this.Opt13.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleYearNew",
				SqlDbType.Int, 4, this.VehicleYearNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleMakeNew",
				SqlDbType.Int, 0, this.VehicleMakeNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleModelNew",
				SqlDbType.Int, 0, this.VehicleModelNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VINNew",
				SqlDbType.Char, 17, this.VINNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FirstNameNew",
				SqlDbType.VarChar, 15, this.FirstNameNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("InitialNew",
				SqlDbType.Char, 1, this.InitialNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna1New",
				SqlDbType.VarChar, 15, this.Lastna1New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna2New",
				SqlDbType.VarChar, 15, this.Lastna2New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1New",
				SqlDbType.VarChar, 30, this.Adds1New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2New",
				SqlDbType.VarChar, 30, this.Adds2New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CityNew",
				SqlDbType.VarChar, 14, this.CityNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("StateNew",
				SqlDbType.Char, 2, this.StateNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ZipNew",
				SqlDbType.Char, 10, this.ZipNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1_FNew",
				SqlDbType.VarChar, 30, this.Adds1_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2_FNew",
				SqlDbType.VarChar, 30, this.Adds2_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City_FNew",
				SqlDbType.VarChar, 14, this.City_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip_FNew",
				SqlDbType.Char, 10, this.Zip_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TotalPremiumNew",
				SqlDbType.Float, 0, this.TotalPremiumNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text1",
				SqlDbType.VarChar, 70, this.Text1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text2",
				SqlDbType.VarChar, 70, this.Text2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text3",
				SqlDbType.VarChar, 70, this.Text3.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text4",
				SqlDbType.VarChar, 70, this.Text4.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text5",
				SqlDbType.VarChar, 70, this.Text5.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text6",
				SqlDbType.VarChar, 70, this.Text6.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text7",
				SqlDbType.VarChar, 70, this.Text7.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text8",
				SqlDbType.VarChar, 70, this.Text8.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text9",
				SqlDbType.VarChar, 70, this.Text9.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text10",
				SqlDbType.VarChar, 70, this.Text10.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text11",
				SqlDbType.VarChar, 70, this.Text11.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text12",
				SqlDbType.VarChar, 70, this.Text12.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text13",
				SqlDbType.VarChar, 70, this.Text13.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDVIN",
				SqlDbType.Int, 0, this.QuotesAutoIDVIN.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDLoss",
				SqlDbType.Int, 0, this.QuotesAutoIDLoss.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDMake",
				SqlDbType.Int, 0, this.QuotesAutoIDMake.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDModel",
				SqlDbType.Int, 0, this.QuotesAutoIDModel.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDYear",
				SqlDbType.Int, 0, this.QuotesAutoIDYear.ToString(),
				ref cookItems);

			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			return xmlDoc;
		}

		private XmlDocument GetUpdateEndorsementAutoXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[68];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleYear",
				SqlDbType.Char, 4, this.VehicleYear.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleMake",
				SqlDbType.Int, 0, this.VehicleMake.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleModel",
				SqlDbType.Int, 0, this.VehicleModel.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VIN",
				SqlDbType.Char, 17, this.VIN.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FirstName",
				SqlDbType.VarChar, 15, this.FirstName.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Initial",
				SqlDbType.Char, 1, this.Initial.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna1",
				SqlDbType.VarChar, 15, this.Lastna1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna2",
				SqlDbType.VarChar, 15, this.Lastna2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.VarChar, 30, this.Adds1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.VarChar, 30, this.Adds2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.VarChar, 14, this.City.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, this.State.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, this.Zip.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1_F",
				SqlDbType.VarChar, 30, this.Adds1_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2_F",
				SqlDbType.VarChar, 30, this.Adds2_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City_F",
				SqlDbType.VarChar, 14, this.City_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip_F",
				SqlDbType.Char, 10, this.Zip_F.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TotalPremium",
				SqlDbType.Float, 0, this.TotalPremium.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt1",
				SqlDbType.Bit, 0, this.Opt1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt2",
				SqlDbType.Bit, 0, this.Opt2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt3",
				SqlDbType.Bit, 0, this.Opt3.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt4",
				SqlDbType.Bit, 0, this.Opt4.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt5",
				SqlDbType.Bit, 0, this.Opt5.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt6",
				SqlDbType.Bit, 0, this.Opt6.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt7",
				SqlDbType.Bit, 0, this.Opt7.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt8",
				SqlDbType.Bit, 0, this.Opt8.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt9",
				SqlDbType.Bit, 0, this.Opt9.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt10",
				SqlDbType.Bit, 0, this.Opt10.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt11",
				SqlDbType.Bit, 0, this.Opt11.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt12",
				SqlDbType.Bit, 0, this.Opt12.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Opt13",
				SqlDbType.Bit, 0, this.Opt13.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleYearNew",
				SqlDbType.Char, 4, this.VehicleYearNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleMakeNew",
				SqlDbType.Int, 0, this.VehicleMakeNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleModelNew",
				SqlDbType.Int, 0, this.VehicleModelNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VINNew",
				SqlDbType.Char, 17, this.VINNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FirstNameNew",
				SqlDbType.VarChar, 15, this.FirstNameNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("InitialNew",
				SqlDbType.Char, 1, this.InitialNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna1New",
				SqlDbType.VarChar, 15, this.Lastna1New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lastna2New",
				SqlDbType.VarChar, 15, this.Lastna2New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1New",
				SqlDbType.VarChar, 30, this.Adds1New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2New",
				SqlDbType.VarChar, 30, this.Adds2New.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CityNew",
				SqlDbType.VarChar, 14, this.CityNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("StateNew",
				SqlDbType.Char, 2, this.StateNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ZipNew",
				SqlDbType.Char, 10, this.ZipNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1_FNew",
				SqlDbType.VarChar, 30, this.Adds1_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds2_FNew",
				SqlDbType.VarChar, 30, this.Adds2_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City_FNew",
				SqlDbType.VarChar, 14, this.City_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Zip_FNew",
				SqlDbType.Char, 10, this.Zip_FNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("TotalPremiumNew",
				SqlDbType.Float, 0, this.TotalPremiumNew.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text1",
				SqlDbType.VarChar, 70, this.Text1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text2",
				SqlDbType.VarChar, 70, this.Text2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text3",
				SqlDbType.VarChar, 70, this.Text3.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text4",
				SqlDbType.VarChar, 70, this.Text4.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text5",
				SqlDbType.VarChar, 70, this.Text5.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text5",
				SqlDbType.VarChar, 70, this.Text5.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text6",
				SqlDbType.VarChar, 70, this.Text6.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text7",
				SqlDbType.VarChar, 70, this.Text7.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text8",
				SqlDbType.VarChar, 70, this.Text8.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text9",
				SqlDbType.VarChar, 70, this.Text9.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text10",
				SqlDbType.VarChar, 70, this.Text10.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text11",
				SqlDbType.VarChar, 70, this.Text11.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text12",
				SqlDbType.VarChar, 70, this.Text12.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Text13",
				SqlDbType.VarChar, 70, this.Text13.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDVIN",
				SqlDbType.Int, 0, this.QuotesAutoIDVIN.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDLoss",
				SqlDbType.Int, 0, this.QuotesAutoIDLoss.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDMake",
				SqlDbType.Int, 0, this.QuotesAutoIDMake.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDModel",
				SqlDbType.Int, 0, this.QuotesAutoIDModel.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("QuotesAutoIDYear",
				SqlDbType.Int, 0, this.QuotesAutoIDYear.ToString(),
				ref cookItems);


			XmlDocument xmlDoc;

			try
			{
				xmlDoc = DbRequestXmlCooker.Cook(cookItems);
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			return xmlDoc;
		}

		private static EndorsementAuto FillProperties(EndorsementAuto endorsement)
		{
			endorsement.EndorsementAutoID  = (int) endorsement._dtEndorsementAuto.Rows[0]["EndorsementAutoID"];
	
			endorsement.VehicleYear     = (int) endorsement._dtEndorsementAuto.Rows[0]["VehicleYear"];
			endorsement.VehicleYearNew  = (int) endorsement._dtEndorsementAuto.Rows[0]["VehicleYearNew"];
			endorsement.VehicleMake     = (int) endorsement._dtEndorsementAuto.Rows[0]["VehicleMake"];
			endorsement.VehicleMakeNew  = (int) endorsement._dtEndorsementAuto.Rows[0]["VehicleMakeNew"];
			endorsement.VehicleModel    = (int) endorsement._dtEndorsementAuto.Rows[0]["VehicleModel"];
			endorsement.VehicleModelNew = (int) endorsement._dtEndorsementAuto.Rows[0]["VehicleModelNew"];
			endorsement.VIN				= endorsement._dtEndorsementAuto.Rows[0]["VIN"].ToString();
			endorsement.VINNew			= endorsement._dtEndorsementAuto.Rows[0]["VINNew"].ToString();
			endorsement.FirstName		= endorsement._dtEndorsementAuto.Rows[0]["FirstName"].ToString();
			endorsement.FirstNameNew	= endorsement._dtEndorsementAuto.Rows[0]["FirstNameNew"].ToString();
			endorsement.Initial			= endorsement._dtEndorsementAuto.Rows[0]["Initial"].ToString();
			endorsement.InitialNew		= endorsement._dtEndorsementAuto.Rows[0]["InitialNew"].ToString();
			endorsement.Lastna1			= endorsement._dtEndorsementAuto.Rows[0]["Lastna1"].ToString();
			endorsement.Lastna1New		= endorsement._dtEndorsementAuto.Rows[0]["Lastna1New"].ToString();
			endorsement.Lastna2			= endorsement._dtEndorsementAuto.Rows[0]["Lastna2"].ToString();
			endorsement.Lastna2New		= endorsement._dtEndorsementAuto.Rows[0]["Lastna2New"].ToString();
			endorsement.Adds1			= endorsement._dtEndorsementAuto.Rows[0]["Adds1"].ToString();
			endorsement.Adds1New		= endorsement._dtEndorsementAuto.Rows[0]["Adds1New"].ToString();
			endorsement.Adds2			= endorsement._dtEndorsementAuto.Rows[0]["Adds2"].ToString();
			endorsement.Adds2New		= endorsement._dtEndorsementAuto.Rows[0]["Adds2New"].ToString();
			endorsement.City			= endorsement._dtEndorsementAuto.Rows[0]["City"].ToString();
			endorsement.CityNew			= endorsement._dtEndorsementAuto.Rows[0]["CityNew"].ToString();
			endorsement.State			= endorsement._dtEndorsementAuto.Rows[0]["State"].ToString();
			endorsement.StateNew		= endorsement._dtEndorsementAuto.Rows[0]["StateNew"].ToString();
			endorsement.Zip				= endorsement._dtEndorsementAuto.Rows[0]["Zip"].ToString();
			endorsement.ZipNew			= endorsement._dtEndorsementAuto.Rows[0]["ZipNew"].ToString();
			endorsement.Adds1_F			= endorsement._dtEndorsementAuto.Rows[0]["Adds1_F"].ToString();
			endorsement.Adds1_FNew		= endorsement._dtEndorsementAuto.Rows[0]["Adds1_FNew"].ToString();
			endorsement.Adds2_F			= endorsement._dtEndorsementAuto.Rows[0]["Adds2_F"].ToString();
			endorsement.Adds2_FNew		= endorsement._dtEndorsementAuto.Rows[0]["Adds2_FNew"].ToString();
			endorsement.City_F			= endorsement._dtEndorsementAuto.Rows[0]["City_F"].ToString();
			endorsement.City_FNew		= endorsement._dtEndorsementAuto.Rows[0]["City_FNew"].ToString();
			endorsement.Zip_F			= endorsement._dtEndorsementAuto.Rows[0]["Zip_F"].ToString();
			endorsement.Zip_FNew		= endorsement._dtEndorsementAuto.Rows[0]["Zip_FNew"].ToString();
			endorsement.Text1			= endorsement._dtEndorsementAuto.Rows[0]["Text1"].ToString();
			endorsement.Text2			= endorsement._dtEndorsementAuto.Rows[0]["Text2"].ToString();
			endorsement.Text3			= endorsement._dtEndorsementAuto.Rows[0]["Text3"].ToString();
			endorsement.Text4			= endorsement._dtEndorsementAuto.Rows[0]["Text4"].ToString();
			endorsement.Opt1			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt1"];
			endorsement.Opt2			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt2"];
			endorsement.Opt3			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt3"];
			endorsement.Opt4			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt4"];
			endorsement.Opt5			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt5"];
			endorsement.Opt6			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt6"];
			endorsement.Opt7			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt7"];
			endorsement.Opt8			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt8"];
			endorsement.Opt9			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt9"];
			endorsement.Opt10			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt10"];
			endorsement.Opt11			= (bool) endorsement._dtEndorsementAuto.Rows[0]["Opt11"];
			endorsement.TotalPremium	= (double) endorsement._dtEndorsementAuto.Rows[0]["TotalPremium"];
			endorsement.TotalPremiumNew	= (double) endorsement._dtEndorsementAuto.Rows[0]["TotalPremiumNew"];
			endorsement.QuotesAutoIDVIN	= (int) endorsement._dtEndorsementAuto.Rows[0]["QuotesAutoIDVIN"];
			endorsement.QuotesAutoIDLoss= (int) endorsement._dtEndorsementAuto.Rows[0]["QuotesAutoIDLoss"];
			endorsement.QuotesAutoIDMake= (int) endorsement._dtEndorsementAuto.Rows[0]["QuotesAutoIDMake"];
			endorsement.QuotesAutoIDModel=(int) endorsement._dtEndorsementAuto.Rows[0]["QuotesAutoIDModel"];
			endorsement.QuotesAutoIDYear= (int) endorsement._dtEndorsementAuto.Rows[0]["QuotesAutoIDYear"];
			return endorsement;
		}
		#endregion

		#region History

		private void History(int mode, int userID)
		{ 
			//Solo se guarda el ADD, ya que no hay modo de editar.
			Audit.History history = new Audit.History();
			history.BuildNotesForHistory("TaskControlID.","",this.TaskControlID.ToString(),mode);
			history.Actions = "ADD";		

			history.KeyID = this.TaskControlID.ToString();
			history.Subject = "ENDORSEMENTAUTO";			
			history.UsersID =  userID;
			history.GetSaveHistory();
		}

		#endregion
	}
}
