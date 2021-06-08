using System;
using System.Data;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.Customer;
using EPolicy.LookupTables;
using EPolicy.Quotes;
using EPolicy.Audit;
using EPolicy.XmlCooker;

namespace EPolicy.TaskControl 
{
	public class AutoGuardServicesContract:Policy
	{
		public AutoGuardServicesContract()
		{
			this.DepartmentID     = 4;     //AutoGuard
			this.PolicyClassID	  = 1;
			this.PolicyType       = "AG";
			this.InsuranceCompany = "099";
			this.Agency           = "001";
			this.Agent            = "001";
			this.Bank             = "000";
			this.Dealer			  = "000";
			this.CompanyDealer	  = "000";
			this.Status           = "Inforce";
			this.TaskStatusID     = int.Parse(LookupTables.LookupTables.GetID("TaskStatus","Open"));
			this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType","AutoGuardServicesContract"));
			// Para el History
			this._mode =(int) TaskControlMode.ADD;
		}

		#region Variable
		private AutoGuardServicesContract  oldAutoGuard = null;
		private DataTable _dtAGPolicy ;
		private string _ApplicationNo   = "";
		private double _Deductible      = 50;
	    private double _rein_amt		= 0.00;
		private string _ren_rei			= "";
		private int _miles				= 0;
		private int _odometer			= 0;
		private double _cost			= 0.00;
		private string _veh_code		= "";
		private string _veh_class		= "";
		private int _MakeID             = 0;
		private string _make			= "";
		private int _ModelID            = 0;
		private string _model			= "";
		private string _yr				= "";
		private string _vin				= "";
		private string _plate           = "";
		private string _purchdt		    = "";
		private double _costo			= 0.00;
		private string _orig_gara		= "";
		private bool _trams_fl			= false;
		private string _trams_dt		= "";
		private string _canc_prdat	    = "";
		private bool _canc_prifl		= false;
		private string _canc_reas		= "";
		private double _canc_agt        = 0.00;
		private double _canc_agy		= 0.00;
		private bool _ctrams_fl			= false;
		private string _ctrams_dt		= "";
		private bool _can_not_fl		= false;
		private string _can_follow	    = "";
		private bool _print_fl			= false;
		private string _print_dt		= "";
		private bool _pr_let_fl			= false;
		private bool _prsta60_fl		= false;
		private bool _prsta90_fl		= false;
		private bool _prstat90fl		= false;
		private string _pr_sta_dt		= "";
		private bool _pr_lets_fl		= false;
		private string _pr_lets_dt	    = "";
		private bool _rei_fl			= false;
		private bool _label_fl			= false;
		private string _label_dt		= "";
		private string _sellername		= "";
		private string _selleradd1		= "";
		private string _selleradd2		= "";
		private string _sellercity		= "";
		private string _sellerstat		= "PR";
		private string _sellerzip		= "";
		private string _serv_dt		    = "";
		//private AuditItem _auditItem;
		// Para el History
		private int _mode = (int) TaskControlMode.CLEAR;

	
		#endregion

		#region Properties

		public string ApplicationNo
		{
			get
			{
				return this._ApplicationNo;
			}
			set 
			{
				this._ApplicationNo = value;
			}
		}

		public double Deductible
		{
			get
			{
				return this._Deductible;
			}
			set 
			{
				this._Deductible = value;
			}
		}

		public double ReinAmount
		{
			get
			{
				return this._rein_amt;
			}
			set 
			{
				this._rein_amt = value;
			}
		}

//		public string Ren_Rei
//		{
//			get
//			{
//				return this._ren_rei;
//			}
//			set 
//			{
//				this._ren_rei = value;
//			}
//		}

		public int Mileage
		{
			get
			{
				return this._miles;
			}
			set 
			{
				this._miles = value;
			}
		}

		public int Odometer
		{
			get
			{
				return this._odometer;
			}
			set 
			{
				this._odometer = value;
			}
		}

		public double VehicleCost
		{
			get
			{
				return this._cost;
			}
			set 
			{
				this._cost = value;
			}
		}

		public string VehicleCode
		{
			get
			{
				return this._veh_code;
			}
			set 
			{
				this._veh_code = value;
			}
		}

		public string VehicleClass
		{
			get
			{
				return this._veh_class;
			}
			set 
			{
				this._veh_class = value;
			}
		}

		public int MakeID
		{
			get
			{
				return this._MakeID;
			}
			set 
			{
				this._MakeID = value;
			}
		}

		public string Make
		{
			get
			{
				return this._make;
			}
			set 
			{
				this._make = value;
			}
		}

		public int ModelID
		{
			get
			{
				return this._ModelID;
			}
			set 
			{
				this._ModelID = value;
			}
		}

		public string Model
		{
			get
			{
				return this._model;
			}
			set 
			{
				this._model = value;
			}
		}

		public string Year
		{
			get
			{
				return this._yr;
			}
			set 
			{
				this._yr = value;
			}
		}

		public string Plate
		{
			get
			{
				return this._plate;
			}
			set 
			{
				this._plate = value;
			}
		}

		public string Vin
		{
			get
			{
				return this._vin;
			}
			set 
			{
				this._vin = value;
			}
		}

		public string PurchaserDate
		{
			get
			{
				return this._purchdt;
			}
			set 
			{
				this._purchdt = value;
			}
		}

		public double costo
		{
			get
			{
				return this._costo;
			}
			set 
			{
				this._costo = value;
			}
		}

		public string orig_gara
		{
			get
			{
				return this._orig_gara;
			}
			set 
			{
				this._orig_gara = value;
			}
		}

		public bool Trams_Fl
		{
			get
			{
				return this._trams_fl;
			}
			set 
			{
				this._trams_fl = value;
			}
		}

