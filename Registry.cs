using System;
using System.Data;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.LookupTables;
using EPolicy.Audit;
using EPolicy.XmlCooker;
using System.Collections;

namespace EPolicy.Customer
{
    public class Registry
    {
        public Registry()
		{

		}

		#region Variables

        private DataTable _dtRegistry;
        private Registry oldRegistry = null;
        private int _RegistryID = 0;
        private string _CustomerNo = "";
        private string _ASSMCAExpDate = "";
        private string _DEAExpDate = "";
        private string _TribunalExpDate = "";
        private string _Cannabisdate = "";
        private string _LicenciaDate = "";
        private string _Licencia = "";
        private string _CDMExpDate = "";
        private string _GoodStandingExpDate = "";
        // private string      _GoodStandingGradDate = "";
        private string _LicenseExpDate = "";
        private string _MedicalSchool = "";
        private string _MDSGradDate = "";
        private string _Internship = "";
        private string _InternGradDate = "";
        private string _Residency = "";
        private string _ResidencyGradDate = "";
        private string _Fellowship = "";
        private string _FellowshipGradDate = "";
        private int _ShareholderQty = 0;
        private string _ShareholderNo = "";
        private int _Mode = (int)RegistryMode.CLEAR;
        private string _MedicalPractice = "";
        private int _PreviousClaims = 0;
        private int _BoardCertified = 0;
        private bool _CV = false;
        private string _CarrierName = "";
        private string _EffectiveDate = "";
        private string _PolicyNo = "";
        private string _PolicyLimits = "";
        private string _Comments = "";
        private int _UserID = 0;
        private string _EntryDate = "";
		#endregion

		#region Public Enumeration

		public enum RegistryMode{ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4};

		#endregion

		#region Properties

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

		public int RegistryID
		{
			get
			{
                return this._RegistryID;
			}
			set
			{
                this._RegistryID = value;
			}
		}

        public string CustomerNo
        {
            get
            {
                return this._CustomerNo;
            }
            set
            {
                this._CustomerNo = value;
            }
        }

        public string ASSMCAExpDate
		{
			get
			{
                return this._ASSMCAExpDate;
			}
			set
			{
                this._ASSMCAExpDate = value;
			}
		}

        public string InternGradDate
        {
            get
            {
                return this._InternGradDate;
            }
            set
            {
                this._InternGradDate = value;
            }
        }

        public string DEAExpDate
        {
            get
            {
                return this._DEAExpDate;
            }
            set
            {
                this._DEAExpDate = value;
            }
        }

        public string CannabisDate
        {
            get
            {
                return this._CannabisDate;
            }
            set
            {
                this._CannabisDate = value;
            }
        }

        public string MDSGradDate
        {
            get
            {
                return this._MDSGradDate;
            }
            set
            {
                this._MDSGradDate = value;
            }
        }

        public string TribunalExpDate
        {
            get
            {
                return this._TribunalExpDate;
            }
            set
            {
                this._TribunalExpDate = value;
            }
        }

        public string LicenciaDate
        {
            get
            {
                return this._LicenciaDate;
            }
            set
            {
                this._LicenciaDate = value;
            }
        }

        public string Licencia
        {
            get
            {
                return this._Licencia;
            }
            set
            {
                this._Licencia = value;
            }
        }

        public string CDMExpDate
        {
            get
            {
                return this._CDMExpDate;
            }
            set
            {
                this._CDMExpDate = value;
            }
        }

        public string ResidencyGradDate
        {
            get
            {
                return this._ResidencyGradDate;
            }
            set
            {
                this._ResidencyGradDate = value;
            }
        }

        public string GoodStandingExpDate
        {
            get
            {
                return this._GoodStandingExpDate;
            }
            set
            {
                this._GoodStandingExpDate = value;
            }
        }

        //public string GoodStandingGradDate
        //{
        //    get
        //    {
        //        return this._GoodStandingGradDate;
        //    }
        //    set
        //    {
        //        this._GoodStandingGradDate = value;
        //    }
        //}

		public int ShareholderQty
		{
			get
			{
                return this._ShareholderQty;
			}
			set
			{
                this._ShareholderQty = value;
			}
		}

        public string ShareholderNo
        {
            get
            {
                return this._ShareholderNo;
            }
            set
            {
                this._ShareholderNo = value;
            }
        }

