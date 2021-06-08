using System;
using System.Xml;
using System.Data;
using Baldrich.DBRequest;
using System.Data.SqlClient;
using EPolicy.XmlCooker;
using EPolicy.Audit;

namespace EPolicy.LookupTables
{
	/// <summary>
	/// Summary description for Bank.
	/// </summary>
	public class Bank
	{
		public Bank()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Enumerations

		public enum Mode{ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4};

		#endregion

		#region Variables
    
		//private Bank  oldBank = null;
		private DataTable _navigationViewModelTable;
		private int _actionMode = (int)Mode.UPDATE;
		private  string _bankID = String.Empty;
		private  string _bankDesc = String.Empty;
		private  string _unico = String.Empty;
		private  string _address1 = String.Empty;
		private  string _address2 = String.Empty;
		private  string _city = String.Empty;
		private  string _state = String.Empty;
		private  string _zipcode = String.Empty ;
		private  string _phone = String.Empty ;
		private  string _bank_actdt = DateTime.Now.ToShortDateString();
		private  bool   _Lease = false;
        private bool _NetCollection = false;
        private string _masterPolicyID = String.Empty;
        private double _VSCBankFee = 0.00;

		#endregion

		#region Properties

		public DataTable NavigationViewModelTable
		{
			get
			{
				return this._navigationViewModelTable;
			}
			set
			{
				this._navigationViewModelTable = value;
			}
		}
		
		public int ActionMode
		{
			get
			{
				return this._actionMode;
			}
			set
			{
				this._actionMode = value;
			}
		}

		public string BankID
		{
			get
			{
				return this._bankID;
			}
			set
			{
				this._bankID = value;
			}
		}


		public string BankDesc
		{
			get
			{
				return this._bankDesc;
			}
			set
			{
				this._bankDesc = value;
			}
		}


		public string Unico
		{
			get
			{
				return this._unico;
			}
			set
			{
				this._unico = value;
			}
		}
		public string Address1
		{
			get
			{
				return this._address1;
			}
			set
			{
				this._address1 = value;
			}
		}
        
		public string Address2
		{
			get
			{
				return this._address2;
			}
			set
			{
				this._address2 = value;
			}
		}
        
		public string City
		{
			get
			{
				return this._city;
			}
			set
			{
				this._city = value;
			}
		}
        
		public string State
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		public string ZipCode
		{
			get
			{
				return this._zipcode;
			}
			set
			{
				this._zipcode = value;
			}
		}