		public string TramsDate
		{
			get
			{
				return this._trams_dt;
			}
			set 
			{
				this._trams_dt = value;
			}
		}

		public string canc_prdat
		{
			get
			{
				return this._canc_prdat;
			}
			set 
			{
				this._canc_prdat = value;
			}
		}

		public bool canc_prifl
		{
			get
			{
				return this._canc_prifl;
			}
			set 
			{
				this._canc_prifl = value;
			}
		}

		public string canc_reas
		{
			get
			{
				return this._canc_reas;
			}
			set 
			{
				this._canc_reas = value;
			}
		}

		public double canc_agt
		{
			get
			{
				return this._canc_agt;
			}
			set 
			{
				this._canc_agt = value;
			}
		}

		public double canc_agy
		{
			get
			{
				return this._canc_agy;
			}
			set 
			{
				this._canc_agy = value;
			}
		}

		public bool Ctrams_fl
		{
			get
			{
				return this._ctrams_fl;
			}
			set 
			{
				this._ctrams_fl = value;
			}
		}

		public string CtramsDate
		{
			get
			{
				return this._ctrams_dt;
			}
			set 
			{
				this._ctrams_dt = value;
			}
		}

		public bool can_not_fl
		{
			get
			{
				return this._can_not_fl;
			}
			set 
			{
				this._can_not_fl = value;
			}
		}

		public string can_follow
		{
			get
			{
				return this._can_follow;
			}
			set 
			{
				this._can_follow = value;
			}
		}

		public bool print_fl
		{
			get
			{
				return this._print_fl;
			}
			set 
			{
				this._print_fl = value;
			}
		}

		public string print_dt
		{
			get
			{
				return this._print_dt;
			}
			set 
			{
				this._print_dt = value;
			}
		}

		public bool pr_let_fl
		{
			get
			{
				return this._pr_let_fl;
			}
			set 
			{
				this._pr_let_fl = value;
			}
		}
		public bool prsta60_fl
		{
			get
			{
				return this._prsta60_fl;
			}
			set 
			{
				this._prsta60_fl = value;
			}
		}
		public bool prsta90_fl
		{
			get
			{
				return this._prsta90_fl;
			}
			set 
			{
				this._prsta90_fl = value;
			}
		}
		public bool prstat90fl
		{
			get
			{
				return this._prstat90fl;
			}
			set 
			{
				this._prstat90fl = value;
			}
		}
		public string pr_sta_dt
		{
			get
			{
				return this._pr_sta_dt;
			}
			set 
			{
				this._pr_sta_dt = value;
			}
		}
		public bool pr_lets_fl
		{
			get
			{
				return this._pr_lets_fl;
			}
			set 
			{
				this._pr_lets_fl = value;
			}
		}
		public string pr_lets_dt
		{
			get
			{
				return this._pr_lets_dt;
			}
			set 
			{
				this._pr_lets_dt = value;
			}
		}
		public bool rei_fl
		{
			get
			{
				return this._rei_fl;
			}
			set 
			{
				this._rei_fl = value;
			}
		}
		public bool label_fl
		{
			get
			{
				return this._label_fl;
			}
			set 
			{
				this._label_fl = value;
			}
		}
		public string label_dt
		{
			get
			{
				return this._label_dt;
			}
			set 
			{
				this._label_dt = value;
			}
		}
		public string SellerName
		{
			get
			{
				return this._sellername;
			}
			set 
			{
				this._sellername = value;
			}
		}
		public string SellerAddress1
		{
			get
			{
				return this._selleradd1;
			}
			set 
			{
				this._selleradd1 = value;
			}
		}
		public string SellerAddress2
		{
			get
			{
				return this._selleradd2;
			}
			set 
			{
				this._selleradd2 = value;
			}
		}
		public string SellerCity
		{
			get
			{
				return this._sellercity;
			}
			set 
			{
				this._sellercity = value;
			}
		}
		public string SellerState
		{
			get
			{
				return this._sellerstat;
			}
			set 
			{
				this._sellerstat = value;
			}
		}
		public string SellerZipCode
		{
			get
			{
				return this._sellerzip;
			}
			set 
			{
				this._sellerzip = value;
			}
		}
		public string ActivationDate
		{
			get
			{
				return this._serv_dt;
			}
			set 
			{
				this._serv_dt = value;
			}
		}
		#endregion

		#region Public Methods

		// Añadi
		public void SaveAutoGuardServicesContract(int UserID)
		{
			this.SavePol(UserID);
		}
		//

		public override void SavePol(int UserID)
		{
			this._mode		= (int) this.Mode;  // Se le asigna el mode de taskControl.
			this.PolicyMode = (int) this.Mode;  // Se le asigna el mode de taskControl.

			base.ValidatePolicy();
			this.Validate();

			// Se utiliza para el History
			//if (this._mode ==2)
			if (this._mode ==2)
				oldAutoGuard = (AutoGuardServicesContract) AutoGuardServicesContract.GetTaskControlByTaskControlID(this.TaskControlID,UserID);
			
			//Si el usuario cambio la prima manualmente, no debe calcular la misma.
			if (this.TotalPremium == 0)
			{
				CalculatePremium();
			}


			base.Save();
			base.SavePol(UserID);	// Validate and Save Policy
            
			SaveAutoGuardServicesContractPolicy(UserID);  // Save AutoGuardServicesContractPolicy

			this._mode = (int) TaskControlMode.UPDATE;
			this.Mode = (int) TaskControlMode.CLEAR;
			//FillProperties(this);
		}