        public string  MedicalSchool
        {
            get
            {
                return this._MedicalSchool ;
            }
            set
            {
                this._MedicalSchool  = value;
            }
        }

        public string  Internship
        {
            get
            {
                return this._Internship;
            }
            set
            {
                this._Internship  = value;
            }
        }

        public string Fellowship
        {
            get
            {
                return this._Fellowship ;
            }
            set
            {
                this._Fellowship  = value;
            }
        }

        public string FellowshipGradDate
        {
            get
            {
                return this._FellowshipGradDate;
            }
            set
            {
                this._FellowshipGradDate = value;
            }
        }

        public string Residency
        {
            get
            {
                return this._Residency;
            }
            set
            {
                this._Residency = value;
            }
        }

        public string LicenseExpDate
        {
            get
            {
                return this._LicenseExpDate;
            }
            set
            {
                this._LicenseExpDate = value;
            }
        }

        public string MedicalPractice
        {
            get
            {
                return this._MedicalPractice;
            }
            set
            {
                this._MedicalPractice = value;
            }
        }

        public int PreviousClaims
        {
            get
            {
                return this._PreviousClaims;
            }
            set
            {
                this._PreviousClaims = value;
            }
        }

        public int BoardCertified
        {
            get
            {
                return this._BoardCertified;
            }
            set
            {
                this._BoardCertified = value;
            }
        }

        public bool CV
        {
            get
            {
                return this._CV;
            }
            set
            {
                this._CV = value;
            }
        }

        public string CarrierName  
        {
            get
            {
                return this._CarrierName ;
            }
            set
            {
                this._CarrierName  = value;
            }
        }

        public string EffectiveDate  
        {
            get
            {
                return this._EffectiveDate ;
            }
            set
            {
                this._EffectiveDate = value;
            }
        }

        public string PolicyNo  
        {
            get
            {
                return this._PolicyNo ;
            }
            set
            {
                this._PolicyNo  = value;
            }
        }

        public string PolicyLimits  
        {
            get
            {
                return this._PolicyLimits ;
            }
            set
            {
                this._PolicyLimits  = value;
            }
        }

        public string Comments  
        {
            get
            {
                return this._Comments ;
            }
            set
            {
                this._Comments  = value;
            }
        }

