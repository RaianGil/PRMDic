using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;
using EPolicy.LookupTables;
using EPolicy;
using EPolicy.XmlCooker;

namespace EPolicy.Quotes
{
	/// <summary>
	/// Summary description for VSCQuote.
	/// </summary>
	public class VSCQuote
	{
		public VSCQuote()
		{
			
		}

		#region Private Variable 

		private string    _EffectiveDate = "";
		private int		  _VehicleYearID = 0;
		private int       _CoveragePlanID = 0;
		private int       _NewUse = 0;
		private int       _Term = 0;
		private int	      _Miles = 0;
		private int       _VehicleMakeID = 0;
		private int       _VehicleModelID = 0;
		private bool      _Turbo = false;
		private bool      _WD4 = false;
		private bool      _Diesel = false;
		private double	  _SuggestedPrice = 0.00;

		private Baldrich.DBRequest.DBRequest _DbRequest = new Baldrich.DBRequest.DBRequest();

		#endregion

		#region Properties
	
		private string  EffectiveDate
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

		private int VehicleYearID
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

		private int CoveragePlanID
		{
			get
			{
				return this._CoveragePlanID;
			}
			set
			{
				this._CoveragePlanID = value;
			}
		}

		private int NewUse
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

		private int Term
		{
			get
			{
				return this._Term;
			}
			set
			{
				this._Term = value;
			}
		}

		private int	Miles
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

		private int VehicleMakeID
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

		private int VehicleModelID
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

		private bool Turbo
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

		private bool WD4
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

		private bool Diesel
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

		private double SuggestedPrice
		{
			get
			{
				return this._SuggestedPrice;
			}
			set
			{
				this._SuggestedPrice = value;
			}
		}

		#endregion

		#region Public Methods

        public DataTable Calculate(string effectiveDate, int coveragePlan, int newuse, int term, string miles, 
            int vehicleMakeID, int vehicleModelID, bool turbo, bool wd4, bool diesel, bool powerTrain, string companyDealer)
		{
			DataTable dt = GetVSCDetails(effectiveDate, coveragePlan, newuse,
            term, miles, vehicleMakeID, vehicleModelID, turbo, wd4, diesel, powerTrain, companyDealer);

            return dt;
		}

		#endregion
        
		#region Private Methods

        private DataTable GetVSCDetails(string effectiveDate, int coveragePlan, int newuse,
            int term, string miles, int vehicleMakeID, int vehicleModelID, bool turbo,
            bool wd4, bool diesel, bool powerTrain, string companyDealer)

		{
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[12];

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                SqlDbType.DateTime, 0, effectiveDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CoveragePlanID",
                SqlDbType.Int, 0, coveragePlan.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Newuse",
                SqlDbType.Int, 0, newuse.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Term",
                SqlDbType.Int, 0, term.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("SetMiles",
                SqlDbType.VarChar, 25, miles.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleMakeID",
                SqlDbType.Int, 0, vehicleMakeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VehicleModelID",
                SqlDbType.Int, 0, vehicleModelID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Turbo",
                SqlDbType.Bit, 0, turbo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("WD4",
                SqlDbType.Bit, 0, wd4.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Diesel",
                SqlDbType.Bit, 0, diesel.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PowerTrain",
                SqlDbType.Bit, 0, powerTrain.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CompanyDealer",
                SqlDbType.Char, 3, companyDealer.ToString(),
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

            DataTable dt = exec.GetQuery("GetVSCRATE2", xmlDoc);
            return dt;
		}

		#endregion
	}
}