		public override void Validate()
		{
			string errorMessage = String.Empty;

//			if (this.PolicyNo == "")
//				errorMessage = "Policy No. is missing or wrong.";
//			else
				if (this.Vin == "")
				errorMessage = "VIN is missing or wrong.";
			else
				if (this.EffectiveDate == "")
				errorMessage = "Effective Date is missing or wrong.";
			else
				if (this.Make == "")
				errorMessage = "Vehicle Make is missing or wrong.";
			else
				if (this.Model == "")
				errorMessage = "Vehicle Model is missing or wrong.";
			else
				if (this.Year == "")
				errorMessage = "Vehicle Year is missing or wrong.";
			else
				if (this.OriginatedAt == 0)
				errorMessage = "Originated is missing.";

//			else
//				if (this.NewUse == 0)
//				errorMessage = "New/Use is missing or wrong.";
	
			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}
		}

		public static AutoGuardServicesContract GetAutoGuardServicesContract(int TaskControlID)
		{
			AutoGuardServicesContract AGPolicy = null;

			DataTable dt = GetAutoGuardServicesContractByTaskControlID(TaskControlID);

			AGPolicy = new AutoGuardServicesContract();
			AGPolicy = (AutoGuardServicesContract) Policy.GetPolicyByTaskControlID(TaskControlID,AGPolicy);  //Policy
			AGPolicy._dtAGPolicy = dt;

			AGPolicy = FillProperties(AGPolicy);

			return AGPolicy;
		}

		#endregion

		#region Private Methods

		public void CalculatePremium()
		{
			Quotes.MBIQuote MbiQuotes = new EPolicy.Quotes.MBIQuote();
			MbiQuotes.Calculate(this.PolicyType.Trim(),this.Model.Trim(),this.Make.Trim(),this.Term);

			if(this.InsuranceCompany == "097")
			{
				this.TotalPremium = 175.00;
			}
			else
			{
				this.TotalPremium = MbiQuotes.premium;
			}

			this.VehicleClass = MbiQuotes.classification;
			this.Mileage      = MbiQuotes.plan;		
		}


		private static DataTable GetAutoGuardServicesContractByTaskControlID(int TaskControlID)
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
			
