using System;
using System.Xml;
using System.Data;
using Baldrich.DBRequest;
using EPolicy.Audit;
using System.Data.SqlClient;
using System.Collections;
using EPolicy.XmlCooker;

 
namespace EPolicy.LookupTables
{
	/// <summary>
	/// Summary description for Agent.
	/// </summary>
	public class Agent
	{
		public Agent()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Enumerations

		public enum Mode{ADD = 1, UPDATE = 2, DELETE = 3, CLEAR = 4};

		#endregion

		#region Variables
    
		//private Agent  oldAgent = null;
		private DataTable _navigationViewModelTable;
		private int _actionMode = (int)Mode.UPDATE;
		private  string _agentID = String.Empty;
        private string _agencyID = String.Empty;
		private  string _agentDesc = String.Empty;
        private string _agencyDesc = String.Empty;
		private  string _agt_addr1 = String.Empty;
		private  string _agt_addr2 = String.Empty;
		private  string _agt_city = String.Empty;
		private  string _agt_st = String.Empty;
		private  string _agt_zip = String.Empty ;
		private  string _agt_phone = String.Empty ;
		private  string _agt_email = String.Empty;
        private  string _agt_socialsecurity = String.Empty;
        private  string _agt_actdt = DateTime.Now.ToShortDateString();
        private  string _agt_licensenum = String.Empty;
        private  string _agt_licensenumexpdate = String.Empty;
        private  string  _CarsID = String.Empty;
        private bool _AllComm = false;
        private string _AccountType = "";
        private string _Banco = "";
        private string _NumCuenta = "";
        private string _NumRuta = "";
        private string _Agency = "";

        

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