		public string Phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				this._phone = value;
			}
		}

		public string Bank_actdt
		{
			get
			{
				return this._bank_actdt;
			}
			set
			{
				this._bank_actdt = value;
			}
		}

		public bool	 Lease
		{
			get
			{
				return this._Lease;
			}
			set
			{
				this._Lease = value;
			}
		}

        public bool NetCollection
        {
            get
            {
                return this._NetCollection;
            }
            set
            {
                this._NetCollection = value;
            }
        }

        public string MasterPolicyID
        {
            get
            {
                return this._masterPolicyID;
            }
            set
            {
                this._masterPolicyID = value;
            }
        }

        public double VSCBankFee
        {
            get
            {
                return this._VSCBankFee;
            }
            set
            {
                this._VSCBankFee = value;
            }
        }
		#endregion

		#region Public Methods
		      
		private string GetNextBankID()
		{
			DataTable dt = LookupTables.GetTable("Bank");
			DataRow[] dr = dt.Select("","BankID");

			DataTable dt2 = dt.Clone();

			for (int rec = 0; rec<=dr.Length-1; rec++)
			{
				DataRow myRow = dt2.NewRow();
				myRow["BankID"] = dr[rec].ItemArray[0].ToString();
				myRow["BankDesc"] = dr[rec].ItemArray[1].ToString();

				dt2.Rows.Add(myRow);
				dt2.AcceptChanges();
			}

			int ID = 0;

			ID = int.Parse(dt2.Rows[dt2.Rows.Count-1]["BankID"].ToString())+1;
						
			return (ID.ToString().PadLeft(3,'0')); 
		}
		#endregion    

		#region Public Functions

		public void Delete(string BankID)
		{
			try
			{
				Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
				executor.Delete("DeleteBankID", 
					this.GetDeleteBankXml(BankID));
			}
			catch(Exception ex)
			{
				this.HandleDeleteError(ex);
			}
		}

		public void Save(int UserID)
		{
			this.Validate();
			Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
			try
			{
				executor.BeginTrans();
				
				switch (this.ActionMode)
				{
					case 1: //ADD
						this.BankID = GetNextBankID();
						executor.Update("AddBank", this.GetInsertBankXml());
						this.History(this._actionMode,UserID);
//						this.AuditInsert(UserID);
//						this.CommitAudit();
						break;
					case 3: //DELETE
						break;
					case 4: //CLEAR
						break;
					default: //UPDATE
						this.History(this._actionMode,UserID);
//						this.AuditUpdate(UserID);
						executor.Update("UpdateBank",this.GetUpdateBankXml());
//						this.CommitAudit();//Commit audit;
						break;
				}
				executor.CommitTrans();
			}
			catch (Exception xcp)
			{
				executor.RollBackTrans();
				this.HandleSaveError(xcp);
			}
		}

		public Bank GetBank(string BankID)
		{
			try
			{
				DataTable dtBank = new DataTable();
				Bank bank = new Bank();
				this.BankID = BankID;		

				Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
			
				dtBank = executor.GetQuery("GetbankByBankID", 
					this.GetBankByBankIDXml());

				this.BankDesc = 
					dtBank.Rows[0]["BankDesc"].ToString().Trim();

				this.Unico = 
					dtBank.Rows[0]["Unico"].ToString().Trim();

				this.Address1 = 
					dtBank.Rows[0]["Address1"].ToString().Trim();

				this.BankID = 
					dtBank.Rows[0]["BankID"].ToString().Trim();

				this.Address2 = 
					dtBank.Rows[0]["Address2"].ToString().Trim();

				this.City = 
					dtBank.Rows[0]["City"].ToString().Trim();

				this.State = 
					dtBank.Rows[0]["State"].ToString().Trim();

				this.ZipCode = 
					dtBank.Rows[0]["ZipCode"].ToString().Trim();

				this.Phone = 
					dtBank.Rows[0]["Phone"].ToString().Trim();

				this.Bank_actdt = 
					dtBank.Rows[0]["Bank_actdt"]!= System.DBNull.Value?((DateTime) dtBank.Rows[0]["Bank_actdt"]).ToShortDateString():"";

				this.Lease =
					bool.Parse(dtBank.Rows[0]["Lease"].ToString().Trim());

                this.NetCollection =
                    bool.Parse(dtBank.Rows[0]["NetCollection"].ToString().Trim());

                this.MasterPolicyID =
                    dtBank.Rows[0]["MasterPolicyID"].ToString().Trim();

                this.VSCBankFee =
                    dtBank.Rows[0]["VSCBankFee"] != System.DBNull.Value ? ((double)dtBank.Rows[0]["VSCBankFee"]) : 0.00;
				return this	;

			}
			catch(Exception ex) 
			{
				throw new Exception(
					"Could not retrieve information for this Bank.", ex);
			}
		}

		#endregion

		#region Private Functions

		private void HandleSaveError(Exception Ex)
		{
			switch(Ex.GetBaseException().GetType().FullName)
			{
				case "System.Data.SqlClient.SqlException":
					SqlException sqlException = (SqlException)Ex.GetBaseException();
				switch(sqlException.Number)
				{
					case 547:
						throw new Exception("The Bank make you are attempting to " +
							"relate to this Bank does not exist.", Ex);
					default:
						throw new Exception("An database server error ocurred while " +
							"saving the Bank.", Ex);
				}
				default:
					throw new Exception("An error ocurred while saving " + 
						" the Bank.", Ex);
			}            
		}

		private void HandleDeleteError(Exception Ex)
		{
			switch(Ex.GetBaseException().GetType().FullName)
			{
				case "System.Data.SqlClient.SqlException":
					SqlException sqlException = (SqlException)Ex.GetBaseException();
				switch(sqlException.Number)
				{
					case 547:
						throw new Exception("The Bank you are attempting to " +
							"delete is being referenced by one or more database " +
							"entities. Please delete any existing references to " +
							"this Bank before attempting to delete it.", Ex);
					default:
						throw new Exception("An database server error ocurred while " +
							"deleting the Bank.", Ex);
				}
				default:
					throw new Exception("An error ocurred while deleting " + 
						" the Bank.", Ex);
			}
		}
  
		private XmlDocument GetDeleteBankXml(string BankID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("BankID",
				SqlDbType.VarChar, 3, this.BankID.ToString(),
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
        
		private XmlDocument GetInsertBankXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[13];

			DbRequestXmlCooker.AttachCookItem("BankID",
				SqlDbType.Char, 3, this.BankID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("BankDesc",
				SqlDbType.Char, 44, this.BankDesc.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Unico",
				SqlDbType.Char, 3, this.Unico.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Address1",
				SqlDbType.Char, 20, this.Address1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Address2",
				SqlDbType.Char, 20, this.Address2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.Char, 14, this.City.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, this.State.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("ZipCode",
				SqlDbType.Char, 10, this.ZipCode.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.Char, 12, this.Phone.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Bank_actdt",
				SqlDbType.Char, 4, this.Bank_actdt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lease",
				SqlDbType.Bit, 0, this.Lease.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NetCollection",
                SqlDbType.Bit, 0, this.NetCollection.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VSCBankFee",
                SqlDbType.Float, 0, this.VSCBankFee.ToString(),
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

		private XmlDocument GetUpdateBankXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[13];
			
			DbRequestXmlCooker.AttachCookItem("BankID",
				SqlDbType.Char, 3, this.BankID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("BankDesc",
				SqlDbType.Char, 44, this.BankDesc.ToString(),
				ref cookItems);


			DbRequestXmlCooker.AttachCookItem("Unico",
				SqlDbType.Char, 3, this.Unico.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Address1",
				SqlDbType.Char, 20, this.Address1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Address2",
				SqlDbType.Char, 20, this.Address2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("City",
				SqlDbType.Char, 14, this.City.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("State",
				SqlDbType.Char, 2, this.State.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("ZipCode",
				SqlDbType.Char, 10, this.ZipCode.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("Phone",
				SqlDbType.Char, 12, this.Phone.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Bank_actdt",
				SqlDbType.Char, 4, this.Bank_actdt.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("Lease",
				SqlDbType.Bit, 0, this.Lease.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("NetCollection",
                SqlDbType.Bit, 0, this.NetCollection.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("VSCBankFee",
                SqlDbType.Float, 0, this.VSCBankFee.ToString(),
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

		private XmlDocument GetBankByBankIDXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];
			
			
			DbRequestXmlCooker.AttachCookItem("BankID",
				SqlDbType.Int, 0, this.BankID.ToString(),
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

		private void Validate()
		{
			string errorMessage = String.Empty;
			bool found = false;

			if(this.BankDesc == "")
			{
				errorMessage += "The Bank cannot be empty.  ";
				found = true;
			}

			
			DataTable dt =  LookupTables.GetTable("Bank");
			
			if (this.ActionMode ==1)
			{
				for (int i=0; i<=dt.Rows.Count-1; i++)
				{
					if(dt.Rows[i]["BankDesc"].ToString().Trim() == this.BankDesc.Trim())
					{
						errorMessage = "The Bank Description is Already Exist.";
						found = true;
					}
				}
			}
			else
			{
				for (int i=0; i<=dt.Rows.Count-1; i++)
				{
					if(dt.Rows[i]["BankDesc"].ToString().Trim() == this.BankDesc.Trim() && dt.Rows[i]["BankID"].ToString().Trim() != this.BankID.ToString().Trim())
					{
						errorMessage = "The Bank Description is Already Exist.";
						found = true;
					}
				}
			}	

			if (found == true)
			{
				throw new Exception(errorMessage);
			}
		}


		#region History

		private void History(int mode, int userID)
		{
			Audit.History history = new Audit.History();
			
			if(_actionMode == 2)
			{
				EPolicy.LookupTables.Bank oldBank = new EPolicy.LookupTables.Bank();
				oldBank = oldBank.GetBank(this.BankID);//userID);

				history.BuildNotesForHistory("BankDesc",oldBank.BankDesc,this.BankDesc,mode);
				history.BuildNotesForHistory("Unico",oldBank.Unico,this.Unico,mode);
				history.BuildNotesForHistory("Address1",oldBank.Address1,this.Address1,mode);
				history.BuildNotesForHistory("Address2",oldBank.Address2,this.Address2,mode);
				history.BuildNotesForHistory("City",oldBank.City,this.City,mode);
				history.BuildNotesForHistory("State",oldBank.State,this.State,mode);
				history.BuildNotesForHistory("ZipCode",oldBank.ZipCode,this.ZipCode,mode);
				history.BuildNotesForHistory("Phone",oldBank.Phone,this.Phone,mode);
				history.BuildNotesForHistory("Bank_actdt",oldBank.Bank_actdt,this.Bank_actdt,mode);
				history.BuildNotesForHistory("Lease",oldBank.Lease.ToString(),this.Lease.ToString(),mode);
                history.BuildNotesForHistory("NetCollection", oldBank.NetCollection.ToString(), this.NetCollection.ToString(), mode);
                history.BuildNotesForHistory("MasterPolicyID", oldBank.MasterPolicyID.ToString(), this.MasterPolicyID.ToString(), mode);
                history.BuildNotesForHistory("VSCBankFee", oldBank.VSCBankFee.ToString(), this.VSCBankFee.ToString(), mode);
				

				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("BankID.","",this.BankID.ToString(),mode);
				history.Actions = "ADD";
			}

			history.KeyID = this.BankID.ToString();
			history.Subject = "BANK";			
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


		#endregion

	}
}