			DataTable dt = exec.GetQuery("GetAutoGuardServicesContractByTaskControlID",xmlDoc);
			return dt;
		}

		private void SaveAutoGuardServicesContractPolicy(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				switch (this.Mode)
				{
					case 1:  //ADD
						this.PolicyID = Executor.Insert("AddAutoGuardServicesContract",this.GetInsertAutoGuardServicesContractXml());
						this.History(this._mode,UserID);
						break;

					case 3:  //DELETE
						Executor.Update("DeleteAutoGuardServicesContract",this.GetDeleteAutoGuardServicesContractXml());
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						this.History(this._mode,UserID);
						Executor.Update("UpdateAutoGuardServicesContract",this.GetUpdateAutoGuardServicesContractXml());
						break;
				}
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Policy. "+xcp.Message,xcp);
			}
		}


		private XmlDocument GetDeleteAutoGuardServicesContractXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("PolicyID",
				SqlDbType.Int, 0, this.PolicyID.ToString(),
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

		private XmlDocument GetUpdateAutoGuardServicesContractXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[49];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyID",
				SqlDbType.Int, 0, this.PolicyID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ApplicationNo",
				SqlDbType.Char, 10, this.ApplicationNo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Deductible",
				SqlDbType.Float, 0, this.Deductible.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("rein_amt",
				SqlDbType.Float, 0, this.ReinAmount.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ren_rei",
				SqlDbType.Char, 2, this.Ren_Rei.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("miles",
				SqlDbType.Int, 0, this.Mileage.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("odometer",
				SqlDbType.Int, 0, this.Odometer.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("cost",
				SqlDbType.Float, 0, this.VehicleCost.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("veh_code",
				SqlDbType.Char, 5, this.VehicleCode.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("veh_class",
				SqlDbType.Char, 1, this.VehicleClass.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("MakeID",
				SqlDbType.Int, 0, this.MakeID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("make",
				SqlDbType.VarChar, 30, this.Make.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ModelID",
				SqlDbType.Int, 0, this.ModelID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Model",
				SqlDbType.VarChar, 30, this.Model.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("yr",
				SqlDbType.Char, 4, this.Year.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("vin",
				SqlDbType.Char, 18, this.Vin.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("plate",
				SqlDbType.VarChar, 10, this.Plate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("purchdt",
				SqlDbType.SmallDateTime, 0, this.PurchaserDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("costo",
				SqlDbType.Float, 0, this.costo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("orig_gara",
				SqlDbType.SmallDateTime, 0, this.orig_gara.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("trams_fl",
				SqlDbType.Bit, 0, this.Trams_Fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("trams_dt",
				SqlDbType.SmallDateTime, 0, this.TramsDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_prdat",
				SqlDbType.SmallDateTime, 0, this.canc_prdat.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_prifl",
				SqlDbType.Bit, 0, this.canc_prifl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_reas",
				SqlDbType.Char, 1, this.canc_reas.ToString(),
				ref cookItems);

//			DbRequestXmlCooker.AttachCookItem("canc_agt",
//				SqlDbType.Float, 0, this.canc_agt.ToString(),
//				ref cookItems);
//
//			DbRequestXmlCooker.AttachCookItem("canc_agy",
//				SqlDbType.Float, 0, this.canc_agy.ToString(),
//				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ctrams_fl",
				SqlDbType.Bit, 0, this.Ctrams_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ctrams_dt",
				SqlDbType.SmallDateTime, 0, this.CtramsDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("can_not_fl",
				SqlDbType.Bit, 0, this.can_not_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("can_follow",
				SqlDbType.SmallDateTime, 0, this.can_follow.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("print_fl",
				SqlDbType.Bit, 0, this.print_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("print_dt",
				SqlDbType.SmallDateTime, 0, this.print_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_let_fl",
				SqlDbType.Bit, 0, this.pr_let_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("prsta60_fl",
				SqlDbType.Bit, 0, this.prsta60_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("prsta90_fl",
				SqlDbType.Bit, 0, this.prsta90_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("prstat90fl",
				SqlDbType.Bit, 0, this.prstat90fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_sta_dt",
				SqlDbType.SmallDateTime, 0, this.pr_sta_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_lets_fl",
				SqlDbType.Bit, 0, this.pr_lets_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_lets_dt",
				SqlDbType.SmallDateTime, 0, this.pr_lets_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("rei_fl",
				SqlDbType.Bit, 0, this.rei_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("label_fl",
				SqlDbType.Bit, 0, this.label_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("label_dt",
				SqlDbType.SmallDateTime, 0, this.label_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellername",
				SqlDbType.Char, 30, this.SellerName.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("selleradd1",
				SqlDbType.Char, 20, this.SellerAddress1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("selleradd2",
				SqlDbType.Char, 20, this.SellerAddress2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellercity",
				SqlDbType.Char, 14, this.SellerCity.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellerstat",
				SqlDbType.Char, 2, this.SellerState.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellerzip",
				SqlDbType.Char, 10, this.SellerZipCode.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("serv_dt",
				SqlDbType.SmallDateTime, 0, this.ActivationDate.ToString(),
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


		private XmlDocument GetInsertAutoGuardServicesContractXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[51];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PolicyID",
				SqlDbType.Int, 0, this.PolicyID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ApplicationNo",
				SqlDbType.Char, 10, this.ApplicationNo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Deductible",
				SqlDbType.Float, 0, this.Deductible.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("rein_amt",
				SqlDbType.Float, 0, this.ReinAmount.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ren_rei",
				SqlDbType.Char, 2, this.Ren_Rei.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("miles",
				SqlDbType.Int, 0, this.Mileage.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("odometer",
				SqlDbType.Int, 0, this.Odometer.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("cost",
				SqlDbType.Float, 0, this.VehicleCost.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("veh_code",
				SqlDbType.Char, 5, this.VehicleCode.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("veh_class",
				SqlDbType.Char, 1, this.VehicleClass.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("MakeID",
				SqlDbType.Int, 0, this.MakeID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("make",
				SqlDbType.VarChar, 30, this.Make.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ModelID",
				SqlDbType.Int, 0, this.ModelID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Model",
				SqlDbType.VarChar, 30, this.Model.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("yr",
				SqlDbType.Char, 4, this.Year.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("vin",
				SqlDbType.Char, 18, this.Vin.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("plate",
				SqlDbType.VarChar, 10, this.Plate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("purchdt",
				SqlDbType.SmallDateTime, 0, this.PurchaserDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("costo",
				SqlDbType.Float, 0, this.costo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("orig_gara",
				SqlDbType.SmallDateTime, 0, this.orig_gara.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("trams_fl",
				SqlDbType.Bit, 0, this.Trams_Fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("trams_dt",
				SqlDbType.SmallDateTime, 0, this.TramsDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_prdat",
				SqlDbType.SmallDateTime, 0, this.canc_prdat.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_prifl",
				SqlDbType.Bit, 0, this.canc_prifl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_reas",
				SqlDbType.Char, 1, this.canc_reas.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_agt",
				SqlDbType.Float, 0, this.canc_agt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("canc_agy",
				SqlDbType.Float, 0, this.canc_agy.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ctrams_fl",
				SqlDbType.Bit, 0, this.Ctrams_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ctrams_dt",
				SqlDbType.SmallDateTime, 0, this.CtramsDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("can_not_fl",
				SqlDbType.Bit, 0, this.can_not_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("can_follow",
				SqlDbType.SmallDateTime, 0, this.can_follow.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("print_fl",
				SqlDbType.Bit, 0, this.print_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("print_dt",
				SqlDbType.SmallDateTime, 0, this.print_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_let_fl",
				SqlDbType.Bit, 0, this.pr_let_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("prsta60_fl",
				SqlDbType.Bit, 0, this.prsta60_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("prsta90_fl",
				SqlDbType.Bit, 0, this.prsta90_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("prstat90fl",
				SqlDbType.Bit, 0, this.prstat90fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_sta_dt",
				SqlDbType.SmallDateTime, 0, this.pr_sta_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_lets_fl",
				SqlDbType.Bit, 0, this.pr_lets_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("pr_lets_dt",
				SqlDbType.SmallDateTime, 0, this.pr_lets_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("rei_fl",
				SqlDbType.Bit, 0, this.rei_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("label_fl",
				SqlDbType.Bit, 0, this.label_fl.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("label_dt",
				SqlDbType.SmallDateTime, 0, this.label_dt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellername",
				SqlDbType.Char, 30, this.SellerName.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("selleradd1",
				SqlDbType.Char, 20, this.SellerAddress1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("selleradd2",
				SqlDbType.Char, 20, this.SellerAddress2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellercity",
				SqlDbType.Char, 14, this.SellerCity.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellerstat",
				SqlDbType.Char, 2, this.SellerState.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("sellerzip",
				SqlDbType.Char, 10, this.SellerZipCode.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("serv_dt",
				SqlDbType.SmallDateTime, 0, this.ActivationDate.ToString(),
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

		private static AutoGuardServicesContract FillProperties(AutoGuardServicesContract policy)
		{
//			policy.MakeID             = (int) policy._dtAGPolicy.Rows[0]["MakeID"];
			policy.Make               = policy._dtAGPolicy.Rows[0]["make"].ToString();
//            policy.ModelID            = (int) policy._dtAGPolicy.Rows[0]["ModelID"];
			policy.Model              = policy._dtAGPolicy.Rows[0]["model"].ToString();
			policy.Year				  = policy._dtAGPolicy.Rows[0]["yr"].ToString();
			policy.Vin				  = policy._dtAGPolicy.Rows[0]["vin"].ToString();
			policy.Plate			  = policy._dtAGPolicy.Rows[0]["plate"].ToString();
			policy.VehicleCost		  = (double) policy._dtAGPolicy.Rows[0]["cost"];
			policy.PurchaserDate	  = (policy._dtAGPolicy.Rows[0]["purchdt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["purchdt"]).ToShortDateString():"";
			policy.Odometer			  = (int) policy._dtAGPolicy.Rows[0]["odometer"];
			policy.VehicleClass		  = policy._dtAGPolicy.Rows[0]["veh_class"].ToString();
			policy.Mileage			  = (int) policy._dtAGPolicy.Rows[0]["miles"];
			policy.ActivationDate	  = (policy._dtAGPolicy.Rows[0]["serv_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["serv_dt"]).ToShortDateString():"";
			policy.Deductible         = (double) policy._dtAGPolicy.Rows[0]["Deductible"];
			policy.SellerName		  = policy._dtAGPolicy.Rows[0]["sellername"].ToString();
			policy.SellerAddress1	  = policy._dtAGPolicy.Rows[0]["selleradd1"].ToString();
			policy.SellerAddress2	  = policy._dtAGPolicy.Rows[0]["selleradd2"].ToString();
			policy.SellerCity		  = policy._dtAGPolicy.Rows[0]["sellercity"].ToString();
			policy.SellerState	      = policy._dtAGPolicy.Rows[0]["sellerstat"].ToString();
			policy.SellerZipCode	  = policy._dtAGPolicy.Rows[0]["sellerzip"].ToString();
			policy.ApplicationNo				= policy._dtAGPolicy.Rows[0]["ApplicationNo"].ToString();
			policy.ReinAmount					= (double) policy._dtAGPolicy.Rows[0]["rein_amt"];
			policy.Ren_Rei						= policy._dtAGPolicy.Rows[0]["ren_rei"].ToString();
			policy.VehicleCode					= policy._dtAGPolicy.Rows[0]["veh_code"].ToString();
			policy.costo						= (double) policy._dtAGPolicy.Rows[0]["costo"];
			policy.orig_gara					= (policy._dtAGPolicy.Rows[0]["orig_gara"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["orig_gara"]).ToShortDateString():"";
			policy.Trams_Fl						= (bool) policy._dtAGPolicy.Rows[0]["trams_fl"];
			policy.TramsDate					= (policy._dtAGPolicy.Rows[0]["trams_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["trams_dt"]).ToShortDateString():"";
			policy.canc_prdat					= (policy._dtAGPolicy.Rows[0]["canc_prdat"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["canc_prdat"]).ToShortDateString():"";
			policy.canc_prifl					= (bool) policy._dtAGPolicy.Rows[0]["canc_prifl"];
			policy.canc_reas					= policy._dtAGPolicy.Rows[0]["canc_reas"].ToString();
//			policy.canc_agt					    = (double) policy._dtAGPolicy.Rows[0]["canc_agt"];
//			policy.canc_agy					    = (double) policy._dtAGPolicy.Rows[0]["canc_agy"];
			policy.Ctrams_fl					= (bool) policy._dtAGPolicy.Rows[0]["ctrams_fl"];
			policy.CtramsDate					= (policy._dtAGPolicy.Rows[0]["ctrams_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["ctrams_dt"]).ToShortDateString():"";
			policy.can_not_fl					= (bool) policy._dtAGPolicy.Rows[0]["can_not_fl"];
			policy.can_follow					= policy._dtAGPolicy.Rows[0]["can_follow"].ToString();
			policy.print_fl						= (bool) policy._dtAGPolicy.Rows[0]["print_fl"];
			policy.print_dt						= (policy._dtAGPolicy.Rows[0]["print_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["print_dt"]).ToShortDateString():"";
			policy.pr_let_fl					= (bool) policy._dtAGPolicy.Rows[0]["pr_let_fl"];
			policy.prsta60_fl					= (bool) policy._dtAGPolicy.Rows[0]["prsta60_fl"];
			policy.prsta90_fl					= (bool) policy._dtAGPolicy.Rows[0]["prsta90_fl"];
			policy.prstat90fl					= (bool) policy._dtAGPolicy.Rows[0]["prstat90fl"];
			policy.pr_sta_dt					= (policy._dtAGPolicy.Rows[0]["pr_sta_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["pr_sta_dt"]).ToShortDateString():"";
			policy.pr_lets_fl					= (bool) policy._dtAGPolicy.Rows[0]["pr_lets_fl"];
			policy.pr_lets_dt					= (policy._dtAGPolicy.Rows[0]["pr_lets_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["pr_lets_dt"]).ToShortDateString():"";
			policy.rei_fl						= (bool) policy._dtAGPolicy.Rows[0]["rei_fl"];
			policy.label_fl						= (bool) policy._dtAGPolicy.Rows[0]["label_fl"];
			policy.label_dt						= (policy._dtAGPolicy.Rows[0]["label_dt"]!= System.DBNull.Value)?((DateTime) policy._dtAGPolicy.Rows[0]["label_dt"]).ToShortDateString():"";

			return policy;
		}

		#endregion

		#region History

		private void History(int mode, int userID)
		{ 
			Audit.History history = new Audit.History();
			
			if(_mode == 2)
			{				
				// Campos de TaskControl
				history.BuildNotesForHistory("TaskControlTypeID",
					LookupTables.LookupTables.GetDescription("TaskControlType",oldAutoGuard.TaskControlTypeID.ToString()),
					LookupTables.LookupTables.GetDescription("TaskControlType",this.TaskControlTypeID.ToString()),
					mode);
				history.BuildNotesForHistory("TaskStatusID",
					LookupTables.LookupTables.GetDescription("TaskStatus",oldAutoGuard.TaskStatusID.ToString()),
					LookupTables.LookupTables.GetDescription("TaskStatus",this.TaskStatusID.ToString()),
					mode);	
				history.BuildNotesForHistory("ProspectID",oldAutoGuard.ProspectID.ToString(),this.ProspectID.ToString(),mode);							
				history.BuildNotesForHistory("CustomerNo",oldAutoGuard.CustomerNo,this.CustomerNo,mode);
				history.BuildNotesForHistory("PolicyID",oldAutoGuard.PolicyID.ToString(),this.PolicyID.ToString(),mode);							
				history.BuildNotesForHistory("PolicyClassID",
					LookupTables.LookupTables.GetDescription("PolicyClass",oldAutoGuard.PolicyClassID.ToString()),
					LookupTables.LookupTables.GetDescription("PolicyClass",this.PolicyClassID.ToString()),
					mode);	
				history.BuildNotesForHistory("Agency",oldAutoGuard.Agent,this.Agent,mode);
				history.BuildNotesForHistory("Agent",oldAutoGuard.Agent,this.Agent,mode);
				history.BuildNotesForHistory("Bank",
					LookupTables.LookupTables.GetDescription("Bank",oldAutoGuard.Bank.ToString()),
					LookupTables.LookupTables.GetDescription("Bank",this.Bank.ToString()),
					mode);	
				history.BuildNotesForHistory("InsuranceCompany",
					LookupTables.LookupTables.GetDescription("InsuranceCompany",oldAutoGuard.InsuranceCompany.ToString()),
					LookupTables.LookupTables.GetDescription("InsuranceCompany",this.InsuranceCompany.ToString()),
					mode);
				history.BuildNotesForHistory("Dealer",oldAutoGuard.Dealer,this.Dealer,mode);
				history.BuildNotesForHistory("CompanyDealer",
					LookupTables.LookupTables.GetDescription("CompanyDealer",oldAutoGuard.CompanyDealer.ToString()),
					LookupTables.LookupTables.GetDescription("CompanyDealer",this.CompanyDealer.ToString()),
					mode);	
				history.BuildNotesForHistory("CloseDate",oldAutoGuard.CloseDate,this.CloseDate,mode);
				history.BuildNotesForHistory("EnteredBy",oldAutoGuard.EnteredBy,this.EnteredBy,mode);
				// Terminan Campos TaskControl
				
				// Campos de AutoGuardServicesContract
				history.BuildNotesForHistory("Vin",oldAutoGuard.Vin,this.Vin,mode);
				history.BuildNotesForHistory("Make",
					LookupTables.LookupTables.GetDescription("VehicleMake",oldAutoGuard.Make.ToString()),
					LookupTables.LookupTables.GetDescription("VehicleMake",this.Make.ToString()),
					mode);	
				history.BuildNotesForHistory("Model",
					LookupTables.LookupTables.GetDescription("VehicleModel",oldAutoGuard.Model.ToString()),
					LookupTables.LookupTables.GetDescription("VehicleModel",this.Model.ToString()),
					mode);
				history.BuildNotesForHistory("Year",
					LookupTables.LookupTables.GetDescription("VehicleYear",oldAutoGuard.Year.ToString()),
					LookupTables.LookupTables.GetDescription("VehicleYear",this.Year.ToString()),
					mode);	
				history.BuildNotesForHistory("Plate",oldAutoGuard.Plate.ToString(),this.Plate.ToString(),mode);
				history.BuildNotesForHistory("VehicleCost",oldAutoGuard.VehicleCost.ToString(),this.VehicleCost.ToString(),mode);
				history.BuildNotesForHistory("PurchaserDate",oldAutoGuard.PurchaserDate.ToString(),this.PurchaserDate.ToString(),mode);
				history.BuildNotesForHistory("Odometer",oldAutoGuard.Odometer.ToString(),this.Odometer.ToString(),mode);
				history.BuildNotesForHistory("VehicleClass",oldAutoGuard.VehicleClass.ToString(),this.VehicleClass.ToString(),mode);
				history.BuildNotesForHistory("Mileage",oldAutoGuard.Mileage.ToString(),this.Mileage.ToString(),mode);
				history.BuildNotesForHistory("ActivationDate",oldAutoGuard.ActivationDate.ToString(),this.ActivationDate.ToString(),mode);
				history.BuildNotesForHistory("Deductible",oldAutoGuard.Deductible.ToString(),this.Deductible.ToString(),mode);
				history.BuildNotesForHistory("SellerName",oldAutoGuard.SellerName.ToString(),this.SellerName.ToString(),mode);
				history.BuildNotesForHistory("SellerAddress1",oldAutoGuard.SellerAddress1.ToString(),this.SellerAddress1.ToString(),mode);
				history.BuildNotesForHistory("SellerAddress1",oldAutoGuard.SellerAddress2.ToString(),this.SellerAddress2.ToString(),mode);
				history.BuildNotesForHistory("SellerCity",oldAutoGuard.SellerCity.ToString(),this.SellerCity.ToString(),mode);
				history.BuildNotesForHistory("SellerState",oldAutoGuard.SellerState.ToString(),this.SellerState.ToString(),mode);
				history.BuildNotesForHistory("SellerZipCode",oldAutoGuard.SellerZipCode.ToString(),this.SellerZipCode.ToString(),mode);
				history.BuildNotesForHistory("ApplicationNo",oldAutoGuard.ApplicationNo.ToString(),this.ApplicationNo.ToString(),mode);
				history.BuildNotesForHistory("ReinAmount",oldAutoGuard.ReinAmount.ToString(),this.ReinAmount.ToString(),mode);
				history.BuildNotesForHistory("Ren_Rei",oldAutoGuard.Ren_Rei.ToString(),this.Ren_Rei.ToString(),mode);
				history.BuildNotesForHistory("VehicleCode",oldAutoGuard.VehicleCode.ToString(),this.VehicleCode.ToString(),mode);
				history.BuildNotesForHistory("orig_gara",oldAutoGuard.orig_gara.ToString(),this.orig_gara.ToString(),mode);
				history.BuildNotesForHistory("Trams_Fl",oldAutoGuard.Trams_Fl.ToString(),this.Trams_Fl.ToString(),mode);
				history.BuildNotesForHistory("TramsDate",oldAutoGuard.TramsDate.ToString(),this.TramsDate.ToString(),mode);
				history.BuildNotesForHistory("costo",oldAutoGuard.costo.ToString(),this.costo.ToString(),mode);
				history.BuildNotesForHistory("canc_prdat",oldAutoGuard.canc_prdat.ToString(),this.canc_prdat.ToString(),mode);
				history.BuildNotesForHistory("canc_prifl",oldAutoGuard.canc_prifl.ToString(),this.canc_prifl.ToString(),mode);
				history.BuildNotesForHistory("canc_reas",oldAutoGuard.canc_reas.ToString(),this.canc_reas.ToString(),mode);
//				history.BuildNotesForHistory("canc_agt",oldAutoGuard.canc_agt.ToString(),this.canc_agt.ToString(),mode);
//				history.BuildNotesForHistory("canc_agy",oldAutoGuard.canc_agy.ToString(),this.canc_agy.ToString(),mode);
				history.BuildNotesForHistory("Ctrams_fl",oldAutoGuard.Ctrams_fl.ToString(),this.Ctrams_fl.ToString(),mode);
				history.BuildNotesForHistory("CtramsDate",oldAutoGuard.CtramsDate.ToString(),this.CtramsDate.ToString(),mode);
				history.BuildNotesForHistory("can_not_fl",oldAutoGuard.can_not_fl.ToString(),this.can_not_fl.ToString(),mode);
				history.BuildNotesForHistory("can_follow",oldAutoGuard.can_follow.ToString(),this.can_follow.ToString(),mode);
				history.BuildNotesForHistory("print_fl",oldAutoGuard.print_fl.ToString(),this.print_fl.ToString(),mode);
				history.BuildNotesForHistory("print_dt",oldAutoGuard.print_dt.ToString(),this.print_dt.ToString(),mode);
				history.BuildNotesForHistory("pr_let_fl",oldAutoGuard.pr_let_fl.ToString(),this.pr_let_fl.ToString(),mode);
				history.BuildNotesForHistory("prsta60_fl",oldAutoGuard.prsta60_fl.ToString(),this.prsta60_fl.ToString(),mode);
				history.BuildNotesForHistory("prsta90_fl",oldAutoGuard.prsta90_fl.ToString(),this.prsta90_fl.ToString(),mode);
				history.BuildNotesForHistory("prstat90fl",oldAutoGuard.prstat90fl.ToString(),this.prstat90fl.ToString(),mode);
				history.BuildNotesForHistory("pr_sta_dt",oldAutoGuard.pr_sta_dt.ToString(),this.pr_sta_dt.ToString(),mode);
				history.BuildNotesForHistory("pr_lets_fl",oldAutoGuard.pr_lets_fl.ToString(),this.pr_lets_fl.ToString(),mode);
				history.BuildNotesForHistory("rei_fl",oldAutoGuard.rei_fl.ToString(),this.rei_fl.ToString(),mode);
				history.BuildNotesForHistory("label_fl",oldAutoGuard.label_fl.ToString(),this.label_fl.ToString(),mode);
				history.BuildNotesForHistory("label_dt",oldAutoGuard.label_dt.ToString(),this.label_dt.ToString(),mode);

				// Terminan Campos AutoGuardServicesContract

				// Campos de Policy
				history.BuildNotesForHistory("DepartmentID",
					LookupTables.LookupTables.GetDescription("Department",oldAutoGuard.DepartmentID.ToString()),
					LookupTables.LookupTables.GetDescription("Department",this.DepartmentID.ToString()),
					mode);
				history.BuildNotesForHistory("PolicyType",oldAutoGuard.PolicyType,this.PolicyType,mode);
				history.BuildNotesForHistory("PolicyNo",oldAutoGuard.PolicyNo,this.PolicyNo,mode);
				history.BuildNotesForHistory("Certificate",oldAutoGuard.Certificate,this.Certificate,mode);
				history.BuildNotesForHistory("Suffix",oldAutoGuard.Suffix,this.Suffix,mode);
				history.BuildNotesForHistory("LoanNo",oldAutoGuard.LoanNo.ToString(),this.LoanNo.ToString(),mode);
				history.BuildNotesForHistory("Term",oldAutoGuard.Term.ToString(),this.Term.ToString(),mode);
				history.BuildNotesForHistory("EffectiveDate",oldAutoGuard.EffectiveDate.ToString(),this.EffectiveDate.ToString(),mode);
				history.BuildNotesForHistory("ExpirationDate",oldAutoGuard.ExpirationDate.ToString(),this.ExpirationDate.ToString(),mode);
				history.BuildNotesForHistory("Charge",oldAutoGuard.Charge.ToString(),this.Charge.ToString(),mode);
				history.BuildNotesForHistory("TotalPremium",oldAutoGuard.TotalPremium.ToString(),this.TotalPremium.ToString(),mode);
				history.BuildNotesForHistory("Status",oldAutoGuard.Status.ToString(),this.Status.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgency",oldAutoGuard.CommissionAgency.ToString(),this.CommissionAgency.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgencyPercent",oldAutoGuard.CommissionAgencyPercent.ToString(),this.CommissionAgencyPercent.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgent",oldAutoGuard.CommissionAgent.ToString(),this.CommissionAgent.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgentPercent",oldAutoGuard.CommissionAgentPercent.ToString(),this.CommissionAgentPercent.ToString(),mode);
				history.BuildNotesForHistory("CommissionDate",oldAutoGuard.CommissionDate.ToString(),this.CommissionDate.ToString(),mode);
				history.BuildNotesForHistory("CancellationDate",oldAutoGuard.CancellationDate.ToString(),this.CancellationDate.ToString(),mode);
				history.BuildNotesForHistory("CancellationEntryDate",oldAutoGuard.CancellationEntryDate.ToString(),this.CancellationEntryDate.ToString(),mode);
				history.BuildNotesForHistory("CancellationUnearnedPercent",oldAutoGuard.CancellationUnearnedPercent.ToString(),this.CancellationUnearnedPercent.ToString(),mode);
				history.BuildNotesForHistory("ReturnPremium",oldAutoGuard.ReturnPremium.ToString(),this.ReturnPremium.ToString(),mode);
				history.BuildNotesForHistory("ReturnCharge",oldAutoGuard.ReturnCharge.ToString(),this.ReturnCharge.ToString(),mode);
				history.BuildNotesForHistory("CancellationAmount",oldAutoGuard.CancellationAmount.ToString(),this.CancellationAmount.ToString(),mode);
				history.BuildNotesForHistory("CancellationMethod",oldAutoGuard.CancellationMethod.ToString(),this.CancellationMethod.ToString(),mode);
				history.BuildNotesForHistory("CancellationReason",oldAutoGuard.CancellationReason.ToString(),this.CancellationReason.ToString(),mode);
				history.BuildNotesForHistory("ReturnCommissionAgency",oldAutoGuard.ReturnCommissionAgency.ToString(),this.ReturnCommissionAgency.ToString(),mode);
				history.BuildNotesForHistory("ReturnCommissionAgent",oldAutoGuard.ReturnCommissionAgent.ToString(),this.ReturnCommissionAgent.ToString(),mode);
				history.BuildNotesForHistory("PaidAmount",oldAutoGuard.PaidAmount.ToString(),this.PaidAmount.ToString(),mode);
				history.BuildNotesForHistory("PaidDate",oldAutoGuard.PaidDate.ToString(),this.PaidDate.ToString(),mode);
				history.BuildNotesForHistory("AutoAssignPolicy",oldAutoGuard.AutoAssignPolicy.ToString(),this.AutoAssignPolicy.ToString(),mode);
				history.BuildNotesForHistory("InvoiceNumber",oldAutoGuard.InvoiceNumber.ToString(),this.InvoiceNumber.ToString(),mode);
				history.BuildNotesForHistory("FileNumber",oldAutoGuard.FileNumber.ToString(),this.FileNumber.ToString(),mode);
				history.BuildNotesForHistory("IsLeasing",oldAutoGuard.IsLeasing.ToString(),this.IsLeasing.ToString(),mode);
				history.BuildNotesForHistory("PaymentType",oldAutoGuard.PaymentType.ToString(),this.PaymentType.ToString(),mode);
				history.BuildNotesForHistory("IsMaster",oldAutoGuard.IsMaster.ToString(),this.IsMaster.ToString(),mode);
				history.BuildNotesForHistory("TCIDApplicationAuto",oldAutoGuard.TCIDApplicationAuto.ToString(),this.TCIDApplicationAuto.ToString(),mode);
				history.BuildNotesForHistory("TCIDQuote",oldAutoGuard.TCIDQuotes.ToString(),this.TCIDQuotes.ToString(),mode);
				history.BuildNotesForHistory("PrintPolicy",oldAutoGuard.PrintPolicy.ToString(),this.PrintPolicy.ToString(),mode);
				history.BuildNotesForHistory("MasterPolicyID",
					LookupTables.LookupTables.GetDescription("MasterPolicy",oldAutoGuard.MasterPolicyID.ToString()),
					LookupTables.LookupTables.GetDescription("MasterPolicy",this.MasterPolicyID.ToString()),
					mode);
				history.BuildNotesForHistory("Prem_Mes",oldAutoGuard.Prem_Mes.ToString(),this.Prem_Mes.ToString(),mode);
				history.BuildNotesForHistory("PMT1",oldAutoGuard.PMT1.ToString(),this.PMT1.ToString(),mode);
				history.BuildNotesForHistory("PrintDate",oldAutoGuard.PrintDate.ToString(),this.PrintDate.ToString(),mode);
				history.BuildNotesForHistory("OriginatedAt",oldAutoGuard.OriginatedAt.ToString(),this.OriginatedAt.ToString(),mode);
				// Terminan Campos Policy


				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("TaskControlID.","",this.TaskControlID.ToString(),mode);
				history.Actions = "ADD";
			}

			history.KeyID = this.TaskControlID.ToString();
			history.Subject = "AUTOGUARDSERVICESCONTRACT";			
			history.UsersID =  userID;
			history.GetSaveHistory();
		}
		
		
		private object SafeConvertToDateTime(string StringObject)
		{
			if(StringObject != string.Empty)
			{
				try	{return DateTime.Parse(StringObject);}
				catch{/*Write to error logging sub-system.*/}
			}
			return StringObject;
		}


#endregion

	}
}
