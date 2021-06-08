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
	public class Customer
	{
		public Customer()
		{

		}

		#region Variables
		
		private Customer  _oldCustomer = null;
		private DataTable _dtCustomer;
		private DataTable _dtContactPerson;
		private DataTable _dtCustomerAddr;
		private DataTable _NavegationCustomerTable;
		private int _Mode = (int) CustomerMode.CLEAR;
		private string _CustomerNo = "";
		private int _ProspectID = 0;
		private bool   _IsBusiness = false;
		private int    _LocationID = 1;
		private int    _ContactPersonID = 0;
		private string _Firstna	= "";
		private string _Initial	= "";
		private string _Lastna1	= "";
		private string _Lastna2	= "";
		private string _Sex		= "";
		private int    _Martst	= 0;
		private int    _BusinessType = 0;
		private string _Adds1	= "";
		private string _Adds2	= "";
		private string _City	= "";
		private string _State	= "PR";
		private string _Zip		= "";
		private string _Homeph	= "";
		private string _Jobph	= "";
		private string _Cellular= "";
        private string _Faxph   = "";
		private string _Birthday = "";
		private string _Age		= "";
		private string _SocSec	= "";
		private string _Licence	= "";
		private int	   _OccupationID = 0;
		private string _Occupa	= "";
		private string _Emplna	= "";
		private string _Emplct	= "";
		private string _EmployerSocialSecurity = "";
		private int    _Emp		= 0;
		private bool   _AvisoCancellation	= true;
		private int    _Mstcust	= 0;
		private string _Email	= "";
		private bool   _Lab		= true;
		private string _Comments   = "";
		private string _Description = "";
		private int    _Dependents = 0;
		private int    _HouseHoldIncome = 0;
		private bool   _OptOut          = false;
		private string _AddressPhysical1 = "";
		private string _AddressPhysical2 = "";
		private string _CityPhysical     = "";
		private string _StatePhysical    = "";
		private string _ZipPhysical      = "";
		private string _EmpPosition      = "";
		private int	   _RelatedToID = 0;
		private string _Business1 = "";
		private string _Business2 = "";
		private string _Business3 = "";
		private bool   _Modify			 = true;
		private string _Warning			 = "";
		private bool _DisableAutomaticCustNo=false;
        private string _License = "";
        private string _BusinessName = "";

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

		public string Warning
		{
			get
			{
				return this._Warning;
			}
			set
			{
				this._Warning = value;
			}
		}

		public DataTable NavegationCustomerTable
		{
			get
			{
				return this._NavegationCustomerTable;
			}
			set
			{
				this._NavegationCustomerTable = value;
			}
		}

		public int ProspectID
		{
			get
			{
				return this._ProspectID;
			}
			set 
			{
				this._ProspectID = value;
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
				this._CustomerNo = value.Trim();
			}
		}

		public bool IsBusiness
		{
			get
			{
				return this._IsBusiness;
			}
			set
			{
				this._IsBusiness = value;
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

		public int ContactPersonID
		{
			get
			{
				return this._ContactPersonID;
			}
			set
			{
				this._ContactPersonID = value;
			}
		}
		
		public string FirstName    //Used for Customer and ContactPerson.
		{
			get
			{
				return this._Firstna;
			}
			set 
			{
				this._Firstna = value.Trim();
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

		public string LastName1    //Used for Customer and ContactPerson.
		{
			get
			{
				return this._Lastna1;
			}
			set 
			{
				this._Lastna1 = value.Trim();
			}
		}

		public string LastName2
		{
			get
			{
				return this._Lastna2;
			}
			set 
			{
				this._Lastna2 = value.Trim();
			}
		}

		public string Sex
		{
			get
			{
				return this._Sex;
			}
			set 
			{
				this._Sex = value.Trim();
			}
		}

		public int MaritalStatus
		{
			get
			{
				return this._Martst;
			}
			set 
			{
				this._Martst = value;
			}
		}

		public int BusinessType
		{
			get
			{
				return this._BusinessType;
			}
			set 
			{
				this._BusinessType = value;
			}
		}

		public string Address1
		{
			get
			{
				return this._Adds1;
			}
			set 
			{
				this._Adds1 = value.Trim();
			}
		}

		public string Address2
		{
			get
			{
				return this._Adds2;
			}
			set 
			{
				this._Adds2 = value.Trim();
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
				this._City = value.Trim();
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
				this._State = value.Trim();
			}
		}

		public string ZipCode
		{
			get
			{
				return this._Zip;
			}
			set 
			{
				this._Zip = value.Trim();
			}
		}

		public string HomePhone		//Used for Customer and ContactPerson (Phone - ContactPerson).
		{
			get
			{
				return this._Homeph;
			}
			set 
			{
				this._Homeph = value.Trim();
			}
		}

		public string JobPhone		//Used for Customer and ContactPerson (Cellular - ContactPerson).
		{
			get
			{
				return this._Jobph;
			}
			set 
			{
				this._Jobph = value.Trim();
			}
		}

		public string Cellular
		{
			get
			{
				return this._Cellular;
			}
			set
			{
				this._Cellular = value.Trim();
			}
		}

        public string FaxPhone
        {
            get
            {
                return this._Faxph;
            }
            set
            {
                this._Faxph = value.Trim();
            }
        }

		public string Birthday
		{
			get
			{
				return this._Birthday;
			}
			set 
			{
				this._Birthday = value.Trim();
			}
		}

		public string Age
		{
			get
			{
				return this._Age;
			}
			set 
			{
				this._Age = value.Trim();
			}
		}

		public string SocialSecurity
		{
			get
			{
				return this._SocSec;
			}
			set 
			{
				this._SocSec = value.Trim();
			}
		}

		public string Licence
		{
			get
			{
				return this._Licence;
			}
			set 
			{
				this._Licence = value.Trim();
			}
		}

		public int OccupationID
		{
			get
			{
				return this._OccupationID;
			}
			set
			{
				this._OccupationID = value;
			}
		}

		public string Occupation
		{
			get
			{
				return this._Occupa;
			}
			set 
			{
				this._Occupa = value.Trim();
			}
		}

		public string EmplName
		{
			get
			{
				return this._Emplna;
			}
			set 
			{
				this._Emplna = value.Trim();
			}
		}

		public string EmplCity
		{
			get
			{
				return this._Emplct;
			}
			set 
			{
				this._Emplct = value.Trim();
			}
		}

		public string EmployerSocialSecurity
		{
			get
			{
				return this._EmployerSocialSecurity;
			}
			set 
			{
				this._EmployerSocialSecurity = value.Trim();
			}
		}
		

		public int EmpID
		{
			get
			{
				return this._Emp;
			}
			set 
			{
				this._Emp = value;
			}
		}

		public bool NoticeCancellation
		{
			get
			{
				return this._AvisoCancellation;
			}
			set 
			{
				this._AvisoCancellation = value;
			}
		}

		public int MasterCustomer
		{
			get
			{
				return this._Mstcust;
			}
			set 
			{
				this._Mstcust = value;
			}
		}

		public string Email		//Used for Customer and ContactPerson.
		{
			get
			{
				return this._Email;
			}
			set 
			{
				this._Email = value.Trim();
			}
		}

		public bool Lab
		{
			get
			{
				return this._Lab;
			}
			set 
			{
				this._Lab = value;
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
				this._Comments = value.Trim();
			}
		}

		public string Description
		{
			get
			{
				return this._Description;
			}
			set 
			{
				this._Description = value.Trim();
			}
		}

		public int Dependents
		{
			get
			{
				return this._Dependents;
			}
			set 
			{
				this._Dependents = value;
			}
		}

		public int HouseHoldIncome 
		{
			get
			{
				return this._HouseHoldIncome;
			}
			set 
			{
				this._HouseHoldIncome = value;
			}
		}

		public bool OptOut 
		{
			get
			{
				return this._OptOut;
			}
			set 
			{
				this._OptOut = value;
			}
		}

		public int RelatedToID
		{
			get
			{
				return this._RelatedToID;
			}
			set
			{
				this._RelatedToID = value;
			}
		}

		public string AddressPhysical1 
		{
			get
			{
				return this._AddressPhysical1;
			}
			set 
			{
				this._AddressPhysical1 = value.Trim();
			}
		}

		public string AddressPhysical2
		{
			get
			{
				return this._AddressPhysical2;
			}
			set 
			{
				this._AddressPhysical2 = value.Trim();
			}
		}

		public string CityPhysical
		{
			get
			{
				return this._CityPhysical;
			}
			set 
			{
				this._CityPhysical = value.Trim();
			}
		}

		public string StatePhysical 
		{
			get
			{
				return this._StatePhysical;
			}
			set 
			{
				this._StatePhysical = value.Trim();
			}
		}

		public string ZipPhysical 
		{
			get
			{
				return this._ZipPhysical;
			}
			set 
			{
				this._ZipPhysical = value.Trim();
			}
		}

		public string BusinessName1 
		{
			get
			{
				return this._Business1;
			}
			set 
			{
				this._Business1 = value.Trim();
			}
		}

		public string BusinessName2 
		{
			get
			{
				return this._Business2;
			}
			set 
			{
				this._Business2 = value.Trim();
			}
		}

		public string BusinessName3 
		{
			get
			{
				return this._Business3;
			}
			set 
			{
				this._Business3 = value.Trim();
			}
		}
		
		public bool DisableAutomaticCustNo 
		{
			get
			{
				return this._DisableAutomaticCustNo;
			}
			set 
			{
				this._DisableAutomaticCustNo = value;
			}
		}

		//Used for ContactPerson
		public string EmpPosition 
		{
			get
			{
				return this._EmpPosition;
			}
			set 
			{
				this._EmpPosition = value.Trim();
			}
		}

        public string License
        {
            get
            {
                return this._License;
            }
            set
            {
                this._License = value.Trim();
            }
        }

        public string BusinessName
        {
            get
            {
                return this._BusinessName;
            }
            set
            {
                this._BusinessName = value.Trim();
            }
        }

		#endregion

		#region Public Enumeration

		public enum CustomerMode{ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4};
		public enum MutationType{CUSTOMER = 1, PHYSICAL_ADDRESS = 2, CONTACT_PERSON = 3};

		#endregion

		#region Public Methods

		public static void CreateProspectIfNecessary(Customer Cust, bool Save, int UserID)
		{
			if(!ProspectExistsForCurrentCustomer(Cust) &&
				Cust.Mode != 2)
			{
				if(UserID == 0)
					throw new Exception("UserID cannot be zero.");
				if(Cust == null)
					throw new Exception("Customer object cannot be null.");

				int tempMode = 0;

                EPolicy.Customer.Prospect prospect = new Prospect();
				prospect.BusinessName =  Cust.BusinessName;
				prospect.Cellular = Cust.Cellular;
				prospect.ConvertToClient = DateTime.Parse("1/1/1753");
				prospect.CustomerNumber = Cust.CustomerNo;
				prospect.Email = Cust.Email;
				prospect.EntryDate = System.DateTime.Now;
				prospect.FirstName = Cust.FirstName;
				prospect.HomePhone = Cust.HomePhone;
				prospect.HouseholdIncomeID = Cust.HouseHoldIncome;
				prospect.IsBusiness = Cust.IsBusiness;
				prospect.LastName1 = Cust.LastName1;
				prospect.LastName2 = Cust.LastName2;
				prospect.LocationID = Cust.LocationID;
				prospect.Modify = true;
				prospect.ReferredDesc = string.Empty;
				prospect.ReferredID = 0;
				prospect.Warning = Cust.Warning;
				prospect.WorkPhone = Cust.JobPhone;
                
				prospect.Mode = 1; //ADD
				
				prospect.SaveProspect(UserID, false);

				Cust.ProspectID = prospect.ProspectID;
				
				if(Save)
				{
					Cust._oldCustomer = Cust;	
					tempMode = Cust.Mode;
					Cust.Mode = 2	; //Update, default
					
					Cust.SaveCustomer(UserID);
					Cust.Mode = tempMode; //Return to original state
				}
			}
		}

		public void Save(int UserID)
		{
			this.Validate();
       
			if (this.IsBusiness)
			{
				SaveContactPerson(UserID); //Save ContactPerson
			}

			SaveCustomer(UserID);      //Save Customer
			SaveCustom_F(UserID);		 //Save Custom_F
            		
			
			CreateProspectIfNecessary(this, true, UserID);
			
			this.Mode = (int) CustomerMode.CLEAR;
		}

		public static Customer GetCustomer(string CustomerNo, int UserID)
		{
			Customer customer = new Customer();
				
			customer._dtCustomer = GetCustomerByCustomerNoDB(CustomerNo);
			
			if (customer._dtCustomer.Rows.Count !=0)
			{
				customer._dtCustomerAddr = GetCustomerAddrByCustomerNoDB(CustomerNo);
			
				if((bool) customer._dtCustomer.Rows[0]["IsBusiness"])  // Used for Business Customer.
				{
					customer._dtContactPerson = GetContactPersonByContactPersonIDDB((int) customer._dtCustomer.Rows[0]["ContactPersonID"]);
				}

				customer = FillCustomerProperties(customer);
				
				//RPR 2004-05-17
				CreateProspectIfNecessary(customer, true, UserID);
			}
			else
			{
				customer=null;
			}			
			return customer;
		}

		public static DataTable GetCustomerByCriteria(string CustomerNo,string FirstName,string LastName1,string LastName2,string SocialSecurity,string Phone, bool IsBusiness,bool All, string EmployerSocialSecurity ,string BusinessName, int UserID)
		{
            DataTable dt = GetCustomerByCriteriaDB(CustomerNo, FirstName, LastName1, LastName2, SocialSecurity, Phone, IsBusiness, All, EmployerSocialSecurity, BusinessName, UserID);

			return dt;
		}

		public static int GetAge(DateTime birthday)   
		{       
			int age   = DateTime.Today.Year - birthday.Year;
			int month = birthday.Month;
			int day	  = birthday.Day;

			int monthDate=0;
			monthDate = DateTime.Today.Month;

			if (month == monthDate)
			{
				if (day > DateTime.Today.Day)
				{
					age = age - 1;
				}
			}
			else
			{
				if (month > monthDate)
				{
					age = age - 1;
				}
			}

			return age;
		}

        public void UpdateCustomerNoAndProspectID(string CustomerNo, int ProspectID, string OldCustomerNo, int OldProspectID)
        {
            UpdateCustomerNoandProspectID(CustomerNo, ProspectID, OldCustomerNo, OldProspectID);
		}
         
		#endregion

		#region Private Methods

		//RPR 2004-05-17
		private static bool ProspectExistsForCurrentCustomer(Customer Cust)
		{
			if(Cust.CustomerNo != string.Empty)
			{
				Baldrich.DBRequest.DBRequest executer = new Baldrich.DBRequest.DBRequest();
				DbRequestXmlCookRequestItem[] requestItems = 
					{new DbRequestXmlCookRequestItem("CustomerNo", 
					SqlDbType.Char, 10, Cust.CustomerNo.Trim())};
				DataTable dt = executer.GetQuery("ProspectExistsForCurrentCustomer",
					DbRequestXmlCooker.Cook(requestItems));
				
				if((dt.Rows.Count > 0 &&
					(dt.Rows[0]["ProspectID"].ToString().Trim() != string.Empty &&
					dt.Rows[0]["ProspectID"].ToString().Trim() != "0")) ||
					Cust.ProspectID != 0)
				{
					return true;
				}
			}
			return false;
		}

		private void Validate()
		{
			string errorMessage = String.Empty;
			this.Warning = String.Empty;

			bool found = false;

			if (this.DisableAutomaticCustNo && this.CustomerNo=="")
			{
				errorMessage = "Please enter the customer number.";
				found = true;
			}

			if(this.IsBusiness)		// Business Customer
			{
				if (this.EmplName == "" &&  found == false)
				{
					errorMessage = "Employer Name is missing or wrong.";
					found = true;
				}
				else if (this.JobPhone == "" && this.Cellular == "" &&  found == false)
				{
					errorMessage = "Work Phone or Cellular is required.";
					found = true;
				}
			}
			else					// Individual Customer
			{
                //if (this.FirstName == "" &&  found == false)
                //{
                //    errorMessage = "FirstName is missing or wrong.";
                //    found = true;
                //}
                //else if (this.LastName1 == "" &&  found == false)
                //{
                //    errorMessage = "LastName1 is missing or wrong.";
                //    found = true;
                //}
                //else if (this.Email == "" && found == false)
                //{
                //    errorMessage = "Email is missing or wrong.";
                //    found = true;
                //}
//				else if (this.HomePhone == "" && this.Cellular == "" &&  found == false)
//				{
//					errorMessage = "Home Phone or Cellular is required.";
//					found = true;
//				}

//				if (this.Birthday != "")
//				{
//					if(DateTime.Parse(this.Birthday) > DateTime.Parse(DateTime.Now.ToShortDateString()))
//					{
//						errorMessage = "The bithday must be equal or smallest than today.";
//					}
//				}
			}

			if(this.Email.Trim() != "" && !this.isEmail(this.Email))
			{
				errorMessage += "Email address is invalid.  ";
				found = true;
			}


			//Verify if the customer exist in our database by the Social Security number and by the Phone Number.
            //if ((this.Mode == 1 || this.Mode == 2) &&  found == false && this.SocialSecurity != "")
            //{
            //    DataTable dt;

            //    if (!this.IsBusiness)
            //    {
            //        dt = VerifyBySocialSecurity();
            //        if (dt.Rows.Count != 0)
            //        {
            //            for(int i=0;i<=dt.Rows.Count-1;i++)
            //            {
            //                if(this.Mode == 1)
            //                {
            //                    errorMessage = "This Social Security number is already exist in the following customer:\r\n"+
            //                        "Customer No. :"+dt.Rows[i]["CustomerNo"].ToString().Trim()+"\r\n"+
            //                        "Customer Name:"+dt.Rows[i]["FirstNa"].ToString().Trim()+" "+dt.Rows[i]["Lastna1"].ToString().Trim();
            //                    found = true;
							
            //                    i = dt.Rows.Count -1;
            //                }
            //                else if (this.CustomerNo.Trim() != dt.Rows[i]["CustomerNo"].ToString().Trim() && this.Mode == 2)
            //                {
            //                    errorMessage = "This Social Security number is already exist in the following customer:\r\n"+
            //                        "Customer No. :"+dt.Rows[i]["CustomerNo"].ToString().Trim()+"\r\n"+
            //                        "Customer Name:"+dt.Rows[i]["FirstNa"].ToString().Trim()+" "+dt.Rows[i]["Lastna1"].ToString().Trim();
            //                    found = true;
            //                }
            //            }
            //        }
            //    }
            //}

				//Verify by the phones.
            //if ((this.Mode == 1 || this.Mode == 2) && found == false)
            //{
            //    DataTable dt;

            //    for(int x=1;x<=2;x++)
            //    {
            //        string phone="";
						
            //        switch (x)
            //        {
            //            case 1:
            //                if(this.IsBusiness)
            //                {
            //                    if(this.JobPhone != "")
            //                    {
            //                        phone = this.JobPhone;
            //                    }
            //                    else
            //                    {
            //                        phone ="";
            //                    }
            //                }
            //                else
            //                {
            //                    if(this.HomePhone != "")
            //                    {
            //                        phone = this.HomePhone;
            //                    }
            //                    else
            //                    {
            //                        phone ="";
            //                    }
            //                }
            //                break;

            //            case 2:
            //                if(this.Cellular != "")
            //                {
            //                    phone = this.Cellular;
            //                }
            //                else
            //                {
            //                    phone ="";
            //                }
            //                break;
            //        }
					
            //        if (phone != "")
            //        {
            //            dt = VerifyByPhone(phone);
            //            if (dt.Rows.Count != 0)
            //            {
            //                for(int i=0;i<=dt.Rows.Count-1;i++)
            //                {
            //                    if(this.Mode == 1)
            //                    {
            //                        this.Warning = "This phone number "+ phone.Trim()+" at least exist in the following customer:\r\n"+
            //                            "Customer No. :"+dt.Rows[i]["CustomerNo"].ToString().Trim()+"\r\n"+
            //                            "Customer Name:"+dt.Rows[i]["FirstNa"].ToString().Trim()+" "+dt.Rows[i]["Lastna1"].ToString().Trim();
            //                        //found = true;
							
            //                        i = dt.Rows.Count -1;
            //                    }
            //                    else if (this.CustomerNo.Trim() != dt.Rows[i]["CustomerNo"].ToString().Trim() && this.Mode == 2)
            //                    {
            //                        this.Warning = "This phone number "+ phone.Trim()+" at least exist in the following customer:\r\n"+
            //                            "Customer No. :"+dt.Rows[i]["CustomerNo"].ToString().Trim()+"\r\n"+
            //                            "Customer Name:"+dt.Rows[i]["FirstNa"].ToString().Trim()+" "+dt.Rows[i]["Lastna1"].ToString().Trim();
            //                        //found = true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
			
			//throw the exception.
			if (errorMessage != String.Empty)
			{
				throw new Exception(errorMessage);
			}	
		}

		/// <summary>
		/// Verifica si el Email es valido.
		/// </summary>
		/// <param name="inputEmail"></param>
		/// <returns></returns>
		private bool isEmail(string inputEmail)
		{
			//inputEmail  = NulltoString(inputEmail);
			string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
			System.Text.RegularExpressions.Regex re = 
				new System.Text.RegularExpressions.Regex (strRegex);
			if (re.IsMatch(inputEmail.Trim()))
				return (true);
			else
				return (false);
		}

		private DataTable VerifyByPhone(string phone)
		{
			DataTable dtCustByPhone;

			dtCustByPhone = GetCustomerByPhoneDB(phone);
			return dtCustByPhone;
		}

		private DataTable VerifyBySocialSecurity()
		{
			DataTable dtCustBySocialSecurity;

			if(this.IsBusiness)
			{
				dtCustBySocialSecurity = GetCustomerBusinessBySocialSecurityDB();
			}
			else
			{
				dtCustBySocialSecurity = GetCustomerBySocialSecurityDB();
			}

			return dtCustBySocialSecurity;
		}

        public static void AssignCustomerNoToControlNo(int taskControlID, string customerNo, int prospectID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[3];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("CustomerNo",
                SqlDbType.Char, 10, customerNo.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ProspectID",
                SqlDbType.Int, 0, prospectID.ToString(),
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

            exec.Update("UpdateAssignCustomerNo", xmlDoc);
        }

		private void SaveContactPerson(int UserID)
		{
			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();

				switch (this.Mode)
				{
					case 1:  //ADD
						this.ContactPersonID =  Executor.Insert("AddContactPerson",
							this.GetInsertContactPersonXml());
						break;

					case 3:  //DELETE
						Executor.Update("DeleteContactPerson",this.GetDeleteContactPersonXml());
						//this.History(this.Mode,UserID,(int)MutationType.CONTACT_PERSON);
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						Executor.Update("UpdateContactPerson",this.GetUpdateContactPersonXml());
						break;
				}
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the ContactPerson. "+xcp.Message,xcp);
			}
		}

		private void SaveCustomer(int UserID)
		{
			this._Modify = true;

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				if (this.Mode == 1 && !this.DisableAutomaticCustNo)
				{
					//Assign new customer number as per the Location.
					DataTable dtCustomerNo = Executor.GetQuery("GetCustomerCounterByParameter",this.GetCustomerCounterXml());
					
					string sequencePrefix ="";

					if (dtCustomerNo.Rows[0]["SequencePrefix"] != System.DBNull.Value)
					{
						sequencePrefix = dtCustomerNo.Rows[0]["SequencePrefix"].ToString().Trim();
					}
					this.CustomerNo =  sequencePrefix + dtCustomerNo.Rows[0]["SequenceCurrent"].ToString();
				}

				Executor.BeginTrans();

				switch (this.Mode)
				{
					case 1:  //ADD
						if (!this.DisableAutomaticCustNo)
						{   //Asigna el Customer No. Automaticamente.
							int custNo =  Executor.Insert("AddCustomer",this.GetInsertCustomerXml());
						}
						else
						{   //El usuario entra el Customer No. manualmente.
							Executor.Update("AddCustomerWithCustomerNo",this.GetInsertCustomerXml());
						}
						this.History(this.Mode,UserID,(int)MutationType.CUSTOMER);
						break;

					case 3:  //DELETE
						Executor.Update("DeleteCustomer",this.GetDeleteCustomerXml());
						//this.AuditDelete(UserID, (int)MutationType.CUSTOMER);
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						this.History(this.Mode,UserID,(int)MutationType.CUSTOMER);
						Executor.Update("UpdateCustomer",this.GetUpdateCustomerXml());
						break;
				}
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Customer. "+xcp.Message,xcp);
			}
		}

		private void SaveCustom_F(int UserID)  //Physical Address
		{
			DataTable custom_f = GetCustomerAddrByCustomerNoDB(this.CustomerNo);
			if (custom_f.Rows.Count == 0)
			{
				this.Mode = (int) CustomerMode.ADD;
			}

			this._Modify = true;

			Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				Executor.BeginTrans();

				switch (this.Mode)
				{
					case 1:  //ADD
						int custNo = Executor.Insert("AddCustom_F",this.GetInsertCustom_FXml());
						break;

					case 3:  //DELETE
						Executor.Update("DeleteCustom_F",this.GetDeleteCustom_FXml());
						//this.AuditDelete(UserID, (int)MutationType.PHYSICAL_ADDRESS);
						break;

					case 4:  //CLEAR						
						break;

					default: //UPDATE
						Executor.Update("UpdateCustom_F",this.GetUpdateCustom_FXml());
						break;
				}
				Executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				Executor.RollBackTrans();
				throw new Exception("Error while trying to save the Physical Address. "+xcp.Message,xcp);
			}
		}



       

		#region Customer (Individual & Business)
		private XmlDocument GetCustomerCounterXml()
		{
			//Find the specific CustomerCounterID as per the LocationID.
			int customerCounterID = 0;

			DataTable dtLocation		= LookupTables.LookupTables.GetTable("Location");
			for (int i = 0; i <= dtLocation.Rows.Count-1; i++)
			{
				if (this.LocationID == (int) dtLocation.Rows[i]["LocationID"])
				{
					customerCounterID = (int) dtLocation.Rows[i]["CustomerCounterID"];
					i = dtLocation.Rows.Count-1;
				}
			}

			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("CustomerCounterID",
				SqlDbType.Int, 0, customerCounterID.ToString(),
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

		private DataTable GetCustomerByPhoneDB(string phone)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[2];

			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.Char, 14, phone,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("IsBusiness",
				SqlDbType.Bit, 0, IsBusiness.ToString(),
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
				 dt = exec.GetQuery("GetCustomerVerifyByPhone", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}

	}

		private DataTable GetCustomerBusinessBySocialSecurityDB()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];


			DbRequestXmlCooker.AttachCookItem("EmployerSocialSecurity",
				SqlDbType.Char, 11, this.EmployerSocialSecurity.Trim(),
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
				 dt = exec.GetQuery("GetCustomerBusinessBySocialSecurity", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}

		}

		private DataTable GetCustomerBySocialSecurityDB()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("SocialSecurity",
				SqlDbType.Char, 11, this.SocialSecurity.Trim(),
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
				 dt = exec.GetQuery("GetCustomerBySocialSecurity", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
		}

		private XmlDocument GetDeleteCustomerXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];


			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
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

		private XmlDocument GetInsertCustomerXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[47];
			
			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ProspectID",
				SqlDbType.Int, 0, this.ProspectID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("IsBusiness",
				SqlDbType.Bit, 0, IsBusiness.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LocationID",
				SqlDbType.Int, 0, LocationID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("ContactPersonID",
				SqlDbType.Int, 0, this.ContactPersonID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Firstna",
				SqlDbType.VarChar, 200, FirstName,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Initial",
				SqlDbType.Char, 1, Initial,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Lastna1",
				SqlDbType.Char, 50, LastName1,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Lastna2",
				SqlDbType.Char, 50, LastName2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Sex",
				SqlDbType.Char, 1, Sex,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Martst",
				SqlDbType.Int, 0, MaritalStatus.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("BusinessType",
				SqlDbType.Int, 0, BusinessType.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.Char, 60, Address1,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.Char, 60, Address2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.Char, 14, City,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, State,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, ZipCode,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Homeph",
				SqlDbType.Char, 14, HomePhone,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Jobph",
				SqlDbType.Char, 14, JobPhone,
				ref cookItems);
			
			
			DbRequestXmlCooker.AttachCookItem("Cellular",
				SqlDbType.Char, 14, Cellular,
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Faxph",
                SqlDbType.Char, 14, FaxPhone,
                ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Birthday",
				SqlDbType.SmallDateTime, 0, Birthday,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Age",
				SqlDbType.Char, 2, Age,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("SocSec",
				SqlDbType.Char, 11, SocialSecurity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Licence",
				SqlDbType.Char, 7, Licence,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("OccupationID",
				SqlDbType.Int, 0, OccupationID.ToString(),
				ref cookItems);
			
			
			DbRequestXmlCooker.AttachCookItem("Occupa",
				SqlDbType.Char, 15, Occupation,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Emplna",
				SqlDbType.Char, 100, EmplName,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Emplct",
				SqlDbType.Char, 20, EmplCity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EmployerSocialSecurity",
				SqlDbType.Char, 11, EmployerSocialSecurity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("emp",
				SqlDbType.Int, 0, EmpID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("AvisoCancellation",
				SqlDbType.Bit, 0, NoticeCancellation.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("MasterCustomerID",
				SqlDbType.Int, 0, MasterCustomer.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Email",
				SqlDbType.Char, 50, Email,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Lab",
				SqlDbType.Bit, 0, Lab.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 200, Comments,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Description",
				SqlDbType.VarChar, 100, Description,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Dependents",
				SqlDbType.Int, 0, Dependents.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("HouseHoldIncome",
				SqlDbType.Int, 0, HouseHoldIncome.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("OptOut",
				SqlDbType.Bit, 0, OptOut.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("RelatedToID",
				SqlDbType.Int, 0, RelatedToID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Business1",
				SqlDbType.Char, 15, BusinessName1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Business2",
				SqlDbType.Char, 15, BusinessName2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Business3",
				SqlDbType.Char, 15, BusinessName3.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Modify",
				SqlDbType.Bit, 0, _Modify.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("License",
                SqlDbType.VarChar, 25, License.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BusinessName",
                SqlDbType.VarChar, 100, BusinessName.ToString(),
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

		private XmlDocument GetUpdateCustomerXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[47];
			
			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ProspectID",
				SqlDbType.Int, 0, this.ProspectID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("IsBusiness",
				SqlDbType.Bit, 0, IsBusiness.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LocationID",
				SqlDbType.Int, 0, LocationID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("ContactPersonID",
				SqlDbType.Int, 0, this.ContactPersonID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Firstna",
				SqlDbType.VarChar, 200, FirstName,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Initial",
				SqlDbType.Char, 1, Initial,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Lastna1",
				SqlDbType.Char, 50, LastName1,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Lastna2",
				SqlDbType.Char, 50, LastName2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Sex",
				SqlDbType.Char, 1, Sex,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Martst",
				SqlDbType.Int, 0, MaritalStatus.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("BusinessType",
				SqlDbType.Int, 0, BusinessType.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.Char, 60, Address1,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.Char, 60, Address2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.Char, 14, City,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, State,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, ZipCode,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Homeph",
				SqlDbType.Char, 14, HomePhone,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Jobph",
				SqlDbType.Char, 14, JobPhone,
				ref cookItems);
			
			
			DbRequestXmlCooker.AttachCookItem("Cellular",
				SqlDbType.Char, 14, Cellular,
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Faxph",
                SqlDbType.Char, 14, FaxPhone,
                ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Birthday",
				SqlDbType.SmallDateTime, 0, Birthday,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Age",
				SqlDbType.Char, 2, Age,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("SocSec",
				SqlDbType.Char, 11, SocialSecurity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Licence",
				SqlDbType.Char, 7, Licence,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("OccupationID",
				SqlDbType.Int, 0, OccupationID.ToString(),
				ref cookItems);
			
			
			DbRequestXmlCooker.AttachCookItem("Occupa",
				SqlDbType.Char, 15, Occupation,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Emplna",
				SqlDbType.Char, 100, EmplName,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Emplct",
				SqlDbType.Char, 20, EmplCity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EmployerSocialSecurity",
				SqlDbType.Char, 11, EmployerSocialSecurity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("emp",
				SqlDbType.Int, 0, EmpID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("AvisoCancellation",
				SqlDbType.Bit, 0, NoticeCancellation.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("MasterCustomerID",
				SqlDbType.Int, 0, MasterCustomer.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Email",
				SqlDbType.Char, 50, Email,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Lab",
				SqlDbType.Bit, 0, Lab.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Comments",
				SqlDbType.VarChar, 200, Comments,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Description",
				SqlDbType.VarChar, 100, Description,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Dependents",
				SqlDbType.Int, 0, Dependents.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("HouseHoldIncome",
				SqlDbType.Int, 0, HouseHoldIncome.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("OptOut",
				SqlDbType.Bit, 0, OptOut.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("RelatedToID",
				SqlDbType.Int, 0, RelatedToID.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Business1",
				SqlDbType.Char, 15, BusinessName1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Business2",
				SqlDbType.Char, 15, BusinessName2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Business3",
				SqlDbType.Char, 15, BusinessName3.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("License",
               SqlDbType.VarChar, 25, License.ToString(),
               ref cookItems);

            DbRequestXmlCooker.AttachCookItem("BusinessName",
                SqlDbType.VarChar, 100, BusinessName.ToString(),
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

        private XmlDocument GetUpdateCustomerNoAndProspectIDXml(string CustomerNo, int ProspectID, string OldCustomerNo, int OldProspectID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[4];
			
			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("ProspectID",
				SqlDbType.Int, 0, ProspectID.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("OldCustomerNo",
				SqlDbType.Char, 10, OldCustomerNo,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("OldProspectID",
				SqlDbType.Int, 0, OldProspectID.ToString(),
				ref cookItems);
            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }
		private static DataTable GetCustomerByCriteriaDB(string CustomerNo,string FirstName,string LastName1,string LastName2,string SocialSecurity,string Phone, bool IsBusiness, bool All, string EmployerSocialSecurity ,string BusinessName, int userID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[11];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("FirstName",
				SqlDbType.VarChar, 100, FirstName,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LastName1",
				SqlDbType.VarChar, 15, LastName1,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LastName2",
				SqlDbType.VarChar, 15, LastName2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("SocialSecurity",
				SqlDbType.VarChar, 11, SocialSecurity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.VarChar, 14, Phone,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("IsBusiness",
				SqlDbType.Bit, 0, IsBusiness.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("All",
				SqlDbType.Bit, 0, All.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EmployerSocialSecurity",
				SqlDbType.VarChar, 11, EmployerSocialSecurity,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("BusinessName",
				SqlDbType.VarChar, 100, BusinessName,
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("UserID",
                SqlDbType.Int, 0, userID.ToString(),
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
				 dt = exec.GetQuery("GetCustomerByCriteria", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}

			
		}

		private static DataTable GetCustomerByCustomerNoDB(string CustomerNo)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];


			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
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
			   dt = exec.GetQuery("GetCustomerByCustomerNo", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
		}

        private void UpdateCustomerNoandProspectID(string CustomerNo, int ProspectID, string OldCustomerNo, int OldProspectID)
        {

            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            try
            {
                Executor.BeginTrans();

                Executor.Update("UpdateCustomerNoAndProspectID", GetUpdateCustomerNoAndProspectIDXml(CustomerNo, ProspectID, OldCustomerNo, OldProspectID));

                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save CustomerNo/ProspectID. " + xcp.Message, xcp);
            }
        }
		
		#endregion

		#region Contact Person
		private static DataTable GetContactPersonByContactPersonIDDB(int ContactPersonID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];


			DbRequestXmlCooker.AttachCookItem("ContactPersonID",
				SqlDbType.Int, 0, ContactPersonID.ToString(),
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
				 dt = exec.GetQuery("GetContactPersonByContactPersonID", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}
	}

		private XmlDocument GetDeleteContactPersonXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];


			DbRequestXmlCooker.AttachCookItem("ContactPersonID",
				SqlDbType.Char, 10, ContactPersonID.ToString(),
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

		private XmlDocument GetInsertContactPersonXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[7];



			DbRequestXmlCooker.AttachCookItem("FirstName",
				SqlDbType.VarChar, 50, FirstName,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("LastName",
				SqlDbType.VarChar, 50, LastName1,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LastName2",
				SqlDbType.VarChar, 50, LastName2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EmpPosition",
				SqlDbType.VarChar, 50, EmpPosition,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.VarChar, 13, JobPhone,
				ref cookItems);
			
			
			DbRequestXmlCooker.AttachCookItem("Cellular",
				SqlDbType.VarChar, 13, Cellular,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Email",
				SqlDbType.VarChar, 100, Email,
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

		private XmlDocument GetUpdateContactPersonXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[8];

			DbRequestXmlCooker.AttachCookItem("ContactPersonID",
				SqlDbType.Int, 0, ContactPersonID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("FirstName",
				SqlDbType.VarChar, 50, FirstName,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("LastName",
				SqlDbType.VarChar, 50, LastName1,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("LastName2",
				SqlDbType.VarChar, 50, LastName2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("EmpPosition",
				SqlDbType.VarChar, 50, EmpPosition,
				ref cookItems);			
			
			DbRequestXmlCooker.AttachCookItem("Phone", 
				SqlDbType.VarChar, 14, JobPhone,
				ref cookItems);                   //Phone

			DbRequestXmlCooker.AttachCookItem("Cellular",
				SqlDbType.Char, 14, Cellular,
				ref cookItems);                  //Cellular
			
			
			DbRequestXmlCooker.AttachCookItem("Email",
				SqlDbType.VarChar, 100, Email,
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

		#endregion

		#region Custom_F
		private XmlDocument GetInsertCustom_FXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[7];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, this.CustomerNo,
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.Char, 60, this.AddressPhysical1,
				ref cookItems);

			
			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.Char, 60, this.AddressPhysical2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.Char, 14, this.CityPhysical,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, this.StatePhysical,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, this.ZipPhysical,
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

		private XmlDocument GetDeleteCustom_FXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, this.CustomerNo,
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

		private XmlDocument GetUpdateCustom_FXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[7];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, this.CustomerNo,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Adds1",
				SqlDbType.Char, 60, this.AddressPhysical1,
				ref cookItems);

			
			DbRequestXmlCooker.AttachCookItem("Adds2",
				SqlDbType.Char, 60, this.AddressPhysical2,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.Char, 14, this.CityPhysical,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, this.StatePhysical,
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Zip",
				SqlDbType.Char, 10, this.ZipPhysical,
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

		private static DataTable GetCustomerAddrByCustomerNoDB(string CustomerNo)

		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("CustomerNo",
				SqlDbType.Char, 10, CustomerNo,
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
				 dt = exec.GetQuery("GetCustomerAddrByCustomerNo", xmlDoc);
				return dt;
			}
			catch(Exception ex)
			{
				throw new Exception("Could not retrieve prospect by criteria.", ex);
			}			
		}

		#endregion

		#region FillProperties
		private static Customer FillCustomerProperties(Customer customer)
		{
			if((bool) customer._dtCustomer.Rows[0]["IsBusiness"])  //Business Customer
			{
				if (customer._dtContactPerson.Rows.Count != 0)
				{
					customer.FirstName  = customer._dtContactPerson.Rows[0]["FirstName"].ToString();
					customer.LastName1  = customer._dtContactPerson.Rows[0]["LastName"].ToString();
					customer.LastName2  = customer._dtContactPerson.Rows[0]["LastName2"].ToString();
					customer.EmpPosition= customer._dtContactPerson.Rows[0]["EmpPosition"].ToString();
					customer.JobPhone   = customer._dtContactPerson.Rows[0]["Phone"].ToString();
					customer.Cellular   = customer._dtContactPerson.Rows[0]["Cellular"].ToString();
					customer.Email      = customer._dtContactPerson.Rows[0]["Email"].ToString();
				}
				customer.BusinessName1 = customer._dtCustomer.Rows[0]["Business1"].ToString();
				customer.BusinessName2 = customer._dtCustomer.Rows[0]["Business2"].ToString();
				customer.BusinessName3 = customer._dtCustomer.Rows[0]["Business3"].ToString();
			}
			else	//Individual Customer
			{
				customer.FirstName  = customer._dtCustomer.Rows[0]["Firstna"].ToString();
				customer.LastName1  = customer._dtCustomer.Rows[0]["Lastna1"].ToString();
				customer.HomePhone  = customer._dtCustomer.Rows[0]["Homeph"].ToString();
				customer.JobPhone   = customer._dtCustomer.Rows[0]["Jobph"].ToString();
				customer.Cellular   = customer._dtCustomer.Rows[0]["Cellular"].ToString();
				customer.Email      = customer._dtCustomer.Rows[0]["Email"].ToString();
			}
			customer.NavegationCustomerTable = customer._dtCustomer;
			customer.CustomerNo = customer._dtCustomer.Rows[0]["CustomerNo"].ToString();
			customer.ProspectID = (customer._dtCustomer.Rows[0]["ProspectID"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["ProspectID"]:0;
			customer.ContactPersonID =  (customer._dtCustomer.Rows[0]["ContactPersonID"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["ContactPersonID"]:0;
			customer.IsBusiness = (bool) customer._dtCustomer.Rows[0]["IsBusiness"];
			customer.LocationID = (customer._dtCustomer.Rows[0]["LocationID"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["LocationID"]:0;
			customer.Initial    = customer._dtCustomer.Rows[0]["Initial"].ToString();
			customer.LastName2  = customer._dtCustomer.Rows[0]["Lastna2"].ToString();
			customer.Sex		= customer._dtCustomer.Rows[0]["Sex"].ToString();
			customer.MaritalStatus = (customer._dtCustomer.Rows[0]["Martst"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["Martst"]:0;
			customer.BusinessType  = (customer._dtCustomer.Rows[0]["BusinessType"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["BusinessType"]:0;
			customer.Address1   = customer._dtCustomer.Rows[0]["Adds1"].ToString();
			customer.Address2   = customer._dtCustomer.Rows[0]["Adds2"].ToString();
			customer.City       = customer._dtCustomer.Rows[0]["City"].ToString();
			customer.State      = customer._dtCustomer.Rows[0]["State"].ToString();
			customer.ZipCode    = customer._dtCustomer.Rows[0]["Zip"].ToString();
			customer.SocialSecurity = customer._dtCustomer.Rows[0]["SocSec"].ToString();
			customer.Birthday   = (customer._dtCustomer.Rows[0]["BirthDay"]!=System.DBNull.Value)?((DateTime) customer._dtCustomer.Rows[0]["BirthDay"]).ToShortDateString():"";
			customer.Age		= customer._dtCustomer.Rows[0]["Age"].ToString();
			customer.Licence	= customer._dtCustomer.Rows[0]["Licence"].ToString();
			customer.OccupationID = (customer._dtCustomer.Rows[0]["OccupationID"]!= System.DBNull.Value)?(int)customer._dtCustomer.Rows[0]["OccupationID"]:0;
			customer.Occupation	= customer._dtCustomer.Rows[0]["Occupa"].ToString();
			customer.EmplName	= customer._dtCustomer.Rows[0]["Emplna"].ToString();
			customer.EmplCity	= customer._dtCustomer.Rows[0]["Emplct"].ToString();
			customer.EmployerSocialSecurity  = customer._dtCustomer.Rows[0]["EmployerSocialSecurity"].ToString();
			customer.EmpID		=  (customer._dtCustomer.Rows[0]["Emp"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["Emp"]:0;
			customer.NoticeCancellation = (bool) customer._dtCustomer.Rows[0]["AvisoCancellation"];
			customer.MasterCustomer = (customer._dtCustomer.Rows[0]["MasterCustomerID"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["MasterCustomerID"]:0;
			customer.Lab		= (bool) customer._dtCustomer.Rows[0]["Lab"];
			customer.Comments   = customer._dtCustomer.Rows[0]["Comments"].ToString();
			customer.Description   = customer._dtCustomer.Rows[0]["Description"].ToString();
			customer.Dependents =  (customer._dtCustomer.Rows[0]["Dependents"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["Dependents"]:0;
			customer.HouseHoldIncome = (customer._dtCustomer.Rows[0]["HouseHoldIncome"]!= System.DBNull.Value)?(int) customer._dtCustomer.Rows[0]["HouseHoldIncome"]:0;
			customer.RelatedToID = (customer._dtCustomer.Rows[0]["RelatedToID"]!= System.DBNull.Value)?(int)customer._dtCustomer.Rows[0]["RelatedToID"]:0;
			customer.OptOut     = (customer._dtCustomer.Rows[0]["OptOut"]!= System.DBNull.Value)?(bool) customer._dtCustomer.Rows[0]["OptOut"]:false;
            customer.License = customer._dtCustomer.Rows[0]["License"].ToString();
            customer.BusinessName = customer._dtCustomer.Rows[0]["BusinessName"].ToString();

			if (customer._dtCustomerAddr.Rows.Count != 0)
			{
				customer.AddressPhysical1	= customer._dtCustomerAddr.Rows[0]["Adds1"].ToString();
				customer.AddressPhysical2	= customer._dtCustomerAddr.Rows[0]["Adds2"].ToString();
				customer.CityPhysical		= customer._dtCustomerAddr.Rows[0]["City"].ToString();
				customer.StatePhysical		= customer._dtCustomerAddr.Rows[0]["State"].ToString();
				customer.ZipPhysical		= customer._dtCustomerAddr.Rows[0]["Zip"].ToString();
			}
			return customer;
		}
		#endregion

		#endregion

		#region Public Methods for Prospect
		
		public static DataTable VerifyProspect(string phone)
		{
			DataTable dtcustomer = GetCustomerByPhone(phone);
			DataTable dtprospect = GetProspectByPhone(phone);

			DataTable dt = BuildDataTable(dtcustomer,dtprospect);
			
			if (dt.Rows.Count ==0)
			{
				dtprospect = GetProspectOnlyByPhone(phone);
				dt = BuildDataTable(dtcustomer,dtprospect);
			}

			return dt;
		}

		# endregion

		#region Private Methods for Prospect

		private static DataTable GetCustomerByPhone(string phone)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.VarChar, 14, phone,
				ref cookItems);

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetCustomerByPhone",DbRequestXmlCooker.Cook(cookItems));

			try
			{
				return dt;
				
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			
		}

		private static DataTable GetProspectByPhone(string phone)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.VarChar, 14, phone,
				ref cookItems);

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetProspectByPhone",DbRequestXmlCooker.Cook(cookItems));

			try
			{
				return dt;
				
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			
		}

		private static DataTable GetProspectOnlyByPhone(string phone)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.VarChar, 14, phone,
				ref cookItems);

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable dt = exec.GetQuery("GetCustomerByPhone",DbRequestXmlCooker.Cook(cookItems));

			try
			{
				return dt;
				
			}
			catch(Exception ex)
			{
				throw new Exception("Could not cook items.", ex);
			}

			
		}
		private static DataTable BuildDataTable(DataTable dtcustomer,DataTable dtprospect)
		{
			DataRow dr;

			if(dtcustomer.Rows.Count !=0)
			{
				for(int r=0; r<= dtcustomer.Rows.Count-1; r++)
				{
					if(dtcustomer.Rows[r]["ProspectID"] == System.DBNull.Value)
					{
						dtcustomer.Rows[r]["ProspectID"] = 0;
					}
				}
			}

			if(dtprospect.Rows.Count !=0)
			{
				for(int i=0; i<= dtprospect.Rows.Count-1; i++)
				{
					dr = dtcustomer.NewRow();
					dr["CustomerNo"]	= "0";
					dr["ProspectID"] = (int) dtprospect.Rows[i]["ProspectID"];
					dr["IsBusiness"] = (bool) dtprospect.Rows[i]["IsBusiness"];
					dr["Firstna"] =  dtprospect.Rows[i]["Firstname"].ToString();
					dr["Lastna1"] =  dtprospect.Rows[i]["Lastname1"].ToString();
					dr["Lastna2"] =  dtprospect.Rows[i]["Lastname2"].ToString();
					dr["Homeph"] =  dtprospect.Rows[i]["HomePhone"].ToString();
					dr["Jobph"]  =  dtprospect.Rows[i]["WorkPhone"].ToString();
					dr["Cellular"] =  dtprospect.Rows[i]["Cellular"].ToString();
					dr["Emplna"] =  dtprospect.Rows[i]["BusinessName"].ToString();
					dr["Email"] =  dtprospect.Rows[i]["Email"].ToString();
					dr["HouseHoldIncome"] = (dtprospect.Rows[0]["HouseHoldIncomeID"] != 
						System.DBNull.Value)
						? int.Parse(dtprospect.Rows[0]["HouseHoldIncomeID"].ToString().Trim()) : 0;

					dtcustomer.Rows.Add(dr);
					dtcustomer.AcceptChanges();
				}
			}
				
			return dtcustomer;
		}

		#region History
		
		private void History(int mode, int userID, int MutationTypeID)
		{
			Audit.History history = new Audit.History();
			
			if(mode == 2)
			{
				Customer oldCustomer = null;

				if(this._oldCustomer == null)
					oldCustomer = Customer.GetCustomer(this.CustomerNo,userID);
				else
					oldCustomer = _oldCustomer;
            
				switch (MutationTypeID)
				{
					case (int)MutationType.CUSTOMER:
						if(this.IsBusiness) //Business customer
						{
							history.BuildNotesForHistory("BusinessType",
								LookupTables.LookupTables.GetDescription("BusinessType",oldCustomer.BusinessType.ToString()),
								LookupTables.LookupTables.GetDescription("BusinessType",this.BusinessType.ToString()),
								mode);
							history.BuildNotesForHistory("Description",oldCustomer.Description,this.Description,mode);
							history.BuildNotesForHistory("EmployerSocialSecurity",oldCustomer.EmployerSocialSecurity,this.EmployerSocialSecurity,mode);
						}
						else //Individual customer
						{
							//history.BuildNotesForHistory("Age",oldCustomer.Age,this.Age,mode);
							history.BuildNotesForHistory("Birthday",oldCustomer.Birthday,this.Birthday,mode);
							history.BuildNotesForHistory("Cellular",oldCustomer.Cellular,this.Cellular,mode);
							history.BuildNotesForHistory("Dependents",oldCustomer.Dependents.ToString(),this.Dependents.ToString(),mode);
							history.BuildNotesForHistory("Email",oldCustomer.Email,this.Email,mode);
							history.BuildNotesForHistory("EmplCity",oldCustomer.EmplCity,this.EmplCity,mode);
							history.BuildNotesForHistory("FisrtName",oldCustomer.FirstName,this.FirstName,mode);
							history.BuildNotesForHistory("HomePhone",oldCustomer.HomePhone,this.HomePhone,mode);
							history.BuildNotesForHistory("HouseHoldIncome",
								LookupTables.LookupTables.GetDescription("HouseHoldIncome",oldCustomer.HouseHoldIncome.ToString()),
								LookupTables.LookupTables.GetDescription("HouseHoldIncome",this.HouseHoldIncome.ToString()),
								mode);
							history.BuildNotesForHistory("Initial",oldCustomer.Initial,this.Initial,mode);
							history.BuildNotesForHistory("JobPhone",oldCustomer.JobPhone,this.JobPhone,mode);
							history.BuildNotesForHistory("Lab",oldCustomer.Lab.ToString(),this.Lab.ToString(),mode);
							history.BuildNotesForHistory("LastName1",oldCustomer.LastName1,this.LastName1,mode);
							history.BuildNotesForHistory("LastName2",oldCustomer.LastName2,this.LastName2,mode);
							history.BuildNotesForHistory("MaritalStatus",
								LookupTables.LookupTables.GetDescription("MaritalStatus",oldCustomer.MaritalStatus.ToString()),
								LookupTables.LookupTables.GetDescription("MaritalStatus",this.MaritalStatus.ToString()),
								mode);
							history.BuildNotesForHistory("MasterCustomer",
								LookupTables.LookupTables.GetDescription("MasterCustomer",oldCustomer.MasterCustomer.ToString()),
								LookupTables.LookupTables.GetDescription("MasterCustomer",this.MasterCustomer.ToString()),
								mode);
							history.BuildNotesForHistory("Occupation",oldCustomer.Occupation,this.Occupation,mode);
							history.BuildNotesForHistory("OccupationID",
								LookupTables.LookupTables.GetDescription("Occupations",oldCustomer.OccupationID.ToString()),
								LookupTables.LookupTables.GetDescription("Occupations",this.OccupationID.ToString()),
								mode);
							history.BuildNotesForHistory("Sex",oldCustomer.Sex,this.Sex,mode);
							history.BuildNotesForHistory("SocialSecurity",oldCustomer.SocialSecurity,this.SocialSecurity,mode);

						}
						//Common to business and individuals
						history.BuildNotesForHistory("EmplName",oldCustomer.EmplName,this.EmplName,mode);
						history.BuildNotesForHistory("Address1",oldCustomer.Address1,this.Address1,mode);
						history.BuildNotesForHistory("Address2",oldCustomer.Address2,this.Address2,mode);
						history.BuildNotesForHistory("City",oldCustomer.City,this.City,mode);
						history.BuildNotesForHistory("Comments",oldCustomer.Comments,this.Comments,mode);
						history.BuildNotesForHistory("Licence",oldCustomer.Licence,this.Licence,mode);
						history.BuildNotesForHistory("LocationID",
							LookupTables.LookupTables.GetDescription("Location",oldCustomer.LocationID.ToString()),
							LookupTables.LookupTables.GetDescription("Location",this.LocationID.ToString()),
							mode);
						history.BuildNotesForHistory("NoticeCancellation",oldCustomer.NoticeCancellation.ToString(),this.NoticeCancellation.ToString(),mode);
						history.BuildNotesForHistory("OptOut",oldCustomer.OptOut.ToString(),this.OptOut.ToString(),mode);
						history.BuildNotesForHistory("ProspectID",oldCustomer.ProspectID.ToString(),this.ProspectID.ToString(),mode);
						history.BuildNotesForHistory("State",oldCustomer.State,this.State,mode);
						history.BuildNotesForHistory("ZipCode",oldCustomer.ZipCode,this.ZipCode,mode);
						history.BuildNotesForHistory("RelatedToID",
							LookupTables.LookupTables.GetDescription("RelatedTo",oldCustomer.RelatedToID.ToString()),
							LookupTables.LookupTables.GetDescription("RelatedTo",this.RelatedToID.ToString()),
							mode);								
						
						//MutationType.PHYSICAL_ADDRESS:
						history.BuildNotesForHistory("AddressPhysical1",oldCustomer.AddressPhysical1,this.AddressPhysical1,mode);
						history.BuildNotesForHistory("AddressPhysical2",oldCustomer.AddressPhysical2,this.AddressPhysical2,mode);
						history.BuildNotesForHistory("CityPhysical",oldCustomer.CityPhysical,this.CityPhysical,mode);
						history.BuildNotesForHistory("StatePhysical",oldCustomer.StatePhysical,this.StatePhysical,mode);
						history.BuildNotesForHistory("ZipPhysical",oldCustomer.ZipPhysical,this.ZipPhysical,mode);

						//MutationType.CONTACT_PERSON:
						if (this.IsBusiness)
						{								
							history.BuildNotesForHistory("Cellular",oldCustomer.Cellular,this.Cellular,mode);
							history.BuildNotesForHistory("Email",oldCustomer.Email,this.Email,mode);
							history.BuildNotesForHistory("EmpPosition",oldCustomer.EmpPosition,this.EmpPosition,mode);
							history.BuildNotesForHistory("FirstName",oldCustomer.FirstName,this.FirstName,mode);
							history.BuildNotesForHistory("JobPhone",oldCustomer.JobPhone,this.JobPhone,mode);
							history.BuildNotesForHistory("LastName1",oldCustomer.LastName1,this.LastName1,mode);
						}
						break;

					default: 
						//
						break;						
				}
				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("Customer No.","",this.CustomerNo,mode);
				history.Actions = "ADD";
			}

			history.KeyID = this.CustomerNo;
			history.Subject = "CUSTOMER";			
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

		# endregion
	}
}