        public bool AllComm
        {
            get
            {
                return this._AllComm;
            }
            set
            {
                this._AllComm = value;
            }
        }
        public string AccountType
        {
            get { return _AccountType; }
            set { _AccountType = value; }
        }
        public string Agency
        {
            get { return _Agency; }
            set { _Agency = value; }
        }
         public string Banco
        {
            get { return _Banco; }
            set { _Banco = value; }
        }
        public string NumCuenta
        {
            get { return _NumCuenta; }
            set { _NumCuenta = value; }
        } 
        public string NumRuta
        {
            get { return _NumRuta; }
            set { _NumRuta = value; }
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

		public string AgentID
		{
			get
			{
				return this._agentID;
			}
			set
			{
				this._agentID = value;
			}
		}

        public string AgencyID
        {
            get
            {
                return this._agencyID;
            }
            set
            {
                this._agencyID = value;
            }
        }


		public string AgentDesc
		{
			get
			{
				return this._agentDesc;
			}
			set
			{
				this._agentDesc = value;
			}
		}

        public string AgencyDesc
        {
            get
            {
                return this._agencyDesc;
            }
            set
            {
                this._agencyDesc = value;
            }
        }

		public string agt_addr1
		{
			get
			{
				return this._agt_addr1;
			}
			set
			{
				this._agt_addr1 = value;
			}
		}
        
		public string agt_addr2
		{
			get
			{
				return this._agt_addr2;
			}
			set
			{
				this._agt_addr2 = value;
			}
		}
        
		public string agt_city
		{
			get
			{
				return this._agt_city;
			}
			set
			{
				this._agt_city = value;
			}
		}
        
		public string agt_st
		{
			get
			{
				return this._agt_st;
			}
			set
			{
				this._agt_st = value;
			}
		}

		public string agt_zip
		{
			get
			{
				return this._agt_zip;
			}
			set
			{
				this._agt_zip = value;
			}
		}


		public string agt_phone
		{
			get
			{
				return this._agt_phone;
			}
			set
			{
				this._agt_phone = value;
			}
		}

		public string agt_actdt
		{
			get
			{
				return this._agt_actdt;
			}
			set
			{
				this._agt_actdt = value;
			}
		}

        public string agt_email
        {
            get 
            {
                return this._agt_email;
            }
            set 
            {
                this._agt_email = value;
            }
        }

        public string agt_socialsecurity
        {
            get 
            {
                return this._agt_socialsecurity;
            }
            set 
            {
                this._agt_socialsecurity = value;
            }
        }

        public string agt_licensenum
        {
            get
            {
                return this._agt_licensenum;
            }
            set
            {
                this._agt_licensenum = value;
            }
        }

        public string agt_licensenumexpdate
        {
            get
            {
                return this._agt_licensenumexpdate;
            }
            set
            {
                this._agt_licensenumexpdate = value;
            }
        }

        public string CarsID
        {
            get
            {
                return this._CarsID;
            }
            set
            {
                this._CarsID = value;
            }
        }
		#endregion

		#region Public Methods
		      
		private string GetNextAgentID()
		{
			DataTable dt = LookupTables.GetTable("Agent");
			DataRow[] dr = dt.Select("","AgentID");

			DataTable dt2 = dt.Clone();

			for (int rec = 0; rec<=dr.Length-1; rec++)
			{
				DataRow myRow = dt2.NewRow();
				myRow["AgentID"] = dr[rec].ItemArray[0].ToString();
				myRow["AgentDesc"] = dr[rec].ItemArray[1].ToString();

				dt2.Rows.Add(myRow);
				dt2.AcceptChanges();
			}

			int ID = 0;

			ID = int.Parse(dt2.Rows[dt2.Rows.Count-1]["AgentID"].ToString())+1;
						
			return (ID.ToString().PadLeft(3,'0')); 
		}
		#endregion    
		
		#region Public Functions

		public void Delete(string AgentID)
		{
			try
			{
				Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
				executor.Delete("DeleteAgentID", 
					this.GetDeleteAgentXml(AgentID));
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
						this.AgentID = GetNextAgentID();
						executor.Update("AddAgent", this.GetInsertAgentXml());
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
						executor.Update("UpdateAgent",this.GetUpdateAgentXml());
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

        public DataTable GetAgencyBelongsTo(string AgentID) //,  string AgencyID)  //Alexis Grid 1
        {
            try
            {
                DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[1];

                DbRequestXmlCooker.AttachCookItem("AgentID",
                    SqlDbType.VarChar, 4, AgentID.ToString(),
                    ref cookItems);

                //DbRequestXmlCooker.AttachCookItem("AgencyID",
                //   SqlDbType.VarChar, 4, AgencyID.ToString(),
                //   ref cookItems);

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
                    dt = exec.GetQuery("GetAgencyBelongsTo", xmlDoc);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("There is no information to display, please try again.", ex);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddAgencyBelongsTo(string AgentID, string AgencyID) //Alexis Grid 2
        {
            try
            {
                XmlDocument xml = null;
                DBRequest executor = new DBRequest();

                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[2];

                DbRequestXmlCooker.AttachCookItem("AgentID",
                SqlDbType.VarChar, 4, AgentID.ToString(), ref cooker);

                DbRequestXmlCooker.AttachCookItem("AgencyID",
                SqlDbType.VarChar, 4, AgencyID.ToString(), ref cooker);

                Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();


                try
                {
                    xml = DbRequestXmlCooker.Cook(cooker);
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not cook items.", ex);
                }
                try
                {
                    exec.Insert("AddAgencyBelongsTo", xml);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAgencyBelongsTo(int AgencyBelongsToID) //Alexis Grid 3
        {
            try
            {
                XmlDocument xml = null;
                DBRequest executor = new DBRequest();
                
                DbRequestXmlCookRequestItem[] cooker = new DbRequestXmlCookRequestItem[1];
                DbRequestXmlCooker.AttachCookItem("AgencyBelongsToID",
                SqlDbType.Int, 0, AgencyBelongsToID.ToString(), ref cooker);


                xml = DbRequestXmlCooker.Cook(cooker);

                executor.Update("DeleteAgencyBelongsTo", xml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public Agent GetAgent(string AgentID)
		{
			try
			{
				DataTable dtAgent = new DataTable();
				Agent agent = new Agent();
				this.AgentID = AgentID;		

				Baldrich.DBRequest.DBRequest executor = new Baldrich.DBRequest.DBRequest();
			
				dtAgent = executor.GetQuery("GetagentByAgentID", 
					this.GetAgentByAgentIDXml());

				this.AgentDesc = 
					dtAgent.Rows[0]["AgentDesc"].ToString().Trim();

				this.agt_addr1 = 
					dtAgent.Rows[0]["agt_addr1"].ToString().Trim();

				this.AgentID = 
					dtAgent.Rows[0]["AgentID"].ToString().Trim();

				this.agt_addr2 = 
					dtAgent.Rows[0]["agt_addr2"].ToString().Trim();

				this.agt_city = 
					dtAgent.Rows[0]["agt_city"].ToString().Trim();

				this.agt_st = 
					dtAgent.Rows[0]["agt_st"].ToString().Trim();

				this.agt_zip = 
					dtAgent.Rows[0]["agt_zip"].ToString().Trim();

				this.agt_phone = 
					dtAgent.Rows[0]["agt_phone"].ToString().Trim();

				this.agt_actdt = 
					dtAgent.Rows[0]["agt_actdt"]!= System.DBNull.Value?((DateTime) dtAgent.Rows[0]["agt_actdt"]).ToShortDateString():"";

                this.agt_email =
                    dtAgent.Rows[0]["agt_email"].ToString().Trim();

                this.agt_socialsecurity =
                    dtAgent.Rows[0]["agt_socialsecurity"].ToString().Trim();

                this.agt_licensenum =
                    dtAgent.Rows[0]["agt_licensenum"].ToString().Trim();

                this.agt_licensenumexpdate =
                    dtAgent.Rows[0]["agt_licensenumexpdate"].ToString().Trim();

                this.CarsID =
                    dtAgent.Rows[0]["CarsID"].ToString().Trim();
                this.AllComm =
                    dtAgent.Rows[0]["AllComm"] != System.DBNull.Value? ((bool)dtAgent.Rows[0]["AllComm"]):false;
                this.AccountType =
                    dtAgent.Rows[0]["AccountType"] != System.DBNull.Value ? dtAgent.Rows[0]["AccountType"].ToString() : "";
                this.Banco =
                    dtAgent.Rows[0]["Banco"] != System.DBNull.Value ? dtAgent.Rows[0]["Banco"].ToString() : "";
                this.NumCuenta =
                    dtAgent.Rows[0]["NumCuenta"] != System.DBNull.Value ? dtAgent.Rows[0]["NumCuenta"].ToString() : "";
                this.NumRuta =
                   dtAgent.Rows[0]["NumRuta"] != System.DBNull.Value ? dtAgent.Rows[0]["NumRuta"].ToString() : "";
                this.Agency =
                  dtAgent.Rows[0]["Agency"] != System.DBNull.Value ? dtAgent.Rows[0]["Agency"].ToString() : "";

				return this;
			}
			catch(Exception ex) 
			{
				throw new Exception(
					"Could not retrieve information for this Agent.", ex);
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
						throw new Exception("The Agent make you are attempting to " +
							"relate to this Agent does not exist.", Ex);
					default:
						throw new Exception("An database server error ocurred while " +
							"saving the Agent.", Ex);
				}
				default:
					throw new Exception("An error ocurred while saving " + 
						" the Agent.", Ex);
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
						throw new Exception("The Agent you are attempting to " +
							"delete is being referenced by one or more database " +
							"entities. Please delete any existing references to " +
							"this Agent before attempting to delete it.", Ex);
					default:
						throw new Exception("An database server error ocurred while " +
							"deleting the Agent.", Ex);
				}
				default:
					throw new Exception("An error ocurred while deleting " + 
						" the Agent.", Ex);
			}
		}
  
		private XmlDocument GetDeleteAgentXml(string AgentID)
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("AgentID",
				SqlDbType.VarChar, 3, this.AgentID.ToString(),
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
        
		private XmlDocument GetInsertAgentXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[19];

			
			DbRequestXmlCooker.AttachCookItem("AgentID",
				SqlDbType.VarChar, 3, this.AgentID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("AgentDesc",
				SqlDbType.VarChar, 30, this.AgentDesc.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("agt_addr1",
				SqlDbType.VarChar, 100, this.agt_addr1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("agt_addr2",
				SqlDbType.VarChar, 100, this.agt_addr2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("agt_city",
				SqlDbType.VarChar, 14, this.agt_city.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("agt_st",
				SqlDbType.VarChar, 2, this.agt_st.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("agt_zip",
				SqlDbType.VarChar, 10, this.agt_zip.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("agt_phone",
				SqlDbType.VarChar, 14, this.agt_phone.ToString(),
				ref cookItems);

			
			DbRequestXmlCooker.AttachCookItem("agt_actdt",
				SqlDbType.VarChar, 4, this.agt_actdt.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_email",
                SqlDbType.VarChar, 100, this.agt_email.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_socialsecurity",
                SqlDbType.VarChar, 11, this.agt_socialsecurity.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_licensenum",
                SqlDbType.VarChar, 10, this.agt_licensenum.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_licensenumexpdate",
                SqlDbType.VarChar, 10, this.agt_licensenumexpdate.ToString(),
                ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AllComm",
               SqlDbType.Bit, 0, this.AllComm.ToString(),
               ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AccountType",
              SqlDbType.VarChar, 15, this.AccountType.ToString(),
              ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Banco",
             SqlDbType.VarChar, 100, this.Banco.ToString(),
             ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NumCuenta",
            SqlDbType.VarChar, 50, this.NumCuenta.ToString(),
            ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NumRuta",
           SqlDbType.VarChar, 50, this.NumRuta.ToString(),
           ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Agency",
           SqlDbType.VarChar, 3, this.Agency.ToString(),
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

		private XmlDocument GetUpdateAgentXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[19];
			
			DbRequestXmlCooker.AttachCookItem("AgentID",
				SqlDbType.Char, 3, this.AgentID.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("AgentDesc",
				SqlDbType.Char, 30, this.AgentDesc.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("agt_addr1",
				SqlDbType.Char, 100, this.agt_addr1.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("agt_addr2",
				SqlDbType.VarChar, 100, this.agt_addr2.ToString(),
				ref cookItems);

			DbRequestXmlCooker.AttachCookItem("agt_city",
				SqlDbType.VarChar, 14, this.agt_city.ToString(),
				ref cookItems);			

			DbRequestXmlCooker.AttachCookItem("agt_st",
				SqlDbType.VarChar, 2, this.agt_st.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("agt_zip",
				SqlDbType.VarChar, 10, this.agt_zip.ToString(),
				ref cookItems);
			
			DbRequestXmlCooker.AttachCookItem("agt_phone",
				SqlDbType.VarChar, 14, this.agt_phone.ToString(),
				ref cookItems);

			
			DbRequestXmlCooker.AttachCookItem("agt_actdt",
				SqlDbType.VarChar, 4, this.agt_actdt.ToString(),
				ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_email",
                SqlDbType.VarChar, 100, this.agt_email.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_socialsecurity",
                SqlDbType.VarChar, 11, this.agt_socialsecurity.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_licensenum",
                SqlDbType.VarChar, 10, this.agt_licensenum.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("agt_licensenumexpdate",
                SqlDbType.VarChar, 10, this.agt_licensenumexpdate.ToString(),
                ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AllComm",
              SqlDbType.Bit, 0, this.AllComm.ToString(),
              ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AccountType",
             SqlDbType.VarChar, 15, this.AccountType.ToString(),
             ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Banco",
            SqlDbType.VarChar, 100, this.Banco.ToString(),
            ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NumCuenta",
            SqlDbType.VarChar, 50, this.NumCuenta.ToString(),
            ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NumRuta",
           SqlDbType.VarChar, 50, this.NumRuta.ToString(),
           ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Agency",
          SqlDbType.VarChar, 3, this.Agency.ToString(),
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

		private XmlDocument GetAgentByAgentIDXml()
		{
			DbRequestXmlCookRequestItem[] cookItems = 
				new DbRequestXmlCookRequestItem[1];

			DbRequestXmlCooker.AttachCookItem("AgentID",
				SqlDbType.Char, 3, this.AgentID.ToString(),
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

			if(this.AgentDesc == "")
			{
				errorMessage += "The Agent cannot be empty.  ";
				found = true;
			}

			DataTable dt =  LookupTables.GetTable("Agent");
			
			if (this.ActionMode ==1)
			{
				for (int i=0; i<=dt.Rows.Count-1; i++)
				{
					if(dt.Rows[i]["AgentDesc"].ToString().Trim().ToUpper() == this.AgentDesc.Trim().ToUpper())
					{
						errorMessage = "This Agent Description is Already exist.";
						found = true;
					}
				}
			}
			else
			{
				for (int i=0; i<=dt.Rows.Count-1; i++)
				{
					if(dt.Rows[i]["AgentDesc"].ToString().Trim() == this.AgentDesc.Trim() && dt.Rows[i]["AgentID"].ToString().Trim() != this.AgentID.ToString().Trim())
					{
						errorMessage = "The Agent Description is Already exist.";
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
				EPolicy.LookupTables.Agent oldAgent = new EPolicy.LookupTables.Agent();
				oldAgent = oldAgent.GetAgent(this.AgentID);//userID);

				history.BuildNotesForHistory("AgentDesc",oldAgent.AgentDesc,this.AgentDesc,mode);
				history.BuildNotesForHistory("agt_addr1",oldAgent.agt_addr1,this.agt_addr1,mode);
				history.BuildNotesForHistory("agt_addr2",oldAgent.agt_addr2,this.agt_addr2,mode);
				history.BuildNotesForHistory("agt_city",oldAgent.agt_city,this.agt_city,mode);
				history.BuildNotesForHistory("agt_st",oldAgent.agt_st,this.agt_st,mode);
				history.BuildNotesForHistory("agt_zip",oldAgent.agt_zip,this._agt_zip,mode);
				history.BuildNotesForHistory("agt_phone",oldAgent.agt_phone,this.agt_phone,mode);
                history.BuildNotesForHistory("agt_email", oldAgent.agt_email, this.agt_email, mode);
                history.BuildNotesForHistory("agt_socialsecurity", oldAgent.agt_socialsecurity, this.agt_socialsecurity, mode);
                history.BuildNotesForHistory("agt_licencenum", oldAgent.agt_licensenum, this.agt_licensenum, mode);
                history.BuildNotesForHistory("agt_licencenumexpdate", oldAgent.agt_licensenumexpdate, this.agt_licensenumexpdate, mode);
				

				history.Actions = "EDIT";
			}
			else  //ADD & DELETE
			{
				history.BuildNotesForHistory("AgentID.","",this.AgentID.ToString(),mode);
				history.Actions = "ADD";
			}

			history.KeyID = this.AgentID.ToString();
			history.Subject = "AGENT";			
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
