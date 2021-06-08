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
	public class Policies:Policy
	{
		public Policies()
		{
			this.AgentList		  = Policy.GetAgentListByPolicyClassID(0);
			//this.SupplierList	  = Policy.GetSupplierListByPolicyClassID(0);
			this.DepartmentID     = 0;    
			this.PolicyClassID	  = 0;
			this.PolicyType       = "";
			this.InsuranceCompany = "";
			this.Agency           = "";
            //this.City       = 0;
			this.Agent            = "";
			this.SupplierID		  = "";
			this.Bank             = "000";
			this.Dealer			  = "000";
			this.CompanyDealer	  = "000";
			this.Status           = "Inforce";
			this.TaskStatusID     = int.Parse(LookupTables.LookupTables.GetID("TaskStatus","Open"));
			this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType","Policies"));
			// Para el History
			this._mode =(int) TaskControlMode.ADD;
		}

		#region Variable

        //private int _City = 0;
		private Policies  oldPolices = null;
		//private Policy _Policy = new Policy();
		private DataTable _dtPolices ;
        private DataTable _EndorsementCollection = null;
        private DataTable _Endorsement;
		private PolicyDetailcs _PolicyDetailcs= null;
		private int _PoliciesID			= 0;
		private int _Milleages			= 0;
		private double _Cost			= 0.00;
		private double _FinanceAmt   	= 0.00;
		private string _VehicleClass	= "";
		private int _VehicleMakeID      = 0;
		private int _VehicleModelID     = 0;
		private int _VehicleYearID		= 0;
		private string _VIN				= "";
		private string _Plate           = "";
		private string _PurchaseDate    = "";
		private int _NewUse				= 0;
		private string _Comments		= "";
		private double _Balance			= 0.00;
		private bool _PrestamoArrenda   = false;
		private string _InsuranceCompanyPrimaria = "000";
		private string _NumeroPolizaPrimaria = "";
		private int _CoveragePlan		= 0;
		private int _Miles				= 0;
		private bool _Diesel				= false;
		private bool _WD4				= false;
		private bool _Turbo				= false;
		private bool _CommercialUse		= false;
		private string _VehicleCode		= "";
        private string _EffDateCompany = "";
        private string _Class = "";
        private double _LossFund = 0.00;
        private double _OverHead = 0.00;
        private double _BankFee = 0.00;
        private double _Profit = 0.00;
        private double _Concurso = 0.00;
        private double _DealerCost = 0.00;
        private double _DealerProfit = 0.00;
        private double _CanReserve = 0.00;
        private double _DealerNet = 0.00;
        private int _VehicleServiceContractQuoteID = 0;
        private int _PRMedicRATEID = 0;
        private int _PRMedicalLimit = 0;
        private string _IsoCode = "";
        private double _RateYear1 = 0.00;
        private double _RateYear2 = 0.00;
        private double _RateYear3 = 0.00;
        private double _MCMRate = 0.00;
        private int _ApplicationID = 0;

        private double _PrimaryTN1 = 0.00;
        private double _PrimaryTN2 = 0.00;
        private double _PrimaryTN3 = 0.00;
        private double _PrimaryTN4 = 0.00;
        private double _PrimaryTN5 = 0.00;
        private double _RateTN1 = 0.00;
        private double _RateTN2 = 0.00;
        private double _RateTN3 = 0.00;
        private double _RateTN4 = 0.00;
        private double _RateTN5 = 0.00;
        private double _RateTN6 = 0.00;
        private double _PremiumTN1 = 0.00;
        private double _PremiumTN2 = 0.00;
        private double _PremiumTN3 = 0.00;
        private double _PremiumTN4 = 0.00;
        private double _PremiumTN5 = 0.00;
        private int _QuantityTN1 = 0;
        private int _QuantityTN2 = 0;
        private int _QuantityTN3 = 0;
        private int _QuantityTN4 = 0;
        private int _QuantityTN5 = 0;
        private int _QuantityTN6 = 0;
        private double _TotPremTN1 = 0.00;
        private double _TotPremTN2 = 0.00;
        private double _TotPremTN3 = 0.00;
        private double _TotPremTN4 = 0.00;
        private double _TotPremTN5 = 0.00;
        private double _TotPremTN6 = 0.00;
        private double _ExcessTN1 = 0.00;
        private double _ExcessTN2 = 0.00;
        private double _ExcessTN3 = 0.00;
        private double _ExcessTN4 = 0.00;
        private double _ExcessTN5 = 0.00;
        private double _ERateTN1 = 0.00;
        private double _ERateTN2 = 0.00;
        private double _ERateTN3 = 0.00;
        private double _ERateTN4 = 0.00;
        private double _ERateTN5 = 0.00;
        private double _ERateTN6 = 0.00;
        private double _EPremiumTN1 = 0.00;
        private double _EPremiumTN2 = 0.00;
        private double _EPremiumTN3 = 0.00;
        private double _EPremiumTN4 = 0.00;
        private double _EPremiumTN5 = 0.00;
        private int _EQuantityTN1 = 0;
        private int _EQuantityTN2 = 0;
        private int _EQuantityTN3 = 0;
        private int _EQuantityTN4 = 0;
        private int _EQuantityTN5 = 0;
        private int _EQuantityTN6 = 0;
        private double _ETotPremTN1 = 0.00;
        private double _ETotPremTN2 = 0.00;
        private double _ETotPremTN3 = 0.00;
        private double _ETotPremTN4 = 0.00;
        private double _ETotPremTN5 = 0.00;
        private double _ETotPremTN6 = 0.00;
        private double _TotalPrimary = 0.00;
        private double _TotalExcess = 0.00;

        private string _priCarierName1;        
        private string _priPolEffecDate1;
        private string _priPolLimits1;
        private string _priClaims1;

        private bool _isEndorsement = false;

        private bool _isRecalculated = false;

		private int _mode				= (int) TaskControlMode.CLEAR;
	
		#endregion

		#region Properties

        public DataTable Endorsement
        {
            get
            {
                this._Endorsement = GetEndorsementDetailByTaskControlID(TaskControlID);
                return (this._Endorsement);
            }
            set
            {
                this._Endorsement = value;
            }
        }

        public DataTable EndorsementCollection
        {
            get
            {
                if (this._EndorsementCollection == null)
                    this._EndorsementCollection = DataTableEndorsementTemp();
                return (this._EndorsementCollection);
            }
            set
            {
                this._EndorsementCollection = value;
            }
        }

		public PolicyDetailcs PolicyDetailcs
		{
			get
			{
				if(this._PolicyDetailcs == null)
					this._PolicyDetailcs = new PolicyDetailcs();
				return (this._PolicyDetailcs);
			}
			set
			{
				this._PolicyDetailcs = value;
			}
		}

		public int PoliciesID
		{
			get
			{
				return this._PoliciesID;
			}
			set 
			{
				this._PoliciesID = value;
			}
		}

		public int Milleages
		{
			get
			{
				return this._Milleages;
			}
			set 
			{
				this._Milleages = value;
			}
		}

		public double Cost
		{
			get
			{
				return this._Cost;
			}
			set 
			{
				this._Cost = value;
			}
		}
		
		public double FinanceAmt
		{
			get
			{
				return this._FinanceAmt;
			}
			set 
			{
				this._FinanceAmt = value;
			}
		}

		public string VehicleClass
		{
			get
			{
				return this._VehicleClass;
			}
			set 
			{
				this._VehicleClass = value;
			}
		}

		public int VehicleMakeID
		{
			get
			{
				return this._VehicleMakeID;
			}
			set 
			{
				this._VehicleMakeID = value;
			}
		}

		public int VehicleModelID
		{
			get
			{
				return this._VehicleModelID;
			}
			set 
			{
				this._VehicleModelID = value;
			}
		}

		public int VehicleYearID
		{
			get
			{
				return this._VehicleYearID;
			}
			set 
			{
				this._VehicleYearID = value;
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

		public string Plate
		{
			get
			{
				return this._Plate;
			}
			set 
			{
				this._Plate = value;
			}
		}

		public string PurchaseDate
		{
			get
			{
				return this._PurchaseDate;
			}
			set 
			{
				this._PurchaseDate = value;
			}
		}

		public int NewUse
		{
			get
			{
				return this._NewUse;
			}
			set 
			{
				this._NewUse = value;
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

		public double Balance
		{
			get
			{
				return this._Balance;
			}
			set 
			{
				this._Balance = value;
			}
		}

		public bool PrestamoArrenda   
		{
			get
			{
				return this._PrestamoArrenda;
			}
			set 
			{
				this._PrestamoArrenda = value;
			}
		}

        public bool isEndorsement
        {
            get
            {
                return this._isEndorsement;
            }
            set
            {
                this._isEndorsement = value;
            }
        }

        public bool isRecalculated
        {
            get
            {
                return this._isRecalculated;
            }
            set
            {
                this._isRecalculated = value;
            }
        }

		public string InsuranceCompanyPrimaria 
		{
			get
			{
				return this._InsuranceCompanyPrimaria;
			}
			set 
			{
				this._InsuranceCompanyPrimaria = value;
			}
		}

		public string NumeroPolizaPrimaria 
		{
			get
			{
				return this._NumeroPolizaPrimaria;
			}
			set 
			{
				this._NumeroPolizaPrimaria = value;
			}
		}

		public int CoveragePlan		
		{
			get
			{
				return this._CoveragePlan;
			}
			set 
			{
				this._CoveragePlan = value;
			}
		}

		public int Miles		
		{
			get
			{
				return this._Miles;
			}
			set 
			{
				this._Miles = value;
			}
		}

		public bool Diesel		
		{
			get
			{
				return this._Diesel;
			}
			set 
			{
				this._Diesel = value;
			}
		}

		public bool WD4		
		{
			get
			{
				return this._WD4;
			}
			set 
			{
				this._WD4 = value;
			}
		}

		public bool Turbo		
		{
			get
			{
				return this._Turbo;
			}
			set 
			{
				this._Turbo = value;
			}
		}

		public bool CommercialUse		
		{
			get
			{
				return this._CommercialUse;
			}
			set 
			{
				this._CommercialUse = value;
			}
		}

		public string VehicleCode
		{
			get
			{
				return this._VehicleCode;
			}
			set 
			{
				this._VehicleCode = value;
			}
		}

        public string EffDateCompany
		{
			get
			{
                return this._EffDateCompany;
			}
			set 
			{
                this._EffDateCompany = value;
			}
		}

        public string Class
        {
            get
            {
                return this._Class;
            }
            set
            {
                this._Class = value;
            }
        }

        public double LossFund
        {
            get
            {
                return this._LossFund;
            }
            set
            {
                this._LossFund = value;
            }
        }

        public double OverHead
        {
            get
            {
                return this._OverHead;
            }
            set
            {
                this._OverHead = value;
            }
        }

        public double BankFee
        {
            get
            {
                return this._BankFee;
            }
            set
            {
                this._BankFee = value;
            }
        }

        public double Profit
        {
            get
            {
                return this._Profit;
            }
            set
            {
                this._Profit = value;
            }
        }

        public double Concurso
        {
            get
            {
                return this._Concurso;
            }
            set
            {
                this._Concurso = value;
            }
        }

        public double DealerCost
        {
            get
            {
                return this._DealerCost;
            }
            set
            {
                this._DealerCost = value;
            }
        }

        public double DealerProfit
        {
            get
            {
                return this._DealerProfit;
            }
            set
            {
                this._DealerProfit = value;
            }
        }

        public double CanReserve
        {
            get
            {
                return this._CanReserve;
            }
            set
            {
                this._CanReserve = value;
            }
        }

        public double DealerNet
        {
            get
            {
                return this._DealerNet;
            }
            set
            {
                this._DealerNet = value;
            }
        }

        public int VehicleServiceContractQuoteID
        {
            get
            {
                return this._VehicleServiceContractQuoteID;
            }
            set
            {
                this._VehicleServiceContractQuoteID = value;
            }
        }

        public int PRMedicRATEID
        {
            get
            {
                return this._PRMedicRATEID;
            }
            set
            {
                this._PRMedicRATEID = value;
            }
        }

        public int PRMedicalLimit
        {
            get
            {
                return this._PRMedicalLimit;
            }
            set
            {
                this._PRMedicalLimit = value;
            }
        }

        public string IsoCode
        {
            get
            {
                return this._IsoCode;
            }
            set
            {
                this._IsoCode = value;
            }
        }

        public double RateYear1
        {
            get
            {
                return this._RateYear1;
            }
            set
            {
                this._RateYear1 = value;
            }
        }

        public double RateYear2
        {
            get
            {
                return this._RateYear2;
            }
            set
            {
                this._RateYear2 = value;
            }
        }

        public double RateYear3
        {
            get
            {
                return this._RateYear3;
            }
            set
            {
                this._RateYear3 = value;
            }
        }

        public double MCMRate
        {
            get
            {
                return this._MCMRate;
            }
            set
            {
                this._MCMRate = value;
            }
        }

        public int ApplicationID
        {
            get
            {
                return this._ApplicationID;
            }
            set
            {
                this._ApplicationID = value;
            }
        }

        public bool PolicyCanRenewDt(int _TaskControlID, int _Suffix)
        {
            DataTable dt = new DataTable();
            dt = PolicyCanRenew(_TaskControlID);

            if (dt.Rows.Count != 0)
            {
                if (_Suffix < int.Parse(dt.Rows[0]["MaxSuffix"].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        //AgencyCity
        //public int City
        //{
        //    get
        //    {
        //        return this._City;
        //    }
        //    set
        //    {
        //        this._City = value;
        //    }
        //}


        //Nurses and Technitians Table
        public double PrimaryTN1
        {
            get { return this._PrimaryTN1; }
            set { this._PrimaryTN1 = value; }
        }
        public double PrimaryTN2
        {
            get { return this._PrimaryTN2; }
            set { this._PrimaryTN2 = value; }
        }
        public double PrimaryTN3
        {
            get { return this._PrimaryTN3; }
            set { this._PrimaryTN3 = value; }
        }
        public double PrimaryTN4
        {
            get { return this._PrimaryTN4; }
            set { this._PrimaryTN4 = value; }
        }
        public double PrimaryTN5
        {
            get { return this._PrimaryTN5; }
            set { this._PrimaryTN5 = value; }
        }
        public double RateTN1
        {
            get { return this._RateTN1; }
            set { this._RateTN1 = value; }
        }
        public double RateTN2
        {
            get { return this._RateTN2; }
            set { this._RateTN2 = value; }
        }
        public double RateTN3
        {
            get { return this._RateTN3; }
            set { this._RateTN3 = value; }
        }
        public double RateTN4
        {
            get { return this._RateTN4; }
            set { this._RateTN4 = value; }
        }
        public double RateTN5
        {
            get { return this._RateTN5; }
            set { this._RateTN5 = value; }
        }
        public double RateTN6
        {
            get { return this._RateTN6; }
            set { this._RateTN6 = value; }
        }
        public double PremiumTN1
        {
            get { return this._PremiumTN1; }
            set { this._PremiumTN1 = value; }
        }
        public double PremiumTN2
        {
            get { return this._PremiumTN2; }
            set { this._PremiumTN2 = value; }
        }
        public double PremiumTN3
        {
            get { return this._PremiumTN3; }
            set { this._PremiumTN3 = value; }
        }
        public double PremiumTN4
        {
            get { return this._PremiumTN4; }
            set { this._PremiumTN4 = value; }
        }
        public double PremiumTN5
        {
            get { return this._PremiumTN5; }
            set { this._PremiumTN5 = value; }
        }
        public int QuantityTN1
        {
            get { return this._QuantityTN1; }
            set { this._QuantityTN1 = value; }
        }
        public int QuantityTN2
        {
            get { return this._QuantityTN2; }
            set { this._QuantityTN2 = value; }
        }
        public int QuantityTN3
        {
            get { return this._QuantityTN3; }
            set { this._QuantityTN3 = value; }
        }
        public int QuantityTN4
        {
            get { return this._QuantityTN4; }
            set { this._QuantityTN4 = value; }
        }
        public int QuantityTN5
        {
            get { return this._QuantityTN5; }
            set { this._QuantityTN5 = value; }
        }
        public int QuantityTN6
        {
            get { return this._QuantityTN6; }
            set { this._QuantityTN6 = value; }
        }
        public double TotPremTN1
        {
            get { return this._TotPremTN1; }
            set { this._TotPremTN1 = value; }
        }
        public double TotPremTN2
        {
            get { return this._TotPremTN2; }
            set { this._TotPremTN2 = value; }
        }
        public double TotPremTN3
        {
            get { return this._TotPremTN3; }
            set { this._TotPremTN3 = value; }
        }
        public double TotPremTN4
        {
            get { return this._TotPremTN4; }
            set { this._TotPremTN4 = value; }
        }
        public double TotPremTN5
        {
            get { return this._TotPremTN5; }
            set { this._TotPremTN5 = value; }
        }
        public double TotPremTN6
        {
            get { return this._TotPremTN6; }
            set { this._TotPremTN6 = value; }
        }
        public double ExcessTN1
        {
            get { return this._ExcessTN1; }
            set { this._ExcessTN1 = value; }
        }
        public double ExcessTN2
        {
            get { return this._ExcessTN2; }
            set { this._ExcessTN2 = value; }
        }
        public double ExcessTN3
        {
            get { return this._ExcessTN3; }
            set { this._ExcessTN3 = value; }
        }
        public double ExcessTN4
        {
            get { return this._ExcessTN4; }
            set { this._ExcessTN4 = value; }
        }
        public double ExcessTN5
        {
            get { return this._ExcessTN5; }
            set { this._ExcessTN5 = value; }
        }
        public double ERateTN1
        {
            get { return this._ERateTN1; }
            set { this._ERateTN1 = value; }
        }
        public double ERateTN2
        {
            get { return this._ERateTN2; }
            set { this._ERateTN2 = value; }
        }
        public double ERateTN3
        {
            get { return this._ERateTN3; }
            set { this._ERateTN3 = value; }
        }
        public double ERateTN4
        {
            get { return this._ERateTN4; }
            set { this._ERateTN4 = value; }
        }
        public double ERateTN5
        {
            get { return this._ERateTN5; }
            set { this._ERateTN5 = value; }
        }
        public double ERateTN6
        {
            get { return this._ERateTN6; }
            set { this._ERateTN6 = value; }
        }
        public double EPremiumTN1
        {
            get { return this._EPremiumTN1; }
            set { this._EPremiumTN1 = value; }
        }
        public double EPremiumTN2
        {
            get { return this._EPremiumTN2; }
            set { this._EPremiumTN2 = value; }
        }
        public double EPremiumTN3
        {
            get { return this._EPremiumTN3; }
            set { this._EPremiumTN3 = value; }
        }
        public double EPremiumTN4
        {
            get { return this._EPremiumTN4; }
            set { this._EPremiumTN4 = value; }
        }
        public double EPremiumTN5
        {
            get { return this._EPremiumTN5; }
            set { this._EPremiumTN5 = value; }
        }
        public int EQuantityTN1
        {
            get { return this._EQuantityTN1; }
            set { this._EQuantityTN1 = value; }
        }
        public int EQuantityTN2
        {
            get { return this._EQuantityTN2; }
            set { this._EQuantityTN2 = value; }
        }
        public int EQuantityTN3
        {
            get { return this._EQuantityTN3; }
            set { this._EQuantityTN3 = value; }
        }
        public int EQuantityTN4
        {
            get { return this._EQuantityTN4; }
            set { this._EQuantityTN4 = value; }
        }
        public int EQuantityTN5
        {
            get { return this._EQuantityTN5; }
            set { this._EQuantityTN5 = value; }
        }
        public int EQuantityTN6
        {
            get { return this._EQuantityTN6; }
            set { this._EQuantityTN6 = value; }
        }
        public double ETotPremTN1
        {
            get { return this._ETotPremTN1; }
            set { this._ETotPremTN1 = value; }
        }
        public double ETotPremTN2
        {
            get { return this._ETotPremTN2; }
            set { this._ETotPremTN2 = value; }
        }
        public double ETotPremTN3
        {
            get { return this._ETotPremTN3; }
            set { this._ETotPremTN3 = value; }
        }
        public double ETotPremTN4
        {
            get { return this._ETotPremTN4; }
            set { this._ETotPremTN4 = value; }
        }
        public double ETotPremTN5
        {
            get { return this._ETotPremTN5; }
            set { this._ETotPremTN5 = value; }
        }
        public double ETotPremTN6
        {
            get { return this._ETotPremTN6; }
            set { this._ETotPremTN6 = value; }
        }
        public double TotalPrimary
        {
            get { return this._TotalPrimary; }
            set { this._TotalPrimary = value; }
        }

        public double TotalExcess
        {
            get { return this._TotalExcess; }
            set { this._TotalExcess = value; }
        }


        public string PriPolEffecDate1
        {
            get { return _priPolEffecDate1; }
            set { _priPolEffecDate1 = value; }
        }

        public string PriPolLimits1
        {
            get { return _priPolLimits1; }
            set { _priPolLimits1 = value; }
        }

        public string PriCarierName1
        {
            get { return _priCarierName1; }
            set { _priCarierName1 = value; }
        }

        public string PriClaims1
        {
            get { return _priClaims1; }
            set { _priClaims1 = value; }
        }

		#endregion

		#region Public Methods

		// Añadi
		public void SavePolicies(int UserID)
		{
			this.SavePol(UserID);
		}
		//

		public override void SavePol(int UserID)
		{
			this._mode		= (int) this.Mode;  // Se le asigna el mode de taskControl.
			this.PolicyMode = (int) this.Mode;  // Se le asigna el mode de taskControl.

			this.Validate();
			base.ValidatePolicy();			

			//Se utiliza para el History
			//if (this._mode ==2)
			if (this._mode ==2)
				oldPolices = (Policies) Policies.GetTaskControlByTaskControlID(this.TaskControlID,UserID);
			
			//Si el usuario cambio la prima manualmente, no debe calcular la misma.
			if (this.TotalPremium == 0)
			{
				//CalculatePremium();
			}

			if (this.Customer.CustomerNo.Trim() == "")
				this.Customer.Mode = 1;
			else
				this.Customer.Mode = 2;

			this.Customer.IsBusiness = false;
			this.Customer.Save(UserID);

			this.CustomerNo = this.Customer.CustomerNo;
			this.ProspectID = this.Customer.ProspectID;

			base.Save();
			base.SavePol(UserID);	// Validate and Save Policy
            
			SavePoliciesPolicies(UserID);  // Save Policies
			this.PolicyDetailcs.SavePolicyDetail(UserID,this.TaskControlID);

			this._mode = (int) TaskControlMode.UPDATE;
			this.Mode = (int) TaskControlMode.CLEAR;
			//FillProperties(this);
		}

        public void SavePoliciesEQuotes(int UserID)
        {
            this.SavePolEQuotes(UserID);
        }
        //

        public void SavePolEQuotes(int UserID)
        {
            this._mode = (int)this.Mode;  // Se le asigna el mode de taskControl.
            this.PolicyMode = (int)this.Mode;  // Se le asigna el mode de taskControl.

            this.Validate();
            base.ValidatePolicy();

            //Se utiliza para el History
            //if (this._mode ==2)
            if (this._mode == 2)
                oldPolices = (Policies)Policies.GetTaskControlByTaskControlID(this.TaskControlID, UserID);

            //Si el usuario cambio la prima manualmente, no debe calcular la misma.
            if (this.TotalPremium == 0)
            {
                //CalculatePremium();
            }

            if (this.Customer.CustomerNo.Trim() == "")
                this.Customer.Mode = 1;
            else
                this.Customer.Mode = 2;

            this.Customer.IsBusiness = false;
            this.Customer.Save(UserID);

            this.CustomerNo = this.Customer.CustomerNo;
            this.ProspectID = this.Customer.ProspectID;

            base.Save();
            base.SavePolQuote(UserID);	// Validate and Save Policy

            SavePoliciesPoliciesEQuotes(UserID);  // Save Policies
            this.PolicyDetailcs.SavePolicyDetail(UserID, this.TaskControlID);

            this._mode = (int)TaskControlMode.UPDATE;
            this.Mode = (int)TaskControlMode.CLEAR;
            //FillProperties(this);
        }

		public override void Validate()
		{
			string errorMessage = String.Empty;

            if (this.PolicyClassID != 9 && this.PolicyClassID != 1 && this.PolicyClassID != 13)//No aplica para Auto Gap,Etch y para VSC.
			{
				if (this.PolicyNo == "")
					errorMessage = "Policy No. is missing or wrong.";
			}
            else
                if (this.PolicyClassID == 9)//Aplica para PRMedical.
                {
                    if (this.Term.ToString().Trim() == "0" || this.Term.ToString().Trim() == "")
                        errorMessage = "Term is missing or wrong.";
                    else
                        if (this.PolicyNo == "" && this.AutoAssignPolicy == false)
                            errorMessage = "Policy No./Contract No. is missing or wrong.";
                }

            if (errorMessage.Trim() == "")
            {
                if (this.EffectiveDate == "")
                    errorMessage = "Effective Date is missing or wrong.";
                else
                    if (this.PolicyClassID == 0)
                        errorMessage = "Line of Business is missing or wrong.";
                    else
                        if (this.Customer.FirstName == "")
                            errorMessage = "First Name is missing or wrong.";
                        else
                            if (this.Customer.LastName1 == "")
                                errorMessage = "Last Name is missing or wrong.";
                            else
                                if (this.OriginatedAt == 0)
                                    errorMessage = "Originated is missing.";
                                else
                                    if (this.TotalPremium == 0 && this.PolicyType.Trim() != "PPT" && this.PolicyType.Trim() != "PET")
                                        errorMessage = "TotalPremium must be greater than 0.";
            }  
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}
		}

        public string CheckVINByPolicyClass(string VIN, int PolicyClassID)
        {
            DataTable dt = Policy.GetVINByPolicyClass(VIN, PolicyClassID);

            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return "This VIN number is already exist in our database. Policy Number - " + dt.Rows[0]["PolicyNo"].ToString().Trim();
            }           
        }

        public bool CheckPolicyNo(string policyType,string policyNo, string certificate, string sufijo)
        {
            DataTable dt = Policy.GetPolicyByPolicyNo(policyType, policyNo, certificate, sufijo);

            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

		public static Policies GetPolicies(int TaskControlID)
		{
			Policies policies = null;

			DataTable dt = GetPoliciesByTaskControlID(TaskControlID);

			policies = new Policies();
			policies = (Policies) Policy.GetPolicyByTaskControlID(TaskControlID,policies);  //Policy
			policies._dtPolices = dt;

			policies = FillProperties(policies);

			return policies;
		}

        public static Policies GetPoliciesEQuotes(int TaskControlID)
        {
            Policies policies = null;

            DataTable dt = GetPoliciesEQuotesByTaskControlID(TaskControlID);

            policies = new Policies();
            policies = (Policies)Policy.GetPolicyQuoteByTaskControlID(TaskControlID, policies);  //Policy
            policies._dtPolices = dt;

            policies = FillProperties(policies);

            return policies;
        }

		public static void DeletePoliciesByTaskControlID(int taskControlID)
		{
			DBRequest Executor = new DBRequest();

			try
			{
				Executor.BeginTrans();
				Executor.Update("DeletePolicies",DeletePoliciesByTaskControlIDXml(taskControlID));
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error, Please try again. "+xcp.Message,xcp);
			}
		}

        public static DataTable GetEtchRateByetchRateID(int EtchRateID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("EtchRateID",
            SqlDbType.Int, 0, EtchRateID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                dt = exec.GetQuery("GetEtchRateByetchRateID", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetVSCSunGuardInterfase(int policyClassID, string BegDate, string EndDate)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("BegDate",
            SqlDbType.VarChar, 10, BegDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
            SqlDbType.VarChar, 10, EndDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClassID",
            SqlDbType.Int, 0, policyClassID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                dt = exec.GetQuery("GetVSCSunGuardInterface", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetVSCProductionHeader(int policyClassID, string BegDate, string EndDate, bool IsNewPolicies)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("BegDate",
            SqlDbType.VarChar, 10, BegDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
            SqlDbType.VarChar, 10, EndDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClassID",
            SqlDbType.Int, 0, policyClassID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                if (IsNewPolicies)
                {
                    dt = exec.GetQuery("GetVSCProductionPoliciesHeader", xmlDoc);
                }
                else
                {
                    dt = exec.GetQuery("GetVSCProductionCancHeader", xmlDoc);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }			
        }

        public static DataTable GetVSCProductionDetail(int policyClassID, string BegDate, string EndDate, bool IsNewPolicies)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("BegDate",
            SqlDbType.VarChar, 10, BegDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
            SqlDbType.VarChar, 10, EndDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClassID",
            SqlDbType.Int, 0, policyClassID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                if (IsNewPolicies)
                {
                    dt = exec.GetQuery("GetVSCProductionPoliciesDetail", xmlDoc);
                }
                else
                {
                    dt = exec.GetQuery("GetVSCProductionCancDetail", xmlDoc);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetVSCProductionUpdate(int policyClassID, string BegDate, string EndDate, bool IsNewPolicies)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                    new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("BegDate",
            SqlDbType.VarChar, 10, BegDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndDate",
            SqlDbType.VarChar, 10, EndDate.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyClassID",
            SqlDbType.Int, 0, policyClassID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
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
                dt = exec.GetQuery("GetVSCProductionPoliciesUpdate", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }
		#endregion

		#region Private Methods

		public static DataTable GetCoversByPolicyClassID(int policyClassID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("PolicyClassID",
				SqlDbType.Int, 0, policyClassID.ToString(),
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
	
			DataTable dt = exec.GetQuery("GetCoversByPolicyClassID",xmlDoc);
			
			return dt;	
		}
        public static DataTable GetAgentLicDate(string AgentID) ///alexis
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("Agent",
            SqlDbType.VarChar, 20, AgentID.ToString(),
            ref cookItems);

            
            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetAgentLicenseDate", xmlDoc);

            return dt;
        }
        public static DataTable GetAgentByAgency(string AgencyID) ///alexis
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("AgencyID",
            SqlDbType.VarChar, 4, AgencyID.ToString(),
            ref cookItems);


            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetAgentByAgency", xmlDoc);

            return dt;
        }

        public static DataTable GetAgent() ///alexis
        {
            

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetAgent", xmlDoc);

            return dt;
        }

		public static DataTable GetLimitByCoversID(int coversID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("CoversID",
				SqlDbType.Int, 0, coversID.ToString(),
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
	
			DataTable dt = exec.GetQuery("GetLimitByCoversID",xmlDoc);
			
			return dt;	
		}

        public static DataTable GetPRMEDICRATEPRIMARYByClassAndLimitID(string classs, int limitID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("class",
                SqlDbType.VarChar, 5, classs.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("prmedicallimitid",
                SqlDbType.Int, 0, limitID.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetPRMEDICRATEPRIMARYByClassAndLimitID", xmlDoc);

            return dt;
        }

        public static DataTable GetPRMEDICRATEByClassAndLimitID(string classs, int limitID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("class",
                SqlDbType.VarChar, 5, classs.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("prmedicallimitid",
                SqlDbType.Int, 0, limitID.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetPRMEDICRATEByClassAndLimitID", xmlDoc);

            return dt;
        }

		public void CalculatePremium()
		{
//			Quotes.MBIQuote MbiQuotes = new Quotes.MBIQuote();
//			MbiQuotes.Calculate(this.PolicyType.Trim(),this.Model.Trim(),this.Make.Trim(),this.Term);
//
//			if(this.InsuranceCompany == "097")
//			{
//				this.TotalPremium = 175.00;
//			}
//			else
//			{
//				this.TotalPremium = MbiQuotes.premium;
//			}
//
//			this.VehicleClass = MbiQuotes.classification;
//			this.Mileage      = MbiQuotes.plan;		
		}


		private static DataTable GetPoliciesByTaskControlID(int TaskControlID)
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
			
			DataTable dt = exec.GetQuery("GetPoliciesByTaskControlID",xmlDoc);
			return dt;
		}

        private DataTable PolicyCanRenew(int _TaskControlID)
        {

            XmlDocument xml = null;
            DataTable dt = null;
            try
            {
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, _TaskControlID.ToString(), ref cooker);

                xml = DbRequestXmlCooker.Cook(cooker);

                DBRequest executor = new DBRequest();
                dt = executor.GetQuery("GetPolicyRenewalCheck", xml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        private static DataTable GetPoliciesEQuotesByTaskControlID(int TaskControlID)
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
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetPoliciesEQuotesByTaskControlID", xmlDoc);
            return dt;
        }

		private void SavePoliciesPolicies(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();
				switch (this.Mode)
				{
					case 1:  //ADD
						this.PoliciesID = Executor.Insert("AddPolicies",this.GetInsertPoliciesXml());
						this.History(this._mode,UserID);
						break;

					case 3:  //DELETE
						//Executor.Update("DeleteAutoGuardServicesContract",this.GetDeletePoliciesXml());
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						this.History(this._mode,UserID);
						Executor.Update("UpdatePolicies",this.GetUpdatePoliciesXml());
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

        private void SavePoliciesPoliciesEQuotes(int UserID)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();
                switch (this.Mode)
                {
                    case 1:  //ADD
                        this.PoliciesID = Executor.Insert("AddPoliciesEQuotes", this.GetInsertPoliciesXml());
                        this.History(this._mode, UserID);
                        break;

                    case 3:  //DELETE
                        //Executor.Update("DeleteAutoGuardServicesContract",this.GetDeletePoliciesXml());
                        break;

                    case 4:  //CLEAR						
                        break;

                    default: //UPDATE
                        this.History(this._mode, UserID);
                        Executor.Update("UpdatePoliciesEQuotes", this.GetUpdatePoliciesXml());
                        break;
                }
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save the Policy Endorsement. " + xcp.Message, xcp);
            }
        }

		private static XmlDocument DeletePoliciesByTaskControlIDXml(int taskControlID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, taskControlID.ToString(),
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

		private XmlDocument GetUpdatePoliciesXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[106];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Milleages",
				SqlDbType.Int, 0, this.Milleages.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Cost",
				SqlDbType.Float, 0, this.Cost.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FinanceAmt",
				SqlDbType.Float, 0, this.FinanceAmt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Balance",
				SqlDbType.Float, 0, this.Balance.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleClass",
				SqlDbType.VarChar, 20, this.VehicleClass.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
				SqlDbType.Int, 0, this.VehicleMakeID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleModelID",
				SqlDbType.Int, 0, this.VehicleModelID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleYearID",
				SqlDbType.Int, 0, this.VehicleYearID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VIN",
				SqlDbType.Char, 17, this.VIN.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Plate",
				SqlDbType.VarChar, 7, this.Plate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PurchaseDate",
				SqlDbType.DateTime, 0, this.PurchaseDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("NewUse",
				SqlDbType.Int, 0, this.NewUse.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 200, this.Comments.ToString(),
				ref cookItems);
	
			DbRequestXmlCooker.AttachCookItem("PrestamoArrenda",
				SqlDbType.Bit, 0, this.PrestamoArrenda.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("InsuranceCompanyPrimaria",
				SqlDbType.Char, 3, this.InsuranceCompanyPrimaria.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("NumeroPolizaPrimaria",
				SqlDbType.Char, 11, this.NumeroPolizaPrimaria.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CoveragePlan",
				SqlDbType.Int, 0, this.CoveragePlan.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Miles",
				SqlDbType.Int, 0, this.Miles.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Diesel",
				SqlDbType.Bit, 0, this.Diesel.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("WD4",
				SqlDbType.Bit, 0, this.WD4.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Turbo",
				SqlDbType.Bit, 0, this.Turbo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CommercialUse",
				SqlDbType.Bit, 0, this.CommercialUse.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleCode",
				SqlDbType.VarChar, 20, this.VehicleCode.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffDateCompany",
                SqlDbType.DateTime, 0, this.EffDateCompany.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LossFund",
                SqlDbType.Float, 0, this.LossFund.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OverHead",
                SqlDbType.Float, 0, this.OverHead.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("BankFee",
                SqlDbType.Float, 0, this.BankFee.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Profit",
                SqlDbType.Float, 0, this.Profit.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Concurso",
                SqlDbType.Float, 0, this.Concurso.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("DealerCost",
                SqlDbType.Float, 0, this.DealerCost.ToString(),
                ref cookItems);
   
             DbRequestXmlCooker.AttachCookItem("DealerProfit",
                SqlDbType.Float, 0, this.DealerProfit.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("CanReserve",
                SqlDbType.Float, 0, this.CanReserve.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("DealerNet",
                SqlDbType.Float, 0, this.DealerNet.ToString(),
                ref cookItems);
            
             DbRequestXmlCooker.AttachCookItem("VehicleServiceContractQuoteID",
                SqlDbType.Int, 0, this.VehicleServiceContractQuoteID.ToString(),
                ref cookItems);

             DbRequestXmlCooker.AttachCookItem("PRMedicRATEID",
                 SqlDbType.Int, 0, this.@PRMedicRATEID.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("PRMedicalLimit",
                 SqlDbType.Int, 0, this.PRMedicalLimit.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("IsoCode",
                 SqlDbType.Int, 0, this.IsoCode.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("Class",
                 SqlDbType.VarChar, 5, this.Class.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("RateYear1",
                 SqlDbType.Float, 0, this.RateYear1.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("RateYear2",
                 SqlDbType.Float, 0, this.RateYear2.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("RateYear3",
             SqlDbType.Float, 0, this.RateYear3.ToString(),
             ref cookItems);

             DbRequestXmlCooker.AttachCookItem("MCMRate",
             SqlDbType.Float, 0, this.MCMRate.ToString(),
             ref cookItems);

             DbRequestXmlCooker.AttachCookItem("ApplicationID",
                 SqlDbType.Int, 0, this.ApplicationID.ToString(),
                 ref cookItems);

             DbRequestXmlCooker.AttachCookItem("PrimaryTN1", SqlDbType.Float, 0, this.PrimaryTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PrimaryTN2", SqlDbType.Float, 0, this.PrimaryTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PrimaryTN3", SqlDbType.Float, 0, this.PrimaryTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PrimaryTN4", SqlDbType.Float, 0, this.PrimaryTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PrimaryTN5", SqlDbType.Float, 0, this.PrimaryTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("RateTN1", SqlDbType.Float, 0, this.RateTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("RateTN2", SqlDbType.Float, 0, this.RateTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("RateTN3", SqlDbType.Float, 0, this.RateTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("RateTN4", SqlDbType.Float, 0, this.RateTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("RateTN5", SqlDbType.Float, 0, this.RateTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("RateTN6", SqlDbType.Float, 0, this.RateTN6.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PremiumTN1", SqlDbType.Float, 0, this.PremiumTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PremiumTN2", SqlDbType.Float, 0, this.PremiumTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PremiumTN3", SqlDbType.Float, 0, this.PremiumTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PremiumTN4", SqlDbType.Float, 0, this.PremiumTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PremiumTN5", SqlDbType.Float, 0, this.PremiumTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("QuantityTN1", SqlDbType.Float, 0, this.QuantityTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("QuantityTN2", SqlDbType.Float, 0, this.QuantityTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("QuantityTN3", SqlDbType.Float, 0, this.QuantityTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("QuantityTN4", SqlDbType.Float, 0, this.QuantityTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("QuantityTN5", SqlDbType.Float, 0, this.QuantityTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("QuantityTN6", SqlDbType.Float, 0, this.QuantityTN6.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotPremTN1", SqlDbType.Float, 0, this.TotPremTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotPremTN2", SqlDbType.Float, 0, this.TotPremTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotPremTN3", SqlDbType.Float, 0, this.TotPremTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotPremTN4", SqlDbType.Float, 0, this.TotPremTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotPremTN5", SqlDbType.Float, 0, this.TotPremTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotPremTN6", SqlDbType.Float, 0, this.TotPremTN6.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ExcessTN1", SqlDbType.Float, 0, this.ExcessTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ExcessTN2", SqlDbType.Float, 0, this.ExcessTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ExcessTN3", SqlDbType.Float, 0, this.ExcessTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ExcessTN4", SqlDbType.Float, 0, this.ExcessTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ExcessTN5", SqlDbType.Float, 0, this.ExcessTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ERateTN1", SqlDbType.Float, 0, this.ERateTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ERateTN2", SqlDbType.Float, 0, this.ERateTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ERateTN3", SqlDbType.Float, 0, this.ERateTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ERateTN4", SqlDbType.Float, 0, this.ERateTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ERateTN5", SqlDbType.Float, 0, this.ERateTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ERateTN6", SqlDbType.Float, 0, this.ERateTN6.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EPremiumTN1", SqlDbType.Float, 0, this.EPremiumTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EPremiumTN2", SqlDbType.Float, 0, this.EPremiumTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EPremiumTN3", SqlDbType.Float, 0, this.EPremiumTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EPremiumTN4", SqlDbType.Float, 0, this.EPremiumTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EPremiumTN5", SqlDbType.Float, 0, this.EPremiumTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EQuantityTN1", SqlDbType.Float, 0, this.EQuantityTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EQuantityTN2", SqlDbType.Float, 0, this.EQuantityTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EQuantityTN3", SqlDbType.Float, 0, this.EQuantityTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EQuantityTN4", SqlDbType.Float, 0, this.EQuantityTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EQuantityTN5", SqlDbType.Float, 0, this.EQuantityTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("EQuantityTN6", SqlDbType.Float, 0, this.EQuantityTN6.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ETotPremTN1", SqlDbType.Float, 0, this.ETotPremTN1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ETotPremTN2", SqlDbType.Float, 0, this.ETotPremTN2.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ETotPremTN3", SqlDbType.Float, 0, this.ETotPremTN3.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ETotPremTN4", SqlDbType.Float, 0, this.ETotPremTN4.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ETotPremTN5", SqlDbType.Float, 0, this.ETotPremTN5.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("ETotPremTN6", SqlDbType.Float, 0, this.ETotPremTN6.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotalPrimary", SqlDbType.Float, 0, this.TotalPrimary.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("TotalExcess", SqlDbType.Float, 0, this.TotalExcess.ToString(), ref cookItems);

             DbRequestXmlCooker.AttachCookItem("PriCarierName1", SqlDbType.VarChar, 75, this.PriCarierName1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PriPolEffecDate1", SqlDbType.VarChar, 8, this.PriPolEffecDate1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PriPolLimits1", SqlDbType.VarChar, 50, this.PriPolLimits1.ToString(), ref cookItems);
             DbRequestXmlCooker.AttachCookItem("PriClaims1", SqlDbType.VarChar, 50, this.PriClaims1.ToString(), ref cookItems);


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


		private XmlDocument GetInsertPoliciesXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[106];

			DbRequestXmlCooker.AttachCookItem("TaskControlID",
				SqlDbType.Int, 0, this.TaskControlID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Milleages",
				SqlDbType.Int, 0, this.Milleages.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Cost",
				SqlDbType.Float, 0, this.Cost.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FinanceAmt",
				SqlDbType.Float, 0, this.FinanceAmt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Balance",
				SqlDbType.Float, 0, this.Balance.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleClass",
				SqlDbType.VarChar, 20, this.VehicleClass.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
				SqlDbType.Int, 0, this.VehicleMakeID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleModelID",
				SqlDbType.Int, 0, this.VehicleModelID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleYearID",
				SqlDbType.Int, 0, this.VehicleYearID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VIN",
				SqlDbType.Char, 17, this.VIN.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Plate",
				SqlDbType.VarChar, 7, this.Plate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PurchaseDate",
				SqlDbType.DateTime, 0, this.PurchaseDate.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("NewUse",
				SqlDbType.Int, 0, this.NewUse.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 200, this.Comments.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("PrestamoArrenda",
				SqlDbType.Bit, 0, this.PrestamoArrenda.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("InsuranceCompanyPrimaria",
				SqlDbType.Char, 3, this.InsuranceCompanyPrimaria.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("NumeroPolizaPrimaria",
				SqlDbType.Char, 11, this.NumeroPolizaPrimaria.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CoveragePlan",
				SqlDbType.Int, 0, this.CoveragePlan.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Miles",
				SqlDbType.Int, 0, this.Miles.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Diesel",
				SqlDbType.Bit, 0, this.Diesel.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("WD4",
				SqlDbType.Bit, 0, this.WD4.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Turbo",
				SqlDbType.Bit, 0, this.Turbo.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("CommercialUse",
				SqlDbType.Bit, 0, this.CommercialUse.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("VehicleCode",
				SqlDbType.VarChar, 20, this.VehicleCode.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffDateCompany",
               SqlDbType.DateTime, 0, this.EffDateCompany.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LossFund",
                SqlDbType.Float, 0, this.LossFund.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OverHead",
                SqlDbType.Float, 0, this.OverHead.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BankFee",
               SqlDbType.Float, 0, this.BankFee.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Profit",
               SqlDbType.Float, 0, this.Profit.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Concurso",
               SqlDbType.Float, 0, this.Concurso.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerCost",
               SqlDbType.Float, 0, this.DealerCost.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerProfit",
               SqlDbType.Float, 0, this.DealerProfit.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CanReserve",
               SqlDbType.Float, 0, this.CanReserve.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DealerNet",
               SqlDbType.Float, 0, this.DealerNet.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleServiceContractQuoteID",
               SqlDbType.Int, 0, this.VehicleServiceContractQuoteID.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PRMedicRATEID",
                SqlDbType.Int, 0, this.@PRMedicRATEID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PRMedicalLimit",
                SqlDbType.Int, 0, this.PRMedicalLimit.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("IsoCode",
                SqlDbType.Int, 0, this.IsoCode.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Class",
                SqlDbType.VarChar, 5, this.Class.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("RateYear1",
                SqlDbType.Float, 0, this.RateYear1.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("RateYear2",
                SqlDbType.Float, 0, this.RateYear2.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("RateYear3",
                SqlDbType.Float, 0, this.RateYear3.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MCMRate",
                SqlDbType.Float, 0, this.MCMRate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ApplicationID",
                SqlDbType.Int, 0, this.ApplicationID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PrimaryTN1", SqlDbType.Float, 0, this.PrimaryTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN2", SqlDbType.Float, 0, this.PrimaryTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN3", SqlDbType.Float, 0, this.PrimaryTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN4", SqlDbType.Float, 0, this.PrimaryTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryTN5", SqlDbType.Float, 0, this.PrimaryTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN1", SqlDbType.Float, 0, this.RateTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN2", SqlDbType.Float, 0, this.RateTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN3", SqlDbType.Float, 0, this.RateTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN4", SqlDbType.Float, 0, this.RateTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN5", SqlDbType.Float, 0, this.RateTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateTN6", SqlDbType.Float, 0, this.RateTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN1", SqlDbType.Float, 0, this.PremiumTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN2", SqlDbType.Float, 0, this.PremiumTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN3", SqlDbType.Float, 0, this.PremiumTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN4", SqlDbType.Float, 0, this.PremiumTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PremiumTN5", SqlDbType.Float, 0, this.PremiumTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN1", SqlDbType.Float, 0, this.QuantityTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN2", SqlDbType.Float, 0, this.QuantityTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN3", SqlDbType.Float, 0, this.QuantityTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN4", SqlDbType.Float, 0, this.QuantityTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN5", SqlDbType.Float, 0, this.QuantityTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("QuantityTN6", SqlDbType.Float, 0, this.QuantityTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN1", SqlDbType.Float, 0, this.TotPremTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN2", SqlDbType.Float, 0, this.TotPremTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN3", SqlDbType.Float, 0, this.TotPremTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN4", SqlDbType.Float, 0, this.TotPremTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN5", SqlDbType.Float, 0, this.TotPremTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotPremTN6", SqlDbType.Float, 0, this.TotPremTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN1", SqlDbType.Float, 0, this.ExcessTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN2", SqlDbType.Float, 0, this.ExcessTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN3", SqlDbType.Float, 0, this.ExcessTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN4", SqlDbType.Float, 0, this.ExcessTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessTN5", SqlDbType.Float, 0, this.ExcessTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN1", SqlDbType.Float, 0, this.ERateTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN2", SqlDbType.Float, 0, this.ERateTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN3", SqlDbType.Float, 0, this.ERateTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN4", SqlDbType.Float, 0, this.ERateTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN5", SqlDbType.Float, 0, this.ERateTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ERateTN6", SqlDbType.Float, 0, this.ERateTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN1", SqlDbType.Float, 0, this.EPremiumTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN2", SqlDbType.Float, 0, this.EPremiumTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN3", SqlDbType.Float, 0, this.EPremiumTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN4", SqlDbType.Float, 0, this.EPremiumTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EPremiumTN5", SqlDbType.Float, 0, this.EPremiumTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN1", SqlDbType.Float, 0, this.EQuantityTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN2", SqlDbType.Float, 0, this.EQuantityTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN3", SqlDbType.Float, 0, this.EQuantityTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN4", SqlDbType.Float, 0, this.EQuantityTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN5", SqlDbType.Float, 0, this.EQuantityTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EQuantityTN6", SqlDbType.Float, 0, this.EQuantityTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN1", SqlDbType.Float, 0, this.ETotPremTN1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN2", SqlDbType.Float, 0, this.ETotPremTN2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN3", SqlDbType.Float, 0, this.ETotPremTN3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN4", SqlDbType.Float, 0, this.ETotPremTN4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN5", SqlDbType.Float, 0, this.ETotPremTN5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ETotPremTN6", SqlDbType.Float, 0, this.ETotPremTN6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalPrimary", SqlDbType.Float, 0, this.TotalPrimary.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TotalExcess", SqlDbType.Float, 0, this.TotalExcess.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PriCarierName1", SqlDbType.VarChar, 75, this.PriCarierName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolEffecDate1", SqlDbType.VarChar, 8, this.PriPolEffecDate1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolLimits1", SqlDbType.VarChar, 50, this.PriPolLimits1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriClaims1", SqlDbType.VarChar, 50, this.PriClaims1.ToString(), ref cookItems);

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

        private static Policies FillProperties(Policies policies)
        {
            policies.PoliciesID = (int)policies._dtPolices.Rows[0]["PoliciesID"];
            policies.Milleages = (int)policies._dtPolices.Rows[0]["Milleages"];
            policies.Cost = (double)policies._dtPolices.Rows[0]["Cost"];
            policies.FinanceAmt = (double)policies._dtPolices.Rows[0]["FinanceAmt"];
            policies.Balance = (double)policies._dtPolices.Rows[0]["Balance"];
            policies.VehicleMakeID = (int)policies._dtPolices.Rows[0]["VehicleMakeID"];
            policies.VehicleModelID = (int)policies._dtPolices.Rows[0]["VehicleModelID"];
            policies.VehicleYearID = (int)policies._dtPolices.Rows[0]["VehicleYearID"];
            policies.VIN = policies._dtPolices.Rows[0]["VIN"].ToString();
            policies.VehicleClass = policies._dtPolices.Rows[0]["VehicleClass"].ToString();
            policies.Plate = policies._dtPolices.Rows[0]["Plate"].ToString();
            policies.PurchaseDate = (policies._dtPolices.Rows[0]["PurchaseDate"] != System.DBNull.Value) ? ((DateTime)policies._dtPolices.Rows[0]["PurchaseDate"]).ToShortDateString() : "";
            policies.NewUse = (int)policies._dtPolices.Rows[0]["NewUse"];
            policies.Comments = policies._dtPolices.Rows[0]["Comments"].ToString();
            policies.PrestamoArrenda = (bool)policies._dtPolices.Rows[0]["PrestamoArrenda"];
            policies.InsuranceCompanyPrimaria = policies._dtPolices.Rows[0]["InsuranceCompanyPrimaria"].ToString();
            policies.NumeroPolizaPrimaria = policies._dtPolices.Rows[0]["NumeroPolizaPrimaria"].ToString();
            policies.CoveragePlan = (int)policies._dtPolices.Rows[0]["CoveragePlan"];
            policies.Miles = (int)policies._dtPolices.Rows[0]["Miles"];
            policies.Diesel = (bool)policies._dtPolices.Rows[0]["Diesel"];
            policies.WD4 = (bool)policies._dtPolices.Rows[0]["WD4"];
            policies.Turbo = (bool)policies._dtPolices.Rows[0]["Turbo"];
            policies.CommercialUse = (bool)policies._dtPolices.Rows[0]["CommercialUse"];
            policies.VehicleCode = policies._dtPolices.Rows[0]["VehicleCode"].ToString();
            policies.EffDateCompany = (policies._dtPolices.Rows[0]["EffDateCompany"] != System.DBNull.Value) ? ((DateTime)policies._dtPolices.Rows[0]["EffDateCompany"]).ToShortDateString() : "";
            policies.LossFund = (double)policies._dtPolices.Rows[0]["LossFund"];
            policies.OverHead = (double)policies._dtPolices.Rows[0]["OverHead"];
            policies.BankFee = (double)policies._dtPolices.Rows[0]["BankFee"];
            policies.Profit = (double)policies._dtPolices.Rows[0]["Profit"];
            policies.Concurso = (double)policies._dtPolices.Rows[0]["Concurso"];
            policies.DealerCost = (double)policies._dtPolices.Rows[0]["DealerCost"];
            policies.DealerProfit = (double)policies._dtPolices.Rows[0]["DealerProfit"];
            policies.CanReserve = (double)policies._dtPolices.Rows[0]["CanReserve"];
            policies.DealerNet = (double)policies._dtPolices.Rows[0]["DealerNet"];
            policies.VehicleServiceContractQuoteID = (int)policies._dtPolices.Rows[0]["VehicleServiceContractQuoteID"];
            policies.PRMedicRATEID = (int)policies._dtPolices.Rows[0]["PRMedicRATEID"];
            policies.PRMedicalLimit = (int)policies._dtPolices.Rows[0]["PRMedicalLimit"];
            policies.IsoCode = policies._dtPolices.Rows[0]["IsoCode"].ToString();
            policies.Class = policies._dtPolices.Rows[0]["Class"].ToString();
            policies.RateYear1 = (double)policies._dtPolices.Rows[0]["RateYear1"];
            policies.RateYear2 = (double)policies._dtPolices.Rows[0]["RateYear2"];
            policies.RateYear3 = (double)policies._dtPolices.Rows[0]["RateYear3"];
            policies.MCMRate = (double)policies._dtPolices.Rows[0]["MCMRate"];
            policies.ApplicationID = (int)policies._dtPolices.Rows[0]["ApplicationID"];

            policies.PrimaryTN1 = (double)policies._dtPolices.Rows[0]["PrimaryTN1"];
            policies.PrimaryTN2 = (double)policies._dtPolices.Rows[0]["PrimaryTN2"];
            policies.PrimaryTN3 = (double)policies._dtPolices.Rows[0]["PrimaryTN3"];
            policies.PrimaryTN4 = (double)policies._dtPolices.Rows[0]["PrimaryTN4"];
            policies.PrimaryTN5 = (double)policies._dtPolices.Rows[0]["PrimaryTN5"];
            policies.RateTN1 = (double)policies._dtPolices.Rows[0]["RateTN1"];
            policies.RateTN2 = (double)policies._dtPolices.Rows[0]["RateTN2"];
            policies.RateTN3 = (double)policies._dtPolices.Rows[0]["RateTN3"];
            policies.RateTN4 = (double)policies._dtPolices.Rows[0]["RateTN4"];
            policies.RateTN5 = (double)policies._dtPolices.Rows[0]["RateTN5"];
            policies.RateTN6 = (double)policies._dtPolices.Rows[0]["RateTN6"];
            policies.PremiumTN1 = (double)policies._dtPolices.Rows[0]["PremiumTN1"];
            policies.PremiumTN2 = (double)policies._dtPolices.Rows[0]["PremiumTN2"];
            policies.PremiumTN3 = (double)policies._dtPolices.Rows[0]["PremiumTN3"];
            policies.PremiumTN4 = (double)policies._dtPolices.Rows[0]["PremiumTN4"];
            policies.PremiumTN5 = (double)policies._dtPolices.Rows[0]["PremiumTN5"];
            policies.QuantityTN1 = (int)policies._dtPolices.Rows[0]["QuantityTN1"];
            policies.QuantityTN2 = (int)policies._dtPolices.Rows[0]["QuantityTN2"];
            policies.QuantityTN3 = (int)policies._dtPolices.Rows[0]["QuantityTN3"];
            policies.QuantityTN4 = (int)policies._dtPolices.Rows[0]["QuantityTN4"];
            policies.QuantityTN5 = (int)policies._dtPolices.Rows[0]["QuantityTN5"];
            policies.QuantityTN6 = (int)policies._dtPolices.Rows[0]["QuantityTN6"];
            policies.TotPremTN1 = (double)policies._dtPolices.Rows[0]["TotPremTN1"];
            policies.TotPremTN2 = (double)policies._dtPolices.Rows[0]["TotPremTN2"];
            policies.TotPremTN3 = (double)policies._dtPolices.Rows[0]["TotPremTN3"];
            policies.TotPremTN4 = (double)policies._dtPolices.Rows[0]["TotPremTN4"];
            policies.TotPremTN5 = (double)policies._dtPolices.Rows[0]["TotPremTN5"];
            policies.TotPremTN6 = (double)policies._dtPolices.Rows[0]["TotPremTN6"];
            policies.ExcessTN1 = (double)policies._dtPolices.Rows[0]["ExcessTN1"];
            policies.ExcessTN2 = (double)policies._dtPolices.Rows[0]["ExcessTN2"];
            policies.ExcessTN3 = (double)policies._dtPolices.Rows[0]["ExcessTN3"];
            policies.ExcessTN4 = (double)policies._dtPolices.Rows[0]["ExcessTN4"];
            policies.ExcessTN5 = (double)policies._dtPolices.Rows[0]["ExcessTN5"];
            policies.ERateTN1 = (double)policies._dtPolices.Rows[0]["ERateTN1"];
            policies.ERateTN2 = (double)policies._dtPolices.Rows[0]["ERateTN2"];
            policies.ERateTN3 = (double)policies._dtPolices.Rows[0]["ERateTN3"];
            policies.ERateTN4 = (double)policies._dtPolices.Rows[0]["ERateTN4"];
            policies.ERateTN5 = (double)policies._dtPolices.Rows[0]["ERateTN5"];
            policies.ERateTN6 = (double)policies._dtPolices.Rows[0]["ERateTN6"];
            policies.EPremiumTN1 = (double)policies._dtPolices.Rows[0]["EPremiumTN1"];
            policies.EPremiumTN2 = (double)policies._dtPolices.Rows[0]["EPremiumTN2"];
            policies.EPremiumTN3 = (double)policies._dtPolices.Rows[0]["EPremiumTN3"];
            policies.EPremiumTN4 = (double)policies._dtPolices.Rows[0]["EPremiumTN4"];
            policies.EPremiumTN5 = (double)policies._dtPolices.Rows[0]["EPremiumTN5"];
            policies.EQuantityTN1 = (int)policies._dtPolices.Rows[0]["EQuantityTN1"];
            policies.EQuantityTN2 = (int)policies._dtPolices.Rows[0]["EQuantityTN2"];
            policies.EQuantityTN3 = (int)policies._dtPolices.Rows[0]["EQuantityTN3"];
            policies.EQuantityTN4 = (int)policies._dtPolices.Rows[0]["EQuantityTN4"];
            policies.EQuantityTN5 = (int)policies._dtPolices.Rows[0]["EQuantityTN5"];
            policies.EQuantityTN6 = (int)policies._dtPolices.Rows[0]["EQuantityTN6"];
            policies.ETotPremTN1 = (double)policies._dtPolices.Rows[0]["ETotPremTN1"];
            policies.ETotPremTN2 = (double)policies._dtPolices.Rows[0]["ETotPremTN2"];
            policies.ETotPremTN3 = (double)policies._dtPolices.Rows[0]["ETotPremTN3"];
            policies.ETotPremTN4 = (double)policies._dtPolices.Rows[0]["ETotPremTN4"];
            policies.ETotPremTN5 = (double)policies._dtPolices.Rows[0]["ETotPremTN5"];
            policies.ETotPremTN6 = (double)policies._dtPolices.Rows[0]["ETotPremTN6"];
            policies.TotalPrimary = (double)policies._dtPolices.Rows[0]["TotalPrimary"];
            policies.TotalExcess = (double)policies._dtPolices.Rows[0]["TotalExcess"];

            policies.PriCarierName1 = policies._dtPolices.Rows[0]["PriCarierName1"].ToString();
            policies.PriPolEffecDate1 = (policies._dtPolices.Rows[0]["PriPolEffecDate1"] != System.DBNull.Value) ? ((DateTime)policies._dtPolices.Rows[0]["PriPolEffecDate1"]).ToShortDateString() : "";
            policies.PriPolLimits1 = policies._dtPolices.Rows[0]["PriPolLimits1"].ToString();
            policies.PriClaims1 = policies._dtPolices.Rows[0]["PriClaims1"].ToString();

            return policies;
        }

		#endregion

		#region History

		private void History(int mode, int userID)
		{ 
			Audit.History history = new Audit.History();
            LookupTables.Agent agent = new LookupTables.Agent();
            LookupTables.Agent agentOld = new LookupTables.Agent();
            LookupTables.Agency agency = new LookupTables.Agency();
            LookupTables.Agency agencyOld = new LookupTables.Agency();

            
			
			if(_mode == 2)
			{				
				// Campos de TaskControl
				history.BuildNotesForHistory("TaskControlTypeID",
					LookupTables.LookupTables.GetDescription("TaskControlType",oldPolices.TaskControlTypeID.ToString()),
					LookupTables.LookupTables.GetDescription("TaskControlType",this.TaskControlTypeID.ToString()),
					mode);
				history.BuildNotesForHistory("TaskStatusID",
					LookupTables.LookupTables.GetDescription("TaskStatus",oldPolices.TaskStatusID.ToString()),
					LookupTables.LookupTables.GetDescription("TaskStatus",this.TaskStatusID.ToString()),
					mode);	
				history.BuildNotesForHistory("ProspectID",oldPolices.ProspectID.ToString(),this.ProspectID.ToString(),mode);							
				history.BuildNotesForHistory("CustomerNo",oldPolices.CustomerNo,this.CustomerNo,mode);
				history.BuildNotesForHistory("PolicyID",oldPolices.PolicyID.ToString(),this.PolicyID.ToString(),mode);							
				history.BuildNotesForHistory("PolicyClassID",
					LookupTables.LookupTables.GetDescription("PolicyClass",oldPolices.PolicyClassID.ToString()),
					LookupTables.LookupTables.GetDescription("PolicyClass",this.PolicyClassID.ToString()),
					mode);	

                agencyOld.GetAgency(oldPolices.Agency.ToString());
                agency.GetAgency(this.Agency.ToString());
				history.BuildNotesForHistory("Agency",agencyOld.AgencyDesc,agency.AgencyDesc,mode);

                agentOld.GetAgent(oldPolices.Agent.ToString());
                agent.GetAgent(this.Agent.ToString());

				history.BuildNotesForHistory("Agent",agentOld.AgentDesc,agent.AgentDesc,mode);
				history.BuildNotesForHistory("SupplierID",oldPolices.SupplierID,this.SupplierID,mode);
				history.BuildNotesForHistory("Group",
                    LookupTables.LookupTables.GetDescription("MasterPolicy", oldPolices.Bank.ToString()),
                    LookupTables.LookupTables.GetDescription("MasterPolicy", this.Bank.ToString()),
					mode);	
				history.BuildNotesForHistory("InsuranceCompany",
					LookupTables.LookupTables.GetDescription("InsuranceCompany",oldPolices.InsuranceCompany.ToString()),
					LookupTables.LookupTables.GetDescription("InsuranceCompany",this.InsuranceCompany.ToString()),
					mode);
				history.BuildNotesForHistory("Dealer",oldPolices.Dealer,this.Dealer,mode);
				history.BuildNotesForHistory("CompanyDealer",
					LookupTables.LookupTables.GetDescription("CompanyDealer",oldPolices.CompanyDealer.ToString()),
					LookupTables.LookupTables.GetDescription("CompanyDealer",this.CompanyDealer.ToString()),
					mode);	
				history.BuildNotesForHistory("CloseDate",oldPolices.CloseDate,this.CloseDate,mode);
				history.BuildNotesForHistory("EnteredBy",oldPolices.EnteredBy,this.EnteredBy,mode);
				// Terminan Campos TaskControl
				
				// Campos de Policies
				history.BuildNotesForHistory("Cost",oldPolices.Cost.ToString(),this.Cost.ToString(),mode);
				history.BuildNotesForHistory("Finance Amt",oldPolices.FinanceAmt.ToString(),this.FinanceAmt.ToString(),mode);
				history.BuildNotesForHistory("Milleages",oldPolices.Milleages.ToString(),this.Milleages.ToString(),mode);
				history.BuildNotesForHistory("VehicleClass",oldPolices.VehicleClass,this.VehicleClass,mode);
				history.BuildNotesForHistory("_Vehicle Make",
					LookupTables.LookupTables.GetDescription("VehicleMake",oldPolices.VehicleMakeID.ToString()),
					LookupTables.LookupTables.GetDescription("VehicleMake",this.VehicleMakeID.ToString()),
					mode);	
				history.BuildNotesForHistory("Vehicle Model",
					LookupTables.LookupTables.GetDescription("VehicleModel",oldPolices.VehicleModelID.ToString()),
					LookupTables.LookupTables.GetDescription("VehicleModel",this.VehicleModelID.ToString()),
					mode);
				history.BuildNotesForHistory("Vehicle Year",
					LookupTables.LookupTables.GetDescription("VehicleYear",oldPolices.VehicleYearID.ToString()),
					LookupTables.LookupTables.GetDescription("VehicleYear",this.VehicleYearID.ToString()),
					mode);	
				history.BuildNotesForHistory("VIN",oldPolices.VIN.ToString(),this.VIN.ToString(),mode);
				history.BuildNotesForHistory("Plate",oldPolices.Plate.ToString(),this.Plate.ToString(),mode);
				history.BuildNotesForHistory("Purchaser Date",oldPolices.PurchaseDate.ToString(),this.PurchaseDate.ToString(),mode);
				history.BuildNotesForHistory("NewUse",
					LookupTables.LookupTables.GetDescription("NewUse",oldPolices.NewUse.ToString()),
					LookupTables.LookupTables.GetDescription("NewUse",this.NewUse.ToString()),
					mode);	
				history.BuildNotesForHistory("Comments",oldPolices.Comments,this.Comments,mode);
				history.BuildNotesForHistory("Contract Type",oldPolices.PrestamoArrenda.ToString(),this.PrestamoArrenda.ToString(),mode);
				history.BuildNotesForHistory("Primary Insurance Company",oldPolices.InsuranceCompanyPrimaria,this.InsuranceCompanyPrimaria,mode);
				history.BuildNotesForHistory("Policy No Primary",oldPolices.NumeroPolizaPrimaria,this.NumeroPolizaPrimaria,mode);
                history.BuildNotesForHistory("EffDateCompany", oldPolices.EffDateCompany.ToString(), this.EffDateCompany.ToString(), mode);
				// Terminan Campos Policies

				// Campos de Policy
				history.BuildNotesForHistory("DepartmentID",
					LookupTables.LookupTables.GetDescription("Department",oldPolices.DepartmentID.ToString()),
					LookupTables.LookupTables.GetDescription("Department",this.DepartmentID.ToString()),
					mode);
				history.BuildNotesForHistory("PolicyType",oldPolices.PolicyType,this.PolicyType,mode);
				history.BuildNotesForHistory("PolicyNo",oldPolices.PolicyNo,this.PolicyNo,mode);
				history.BuildNotesForHistory("Certificate",oldPolices.Certificate,this.Certificate,mode);
				history.BuildNotesForHistory("Suffix",oldPolices.Suffix,this.Suffix,mode);
				history.BuildNotesForHistory("LoanNo",oldPolices.LoanNo.ToString(),this.LoanNo.ToString(),mode);
				history.BuildNotesForHistory("Term",oldPolices.Term.ToString(),this.Term.ToString(),mode);
				history.BuildNotesForHistory("EffectiveDate",oldPolices.EffectiveDate.ToString(),this.EffectiveDate.ToString(),mode);
				history.BuildNotesForHistory("ExpirationDate",oldPolices.ExpirationDate.ToString(),this.ExpirationDate.ToString(),mode);
				history.BuildNotesForHistory("Charge",oldPolices.Charge.ToString(),this.Charge.ToString(),mode);
				history.BuildNotesForHistory("TotalPremium",oldPolices.TotalPremium.ToString(),this.TotalPremium.ToString(),mode);

                //////////////
                history.BuildNotesForHistory("GapBegDate1", oldPolices.GapBegDate.ToString(), this.GapBegDate.ToString(), mode);
                history.BuildNotesForHistory("GapBegDate2", oldPolices.GapBegDate2.ToString(), this.GapBegDate2.ToString(), mode);
                history.BuildNotesForHistory("GapBegDate3", oldPolices.GapBegDate3.ToString(), this.GapBegDate3.ToString(), mode);
                history.BuildNotesForHistory("GapEndDate1", oldPolices.GapEndDate.ToString(), this.GapEndDate.ToString(), mode);
                history.BuildNotesForHistory("GapEndDate2", oldPolices.GapEndDate2.ToString(), this.GapEndDate2.ToString(), mode);
                history.BuildNotesForHistory("GapEndDate3", oldPolices.GapEndDate3.ToString(), this.GapEndDate3.ToString(), mode);
                history.BuildNotesForHistory("Anniversariy", oldPolices.Anniversary.ToString(), this.Anniversary.ToString(), mode);
                history.BuildNotesForHistory("Employees No.", oldPolices.NumberOfEmployees.ToString(), this.NumberOfEmployees.ToString(), mode);
                history.BuildNotesForHistory("Update Form", oldPolices.UpdateForm.ToString(), this.UpdateForm.ToString(), mode);
                history.BuildNotesForHistory("Limit", oldPolices.PRMedicalLimit.ToString(), this.PRMedicalLimit.ToString(), mode);
                ///////////

				history.BuildNotesForHistory("Status",oldPolices.Status.ToString(),this.Status.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgency",oldPolices.CommissionAgency.ToString(),this.CommissionAgency.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgencyPercent",oldPolices.CommissionAgencyPercent.ToString(),this.CommissionAgencyPercent.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgent",oldPolices.CommissionAgent.ToString(),this.CommissionAgent.ToString(),mode);
				history.BuildNotesForHistory("CommissionAgentPercent",oldPolices.CommissionAgentPercent.ToString(),this.CommissionAgentPercent.ToString(),mode);
				history.BuildNotesForHistory("CommissionDate",oldPolices.CommissionDate.ToString(),this.CommissionDate.ToString(),mode);
				history.BuildNotesForHistory("CancellationDate",oldPolices.CancellationDate.ToString(),this.CancellationDate.ToString(),mode);
				history.BuildNotesForHistory("CancellationEntryDate",oldPolices.CancellationEntryDate.ToString(),this.CancellationEntryDate.ToString(),mode);
				history.BuildNotesForHistory("CancellationUnearnedPercent",oldPolices.CancellationUnearnedPercent.ToString(),this.CancellationUnearnedPercent.ToString(),mode);
				history.BuildNotesForHistory("ReturnPremium",oldPolices.ReturnPremium.ToString(),this.ReturnPremium.ToString(),mode);
				history.BuildNotesForHistory("ReturnCharge",oldPolices.ReturnCharge.ToString(),this.ReturnCharge.ToString(),mode);
				history.BuildNotesForHistory("CancellationAmount",oldPolices.CancellationAmount.ToString(),this.CancellationAmount.ToString(),mode);
				history.BuildNotesForHistory("CancellationMethod",oldPolices.CancellationMethod.ToString(),this.CancellationMethod.ToString(),mode);
				history.BuildNotesForHistory("CancellationReason",oldPolices.CancellationReason.ToString(),this.CancellationReason.ToString(),mode);
				history.BuildNotesForHistory("ReturnCommissionAgency",oldPolices.ReturnCommissionAgency.ToString(),this.ReturnCommissionAgency.ToString(),mode);
				history.BuildNotesForHistory("ReturnCommissionAgent",oldPolices.ReturnCommissionAgent.ToString(),this.ReturnCommissionAgent.ToString(),mode);
				history.BuildNotesForHistory("PaidAmount",oldPolices.PaidAmount.ToString(),this.PaidAmount.ToString(),mode);
				history.BuildNotesForHistory("PaidDate",oldPolices.PaidDate.ToString(),this.PaidDate.ToString(),mode);
				history.BuildNotesForHistory("AutoAssignPolicy",oldPolices.AutoAssignPolicy.ToString(),this.AutoAssignPolicy.ToString(),mode);
				history.BuildNotesForHistory("Group Disc.",oldPolices.InvoiceNumber.ToString(),this.InvoiceNumber.ToString(),mode);
				history.BuildNotesForHistory("FileNumber",oldPolices.FileNumber.ToString(),this.FileNumber.ToString(),mode);
				history.BuildNotesForHistory("IsLeasing",oldPolices.IsLeasing.ToString(),this.IsLeasing.ToString(),mode);
				history.BuildNotesForHistory("PaymentType",oldPolices.PaymentType.ToString(),this.PaymentType.ToString(),mode);
				history.BuildNotesForHistory("IsMaster",oldPolices.IsMaster.ToString(),this.IsMaster.ToString(),mode);
				history.BuildNotesForHistory("TCIDApplicationAuto",oldPolices.TCIDApplicationAuto.ToString(),this.TCIDApplicationAuto.ToString(),mode);
				history.BuildNotesForHistory("TCIDQuote",oldPolices.TCIDQuotes.ToString(),this.TCIDQuotes.ToString(),mode);
				history.BuildNotesForHistory("PrintPolicy",oldPolices.PrintPolicy.ToString(),this.PrintPolicy.ToString(),mode);
				history.BuildNotesForHistory("MasterPolicyID",
					LookupTables.LookupTables.GetDescription("MasterPolicy",oldPolices.MasterPolicyID.ToString()),
					LookupTables.LookupTables.GetDescription("MasterPolicy",this.MasterPolicyID.ToString()),
					mode);
				history.BuildNotesForHistory("Prem_Mes",oldPolices.Prem_Mes.ToString(),this.Prem_Mes.ToString(),mode);
				history.BuildNotesForHistory("PMT1",oldPolices.PMT1.ToString(),this.PMT1.ToString(),mode);
				history.BuildNotesForHistory("PrintDate",oldPolices.PrintDate.ToString(),this.PrintDate.ToString(),mode);
				history.BuildNotesForHistory("OriginatedAt",oldPolices.OriginatedAt.ToString(),this.OriginatedAt.ToString(),mode);
                history.BuildNotesForHistory("Policy Limit", LookupTables.LookupTables.GetDescription("PRMedicalLimit", oldPolices.PRMedicalLimit.ToString()),
                                                             LookupTables.LookupTables.GetDescription("PRMedicalLimit", this.PRMedicalLimit.ToString()), mode);

                DataTable oldSpecialty = new DataTable();
                DataTable newSpecialty = new DataTable();

                if (this.PolicyType.Trim() == "PE")
                {
                    oldSpecialty = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(oldPolices.PRMedicRATEID, oldPolices.IsoCode);
                    newSpecialty = EPolicy.TaskControl.Application.GetPRMEDICRATEBYISOCODE(this.PRMedicRATEID, this.IsoCode);
                }
                else
                {
                    oldSpecialty = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(oldPolices.PRMedicRATEID, oldPolices.IsoCode);
                    newSpecialty = EPolicy.TaskControl.Application.GetPRMEDICRATEPRIMARYBYISOCODE(this.PRMedicRATEID, this.IsoCode);
                }

                if (oldSpecialty.Rows.Count > 0 && newSpecialty.Rows.Count > 0)
                {
                    string oldSpecialtyDesc = oldSpecialty.Rows[0]["PRMEDICRATEDesc"].ToString();
                    string newSpecialtyDesc = newSpecialty.Rows[0]["PRMEDICRATEDesc"].ToString();

                    history.BuildNotesForHistory("Specialty", oldSpecialtyDesc, newSpecialtyDesc, mode);
                }
                history.BuildNotesForHistory("Retro Date", oldPolices.RetroactiveDate.ToString(), this.RetroactiveDate.ToString(), mode);
                history.BuildNotesForHistory("Effective Date", oldPolices.EffectiveDate.ToString(), this.EffectiveDate.ToString(), mode);
                history.BuildNotesForHistory("Expiration Date", oldPolices.ExpirationDate.ToString(), this.ExpirationDate.ToString(), mode);
				// Terminan Campos Policy


				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("TaskControlID.","",this.TaskControlID.ToString(),mode);
                if(this.Ren_Rei != "RI")
				    history.Actions = "ADD";
                else
                    history.Actions = "REINST.";
			}

			history.KeyID = this.TaskControlID.ToString();
			history.Subject = "POLICIES";			
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


        #region EndorsementDetailCollection

        public void SaveEndorsementDetailCollection(int UserID, int taskControlID)
        {
                DBRequest Executor = new DBRequest();
                Executor.Update("DeleteEndorsementDetailByTaskControlID", DeleteEndorsementDetailByTaskControlIDXml(taskControlID));

                for (int i = 0; i < EndorsementCollection.Rows.Count; i++)
                {
                    this.Mode = 1; //Add

                    Executor.BeginTrans();
                    int locationID = Executor.Insert("AddEndorsementDetail", this.GetInsertEndorsementDetailXml(i));
                    Executor.CommitTrans();
                }
        }

        private XmlDocument DeleteEndorsementDetailByTaskControlIDXml(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(), ref cookItems);

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

        private XmlDocument GetInsertEndorsementDetailXml(int index)
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[7];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
              SqlDbType.Int, 0, this.TaskControlID.ToString(),
              ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorseNo",
             SqlDbType.VarChar, 50, EndorsementCollection.Rows[index]["EndorseNo"].ToString(),
             ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorsePrepDt",
             SqlDbType.VarChar, 50, EndorsementCollection.Rows[index]["EndorsePrepDt"].ToString(),
             ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorseEffDt",
             SqlDbType.VarChar, 50, EndorsementCollection.Rows[index]["EndorseEffDt"].ToString(),
             ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorsePrem",
             SqlDbType.Float, 0, EndorsementCollection.Rows[index]["EndorsePrem"].ToString(),
             ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorseType",
             SqlDbType.VarChar, 50, EndorsementCollection.Rows[index]["EndorseType"].ToString(),
             ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EndorseComment",
             SqlDbType.VarChar, 50, EndorsementCollection.Rows[index]["EndorseComment"].ToString(),
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

        public static DataTable GetEndorsementDetailByTaskControlID(int TaskControlID)
        {
            DataTable dt = GetEndorsementDetailByTaskControlIDDB(TaskControlID);
            return dt;
        }

        private static DataTable GetEndorsementDetailByTaskControlIDDB(int taskControlID)
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
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            DataTable dt = exec.GetQuery("GetEnvironmentalPPLLocationDetailByTaskControlID", xmlDoc);

            return dt;
        }

        private DataTable DataTableEndorsementTemp()
        {
            DataTable myDataTable = new DataTable("DataTableEndorsementTemp");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "TaskControlID";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "TaskControlID";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseNo";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseNo";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorsePrepDt";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorsePrepDt";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseEffDt";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseEffDt";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Float");
            myDataColumn.ColumnName = "EndorsePrem";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorsePrem";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseType";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseType";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "EndorseComment";
            myDataColumn.AutoIncrement = false;
            myDataColumn.Caption = "EndorseComment";
            myDataColumn.ReadOnly = false;
            myDataColumn.Unique = false;
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "LocationID";
            myDataColumn.AutoIncrement = true;
            myDataColumn.AutoIncrementSeed = 1;
            myDataColumn.AutoIncrementStep = 1;
            myDataColumn.AllowDBNull = false;
            myDataColumn.ReadOnly = true;
            myDataColumn.Unique = true;
            myDataTable.Columns.Add(myDataColumn);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[8];
            PrimaryKeyColumns[0] = myDataTable.Columns["EndorsementDetailID"];
            myDataTable.PrimaryKey = PrimaryKeyColumns;

            return myDataTable;
        }

        #endregion
	}
}