        public int UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }
        }

        public string EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                this._EntryDate = value;
            }

        }

		#endregion

		#region Public Methods

		public static Registry GetRegistryByRegistryID(int registryID)
		{
			Registry registry = null;

            DataTable dt = GetRegistryByRegistryIDDB(registryID);
            registry = new Registry();

            registry._dtRegistry = dt;
            registry = FillProperties(registry);

			return registry;
		}

        public static Registry GetRegistryByCustomerNo(int customerNo)
        {
            Registry registry = null;

            DataTable dt = GetRegistryByCustomerNoDB(customerNo);
            registry = new Registry();

            registry._dtRegistry = dt;

            if(dt.Rows.Count > 0)
                registry = FillProperties(registry);

            return registry;
        }

        //public static DataTable GetRegistryByCustomerNo(int customerNo)
        //{
        //    DataTable dt = GetRegistryByCustomerNoDB(customerNo);
        //    return dt;
        //}

        private static DataTable GetHospitals()
        {

            DBRequest exec = new DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetHospital", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to find hospital data.", ex);
            }
        }

		public void SaveRegistry(int UserID, int taskControlID)
		{
			this.Save(UserID, taskControlID);
		}

        public void SavePrivileges(int privilegeID, int registryID, int hospitalID)
        {
            SavePrivilege(privilegeID, registryID, hospitalID);
        }

        public void DeletePrivileges(int privilegeID)
        {
            DeletePrivelege(privilegeID);
        }

        public DataTable GetPrivileges(int registryID)
        {
            return GetPrivilege(registryID);
        }
        //public static void DeleteMedicoByMedicoID(int medicoID)
        //{
        //    //Hay que eliminar todas las transacciones relacionadas.
        //    DBRequest Executor = new DBRequest();
        //    Executor.Update("DeleteMedico",DeleteMedicoByMedicoIDXml(medicoID));
        //}

		#endregion

		#region Private Methods
		private void Save(int UserID, int taskControlID)
		{
			if (this.Mode ==2) //Para el History
				oldRegistry = (Registry) GetRegistryByRegistryID(this.RegistryID);

			DBRequest Executor = new DBRequest();
			try
			{
				Executor.BeginTrans();
				switch (this.Mode)
				{
					case 1:  //ADD
						this.RegistryID = Executor.Insert("AddRegistry",this.GetInsertRegistryXml());
						//DataTable dt = GetCustomerByCustomerID(this.CustomerID);
						//this.LocationID = (int) dt.Rows[0]["LocationID"];
						this.History(this.Mode,UserID, taskControlID);
						break;

					default: //UPDATE
						this.History(this.Mode,UserID, taskControlID);
                        Executor.Update("AddRegistry", this.GetUpdateRegistryXml());
						break;
				}
				Executor.CommitTrans();
				
				if (this.Mode==1)  //ADD
				{
                    this.History(this.Mode, UserID, taskControlID);
				}
			}

			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("An error occurred while trying to save registry. "+xcp.Message,xcp);
			}

			this.Mode = 4;
		}

        //private static XmlDocument DeleteMedicoByMedicoIDXml(int medicoID)
        //{
        //    DbRequestXmlCookRequestItem[] cookItems = 
        //        new DbRequestXmlCookRequestItem[1];

        //    DbRequestXmlCooker.AttachCookItem("MedicoID",
        //        SqlDbType.Int, 0, medicoID.ToString(),
        //        ref cookItems);

        //    XmlDocument xmlDoc;

        //    try
        //    {
        //        xmlDoc = DbRequestXmlCooker.Cook(cookItems);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception("Could not cook items.", ex);
        //    }

        //    return xmlDoc;
        //}

		private static DataTable GetRegistryByRegistryIDDB(int registryID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("RegistryID",
                SqlDbType.Int, 0, registryID.ToString(),
				ref cookItems);

			DBRequest exec = new DBRequest();
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
				dt = exec.GetQuery("GetRegistryByRegistryID", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Unable to find registry data.", ex);
			}			
		}

		private static DataTable GetRegistryByCustomerNoDB(int customerNo)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
                SqlDbType.Int, 0, customerNo.ToString(),
				ref cookItems);

			DBRequest exec = new DBRequest();
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
                dt = exec.GetQuery("GetRegistryByCustomerNo", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
                throw new Exception("Unable to find registry data.", ex);
			}			
		}

        private static DataTable GetPrivilege(int registryID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("RegistryID",
                SqlDbType.Int, 0, registryID.ToString(),
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
                dt = exec.GetQuery("GetPrivilege", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to find privilege data.", ex);
            }
        }

		private XmlDocument GetInsertRegistryXml()
		{
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[32];

            DbRequestXmlCooker.AttachCookItem("RegistryID",
                SqlDbType.Int, 0, "0",
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CustomerNo",
                SqlDbType.VarChar, 10, this.CustomerNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ASSMCSExpDate",
                SqlDbType.VarChar, 20, this.ASSMCAExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("InternGradDate",
                SqlDbType.VarChar, 20, this.InternGradDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DEAExpDate",
                SqlDbType.VarChar, 20, this.DEAExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CannabisDate",
               SqlDbType.VarChar, 20, this.CannabisDate.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MDSGradDate",
                SqlDbType.VarChar, 20, this.MDSGradDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TribunalExpDate",
                SqlDbType.VarChar, 20, this.TribunalExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LicenciaDate",
                SqlDbType.VarChar, 20, this.LicenciaDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Licencia",
                SqlDbType.VarChar, 20, this.Licencia.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CDMExpDate",
                SqlDbType.VarChar, 20, this.CDMExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ResidencyGradDate",
                SqlDbType.VarChar, 20, this.ResidencyGradDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("GoodStandingExpDate",
                SqlDbType.VarChar, 20, this.GoodStandingExpDate.ToString(),
                ref cookItems);

            //DbRequestXmlCooker.AttachCookItem("GoodStandingGradDate",
            //    SqlDbType.VarChar, 20, this.GoodStandingGradDate.ToString(),
            //    ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LicenseExpDate",
                SqlDbType.VarChar, 20, this.LicenseExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ShareholderQty",
                SqlDbType.Int, 0, this.ShareholderQty.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ShareholderNo",
                SqlDbType.VarChar, 20, this.ShareholderNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalSchool",
                SqlDbType.VarChar, 100, this.MedicalSchool.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Internship",
                SqlDbType.VarChar, 100, this.Internship.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Fellowship",
                SqlDbType.VarChar, 100, this.Fellowship.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("FellowshipGradDate",
                SqlDbType.VarChar, 20, this.FellowshipGradDate.ToString(),
                ref cookItems);


            DbRequestXmlCooker.AttachCookItem("Residency",
                SqlDbType.VarChar, 100, this.Residency.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalPractice",
                SqlDbType.VarChar, 500, this.MedicalPractice.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PreviousClaims",
                SqlDbType.Int, 0, this.PreviousClaims.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BoardCertified",
                SqlDbType.Int, 0, this.BoardCertified.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CV",
                SqlDbType.Bit, 0, this.CV.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CarrierName",
                SqlDbType.VarChar, 100, this.CarrierName.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                SqlDbType.VarChar, 20, this.EffectiveDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
                SqlDbType.VarChar, 20, this.PolicyNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyLimits",
                SqlDbType.VarChar, 50, this.PolicyLimits.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Comments",
                SqlDbType.VarChar, 2000, this.Comments.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, this.UserID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EntryDate",
                SqlDbType.VarChar, 20, this.EntryDate.ToString(),
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

		private XmlDocument GetUpdateRegistryXml()
		{
            DbRequestXmlCookRequestItem[] cookItems =
                 new DbRequestXmlCookRequestItem[32];

            DbRequestXmlCooker.AttachCookItem("RegistryID",
                SqlDbType.Int, 0, this.RegistryID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CustomerNo",
                SqlDbType.VarChar, 10, this.CustomerNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ASSMCSExpDate",
                SqlDbType.VarChar, 20, this.ASSMCAExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("DEAExpDate",
                SqlDbType.VarChar, 20, this.DEAExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CannabisDate",
                SqlDbType.VarChar, 20, this.CannabisDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("TribunalExpDate",
                SqlDbType.VarChar, 20, this.TribunalExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LicenciaDate",
                SqlDbType.VarChar, 20, this.LicenciaDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Licencia",
                SqlDbType.VarChar, 20, this.Licencia.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CDMExpDate",
                SqlDbType.VarChar, 20, this.CDMExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("GoodStandingExpDate",
                SqlDbType.VarChar, 20, this.GoodStandingExpDate.ToString(),
                ref cookItems);

            //DbRequestXmlCooker.AttachCookItem("GoodStandingGradDate",
            //    SqlDbType.VarChar, 20, this.GoodStandingGradDate.ToString(),
            //    ref cookItems);

            DbRequestXmlCooker.AttachCookItem("LicenseExpDate",
                SqlDbType.VarChar, 20, this.LicenseExpDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ShareholderQty",
                SqlDbType.Int, 0, this.ShareholderQty.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ShareholderNo",
                SqlDbType.VarChar, 20, this.ShareholderNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalSchool",
                SqlDbType.VarChar, 100, this.MedicalSchool.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MDSGradDate",
                SqlDbType.VarChar, 20, this.MDSGradDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Internship",
                SqlDbType.VarChar, 100, this.Internship.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("InternGradDate",
                SqlDbType.VarChar, 20, this.InternGradDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Fellowship",
                SqlDbType.VarChar, 100, this.Fellowship.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("FellowshipGradDate",
                SqlDbType.VarChar, 100, this.FellowshipGradDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Residency",
                SqlDbType.VarChar, 100, this.Residency.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ResidencyGradDate",
              SqlDbType.VarChar, 20, this.ResidencyGradDate.ToString(),
              ref cookItems);

            DbRequestXmlCooker.AttachCookItem("MedicalPractice",
                SqlDbType.VarChar, 500, this.MedicalPractice.ToString(),
                ref cookItems);


            DbRequestXmlCooker.AttachCookItem("PreviousClaims",
                SqlDbType.Int, 0, this.PreviousClaims.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BoardCertified",
                SqlDbType.Int, 0, this.BoardCertified.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CV",
                SqlDbType.Bit, 0, this.CV.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CarrierName",
                SqlDbType.VarChar, 100, this.CarrierName.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EffectiveDate",
                SqlDbType.VarChar, 20, this.EffectiveDate.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyNo",
                SqlDbType.VarChar, 20, this.PolicyNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PolicyLimits",
                SqlDbType.VarChar, 50, this.PolicyLimits.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Comments",
                SqlDbType.VarChar, 2000, this.Comments.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, this.UserID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("EntryDate",
                SqlDbType.VarChar, 20, this.EntryDate.ToString(),
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

        private static void SavePrivilege(int privilegeID, int registryID, int hospitalID)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("PrivilegeID",
                SqlDbType.Int, 0, privilegeID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("RegistryID",
                SqlDbType.Int, 0, registryID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("HospitalID",
                SqlDbType.Int, 0, hospitalID.ToString(),
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

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            exec.Insert("AddPrivilege", xmlDoc);
        }

        private static void DeletePrivelege(int privilegeID)
        {

            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PrivilegeID",
                SqlDbType.Int, 0, privilegeID.ToString(),
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

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

            exec.Update("DeletePrivilege", xmlDoc);
        }


		private void History(int mode, int userID, int taskControlID)
		{
			History history = new History();
			
			if(mode == 2)
			{
                history.BuildNotesForHistory("ASSMCSA Expiration Date", oldRegistry.ASSMCAExpDate.ToString(), this.ASSMCAExpDate.ToString(), mode);
                history.BuildNotesForHistory("DEA Expriation Date", oldRegistry.DEAExpDate.ToString(), this.DEAExpDate.ToString(), mode);
                history.BuildNotesForHistory("Cannabis Date", oldRegistry.CannabisDate.ToString(), this.CannabisDate.ToString(), mode);
                history.BuildNotesForHistory("Tribunal Expiration Date", oldRegistry.TribunalExpDate.ToString(), this.TribunalExpDate.ToString(), mode);
                history.BuildNotesForHistory("CDM Expiration Date", oldRegistry.CDMExpDate.ToString(), this.CDMExpDate.ToString(), mode);
                history.BuildNotesForHistory("Good Standing Expiration Date", oldRegistry.GoodStandingExpDate.ToString(), this.GoodStandingExpDate.ToString(), mode);
                history.BuildNotesForHistory("License Expiration Date", oldRegistry.LicenseExpDate.ToString(), this.LicenseExpDate.ToString(), mode);
                history.BuildNotesForHistory("Shareholder Qty.", oldRegistry.ShareholderQty.ToString(), this.ShareholderQty.ToString(), mode);
                history.BuildNotesForHistory("Medical School", oldRegistry.MedicalSchool.ToString(), this.MedicalSchool.ToString(), mode);
                history.BuildNotesForHistory("Internship", oldRegistry.Internship.ToString(), this.Internship.ToString(), mode);
                history.BuildNotesForHistory("Residency", oldRegistry.Residency.ToString(), this.Residency.ToString(), mode);
                history.BuildNotesForHistory("Fellowship", oldRegistry.Fellowship.ToString(), this.Fellowship.ToString(), mode);
                history.BuildNotesForHistory("Medical Practice", oldRegistry.MedicalPractice.ToString(), this.MedicalPractice.ToString(), mode);
                history.BuildNotesForHistory("Previous Claims", oldRegistry.PreviousClaims.ToString(), this.PreviousClaims.ToString(), mode);
                history.BuildNotesForHistory("Board Certified", oldRegistry.BoardCertified.ToString(), this.BoardCertified.ToString(), mode);
                history.BuildNotesForHistory("Curriculum Vitae", oldRegistry.CV.ToString(), this.CV.ToString(), mode);
                history.BuildNotesForHistory("Policy No.", oldRegistry.PolicyNo.ToString(), this.PolicyNo.ToString(), mode);
                history.BuildNotesForHistory("Policy Limit", oldRegistry.PolicyLimits.ToString(), this.PolicyLimits.ToString(), mode);
                history.BuildNotesForHistory("Carrier Name", oldRegistry.CarrierName.ToString(), this.CarrierName.ToString(), mode);
                history.BuildNotesForHistory("Effective Date", oldRegistry.EffectiveDate.ToString(), this.EffectiveDate.ToString(), mode);
                history.BuildNotesForHistory("Policy No.", oldRegistry.PolicyNo.ToString(), this.PolicyNo.ToString(), mode);
                history.BuildNotesForHistory("Comments", oldRegistry.Comments.ToString(), this.Comments.ToString(), mode);

				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("Registry ID","",this.RegistryID.ToString(),mode);
				history.Actions = "ADD";
			}

            history.KeyID = taskControlID.ToString();
			history.Subject = "REGISTRY";			
			history.UsersID =  userID;
			history.GetSaveHistory();
		}



		private static Registry FillProperties(Registry registry)
		{
            registry.RegistryID = (registry._dtRegistry.Rows[0]["RegistryID"] != System.DBNull.Value) ? (int)registry._dtRegistry.Rows[0]["RegistryID"] : 0;
            registry.CustomerNo = (registry._dtRegistry.Rows[0]["CustomerNo"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["CustomerNo"] : "";
            registry.ASSMCAExpDate = (registry._dtRegistry.Rows[0]["ASSMCAExpDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["ASSMCAExpDate"].ToString() : "";
            registry.DEAExpDate = (registry._dtRegistry.Rows[0]["DEAExpDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["DEAExpDate"] : "";
            registry.CannabisDate = (registry._dtRegistry.Rows[0]["CannabisDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["CannabisDate"] : "";
            registry.TribunalExpDate = (registry._dtRegistry.Rows[0]["TribunalExpDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["TribunalExpDate"].ToString() : "";
            registry.CDMExpDate = (registry._dtRegistry.Rows[0]["CDMExpDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["CDMExpDate"] : "";
            registry.GoodStandingExpDate = (registry._dtRegistry.Rows[0]["GoodStandingExpDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["GoodStandingExpDate"] : "";
            registry.LicenseExpDate = (registry._dtRegistry.Rows[0]["LicenseExpDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["LicenseExpDate"].ToString() : "";
            registry.ShareholderQty = (registry._dtRegistry.Rows[0]["ShareholderQty"] != System.DBNull.Value) ? (int)registry._dtRegistry.Rows[0]["ShareholderQty"] : 0;
            registry.MedicalSchool = (registry._dtRegistry.Rows[0]["MedicalSchool"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["MedicalSchool"].ToString() : "";
            registry.Internship = (registry._dtRegistry.Rows[0]["Internship"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["Internship"] : "";
            registry.Residency = (registry._dtRegistry.Rows[0]["Residency"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["Residency"].ToString() : "";
            registry.Fellowship = (registry._dtRegistry.Rows[0]["Fellowship"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["Fellowship"] : "";
            registry.MedicalPractice = (registry._dtRegistry.Rows[0]["MedicalPractice"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["MedicalPractice"].ToString() : "";
            registry.PreviousClaims = (registry._dtRegistry.Rows[0]["PreviousClaims"] != System.DBNull.Value) ? (int)registry._dtRegistry.Rows[0]["PreviousClaims"] : 0;
            registry.BoardCertified = (registry._dtRegistry.Rows[0]["BoardCertified"] != System.DBNull.Value) ? (int)registry._dtRegistry.Rows[0]["BoardCertified"] : 0;
            registry.CV = (registry._dtRegistry.Rows[0]["CV"] != System.DBNull.Value) ? bool.Parse(registry._dtRegistry.Rows[0]["CV"].ToString()) : false;
            registry.CarrierName = (registry._dtRegistry.Rows[0]["CarrierName"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["CarrierName"].ToString() : "";
            registry.EffectiveDate = (registry._dtRegistry.Rows[0]["EffectiveDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["EffectiveDate"] : "";
            registry.PolicyNo = (registry._dtRegistry.Rows[0]["PolicyNo"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["PolicyNo"].ToString() : "";
            registry.PolicyLimits = (registry._dtRegistry.Rows[0]["PolicyLimits"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["PolicyLimits"] : "";
            registry.Comments = (registry._dtRegistry.Rows[0]["Comments"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["Comments"] : "";
            registry.UserID = (registry._dtRegistry.Rows[0]["UserID"] != System.DBNull.Value) ? (int)registry._dtRegistry.Rows[0]["UserID"] : 0;
            registry.EntryDate = (registry._dtRegistry.Rows[0]["EntryDate"] != System.DBNull.Value) ? (string)registry._dtRegistry.Rows[0]["EntryDate"].ToString() : "";

			return registry;
		}

		#endregion
    }
}